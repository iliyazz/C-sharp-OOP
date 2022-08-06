namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int INITIALSIZE = 3;
        private const int INCREASESIZEBY = 3;
        public FreshwaterFish(string name, string species, decimal price) 
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
