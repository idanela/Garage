
using System;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        // Data Member:
        protected float m_CurrentAmountOfEnergy;
        protected readonly float r_MaxCapacityEnergy;

        // Enums:
        public enum eEngineType
        {
            Gas = 0,
            Electric
        }

        // Constructors:
        protected Engine(float iCurrentCapacityEnergy, float i_MaxCapacityEnergy)
        {
            m_CurrentAmountOfEnergy = iCurrentCapacityEnergy;
            r_MaxCapacityEnergy = i_MaxCapacityEnergy;
        }

        // Properties:
        protected float CurrentCapacityEnergy
        {
            get
            {
                return m_CurrentAmountOfEnergy;
            }
            set
            {
                m_CurrentAmountOfEnergy = value;
            }
        }

        protected float MaxCapacityEnergy
        {
            get
            {
                return r_MaxCapacityEnergy;
            }
        }

        // Methods:
        protected virtual void FillUpEnergy(float i_EnergyAmountToFill, string i_GasType)
        {
            if (CurrentCapacityEnergy + i_EnergyAmountToFill < MaxCapacityEnergy)
            {
                m_CurrentAmountOfEnergy += i_EnergyAmountToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(i_EnergyAmountToFill);
            }
        }
    }
}
