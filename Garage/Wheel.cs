
namespace Ex03.GarageLogic
{
    public struct Wheel
    {
        // Data Members:
        private readonly string r_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        // Enums:
        public enum eWheelsPerVehicle
        {
            Bike = 2,
            Car = 4,
            Truck = 16
        }

        public enum eMaxAirPressure
        {
            Bike = 28,
            Car = 32,
            Truck = 30
        }

        // Constructors:
        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        // Properties:
        public string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }



        // Methods:
        public void InflateWheel(float i_AirPressure)
        {
            if (CurrentAirPressure + i_AirPressure < MaxAirPressure)
            {
                CurrentAirPressure += i_AirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(i_AirPressure);
            }
        }

        // Object Overrides:
        public override string ToString()
        {
            return string.Format(
@"
Manufacturer: {0}.
AirPressure: {1}.",
Manufacturer,
CurrentAirPressure);
        }
    }
}
