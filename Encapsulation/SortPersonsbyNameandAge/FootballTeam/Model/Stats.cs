namespace FootballTeam.Model
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private decimal count = 5;
        private decimal avarageScore;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
            AvarageScore = avarageScore;
        }

        protected int Endurance
        {
            get
            {
                return endurance;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }
                endurance = value;
            }
        }
        protected int Sprint
        {
            get
            {
                return sprint;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }
                sprint = value;
            }
        }
        protected int Dribble
        {
            get
            {
                return dribble;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                }
                dribble = value;
            }
        }
        protected int Passing
        {
            get { return passing; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }
                passing = value;
            }
        }
        protected int Shooting
        {
            get { return shooting; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }
                shooting = value;
            }
        }
        protected decimal AvarageScore
        {
            get
            {
                return avarageScore;
            }
            private set
            {
                avarageScore = (Endurance + Sprint + Dribble + Passing + Shooting) / count;
            }
        }

    }
}
