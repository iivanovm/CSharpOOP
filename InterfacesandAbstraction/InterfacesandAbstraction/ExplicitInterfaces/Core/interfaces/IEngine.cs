using ExplicitInterfaces.IO.interfaces;

namespace ExplicitInterfaces.Core.interfaces;

public interface IEngine
{
    void run(IReader reader,IWriter writer);
}
