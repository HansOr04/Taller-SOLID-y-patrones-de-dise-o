using Best_Practices.ModelBuilders;
using Best_Practices.Models;
using System;

namespace Best_Practices.Infraestructure.Factories
{
    public class FordMustangFactory : IVehicleFactory
    {
        public string VehicleType => "mustang";

        public Vehicle CreateVehicle()
        {
            return new VehicleBuilder()
                .SetBrand("Ford")
                .SetModel("Mustang")
                .SetColor("Red")
                .SetYear(DateTime.Now.Year)
                .SetHorsepower(450)
                .SetTransmissionType("Manual")
                .SetEngineType("Gasoline")
                .SetFuelLimit(15.0)
                .BuildCar();
        }
    }
}
