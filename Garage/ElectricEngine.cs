
using System;

namespace Garage
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
        protected override void FillUpEnergy(float i_EnergyAmountToFill, string i_GasType)
        {
            chargeEngine(i_EnergyAmountToFill);
        }

        private void chargeEngine(float i_AmountToCharge)
        {
            if (m_CurrentAmountOfEnergy + i_AmountToCharge < m_MaxCapacityEnergy)
            {
                m_CurrentAmountOfEnergy += i_AmountToCharge;
            }
            else
            {
                // throw new ValutOutOfRangeException.
            }
        }
    }
}
