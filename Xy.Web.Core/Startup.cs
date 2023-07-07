namespace Xy.Web.Core;

// 需要忽略警告的代码段
#pragma warning disable CA1822

/// <summary>
/// 
/// </summary>
public class Startup : AppStartup
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        // 控制台输出格式
        services.AddConsoleFormatter();
        //
        services.AddJwt<JwtHandler>();
        // 跨域
        services.AddCorsAccessor();
        //
        services.AddControllersWithViews()
            .AddAppLocalization()  // 注册多语言
            .AddInjectWithUnifyResult<XyResultProvider>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        // 强制使用Https
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        // 配置多语言，必须在 路由注册之前
        app.UseAppLocalization();

        app.UseRouting();

        // 跨域
        app.UseCorsAccessor();

        // 安全鉴权
        app.UseAuthentication();
        app.UseAuthorization();

        //注册Furio And Swagger
        app.UseInject();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "Admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}


#pragma warning restore CA1822