namespace Vehicles.Factories
{
    using Vehicles.Models;
    using System;
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumotion)
        {
            Vehicle vehicle;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumotion);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumotion);
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type");
            }
            return vehicle;
        }
    }
}
