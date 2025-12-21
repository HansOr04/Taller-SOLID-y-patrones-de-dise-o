using Best_Practices.ModelBuilders;

namespace Best_Practices.Models
{
    public class Car : Vehicle
    {
        public override int Tires => 4;

        public Car(VehicleBuilder builder) : base(builder)
        {
        }
    }
}
