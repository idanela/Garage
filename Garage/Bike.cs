using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Bike : Vehicle
    {
        // Data members
        string m_LicenceType;
        int m_EngineVolume;

        public Bike(string i_LicenceType, ushort i_EngineVolume, string i_Model, string i_OwnersName, string i_VehicleIdNumber, float i_PrecentageOfEnergyLeft, List<Wheel> i_Wheels, Engine i_Engine)
           : base(i_Model, i_OwnersName, i_VehicleIdNumber, i_PrecentageOfEnergyLeft, i_Wheels, i_Engine)
        {
            m_LicenceType = i_LicenceType;
            m_EngineVolume = i_EngineVolume;
        }

        //Properties
        public string LicenceType
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


    }
}
