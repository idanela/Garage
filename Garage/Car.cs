using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public sealed class Car : Vehicle
    {
        public enum eColorOfCar
        {
            Gray,
            White,
            Green,
            Red
        }

        public enum eNumOfDoors
        {
            one = 1,
            Two,
            Three,
            Four
        }

        //Data members
        private eNumOfDoors m_NumOfDoors;
        private eColorOfCar m_ColorOfCar;

        public Car(string i_Model, string i_LicenseNumber, Engine i_Engine)
            : base(i_Model, i_LicenseNumber, i_Engine)
        {
            for (int i = 0; i < (int)Wheel.eWheelsPerVehicle.Car; i++)
            {
                m_Wheels.Add(new Wheel((float)Wheel.eMaxAirPressure.Car));
            }
        }

        //Properties
        public eNumOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
        }

        public eColorOfCar ColorOfCar
        {
            get
            {
                return m_ColorOfCar;
            }
        }

        public override void updateProperties(object i_ColorOfCar, object i_NumOfDoors)
        {
            m_ColorOfCar = (eColorOfCar)i_ColorOfCar;
            m_NumOfDoors = (eNumOfDoors)i_NumOfDoors;
        }


    }
}


