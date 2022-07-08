
namespace P05FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Team
    {
        private string name;
        private readonly List<Player> players;
        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int AveragePoints
        {
            get
            {
                if (players.Any())
                {
                    return (int)Math.Round(this.players.Average(x => x.Stats));
                }
                return 0;
            }
            
        }
        
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public bool RemovePlayer(string name) 
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            return players.Remove(player); 
        } 
    }
}
