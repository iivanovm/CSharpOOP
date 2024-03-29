﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories.Entities
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> formulaOneCars;

        public FormulaOneCarRepository()
        {
            formulaOneCars = new List<IFormulaOneCar>();
        }


        public IReadOnlyCollection<IFormulaOneCar> Models => formulaOneCars;

        public void Add(IFormulaOneCar model)=>formulaOneCars.Add(model);

        public IFormulaOneCar FindByName(string name)=>formulaOneCars.FirstOrDefault(f=>f.Model == name);

        public bool Remove(IFormulaOneCar model)=>formulaOneCars.Remove(model);
    }
}
