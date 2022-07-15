namespace Vehicles.Models
{

    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionIncrement = 1.6;
        private const double RefuelCoefficient = 0.95;

        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }
        protected override double FuelConsumptionModifier => TruckFuelConsumptionIncrement;
        public override void Refuel(double litters)
        {

            if (this.TankCapacity <= FuelQuantity + litters * RefuelCoefficient)
            {
                base.Refuel(litters);
            }
            else
            {
                base.Refuel(litters * RefuelCoefficient);
            }

        }
    }
}
