using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
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

        public decimal Rating
        {
            get => this.CalculateRating();
        }

        private int CalculateRating()
        {
            if (this.players.Count != 0)
            {
                return (int)Math.Round(this.players.Average(p => p.Stats));
            }
            else
            {
                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);

        }

        public void RemovePlayer(string player)
        {
            if (this.players.FirstOrDefault(p => p.Name == player) != null)
            {
                Player current = this.players.FirstOrDefault(p => p.Name == player);
                this.players.Remove(current);
            }
            else
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team. ");
            }

        }

        public override string ToString()
        {
            return $"{this.name} - {this.Rating}";
        }
    }
}
