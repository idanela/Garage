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
        private bool m_HasDangerCarry;
        private readonly float r_CargoVolume;

        public Truck(bool i_HasDangerCarry,float i_CargoVolume, string i_Model, string i_VehicleIdNumber, float i_PrecentageOfEnergyLeft, List<Wheel> i_Wheels, Engine i_Engine)
            : base(i_Model, i_VehicleIdNumber, i_PrecentageOfEnergyLeft, i_Wheels, i_Engine)
        {
            m_HasDangerCarry = i_HasDangerCarry; // = false?
            r_CargoVolume = i_CargoVolume;
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
                return r_CargoVolume;
            }
        }

    }
}
