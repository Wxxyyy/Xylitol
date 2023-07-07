using System.Linq;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xy.Core.Entity;

namespace Xy.DataBase.Core;

/// <summary>
/// 
/// </summary>
[AppDbContext("XyfTest", DbProvider.MySql)]
public class DefaultDbContext : AppDbContext<DefaultDbContext>
{
    /// <summary>
    /// 设置最小日期时间
    /// </summary>
    private DateTimeOffset minDateTimeOffset = Convert.ToDateTime("1900-01-01");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
        
    }

    /// <summary>
    /// 重写 提交更改之前SavingChanages 事件
    /// </summary>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    protected override void SavingChangesEvent(DbContextEventData eventData, InterceptionResult<int> result)
    {
        // 1.获取当前事件对应上下文
        var dbContext = eventData.Context;
        // 2.强制检查一遍实体更改信息
        dbContext!.ChangeTracker.DetectChanges();
        // 3.通过请求中获取当前操作人
        // var userId = App.HttpContext.GetValue<string>(ClaimConst.Uid);
        // var userName = App.HttpContext.GetValue<string>(ClaimConst.Nick);

         var userId = "00000000";
         //var userName = "System";

        // 获取所有新增和更新的实体
        var entities = dbContext.ChangeTracker.Entries()
                    .Where(u => u.State == EntityState.Added||u.State == EntityState.Modified || u.State == EntityState.Deleted );

        foreach (var entity in entities)
        {
            switch (entity.State)
            {
                // 新增操作
                case EntityState.Added:
                    // 如果是新增操作，就修改新增时间及操作的用户ID
                    if (entity.Entity is BaseEntity AddEntity)
                    {
                        // 判断创建时间是否小于 定义的最小日期时间，如果是则设置为当前时间
                        if (AddEntity.CreatedDt < minDateTimeOffset)
                        {
                            AddEntity.CreatedDt = DateTimeOffset.UtcNow;
                        }
                        // 创建用户ID
                        AddEntity.CreatedUid = userId;
                    }
                    break;
                // 修改操作
                case EntityState.Modified:
                    if (entity.Entity is BaseEntity EditEntity)
                    {
                        //判断是否是软删除/假删除  如果是假删除 设置删除信息
                        //bool isdeleted = Convert.ToBoolean(entity.Property(nameof(BaseEntity.IsDeleted)).CurrentValue);
                        if (EditEntity.UpdatedDt < minDateTimeOffset)
                        {
                            EditEntity.UpdatedDt = DateTimeOffset.UtcNow;
                        }
                        EditEntity.UpdatedUid = userId;
                        EditEntity.IsDeleted = true;
                        // 排除创建人
                        entity.Property(nameof(BaseEntity.CreatedDt)).IsModified = false;
                        // 排除创建日期
                        entity.Property(nameof(BaseEntity.CreatedDt)).IsModified = false;
                    }
                    break;
                // 删除操作
                case EntityState.Deleted:
                    //删除的话，先不作处理吧
                    break;
            }
        }
    }



}
