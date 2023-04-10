using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories.Models
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> delicacies;

        public DelicacyRepository()
        {
            delicacies = new List<IDelicacy>(); 
        }
        public IReadOnlyCollection<IDelicacy> Models => delicacies;

        public void AddModel(IDelicacy model)=>delicacies.Add(model);
    }

    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> booths;

        public BoothRepository()
        {
            booths = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => booths;

        public void AddModel(IBooth model)=>booths.Add(model);
    }

}
