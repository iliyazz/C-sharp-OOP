

namespace MilitaryElite.Models
{
    using MilitaryElite.Enum;
    using MilitaryElite.IO.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions  
        {
            get 
            {
                return missions;
            } 
        }
        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var item in this.missions)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
