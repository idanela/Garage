using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_Model;
        protected readonly string r_VehicleIdNumber;
        protected float m_PrecentageOfEnergyLeft;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;

        protected Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine)
        {
            r_Model = i_Model;
            r_VehicleIdNumber = i_LicenseNumber;
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
                return r_VehicleIdNumber;
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

        public abstract void UpdateWheels();

        public void UpdatManufactererOfWheels(string i_NameOfManufacterer)
        {
            Wheel wheel;
            for(int i = 0; i<this.Wheels.Count; i++)
            {
                wheel = m_Wheels[i];
                wheel.Manufacturer = i_NameOfManufacterer;
                m_Wheels[i] = wheel;
            }
        }
    }
}



