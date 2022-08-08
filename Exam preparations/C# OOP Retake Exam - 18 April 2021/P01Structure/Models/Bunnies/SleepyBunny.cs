namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        public SleepyBunny(string name)
            : base(name, 50)
        {
        }

        public override void Work()
        {
            if (this.Energy - 15 < 0)
            {
                this.Energy = 0;
            }
            else
            {
                this.Energy -= 15;
            }
        }
    }
}
