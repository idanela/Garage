
using System;

namespace Ex03.GarageLogic
{
    public sealed class ElectricEngine : Engine
    {
        // Constants:
        public const float k_BikeBatteryTime = 1.6f;    // Can be internal?
        public const float k_CarBatteryTime = 4.8f;     // Can be internal?

        // Constructors:
        public ElectricEngine(float i_CurrentAmountToCharge, float i_MaxCapacity) : base(i_CurrentAmountToCharge, i_MaxCapacity)
        {
        }

        // Methods:
        protected override void FillUpEnergy(float i_EnergyAmountToFill, string i_GasType = null)
        {
            hasNoGas(i_GasType);
            chargeEngine(i_EnergyAmountToFill);
        }

        private void hasNoGas(string i_GasType)
        {
            if (i_GasType != null)
            {
                throw new ArgumentException("Electric engine does not use gas. Gas type was ", i_GasType);
            }
        }

        private void chargeEngine(float i_AmountToCharge)
        {
            if (CurrentCapacityEnergy + i_AmountToCharge < MaxCapacityEnergy)
            {
                CurrentCapacityEnergy += i_AmountToCharge;
            }
            else
            {
                // throw new ValueOutOfRangeException.
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
