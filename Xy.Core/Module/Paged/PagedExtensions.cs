using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Xy.Core.Module.Paged;

/// <summary>
/// 分页扩展类
/// </summary>
public static class PagedExtensions
{
    /// <summary>
    /// Lyear 分页扩展(返回支持lyear格式的数据)
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="list"></param>
    /// <param name="totalCount">总数据条数</param>
    /// <param name="pageIndex">查询页数</param>
    /// <param name="pageSize">条数</param>
    /// <returns></returns>
    public static PagedResult<TEntity> ToLyearPagedList<TEntity>(this IList<TEntity> list, int totalCount, int pageIndex = 1, int pageSize = 10)
    {
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        return new PagedResult<TEntity>
        {
            Page = pageIndex,
            Limit = pageSize,
            Rows = list,
            Total = totalCount,
            TotalPage = totalPages,
        };
    }

    /// <summary>
    /// Layui分页扩展(返回支持layui格式的数据)
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="list"></param>
    /// <param name="pageIndex">查询页数</param>
    /// <param name="pageSize">条数</param>
    /// <returns></returns>
    public static PagedResult<TEntity> ToLyearPagedList<TEntity>(this IQueryable<TEntity> list, int pageIndex = 1, int pageSize = 20)
    {
        var totalPages = (int)Math.Ceiling(list.Count() / (double)pageSize);

        return new PagedResult<TEntity>
        {
            Page = pageIndex,
            Limit = pageSize,
            Rows = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
            Total = list.Count(),
            TotalPage = totalPages,
        };
    }

     /// <summary>
    /// 分页拓展
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entities"></param>
    /// <param name="pageIndex">页码，必须大于0</param>
    /// <param name="pageSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<PagedResult<TEntity>> ToLyearPagedListAsync<TEntity>(this IQueryable<TEntity> entities, int pageIndex = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        if (pageIndex <= 0) throw new InvalidOperationException($"{nameof(pageIndex)} 必须是大于0的正整数。");

        var totalCount = await entities.CountAsync(cancellationToken);
        var items = await entities.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        return new PagedResult<TEntity>
        {
            Page = pageIndex,
            Limit = pageSize,
            Rows = items,
            Total = totalCount,
            TotalPage = totalPages,
        };
    }

}