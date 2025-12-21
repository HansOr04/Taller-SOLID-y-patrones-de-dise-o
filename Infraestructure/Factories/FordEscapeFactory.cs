using Best_Practices.ModelBuilders;
using Best_Practices.Models;
using System;

namespace Best_Practices.Infraestructure.Factories
{
    public class FordEscapeFactory : IVehicleFactory
    {
        public string VehicleType => "escape";

        public Vehicle CreateVehicle()
        {
            return new VehicleBuilder()
                .SetBrand("Ford")
                .SetModel("Escape")
                .SetColor("Red")
                .SetYear(DateTime.Now.Year)
                .SetHorsepower(250)
                .SetTransmissionType("Automatic")
                .SetEngineType("Gasoline")
                .SetFuelLimit(14.0)
                .BuildCar();
        }
    }
}
