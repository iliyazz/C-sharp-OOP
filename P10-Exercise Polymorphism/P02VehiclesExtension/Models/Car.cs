namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car : Vehicle
    {
        private const double CarFuelConsumptionIncrement = 0.9;
        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption) : base( tankCapacity, fuelQuantity, fuelConsumption)
        {

        }
        protected override double FuelConsumptionModifier => CarFuelConsumptionIncrement;
    }
}
