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

                if (!Enum.IsDefined(typeof(eLicenceType), value))
                {
                    throw new ArgumentException("value is not one of the options ");
                }

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
                if (value <= 0)
                {
                    throw new ArgumentException("Trunk volume can not be negative");
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

        public bool setBikeEngineeVolume(string i_TrunkVoulmeInfo)
        {
            int volume;
            bool isValidinput = false;
            int.TryParse(i_TrunkVoulmeInfo, out volume);
            if (isValidinput)
            {
                m_EngineVolume = volume;
            }

            return isValidinput;
        }
        public eLicenceType SetLicseneType(string i_TrunkVoulmeInfo)
        {
            eLicenceType hasDangerCargo;
            bool isValidinput = false;
            float.TryParse(i_TrunkVoulmeInfo, out hasDangerCargo);
            if (isValidinput)
            {
                m_HasDangerCarry = hasDangerCargo;
            }

            return isValidinput;
        }
        public override Dictionary<string, object> GetMessagesAndParams()
        {
            Dictionary<string, object> request = new Dictionary<string, object>();

            request.Add("Insert Engine volume: ", m_EngineVolume);
            request.Add("Insert licence type: ", m_LicenceType);
            return request;
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
