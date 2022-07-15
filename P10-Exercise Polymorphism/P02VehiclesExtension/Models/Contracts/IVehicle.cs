namespace Vehicles.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get;}
        double FuelConsumption { get;}
        double TankCapacity { get;}
        //public bool IsEmpty { get; set; }
        string Drive(double distance);
        void Refuel(double litters);
    }
}
