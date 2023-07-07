using Xy.Core.Entity;
using Xy.Core.Utils;

namespace Xy.Application.Admin;

/// <summary>
/// 用户服务
/// </summary>
/// 内置依赖接口：[ITransient：对应暂时/瞬时作用域服务生存期],[IScoped：对应请求作用域服务生存期],[ISingleton：对应单例作用域服务生存期]
/// IDynamicApiController [动态WebApi,需要在swagger中显示就加上]
public class UserService : IUserService, ITransient, IDynamicApiController
{
    private readonly IRepository<SysUser> _repository;


    /// <summary>
    /// 构造/依赖注入
    /// </summary>
    public UserService(IRepository<SysUser> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// 获取用户信息列表(分页)
    /// </summary>
    /// <param name="searchQuery">分页信息</param>
    /// <returns></returns>
    [HttpPost("GetUserList")]
    public async Task<PagedResult<UserListOutput>> GetUserListByLayer(UserQuery searchQuery)
    {
        // 默认情况下，EF Core 会跟踪所有实体，也就是任何数据改变都会引起数据检查，所以如果只做查询操作，建议关闭实体跟踪功能。
        // DetachedEntities：脱轨/不追踪实体
        // AsQueryable(false)：不追踪实体
        // Entities.AsNoTracking()：手动关闭实体追踪
        // var users = await _repository.DetachedEntities
        //     .Where(u => u.IsDeleted == false)
        //     .Select(u => u.Adapt<UserListOutput>())
        //     .ToLyearPagedListAsync(searchQuery.Page, searchQuery.Limit);
        // return users;
        // var users = await _repository
        // .Where(u=>u.IsDeleted == false)
        // .ProjectToType<UserListOutput>()
        // .ToLyearPagedListAsync(searchQuery.Page, searchQuery.Limit);
        // return users;

        var users = await _repository.DetachedEntities
                .Where(u => u.IsDeleted == false)
                .ProjectToType<UserListOutput>()
                .ToLyearPagedListAsync(searchQuery.Page, searchQuery.Limit);
        return users;

    }

    /// <summary>
    /// 添加用户
    /// </summary>
    [HttpPost("Add")]
    public async Task Add(UserInput input)
    {
        if (string.IsNullOrEmpty(input.UserId))
        {
            #region 新增用户
            if (_repository.Any(u => u.Account == input.UserAcc))
            {
                throw Oops.Bah($"账号:{input.UserAcc} 已存在");
            }
            if (_repository.Any(u => u.Email == input.Email))
            {
                throw Oops.Bah($"邮箱:{input.Email} 已存在");
            }
            var AddEntity = input.Adapt<SysUser>();
            AddEntity.Uid = await VerificationId(IDGenHelper.NextId());
            AddEntity.Password = SM4Utils.加密(input.UserPwd);
            //AddEntity.Password = SM4Utils.Encrypt(new SM4Utils { Data = input.Password });
            await _repository.InsertNowAsync(AddEntity);


            #endregion AddUser-End
        }
        else
        {
            #region 修改用户
            // 1.先判断用户是否存在
            if (!_repository.Any(u => u.Uid == input.UserId && u.Account == input.UserAcc && u.IsDeleted == false))
            {
                throw Oops.Bah($"账号:{input.UserAcc} 不存在,请重新操作");
            }
            var entity = await _repository.FirstOrDefaultAsync(u => u.Uid == input.UserId && u.Account == input.UserAcc);

            input.Adapt(entity);
            if (!string.IsNullOrEmpty(input.UserPwd))
            {
                entity.Password = SM4Utils.加密(input.UserPwd);
            }


            #endregion EditUser-End
        }
    }

    /// <summary>
    /// 构造方法，判断新生成的ID是否重复
    /// </summary>
    /// <param name="id">你要用的ID</param>
    /// <returns>如果Id没重复就返回你的ID，如果重复了将生成信息ID</returns>
    private async Task<string> VerificationId(string id)
    {
        if (await _repository.AnyAsync(u => u.Uid == id))
        {
            return await VerificationId(IDGenHelper.NextId());
        }
        else
        {
            return id;
        }
    }







}