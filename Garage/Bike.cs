using System;
using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public sealed class Bike : Vehicle
    {
        public enum eLicenceType
        {
            A,
            A1,
            B,
            B1
        }

        // Data members
        private eLicenceType m_LicenceType;
        private int m_EngineVolume;

        public Bike(string i_Model, string i_LicenseNumber, Engine i_Engine)
           : base(i_Model, i_LicenseNumber, i_Engine)
        {
            AddWheels();
        }

        //Properties
        public eLicenceType LicenceType
        {
            get
            {
                return m_LicenceType;
            }
            set
            {
                m_LicenceType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                if(value<=0)
                {
                    throw new ArgumentException("The volume of an engine can not be zero or less.");
                }
                m_EngineVolume = value;
            }
        }

        public override void UpdateProperties(object i_engineVolume, object i_LicenseType)
        {
            m_EngineVolume = (int)i_engineVolume;
            m_LicenceType = (eLicenceType)i_LicenseType;
        }

        public override void AddWheels()
        {
            for (int i = 0; i < (int)Wheel.eWheelsPerVehicle.Bike; i++)
            {
                m_Wheels.Add(new Wheel((float)Wheel.eMaxAirPressure.Bike));
            }
        }

        public override List <string> GetMessagesAndParams(out List<object> i_Members)
        {
            List<string> messages = new List<string>();
            messages.Add("Insert kind of license: ");
            i_Members.Add(m_LicenceType);
            messages.Add("Insert Engine volume: ");
            i_Members.Add(m_EngineVolume);

            return messages;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"
EngineVolume: {0}
License kind: {1}
",
m_EngineVolume,m_LicenceType);
        }
    }
}
