﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_Model;
        protected readonly string r_VehicleIdNumber;
        protected float m_PrecentageOfEnergyLeft;
        protected List<Wheel> m_Wheels;
        Engine m_Engine;

        protected Vehicle(string i_Model, string i_VehicleIdNumber, Engine i_Engine)
        {
            r_Model = i_Model;
            r_VehicleIdNumber = i_VehicleIdNumber;
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

        public string VehicleIdNumber
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

        virtual public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public abstract void updateProperties(object i_Obj, object i_SecObj);
    }
}



