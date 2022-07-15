namespace Vehicles.Models
{
    using Contracts;
    using System;
    public abstract class Vehicle : IVehicle
    {
        private const double BusFuelConsumptionIncrementWithPeople = 1.4;
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        private Vehicle()
        {
            this.FuelConsumptionModifier = 0;
        }
        protected Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : this()
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        //public bool IsEmpty { get; set; }
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            private set
            {
                if (this.TankCapacity < value)
                {
                    fuelQuantity = 0;
                    //throw new ArgumentException($"Cannot fit {value} fuel in the tank");
                }
                else
                {
                    this.fuelQuantity = value;
                }

            }
        }
        public double TankCapacity { get; private set; }
        //{
        //    get
        //    {
        //        return this.tankCapacity;
        //    }
        //    private set
        //    {
        //        this.tankCapacity = value;
        //    }
        //}

        public double  FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }

            protected set 
            {
                this.fuelConsumption = value + this.FuelConsumptionModifier;
            } 
        }
        protected virtual double FuelConsumptionModifier { get; }
        
        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;
            if (fuelNeeded > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
             this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";

        }
        public string DriveEmpty(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption - BusFuelConsumptionIncrementWithPeople);
            if (fuelNeeded > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
             this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";

        }
        
        public  virtual void Refuel(double litters)
        {
            if (litters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.TankCapacity <= fuelQuantity + litters)
            {
                throw new ArgumentException($"Cannot fit {litters} fuel in the tank");
            }
            this.FuelQuantity += litters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
