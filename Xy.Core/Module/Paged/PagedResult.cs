namespace Xy.Core.Module.Paged;

/// <summary>
/// 数据集合(Lyear格式的数据)
/// </summary>
/// <typeparam name="T"></typeparam>
public class PagedResult<T>
{
    /// <summary>
    /// 数据集
    /// </summary>
    public ICollection<T> Rows { get; set; }

    /// <summary>
    /// 总数据条数
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// 当前索引页
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// 每页显示条数
    /// </summary>
    public int Limit { get; set; }

    /// <summary>
    /// 总页数
    /// </summary>
    public int TotalPage { get; set; }
}