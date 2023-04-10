using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories.Entities
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;
        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => planets;

        public void AddItem(IPlanet model)=>planets.Add(model);

        public IPlanet FindByName(string name)=>planets.FirstOrDefault(pl=>pl.Name == name);

        public bool RemoveItem(string name)=>planets.Remove(planets.FirstOrDefault(pltr=>pltr.Name == name));
    }
}