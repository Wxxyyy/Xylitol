namespace Xylitol.Areas.Admin.Controllers;

/// <summary>
/// Admin控制器
/// </summary>
[Area("Admin")]
public class HomeController : Controller
{
    /// <summary>
    /// Index首页
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// 仪表盘
    /// </summary>
    /// <returns></returns>
    public IActionResult Dashboard()
    {
        return View();
    }

}
