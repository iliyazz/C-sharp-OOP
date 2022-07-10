

namespace MilitaryElite.Models
{
    using MilitaryElite.Enum;
    using MilitaryElite.IO.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;


        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }


        public IReadOnlyCollection<IRepair> Repairs
        {
            get
            {
                return this.repairs;
            }
        }


        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var item in this.repairs)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
