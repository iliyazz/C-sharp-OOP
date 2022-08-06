namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int INITIALCOMFORT = 1;
        private const decimal INITIALPRICE = 5m;
        public Ornament() 
            : base(INITIALCOMFORT, INITIALPRICE)
        {
        }
    }
}
