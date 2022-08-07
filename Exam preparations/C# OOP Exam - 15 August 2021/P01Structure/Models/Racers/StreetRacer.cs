namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        public StreetRacer(string username, ICar car)
            : base(username, "aggressive", 10, car)
        {
        }

        public override void Race()
        {
            throw new System.NotImplementedException();
        }
    }
}
