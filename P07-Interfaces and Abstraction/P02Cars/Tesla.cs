
namespace Cars
{
    public class Tesla : IElectricCar, ICar
    {
        public int Battery { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

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
