using RobotService.Models.Contracts;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models.Models.Supplement;

public abstract partial class Supplement : ISupplement
{

    private int interfaceStandard;
    private int batteryUsage;

    protected Supplement(int interfaceStandard, int batteryUsage)
    {
        InterfaceStandard = interfaceStandard;
        BatteryUsage = batteryUsage;
    }

    public int InterfaceStandard
    {
        get; private set;
    }



    public int BatteryUsage
    {
        get; private set;
    }

}
