using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        private string username;
        private int level;

        public string Username { get => username; set => username = value; }
        public int Level { get => level; set => level = value; }

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
