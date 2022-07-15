namespace Vehicles.Core
{
    using Models;
    using System;
    using Vehicles.Models.Contracts;

    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Vehicle bus;
        public Engine(Vehicle car, Vehicle truck, Vehicle bus)
        {
            this.car = car;
            this.truck = truck; 
            this.bus = bus;
        }
        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] cmdArg = Console.ReadLine().Split();
                    string cmdType = cmdArg[0];
                    string vehicleType = cmdArg[1];
                    double cmdParam = double.Parse(cmdArg[2]);
                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(this.car.Drive(cmdParam));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(this.truck.Drive(cmdParam));
                        }
                        else if (vehicleType == "Bus")
                        {

                            Console.WriteLine(this.bus.Drive(cmdParam));
                        }
                    }
                    else if (cmdType == "DriveEmpty")
                    {
                        //bus.IsEmpty = false;
                        Console.WriteLine(this.bus.DriveEmpty(cmdParam));
                        //bus.IsEmpty = true;
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.car.Refuel(cmdParam);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.truck.Refuel(cmdParam);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.bus.Refuel(cmdParam);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message); ;
                }
            }
            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }
    }
}
