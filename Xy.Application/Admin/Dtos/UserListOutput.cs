namespace Xy.Application.Admin;

public class UserListOutput
{
    /// <summary>
    /// 唯一识别Uid
    /// </summary>
    public string userId { get; set; }

    /// <summary>
    /// 用户账户
    /// </summary>
    public string userAccount { get; set; }

    /// <summary>
    /// 用户昵称
    /// </summary>
    public string nickName { get; set; }

    /// <summary>
    /// 用户姓名
    /// </summary>
    public string userName { get; set; }

    /// <summary>
    /// 性别 - 0：男生 1：女生 2：❀
    /// </summary>
    public int userGender { get; set; }


    /// <summary>
    /// 电话
    /// </summary>
    public string userPhone { get; set; }

    /// <summary>
    /// 邮件
    /// </summary>
    public string userEmail { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string userRemark { get; set; }

    /// <summary>
    /// 状态 - 0:正常,1禁用,2封禁
    /// </summary>
    public int userStatus { get; set; }

}