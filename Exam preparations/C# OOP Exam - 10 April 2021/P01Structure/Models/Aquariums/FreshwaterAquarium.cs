namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int INITIALAQUARIUMCAPACITY = 50;
        public FreshwaterAquarium(string name)
            : base(name, INITIALAQUARIUMCAPACITY)
        {
        }
    }
}
