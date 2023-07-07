namespace Xy.DataBase.Core;

/// <summary>
/// 
/// </summary>
public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options =>
        {
            options.AddDbPool<DefaultDbContext>();
        }, "Xy.Ef.Migrations");
    }
}
