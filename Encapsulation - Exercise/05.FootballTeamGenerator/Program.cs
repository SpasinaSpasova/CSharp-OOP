using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                string[] tokens = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                try
                {

               
                switch (tokens[0])
                {
                    case "Team":
                        teams.Add(new Team(tokens[1]));
                        break;
                    case "Add":
                        if (!teams.Any(t => t.Name == tokens[1]))
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }
                        else
                        {
                            Team currentTeam = teams.First(t => t.Name == tokens[1]);
                            currentTeam.AddPlayer(new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7])));
                        }
                        break;
                    case "Remove":
                        Team teamToRemove = teams.FirstOrDefault(t => t.Name == tokens[1]);
                        teamToRemove.RemovePlayer(tokens[2]);
                        break;
                    case "Rating":
                        if (!teams.Any(t=>t.Name==tokens[1]))
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine(teams.Find(t=>t.Name==tokens[1]).ToString());
                        }
                        break;
                }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
