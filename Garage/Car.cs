using System;
using System.Collections.Generic;

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
            One = 1,
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
            AddWheels();
        }

        //Properties
        public eNumOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                if (!Enum.IsDefined(typeof(eNumOfDoors), value))
                {
                    throw new ValueOutOfRangeException((float)eNumOfDoors.One, (float)eNumOfDoors.Four);
                }

                m_NumOfDoors = value;  
            }
        }

        public eColorOfCar ColorOfCar
        {
            get
            {
                return m_ColorOfCar;
            }
            set
            {
                if (!Enum.IsDefined(typeof(eColorOfCar), value))
                {
                    throw new ArgumentException("value is not one of the options ");
                }

                m_ColorOfCar = value;
            }
        }

        public override void UpdateProperties(object i_ColorOfCar, object i_NumOfDoors)
        {
            m_ColorOfCar = (eColorOfCar)i_ColorOfCar;
            m_NumOfDoors = (eNumOfDoors)i_NumOfDoors;
        }

        public override void AddWheels()
        {
            for (int i = 0; i < (int)Wheel.eWheelsPerVehicle.Car; i++)
            {
                m_Wheels.Add(new Wheel((float)Wheel.eMaxAirPressure.Car));
            }
        }

        public override Dictionary<string, object> GetMessagesAndParams()
        {

            Dictionary<string, object> request = new Dictionary<string, object>();

            request.Add("Insert number of doors: ",  m_NumOfDoors);
            request.Add("Insert color of car: ",  m_ColorOfCar);
            return request;
        }
        public override string ToString()
        {
            return base.ToString() + string.Format(@"
Number of doors: {0}
color of car: {1}
",
           m_NumOfDoors, m_ColorOfCar);
        }
    }
}


