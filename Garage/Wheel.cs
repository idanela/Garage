
namespace Garage
{
    public struct Wheel
    {
        // Data Members:
        private readonly string m_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float m_MaxAirPressure;

        // Constructors:
        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        // Methods:
        public void InflateWheel(float i_AirPressure)
        {
            if (m_CurrentAirPressure + i_AirPressure < m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirPressure;
            }
            else
            {
                // throw new ValutOutOfRangeException();
            }
        }
    }
}
