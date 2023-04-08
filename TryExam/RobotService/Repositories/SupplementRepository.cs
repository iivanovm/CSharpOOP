using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories;

public class SupplementRepository : IRepository<ISupplement>
{
    private readonly List<ISupplement> supplements;

    public SupplementRepository()
    {
        supplements = new List<ISupplement>();
    }

    public void AddNew(ISupplement model)=>supplements.Add(model);

    public ISupplement FindByStandard(int interfaceStandard)=>supplements.FirstOrDefault(s=>s.InterfaceStandard == interfaceStandard);

    public IReadOnlyCollection<ISupplement> Models() => supplements;

    public bool RemoveByName(string typeName)=>supplements.Remove(supplements.FirstOrDefault(x=>x.GetType().Name == typeName));

    public ISupplement FindByModel(string modelName)=> supplements.FirstOrDefault(x => x.GetType().Name == modelName);
}
