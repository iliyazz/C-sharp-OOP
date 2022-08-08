namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        public HappyBunny(string name)
            : base(name, 100)
        {
        }

        public override void Work()
        {
            if (this.Energy -10 < 0)
            {
                this.Energy = 0;
            }
            else
            {
                this.Energy -= 10;
            }
        }
    }
}
