using System;
using System.Collections.Generic;
using System.Reflection;
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

        public string i_LicenseNumber
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

        public abstract void UpdateProperties(object i_Obj, object i_SecObj);

        public abstract void AddWheels();
        public abstract List<string> GetMessagesAndParams(out List<object> i_Members);

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

        public void checkekValidProperty(object i_Param, string i_Input)
        {
            object obj = null;
            object [] args = { i_Input, obj};
            Type type = i_Param.GetType();
            MethodInfo tryParse = type.GetMethod("TryParse");
            if( tryParse != null)
            {
                if(!(bool)tryParse.Invoke(null,args))
                {
                    throw new ArgumentException("not a valid formated type");
                }
                else
                {
                    i_Param = obj;
                }
                    
            }
            else
            {
                throw new ArgumentException("not a valid formated type");
            }
        }



        public override string ToString()
        {
            return string.Format(@"
Model:{0}
license number:{1}
Wheels:", r_Model,r_LisenceNumber) + m_Wheels.ToString() + m_Engine.ToString();
        }
    }
}



