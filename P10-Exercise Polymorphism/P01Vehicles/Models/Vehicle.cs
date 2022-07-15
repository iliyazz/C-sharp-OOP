namespace Vehicles.Models
{
    using Contracts;
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private Vehicle()
        {
            this.FuelConsumptionModifier = 0;
        }
        protected Vehicle(double fuelQuantity, double fuelConsumption)
            : this()
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            private set 
            {
                this.fuelQuantity = value;
            }
        }

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

        public  virtual void Refuel(double litters)
        {
            this.FuelQuantity += litters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
