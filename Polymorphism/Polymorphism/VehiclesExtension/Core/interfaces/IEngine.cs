using Vehicles.IO.interfaces;

namespace Vehicles.Core.interfaces
{
    public interface IEngine
    {
        void Start(IReader reader,IWriter writer);
    }
}
