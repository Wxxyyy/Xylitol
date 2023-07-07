namespace Xy.Core.Entity;

/// <summary>
/// 主键id基类
/// </summary>
public abstract class PrimaryIdEntity : IPrivateEntity
{
    /// <summary>
    /// 主键Id
    /// </summary>
    /// <value></value>
    [Key]
    [Comment("主键Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual long Id { get; set; }
}

/// <summary>
/// 框架实体基类
/// </summary>
public class BaseEntity : PrimaryIdEntity
{
    /// <summary>
    /// 创建时间
    /// </summary>
    [Required, Comment("创建时间")]
    public virtual DateTimeOffset CreatedDt { get; set; }

    /// <summary>
    /// 创建用户Uid
    /// </summary>
    [Required, Comment("创建用户Uid")]
    [MaxLength(8)]
    public virtual string CreatedUid { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [Comment("更新时间")]
    public virtual DateTimeOffset? UpdatedDt { get; set; }

    /// <summary>
    /// 更新用户Id
    /// </summary>
    [Comment("更新用户Uid")]
    [MaxLength(8)]
    public virtual string UpdatedUid { get; set; }

    /// <summary>
    /// 软删除标记
    /// </summary>
    [Comment("软删除标记")]
    [JsonIgnore]
    public virtual bool IsDeleted { get; set; } = false;
}
