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

        //Data members
        private ushort m_NumOfDoors;
        private eColorOfCar m_ColorOfCar;

        public Car(ushort i_NumOfDoors, eColorOfCar i_ColorOfCar, string i_Model, string i_LicenseNumber,, Engine i_Engine)
            : base(i_Model, i_LicenseNumber, i_Wheels, i_EngineType)
        {
            Engine = makeEngine(Type Electric)
            m_Wheels = new List<Wheel>(4); 
            m_NumOfDoors = i_NumOfDoors;
            m_ColorOfCar = i_ColorOfCar;
        }

        //Properties
        public ushort NumOfDoors
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

    }
}
        

