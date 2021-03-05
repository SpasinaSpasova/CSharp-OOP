using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const int MinSetsValue = 0;
        private const int MaxSetsValue = 100;

        
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }

        }
        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if (value<MinSetsValue||value>MaxSetsValue)
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (value < MinSetsValue || value > MaxSetsValue)
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                if (value < MinSetsValue || value > MaxSetsValue)
                {
                    throw new ArgumentException($"{nameof(dribble)} should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                if (value < MinSetsValue || value > MaxSetsValue)
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (value < MinSetsValue || value > MaxSetsValue)
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }
        public int Stats { get => this.CalculateAverageStats(); }
        private int CalculateAverageStats()
        {
            return (int)Math.Round((this.Dribble + this.Endurance + this.Passing + this.Shooting + this.Sprint) / (double)5);
        }
    }
}
