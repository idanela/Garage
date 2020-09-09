using System;
using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public sealed class Bike : Vehicle
    {
        public enum eLicenseType
        {
            A = 1,
            A1,
            B,
            B1
        }

        // Data members
        private eLicenseType m_LicenceType;
        private int m_EngineVolume;

        public Bike(string i_Model, string i_LicenseNumber, Engine i_Engine)
           : base(i_Model, i_LicenseNumber, i_Engine)
        {
            AddWheels();
        }

        //Properties
        public eLicenseType LicenceType
        {
            get
            {
                return m_LicenceType;
            }
            set
            {

                if (!Enum.IsDefined(typeof(eLicenseType), value))
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

        public override void AddWheels()
        {
            for (int i = 0; i < (int)Wheel.eWheelsPerVehicle.Bike; i++)
            {
                m_Wheels.Add(new Wheel((float)Wheel.eMaxAirPressure.Bike));
            }
        }

        public override bool CheckAndSetValidProperties(int i_IndexOfInput, string i_InputsFromUser)
        {
            bool isValid = false;

            if (i_IndexOfInput == 0)
            {
                isValid = setBikeEngineeVolume(i_InputsFromUser);
            }
            else
            {
                isValid = SetLicenseType(i_InputsFromUser);
            }

            return isValid;
        }
     
        public bool setBikeEngineeVolume(string i_TrunkVoulmeInfo)
        {
            int volume;
            bool isValidinput = false;
            isValidinput = int.TryParse(i_TrunkVoulmeInfo, out volume);
            if (isValidinput)
            {
                m_EngineVolume = volume;
            }

            return isValidinput;
        }
        public bool SetLicenseType(string i_LicenseType)
        {
            eLicenseType licenseType;
            bool isValidinput = false;

            Enum.TryParse(i_LicenseType, out licenseType);

            isValidinput = Enum.IsDefined(typeof(eLicenseType), licenseType);
            if (isValidinput)
            {
                m_LicenceType = licenseType;
            }

            return isValidinput;
        }

        public override List<string> GetMessagesAndParams()
        {
            List<string> request = new List<string>();

            request.Add("Insert Engine volume: ");
            request.Add(@"Insert licence type: 
1.A
2.A1
3.B
4.B1
");

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
