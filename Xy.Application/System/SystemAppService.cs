using Furion.UnifyResult;

namespace Xy.Application;

/// <summary>
/// 系统服务接口
/// </summary>
public class SystemAppService : IDynamicApiController
{
    private readonly ISystemService _systemService;
    public SystemAppService(ISystemService systemService)
    {
        _systemService = systemService;
    }

    /// <summary>
    /// 获取系统描述
    /// </summary>
    /// <returns></returns>
    public string GetDescription()
    {
        UnifyContext.Fill(new { Message = "操作成功" });
        return _systemService.GetDescription();
    }
}
