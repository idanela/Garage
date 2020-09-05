using System;

namespace Garage
{
    public sealed class GasEngine : Engine
    {
        // Constants:
        public const float k_BikeTank = 5.5f;
        public const float k_CarTank = 50;
        public const float k_TruckeTank = 105;

        // Data Members:
        private readonly string m_GasType;

        // Enums:
        public enum eGasType
        {
            Octan98 = 0,
            Octan96,
            Octan95,
            Soler
        }


        // Constructors:
        public GasEngine(float i_CurrentAmountOfFuel, float i_MaxCapacity, string i_GasType) : base(i_CurrentAmountOfFuel, i_MaxCapacity)
        {
            m_GasType = i_GasType;
        }

        // Properties:
        public string GasType
        {
            get
            {
                return m_GasType;
            }
        }

        // Methods:
        protected override void FillUpEnergy(float i_EnergyAmountToFill, string i_GasType)
        {
            containSameFuelType(i_GasType);
            FuelEngine(i_EnergyAmountToFill);
        }

        private void containSameFuelType(string i_GasType)
        {
            if (i_GasType != GasType)
            {
                throw new ArgumentException("Incorrect fuel type, engine's fuel type that was entered is ", i_GasType);
            }
        }

        private void FuelEngine(float i_EnergyAmountToFill)
        {
            if (CurrentCapacityEnergy + i_EnergyAmountToFill < MaxCapacityEnergy)
            {
                CurrentCapacityEnergy += i_EnergyAmountToFill;
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
Gas Type: {0}.
Remain Liters of Gas: {1}.",
GasType,
CurrentCapacityEnergy);
        }
    }
}
