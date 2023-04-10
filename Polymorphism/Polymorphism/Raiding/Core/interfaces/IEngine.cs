using Raiding.IO.interfaces;

namespace Raiding.Core.interfaces
{
    public interface IEngine
    {
        void Start(IReader reader, IWriter writer);
    }
}
