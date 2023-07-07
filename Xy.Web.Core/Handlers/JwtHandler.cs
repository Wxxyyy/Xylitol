namespace Xy.Web.Core;

/// <summary>
/// 
/// </summary>
public class JwtHandler : AppAuthorizeHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public override Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
    {
        // 这里写您的授权判断逻辑，授权通过返回 true，否则返回 false

        return Task.FromResult(true);
    }
}
