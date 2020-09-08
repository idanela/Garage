using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public sealed class Truck : Vehicle
    {
        //Data Members
        private bool m_HasDangerCarry;
        private float m_CargoVolume;

        public Truck(string i_Model, string i_LicenseNumber, Engine i_Engine)
            : base(i_Model, i_LicenseNumber, i_Engine)
        {
            AddWheels();
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
                if (value <= 0)
                {
                    throw new ValueOutOfRangeException(1, 1000);
                }
                m_CargoVolume = value;
            }
        }

        public override void UpdateProperties(object i_HasDangerousCarry, object i_CargoVolume)
        {
            m_HasDangerCarry = (bool)i_HasDangerousCarry;
            m_CargoVolume = (float)i_CargoVolume;
        }

        public override void AddWheels()
        {
            for (int i = 0; i < (int)Wheel.eWheelsPerVehicle.Truck; i++)
            {
                m_Wheels.Add(new Wheel((float)Wheel.eMaxAirPressure.Truck));
            }
        }


        public override Dictionary<string, object> GetMessagesAndParams()
        {
            Dictionary<string, object> request = new Dictionary<string, object>();

            request.Add("Insert cargo volume: ", m_CargoVolume);
            return request;
        }
        public override string ToString()
        {     
            return base.ToString() + string.Format(@"
Does it carry Dangerous cargo?: {0}
Cargo volume is: {1}
",
           m_HasDangerCarry, m_CargoVolume); 
        }
    }
}
