namespace Xy.Core.UnifyResult;

public class XyResult<T>
{
    /// <summary>
    /// 执行成功
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// 状态码
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// 提示信息
    /// </summary>
    public object Message { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// 附加数据
    /// </summary>
    public object Extras { get; set; }

    /// <summary>
    /// 时间戳
    /// </summary>
    public long Timestamp { get; set; }
}