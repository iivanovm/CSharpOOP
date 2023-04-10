using WildFarm.IO.interfaces;

namespace WildFarm.Core.interfaces;

public interface IEngine
{
    void Start(IReader reader, IWriter writer);
}
