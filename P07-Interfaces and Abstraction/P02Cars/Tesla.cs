
namespace Cars
{
    public class Tesla : IElectricCar, ICar
    {
        public int Battery { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }

        public Tesla(string model, string color, int battery)
        {
            this.Battery = battery;
            this.Model = model;
            this.Color = color;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries";
        }
    }
}
