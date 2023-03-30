﻿using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories.Models
{
    public class CocktailRepository : IRepository<ICocktail>
    {

        private List<ICocktail> cocktails;
        public CocktailRepository()
        {
            cocktails = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => cocktails;

        public void AddModel(ICocktail model)=>cocktails.Add(model);
    }
}
