
namespace Ex03.GarageLogic
{
    public sealed class ElectricEngine : Engine
    {
        // Constants:
        public const float k_BikeBatteryTime = 1.6f;
        public const float k_CarBatteryTime = 4.8f;

        // Constructors:
        public ElectricEngine(float i_MaxCapacity) : base(i_MaxCapacity)
        {
        }

        // Object Overrides:
        public override string ToString()
        {
            return string.Format(
@"
Battery Remain Hours: {0}.",
CurrentAmountOfEnergy);
        }
    }
}
