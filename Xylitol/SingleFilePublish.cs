namespace Xylitol;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "Xy.Application",
            "Xy.Core",
            "Xy.DataBase.Core",
            "Xy.Web.Core"
        };
    }
}