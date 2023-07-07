namespace Xy.Core.Module.Paged;

public class PageBaseQuery
{
    /// <summary>
    /// 排序方式asc需要你服务器按顺序排序，desc倒序排序
    /// </summary>
    private string _order;

    /// <summary>
    /// 排序方式asc需要你服务器按顺序排序，desc倒序排序
    /// </summary>
    /// <example>asc</example>
    public string Order
    {
        get => _order;
        set => _order = value;
    }

    /// <summary>
    /// 起始行，比如你数据库有100条数据，offset等于10表示你服务器需要从第10条数据返回结果
    /// </summary>
    private int _offset;

    /// <summary>
    /// 起始行，比如你数据库有100条数据，offset等于10表示你服务器需要从第10条数据返回结果
    /// </summary>
    public int Offset
    {
        get => _offset;
        set => _offset = value;
    }

    /// <summary>
    /// 用户在输入框搜索的关键词
    /// </summary>
    private string _search;

    /// <summary>
    /// 用户在输入框搜索的关键词
    /// </summary>
    public string Search
    {
        get => _search;
        set => _search = value;
    }


    /// <summary>
    /// 页数
    /// </summary>
    private int _page = 1;

    /// <summary>
    /// 页数
    /// </summary>
    /// <example>1</example>
    public int Page
    {
        get
        {
            if (_page > 0)
            {
                return _page;
            }
            return 1;
        }
        set => _page = value;
    }

    /// <summary>
    /// 查询条数(每次读取多少条数据)
    /// </summary>
    private int _limit = 10;

    /// <summary>
    /// 查询条数(每次读取多少条数据)
    /// </summary>
    /// <example>10</example>
    public int Limit
    {
        get
        {
            if (_limit > 0)
            {
                return _limit;
            }
            return 10;
        }
        set => _limit = value;
    }
}