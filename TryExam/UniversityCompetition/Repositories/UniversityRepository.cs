namespace UniversityCompetition.Repositories;
using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

public class UniversityRepository : IRepository<IUniversity>
{

    private List<IUniversity> universities;

    public UniversityRepository()
    {
        this.universities = new List<IUniversity>();
    }

    public IReadOnlyCollection<IUniversity> Models => universities;

    public void AddModel(IUniversity model)=>this.universities.Add(model);

    public IUniversity FindById(int id)=>this.universities.FirstOrDefault(s=>s.Id==id);

    public IUniversity FindByName(string name)=>this.universities.FirstOrDefault(s=>s.Name==name);
}
