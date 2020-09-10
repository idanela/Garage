
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
            Gas = 1,
            Electric
        }

        // Constructors:
        protected Engine(float i_MaxCapacityEnergy)
        {
            m_CurrentAmountOfEnergy = 0;
            r_MaxCapacityEnergy = i_MaxCapacityEnergy;
        }

        // Properties:
        public float CurrentAmountOfEnergy
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

        public float MaxCapacityEnergy
        {
            get
            {
                return r_MaxCapacityEnergy;
            }
        }

        // Methods:
        public virtual void FillUpEnergy(float i_EnergyAmountToFill)
        {
            if (CurrentAmountOfEnergy + i_EnergyAmountToFill <= MaxCapacityEnergy)
            {
                m_CurrentAmountOfEnergy += i_EnergyAmountToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxCapacityEnergy);
            }
        }
    }
}
