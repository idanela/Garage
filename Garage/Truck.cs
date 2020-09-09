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

        public float CargoVolume
        {
            get
            {
                return m_TrunkVolume;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ValueOutOfRangeException(1, 1000);
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


        public override Dictionary<string, object> GetMessagesAndParams()
        {
            Dictionary<string, object> request = new Dictionary<string, object>();

            request.Add("Insert cargo volume: ", m_TrunkVolume);
            return request;
        }

        public override bool CheckValidProperties(int i_IndexOfInput, params string[] i_InputsFromUser)
        {
            bool isValid = false;

            if (i_IndexOfInput == 0)
            {
                SetDangerCarry(i_InputsFromUser[i_IndexOfInput]);
            }
            else
            {
                SetTrunkVolume(i_InputsFromUser[i_IndexOfInput]);
            }
        }

        public bool SetTrunkVolume(string i_TrunkVoulmeInfo)
        {
            float volume;
            bool isValidinput = false;
            float.TryParse(i_TrunkVoulmeInfo, out volume);
            if(isValidinput)
            {
                m_TrunkVolume = volume;
            }

            return isValidinput;
        }
        public bool SetDangerCarry(string i_TrunkVoulmeInfo)
        {
            bool hasDangerCargo;
            bool isValidinput = false;
            float.TryParse(i_TrunkVoulmeInfo, out hasDangerCargo);
            if (isValidinput)
            {
                m_HasDangerCarry = hasDangerCargo;
            }

            return isValidinput;
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
