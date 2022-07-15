namespace Vehicles.Factories
{
    using Vehicles.Models;
    using System;
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(double tankCapacity, string vehicleType, double fuelQuantity, double fuelConsumotion)
        {
            Vehicle vehicle;
            try
            {
                if (vehicleType == "Car")
                {
                    vehicle = new Car(tankCapacity, fuelQuantity, fuelConsumotion);
                }
                else if (vehicleType == "Truck")
                {
                    vehicle = new Truck(tankCapacity, fuelQuantity, fuelConsumotion);
                }
                else if (vehicleType == "Bus")
                {
                    vehicle = new Bus(tankCapacity, fuelQuantity, fuelConsumotion);
                }
                else
                {
                    throw new InvalidOperationException("Invalid vehicle type");
                }
                return vehicle;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
