using Best_Practices.ModelBuilders;
using Best_Practices.Models;
using System;

namespace Best_Practices.Infraestructure.Factories
{
    public class FordExplorerFactory : IVehicleFactory
    {
        public string VehicleType => "explorer";

        public Vehicle CreateVehicle()
        {
            return new VehicleBuilder()
                .SetBrand("Ford")
                .SetModel("Explorer")
                .SetColor("Black")
                .SetYear(DateTime.Now.Year)
                .SetHorsepower(300)
                .SetTransmissionType("Automatic")
                .SetEngineType("Gasoline")
                .SetFuelLimit(18.0)
                .BuildCar();
        }
    }
}
