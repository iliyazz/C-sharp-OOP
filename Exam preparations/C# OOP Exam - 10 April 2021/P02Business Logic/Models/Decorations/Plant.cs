namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int INITIALCOMFORT = 5;
        private const decimal INITIALPRICE = 10m;

        public Plant()
            : base(INITIALCOMFORT, INITIALPRICE)
        {
        }
    }
}
