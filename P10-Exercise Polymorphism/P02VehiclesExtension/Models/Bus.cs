
namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bus : Vehicle
    {
        private const double BusFuelConsumptionIncrementWithPeople = 1.4;

        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }



        protected override double FuelConsumptionModifier => BusFuelConsumptionIncrementWithPeople;
    }
}

