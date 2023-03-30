namespace UniversityCompetition.Repositories;

using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

public class StudentRepository : IRepository<IStudent>
{
    private List<IStudent> students;

    public StudentRepository()
    {
        this.students = new List<IStudent>();
    }

    public IReadOnlyCollection<IStudent> Models => this.students;

    public void AddModel(IStudent model)=>students.Add(model);

    public IStudent FindById(int id) => students.FirstOrDefault(s => s.Id == id);

    public IStudent FindByName(string name)
    {
        string firstName = name.Split(" ")[0];
        string lastName = name.Split(" ")[1];

        return this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
    }
}
