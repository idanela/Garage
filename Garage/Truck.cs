using System;
using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public sealed class Truck : Vehicle
    {
        //Data Members
        private bool m_HasDangerCarry;
        private float m_TrunkVolume;

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

        public float TrunkVolume
        {
            get
            {
                return m_TrunkVolume;
            }

            set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Voulme of cargo can not be negative");
                }
                m_TrunkVolume = value;
            }
        }

        public override void UpdateProperties(object i_HasDangerousCarry, object i_CargoVolume)
        {
            m_HasDangerCarry = (bool)i_HasDangerousCarry;
            m_TrunkVolume = (float)i_CargoVolume;
        }

        public override void AddWheels()
        {
            for (int i = 0; i < (int)Wheel.eWheelsPerVehicle.Truck; i++)
            {
                m_Wheels.Add(new Wheel((float)Wheel.eMaxAirPressure.Truck));
            }
        }

        public override List<string> GetMessagesAndParams(out List<object> i_Members)
        {
            List<string> messages = new List<string>();
            messages.Add("Insert Trunk Volume: ");
            i_Members.Add(m_TrunkVolume);

            return messages;
        }

        public override string ToString()
        {     
            return base.ToString() + string.Format(@"
Does it carry Dangerous cargo?: {0}
Cargo volume is: {1}
",
           m_HasDangerCarry, m_TrunkVolume); 
        }
    }
}
