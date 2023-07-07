namespace Xylitol.Areas.Admin.Controllers;

/// <summary>
/// 用户管理
/// </summary>
[Area("Admin")]
public class UserController : Controller
{
    // 依赖注入
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger,IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Get]
    public IActionResult List()
    {
        return View();
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [Post]
    public async Task<JsonResult> GetUserList(UserQuery query)
    {
        return Json(await _userService.GetUserListByLayer(query));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}