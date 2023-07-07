namespace Xy.Core.Entity;

/// <summary>
/// 用户表
/// </summary>
[Comment("用户表")]
[Table("Sys_User")]
public class SysUser : BaseEntity, IEntityTypeBuilder<SysUser>
{
    /// <summary>
    /// 唯一识别Uid
    /// </summary>
    [Comment("用户Uid")]
    [Required, MaxLength(10)]
    public string Uid { get; set; } = null!;

    /// <summary>
    /// 账户用户
    /// </summary>
    [Comment("账户用户")]
    [Required, MaxLength(50)]
    public string Account { get; set; } = null!;

    /// <summary>
    /// 密码
    /// </summary>
    [Comment("密码")]
    [Required, MaxLength(50)]
    public string Password { get; set; } = null!;

    /// <summary>
    /// 头像
    /// </summary>
    [Comment("头像")]
    public string Avatar { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [Comment("昵称")]
    [MaxLength(20)]
    public string Nick { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    [Comment("姓名")]
    [MaxLength(20)]
    public string Name { get; set; }

    /// <summary>
    /// 性别 - 0：男生 1：女生 2：❀
    /// </summary>
    [Comment("性别：[0-男生],[1-女生],[2-❀]")]
    [MaxLength(1), DefaultValue(3)]
    public int? Gender { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    [Comment("手机号码")]
    [MaxLength(20)]
    public string Phone { get; set; }

    /// <summary>
    /// 邮件
    /// </summary>
    [Comment("电子邮箱")]
    [Required, MaxLength(50)]
    public string Email { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    [Comment("用户生日")]
    public DateOnly Birthday { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    [Comment("用户地址")]
    [MaxLength(50)]
    public string Address { get; set; }

    /// <summary>
    /// 用户签名
    /// </summary>
    [Comment("用户签名")]
    [MaxLength(50)]
    public string Signature { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Comment("用户备注")]
    [MaxLength(88)]
    public string Remarks { get; set; }

    /// <summary>
    /// 状态 - 0:正常,1禁用,2封禁
    /// </summary>
    [Comment("用户状态：[0-正常],[1-禁用],[2-封禁]")]
    [Required, MaxLength(1), DefaultValue(0)]
    public int Status { get; set; }

    /// <summary>
    /// 最后登录时间
    /// </summary>
    [Comment("最后登录时间")]
    public DateTimeOffset? LastLoginDt { get; set; }

    /// <summary>
    /// 最后登录IP
    /// </summary>
    [Comment("最后登录IP")]
    [MaxLength(20)]
    public string LastLoginIp { get; set; }

    /// <summary>
    /// 最后登录设备
    /// </summary>
    [Comment("最后登录设备")]
    [MaxLength(50)]
    public string LastLoginDev { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entityBuilder"></param>
    /// <param name="dbContext"></param>
    /// <param name="dbContextLocator"></param>
    public void Configure(EntityTypeBuilder<SysUser> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.HasKey(e => new { e.Id, e.Uid })
                .HasName("PRIMARY")
                //.HasAnnotation("Npgsql:ValueGenerationStrategy", new[] { 0, 0 })
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 })
                ;
    }
}