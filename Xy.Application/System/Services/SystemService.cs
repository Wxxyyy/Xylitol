namespace Xy.Application;

public class SystemService : ISystemService, ITransient
{
    public string GetDescription()
    {
        return " 两情若是长久时,又岂在朝朝暮暮。";
    }
}
