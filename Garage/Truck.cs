using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        //Data Members
        bool m_HasDangerCarry;
        float m_CargoVolume;

        public Truck(bool i_HasDangerCarry,float i_CargoVolume, string i_Model, string i_OwnersName, string i_VehicleIdNumber, float i_PrecentageOfEnergyLeft, List<Wheel> i_Wheels, Engine i_Engine)
            : base(i_Model, i_OwnersName, i_VehicleIdNumber, i_PrecentageOfEnergyLeft, i_Wheels, i_Engine)
        {
            m_HasDangerCarry = i_HasDangerCarry;
            m_CargoVolume = i_CargoVolume;
        }

        //Properties
        public bool HasDangerCarry
        {
            get
            {
                return m_HasDangerCarry;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
        }

    }
}
