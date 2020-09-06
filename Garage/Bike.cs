using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Bike : Vehicle
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

        public Bike(string i_Model, string i_VehicleIdNumber, Engine i_Engine)
           : base(i_Model, i_VehicleIdNumber, i_Engine)
        {
            for (int i = 0; i < (int)Wheel.eWheelsPerVehicle.Bike; i++)
            {
                m_Wheels.Add(new Wheel((float)Wheel.eMaxAirPressure.Bike));
            }
        }

        //Properties
        public eLicenceType LicenceType
        {
            get
            {
                return m_LicenceType;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
        }

        public override void updateProperties(object i_engineVolume, object i_LicenseType)
        {
            m_EngineVolume = (int)i_engineVolume;
            m_LicenceType = (eLicenceType)i_LicenseType;
        }
    }
}
