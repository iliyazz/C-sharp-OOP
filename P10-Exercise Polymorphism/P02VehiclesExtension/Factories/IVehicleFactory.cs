namespace Vehicles.Factories
{
    using Models;
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(double tankCapacity, string vehicleType, double fuelQuantoty, double fuelConsumotion);
    }
}
