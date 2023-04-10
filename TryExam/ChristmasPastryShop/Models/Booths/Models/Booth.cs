using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Repositories.Models;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths.Models
{
    public class Booth : IBooth
    {

        private readonly IRepository<IDelicacy> delicacies;
        private readonly IRepository<ICocktail> cocktails;
        private int boothId;
        private int capacity;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            this.delicacies = new DelicacyRepository();
            this.cocktails = new CocktailRepository();

            this.currentBill = 0;
            turnover = 0;
        }

        public int BoothId
        {
            get => boothId;
            private set => boothId = value;
        }
        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityLessThanOne));
                }
                capacity = value;
            }
        }
        public IRepository<IDelicacy> DelicacyMenu => delicacies;
        public IRepository<ICocktail> CocktailMenu => cocktails;
        public double CurrentBill
        {
            get => currentBill;
            private set => currentBill = value;
        }
        public double Turnover
        {
            get => turnover;
            private set => turnover = value;
        }
        public bool IsReserved
        {
            get => isReserved;
            private set => isReserved = value;
        }


        public void ChangeStatus()
        {
            if (IsReserved)
            {
                IsReserved = false;
                return;
            }
            IsReserved = true;
        }
        public void Charge()
        {
            turnover += currentBill;
            currentBill = 0;
        }
        public void UpdateCurrentBill(double amount)
        {
            currentBill += amount;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {this.boothId}");
            sb.AppendLine($"Capacity: {this.capacity}");
            sb.AppendLine($"Turnover: {this.Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach (var cocktail in this.CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }
            sb.AppendLine($"-Delicacy menu:");
            foreach (var delicacy in this.DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
