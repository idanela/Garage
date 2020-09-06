namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        //Data Members
        private bool m_HasDangerCarry;
        private float m_CargoVolume;

        public Truck(string i_Model, string i_VehicleIdNumber, Engine i_Engine)
            : base(i_Model, i_VehicleIdNumber, i_Engine)
        {
            for (int i = 0; i < (int)Wheel.eWheelsPerVehicle.Truck; i++)
            {
                m_Wheels.Add(new Wheel((float)Wheel.eMaxAirPressure.Truck));
            }
        }

        //Properties
        public bool HasDangerCarry
        {
            get
            {
                return m_HasDangerCarry;
            }

            set
            {
                m_HasDangerCarry = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }

            set
            {
                m_CargoVolume = value;
            }
        }

        public override void updateProperties(object i_HasDangerousCarry, object i_CargoVolume)
        {
            m_HasDangerCarry = (bool)i_HasDangerousCarry;
            m_CargoVolume = (float)i_CargoVolume;
        }
    }
}
