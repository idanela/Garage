
using System;

namespace Garage
{
    public abstract class Engine
    {
        // Adding this line just to check changes! (delete me).
        // Data Member:
        protected float m_CurrentAmountOfEnergy;
        protected readonly float m_MaxCapacityEnergy;

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
            m_MaxCapacityEnergy = i_MaxCapacityEnergy;
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
                return m_MaxCapacityEnergy;
            }
        }

        // Methods:
        protected abstract void FillUpEnergy(float i_EnergyAmountToFill, string i_GasType);
    }
}
