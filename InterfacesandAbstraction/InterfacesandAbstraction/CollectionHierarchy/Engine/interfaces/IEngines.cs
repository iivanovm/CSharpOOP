using CollectionHierarchy.IO.interfaces;

namespace CollectionHierarchy.Engine.interfaces;

public interface IEngines
{
    void Run(IReader reader,IWriter writer);
}
