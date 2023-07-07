namespace Xy.Core.UnifyResult;

/// <summary>
/// 规范化RESTful风格返回值
/// </summary>
[UnifyModel(typeof(XyResult<>))]
public class XyResultProvider : IUnifyResultProvider
{
    /// <summary>
    /// 异常返回内容处理
    /// </summary>
    /// <param name="context"></param>
    /// <param name="metadata"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IActionResult OnException(ExceptionContext context, ExceptionMetadata metadata)
    {
        return new JsonResult(RESTfulResult(metadata.StatusCode, errors: metadata.Errors));
    }

    /// <summary>
    /// 处理输出状态码
    /// </summary>
    /// <param name="context"></param>
    /// <param name="statusCode"></param>
    /// <param name="unifyResultSettings"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task OnResponseStatusCodes(HttpContext context, int statusCode, UnifyResultSettingsOptions unifyResultSettings = null)
    {
        // 设置响应状态码
        UnifyContext.SetResponseStatusCodes(context, statusCode, unifyResultSettings);

        switch (statusCode)
        {
            // 处理 401 状态码
            case StatusCodes.Status401Unauthorized:
                await context.Response.WriteAsJsonAsync(RESTfulResult(statusCode, errors: "401 登录已过期，请重新登录😊"),
                    App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
                break;
            // 处理 403 状态码
            case StatusCodes.Status403Forbidden:
                await context.Response.WriteAsJsonAsync(RESTfulResult(statusCode, errors: "403 禁止访问，没有权限🚫"),
                    App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
                break;

            default: break;
        }
    }

    /// <summary>
    /// 成功返回内容处理
    /// </summary>
    /// <param name="context"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IActionResult OnSucceeded(ActionExecutedContext context, object data)
    {
        //switch (context.Result)
        //{
        //    // 处理内容结果
        //    case ContentResult contentResult:
        //        data = contentResult.Content;
        //        break;
        //    // 处理对象结果
        //    case ObjectResult objectResult:
        //        data = objectResult.Value;
        //        break;
        //    case EmptyResult:
        //        data = null;
        //        break;
        //    default:
        //        return null;
        //}
        return new JsonResult(RESTfulResult(StatusCodes.Status200OK, true, data,"请求成功👌"));
    }

    /// <summary>
    /// 验证失败返回内容处理
    /// </summary>
    /// <param name="context"></param>
    /// <param name="metadata"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IActionResult OnValidateFailed(ActionExecutingContext context, ValidationMetadata metadata)
    {
        return new JsonResult(RESTfulResult(metadata.StatusCode ?? StatusCodes.Status400BadRequest, errors: metadata.ValidationResult));

    }


    /// <summary>
    /// 返回 RESTful 风格结果集
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="succeeded"></param>
    /// <param name="data"></param>
    /// <param name="errors"></param>
    /// <returns></returns>
    private static XyResult<object> RESTfulResult(int statusCode, bool succeeded = default, object data = default, object errors = default)
    {
        return new XyResult<object>
        {
            Success = succeeded,
            Code = statusCode,
            Message = errors,
            Data = data,
            Extras = UnifyContext.Take(),
            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
        };
    }
}