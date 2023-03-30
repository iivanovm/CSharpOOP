namespace UniversityCompetition.Repositories;

using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

public class SubjectRepository : IRepository<ISubject>
{
    private List<ISubject> subjects;

    public SubjectRepository()
    {
        this.subjects = new List<ISubject>();
    }

    public IReadOnlyCollection<ISubject> Models => subjects;

    public void AddModel(ISubject model)=>this.subjects.Add(model);

    public ISubject FindById(int id)=>subjects.FirstOrDefault(s=>s.Id==id); 

    public ISubject FindByName(string name)=>subjects.FirstOrDefault(s=>s.Name==name);
}
