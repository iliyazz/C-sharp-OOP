namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int INITIALSIZE = 5;
        private const int INCREASESIZEBY = 2;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = INITIALSIZE;
        }

        public override void Eat()
        {
            this.Size += INCREASESIZEBY;
        }
    }
}
