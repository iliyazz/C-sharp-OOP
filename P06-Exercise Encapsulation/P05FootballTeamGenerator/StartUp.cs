
namespace P05FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = input.Split(";");
                    if (tokens[0] == "Team")
                    {
                        string name = tokens[1];
                        Team team = new Team(name);
                        teams.Add(name, team);
                    }
                    else if (tokens[0] == "Add")
                    {
                        string name = tokens[1];
                        if (!teams.ContainsKey(name))
                        {
                            Console.WriteLine($"Team {name} does not exist.");
                            continue;
                        }
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teams[name].AddPlayer(player);
                    }
                    else if (tokens[0] == "Remove")
                    {
                        string name = tokens[1];
                        if (!teams.ContainsKey(name))
                        {
                            Console.WriteLine($"Team {name} does not exist.");
                            continue;
                        }
                        string playerName = tokens[2];
                        bool isRemoved = teams[name].RemovePlayer(playerName);
                        if (!isRemoved)
                        {
                            Console.WriteLine($"Player {playerName} is not in {name} team.");
                        }
                    }
                    else if (tokens[0] == "Rating")
                    {
                        string name = tokens[1];
                        if (!teams.ContainsKey(name))
                        {
                            Console.WriteLine($"Team {name} does not exist.");
                            continue;
                        }
                        Console.WriteLine($"{name} - {teams[name].AveragePoints}");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
