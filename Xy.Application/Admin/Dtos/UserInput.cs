namespace Xy.Application.Admin;

public class UserInput
{
    /// <summary>
    /// 唯一识别ID
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 用户账户
    /// </summary>
    public string UserAcc { get; set; }

    /// <summary>
    /// 账户密码
    /// </summary>
    public string UserPwd { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string AvatarImg { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    public string Nick { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 性别 - 0 ：男生 1：女生 2：❀
    /// </summary>
    public int Gender { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 邮件
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public DateOnly Birthday { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// 签名
    /// </summary>
    public string Signature { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remarks { get; set; }

    /// <summary>
    /// 状态 - 0:正常,1:禁用,2:封禁
    /// </summary>
    public int Status { get; set; }
}