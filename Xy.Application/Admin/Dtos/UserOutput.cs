namespace Xy.Application.Admin;

public class UserOutput
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
    /// 密码
    /// </summary>
    ///  public string UserPassword { get; set; } = null!;

    /// <summary>
    /// 用户头像
    /// </summary>
    public string userAvatar { get; set; }

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
    /// 生日
    /// </summary>
    public DateOnly userBirthday { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    public string userAddress { get; set; }

    /// <summary>
    /// 用户签名
    /// </summary>
    public string userSignature { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string userRemark { get; set; }

    /// <summary>
    /// 状态 - 0:正常,1禁用,2封禁
    /// </summary>
    public int userStatus { get; set; }

    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTimeOffset lastLoginTime { get; set; }

    /// <summary>
    /// 最后登录IP
    /// </summary>
    public string lastLoginIP { get; set; }

    /// <summary>
    /// 最后登录设备
    /// </summary>
    public string lastLoginDevice { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public virtual DateTimeOffset createTime { get; set; }

    /// <summary>
    /// 创建用户Uid
    /// </summary>
    public virtual string createdUserId { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public virtual DateTimeOffset updateTime { get; set; }

    /// <summary>
    /// 更新用户Id
    /// </summary>
    public virtual string updateUserId { get; set; }
}