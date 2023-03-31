using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;
        public HeroRepository()
        {
            heroes = new List<IHero>();
        }


        public IReadOnlyCollection<IHero> Models => heroes;

        public void Add(IHero model)=>heroes.Add(model);

        public IHero FindByName(string name)=>heroes.FirstOrDefault(h=> h.Name == name);    

        public bool Remove(IHero model)=>heroes.Remove(model);
    }


    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }


        public IReadOnlyCollection<IWeapon> Models =>weapons;

        public void Add(IWeapon model)=>weapons.Add(model);

        public IWeapon FindByName(string name)=>weapons.FirstOrDefault(h=> h.Name == name);

        public bool Remove(IWeapon model)=>weapons.Remove(model);
    }
}
