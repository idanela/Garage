using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Ex03.GarageLogic
{
    public sealed class GasEngine : Engine
    {
        // Constants:
        public const float k_BikeTank = 5.5f;
        public const float k_CarTank = 50;
        public const float k_TruckTank = 105;

        // Data Members:
        private readonly eGasType r_GasType;

        // Enums:
        public enum eGasType
        {
            None,
            Octan96,
            Octan95,
            Soler
        }


        // Constructors:
        public GasEngine(float i_MaxCapacity, eGasType i_GasType) : base(i_MaxCapacity)
        {
            r_GasType = i_GasType;
        }

        // Properties:
        public eGasType GasType
        {
            get
            {
                return r_GasType;
            }
        }

        // Methods:
        public bool ContainSameGasType(eGasType i_GasType)
        {
            bool containSameGasType = false;

            if (r_GasType != i_GasType)
            {
                throw new ArgumentException("Incorrect fuel type, engine's fuel type that was entered is ", i_GasType.ToString());
            }
            else
            {
                containSameGasType = true;
            }

            return containSameGasType;
        }

        // Object Overrides:
        public override string ToString()
        {
            return string.Format(
@"
Gas Type: {0}.
Remain Liters of Gas: {1}.",
GasType,
CurrentAmountOfEnergy);
        }
    }
}
