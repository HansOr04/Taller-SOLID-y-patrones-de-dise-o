using Best_Practices.ModelBuilders;

namespace Best_Practices.Models
{
    public class Motorcycle : Vehicle
    {
        public override int Tires => 2;

        public Motorcycle(VehicleBuilder builder) : base(builder)
        {
        }
    }
}
