using System;

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

        // Methods:
        public override void FillUpEnergy(float i_EnergyAmountToFill, GasEngine.eGasType i_GasType = GasEngine.eGasType.None)
        {
            hasNoGas(i_GasType);
            base.FillUpEnergy(i_EnergyAmountToFill, GasEngine.eGasType.None);
        }

        private void hasNoGas(GasEngine.eGasType i_GasType)
        {
            if (i_GasType != GasEngine.eGasType.None)
            {
                throw new ArgumentException("Electric engine does not use gas. Gas type was ", 
                    Enum.GetName(typeof(GasEngine.eGasType),i_GasType));
            }
        }

        // Object Overrides:
        public override string ToString()
        {
            return string.Format(
@"
Battery Remain Hours: {0}.",
CurrentCapacityEnergy);
        }
    }
}
