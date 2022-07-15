namespace Vehicles
{
    using System;
    using Vehicles.Core;
    using Vehicles.Factories;
    using Vehicles.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();
            string[] truckData = Console.ReadLine().Split();
            string[] busData = Console.ReadLine().Split();
            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory.CreateVehicle(double.Parse(carData[3]), carData[0], double.Parse(carData[1]), double.Parse(carData[2]));
            
            Vehicle truck = vehicleFactory.CreateVehicle(double.Parse(truckData[3]), truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]));
            
            Vehicle bus = vehicleFactory.CreateVehicle(double.Parse(busData[3]), busData[0], double.Parse(busData[1]), double.Parse(busData[2]));
            IEngine engine = new Engine(car, truck, bus);
            engine.Start();
        }
    }
}
