﻿namespace Vehicles.Core
{
    using Models;
    using System;
    using Vehicles.Models.Contracts;

    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        public Engine(Vehicle car, Vehicle truck)
        {
            this.car = car;
            this.truck = truck; 
        }
        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
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
                        Console.WriteLine(this.truck.Drive(cmdParam)) ;
                    }
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
                }

            }
            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
        }
    }
}
