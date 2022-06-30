using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DefaultFuelConsumption = 1.25;
        private int horsePower;
        private double fuel;

        public int HorsePower { get => horsePower; set => horsePower = value; }
        public double Fuel { get => fuel; set => fuel = value; }

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public virtual double FuelConsumption => DefaultFuelConsumption;
        public virtual void Drive(double kilometers)
        {
            if (this.Fuel >= kilometers * this.FuelConsumption)
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }
        }
    }
}
