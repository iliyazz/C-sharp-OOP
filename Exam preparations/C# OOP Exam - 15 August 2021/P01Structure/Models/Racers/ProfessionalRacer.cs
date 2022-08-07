namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        public ProfessionalRacer(string username, ICar car)
            : base(username, "strict", 30, car)
        {
        }

        public override void Race()
        {
            this.DrivingExperience += 10;
        }
    }
}
