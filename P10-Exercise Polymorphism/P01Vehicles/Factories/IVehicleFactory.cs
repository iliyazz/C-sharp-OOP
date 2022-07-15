namespace Vehicles.Factories
{
    using Models;
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQuantoty, double fuelConsumotion);
    }
}
