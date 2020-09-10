using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public sealed class Truck : Vehicle
    {
        // Data Members
        private bool m_HasDangerCarry;
        private float m_TrunkVolume;

        public Truck(string i_Model, string i_LicenseNumber, Engine i_Engine)
            : base(i_Model, i_LicenseNumber, i_Engine)
        {
            this.AddWheels();
        }

        // Properties
        public bool HasDangerCarry
        {
            get
            {
                return this.m_HasDangerCarry;
            }

            set
            {
                this.m_HasDangerCarry = value;
            }
        }

        public float TrunkVolume
        {
            get
            {
                return this.m_TrunkVolume;
            }

            set
            {
                if (value <= 0)
                {
                    new ArgumentException("Trunk volume can not be negative or zero.");
                }

                m_TrunkVolume = value;
            }
        }

        public override void AddWheels()
        {
            for (int i = 0; i < (int)Wheel.eWheelsPerVehicle.Truck; i++)
            {
                m_Wheels.Add(new Wheel((float)Wheel.eMaxAirPressure.Truck));
            }
        }

        public override List<string> GetMessagesAboutParams()
        {
            List<string> request = new List<string>();

            request.Add("Insert trunk volume: ");
            request.Add("Is the truck carries dangerous cargo? (Yes / No)");

            return request;
        }

        public override bool CheckAndSetValidProperties(int i_IndexOfInput, string i_InputsFromUser)
        {
            bool isValid = false;

            if (i_IndexOfInput == 0)
            {
               isValid = setTrunkVolume(i_InputsFromUser);
            }
            else
            {
                isValid = setDangerCarry(i_InputsFromUser);
            }

            return isValid;
        }

        private bool setTrunkVolume(string i_TrunkVoulmeInfo)
        {
            float volume;
            bool isValidinput = false;

            isValidinput = float.TryParse(i_TrunkVoulmeInfo, out volume);
            if (!isValidinput)
            {
                throw new FormatException("Not a valid input for trunk volume.");
            }

            TrunkVolume = volume;

            return isValidinput;
        }

        private bool setDangerCarry(string i_HasDangerousCarry)
        {
            bool isValidInput = i_HasDangerousCarry == "Yes" || i_HasDangerousCarry == "No";

            if (isValidInput)
            {
                HasDangerCarry = i_HasDangerousCarry == "yes";
            }
            
            return isValidInput;
        }

        public override string ToString()
        {
            string printhasHazardousCargo = m_HasDangerCarry ? "Yes" : "No";
            return base.ToString() + string.Format(
                @"
Does it carry Dangerous cargo? {0}
Cargo volume is: {1}
",
           printhasHazardousCargo, 
           m_TrunkVolume); 
        }
    }
}
