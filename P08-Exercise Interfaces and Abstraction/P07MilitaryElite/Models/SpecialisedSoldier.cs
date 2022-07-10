
namespace MilitaryElite.Models
{
    using MilitaryElite.Enum;
    using MilitaryElite.IO.Models.Contracts;
    using System;

    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }
        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsString)
        {
            Corps corps;
            bool isParsed = Enum.TryParse<Corps>(corpsString, out corps);
            if (!isParsed)
            {
                throw new ArgumentException("Invalid corps");
            }
            this.Corps = corps;
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps.ToString()}";
        }
    }
}
