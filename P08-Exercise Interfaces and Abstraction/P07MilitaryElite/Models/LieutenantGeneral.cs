namespace MilitaryElite.Models
{
    using MilitaryElite.IO.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<ISoldier> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates
        {
            get 
            { 
                return this.privates; 
            }
        }
        public void AddPrivate(ISoldier currentPrivate)
        {
            this.privates.Add(currentPrivate);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates: ");
            foreach (var item in this.privates)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
