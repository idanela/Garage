﻿using System.Collections.Generic; 

namespace Garage
{
    public abstract class Vehicle
    {
        protected readonly string m_Model;
        protected readonly string m_OwnersName;
        protected readonly string m_VehicleIdNumber;
        protected float m_PrecentageOfEnergyLeft;
        protected List<Wheel> m_Wheels;

        protected Vehicle (string i_Model, string i_OwnersName, string i_VehicleIdNumber, float i_PrecentageOfEnergyLeft, List<Wheel> i_Wheels)
        {
            m_Model = i_Model;
            m_OwnersName = i_OwnersName;
            m_VehicleIdNumber = i_VehicleIdNumber;
            m_PrecentageOfEnergyLeft = i_PrecentageOfEnergyLeft;
            m_Wheels = i_Wheels;
        }

        // Properties

        public string Model
        {
            get
            {
                return m_Model;
            }
        }

        public string OwnersName
        {
            get
            {
                return m_OwnersName;
            }
        }

        public string VehicleIdNumber
        {
            get 
            {
                return m_VehicleIdNumber;
            }
        }

        virtual public float PrecentageOfEnergyLeft
        {
            get
            {
                return m_PrecentageOfEnergyLeft;
            }
        }

        virtual public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }






    } 
}
