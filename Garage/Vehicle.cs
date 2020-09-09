using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_Model;
        protected readonly string r_LisenceNumber;
        protected float m_PrecentageOfEnergyLeft;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;

        protected Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine)
        {
            m_Wheels = new List<Wheel>();
            r_Model = i_Model;
            r_LisenceNumber = i_LicenseNumber;
            m_PrecentageOfEnergyLeft = 0;
            m_Engine = i_Engine;
        }

        // Properties
        public string Model
        {
            get
            {
                return r_Model;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LisenceNumber;
            }
        }

        virtual public float PrecentageOfEnergyLeft
        {
            get
            {
                return m_PrecentageOfEnergyLeft;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }

            set
            {
                Engine = value;
            }
        }

        public abstract void AddWheels();
        public abstract List<string> GetMessagesAndParams();

        public void UpdatManufactererOfWheels(string i_NameOfManufacterer)
        {
            
            Wheel wheel;
            for (int i = 0; i < this.Wheels.Count; i++)
            {
                wheel = m_Wheels[i];
                wheel.Manufacturer = i_NameOfManufacterer;
                m_Wheels[i] = wheel;
            }
        }


        public abstract bool CheckAndSetValidProperties(int i_IndexOFInput, string i_InputsFromUser);


        public override string ToString()
        {
            return string.Format(@"
Model:{0}
license number:{1}
Wheels:", r_Model, r_LisenceNumber) + m_Wheels[0].ToString() + m_Engine.ToString();
        }
    }
}



