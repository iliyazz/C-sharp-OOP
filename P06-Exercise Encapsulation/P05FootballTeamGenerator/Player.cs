
namespace P05FootballTeamGenerator
{
    using System;
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            CheckPlayerStats("Endurance", endurance);
            CheckPlayerStats("Sprint", sprint);
            CheckPlayerStats("Dribble", dribble);
            CheckPlayerStats("Passing", passing);
            CheckPlayerStats("Shooting", shooting);

            this.Name = name;
            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
        }

        private void CheckPlayerStats(string v, int points)
        {

            if (points < 0 || points > 100)
            {
                throw new ArgumentException($"{v} should be between 0 and 100.");
            }
            
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
        public double Stats
        {
            get
            {
                return (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0;
            }
        }

    }
}

