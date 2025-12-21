using Best_Practices.Models;

namespace Best_Practices.Infraestructure.Factories
{
    public interface IVehicleFactory
    {
        string VehicleType { get; }
        Vehicle CreateVehicle();
    }
}
