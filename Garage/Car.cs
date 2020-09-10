using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public sealed class Car : Vehicle
    {
        public enum eColorOfCar
        {
            Gray = 1,
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
                    throw new ArgumentException("Not one of the colors in set");
                }

                m_ColorOfCar = value;
            }
        }

        public override void AddWheels()
        {
            for (int i = 0; i < (int)Wheel.eWheelsPerVehicle.Car; i++)
            {
                m_Wheels.Add(new Wheel((float)Wheel.eMaxAirPressure.Car));
            }
        }

        public override bool CheckAndSetValidProperties(int i_IndexOfInput,  string i_InputsFromUser)
        {
            bool isValid = false;

            if (i_IndexOfInput == 0)
            {
                isValid = setNumOfDoors(i_InputsFromUser);
            }
            else
            {
                isValid = setColorOfCar(i_InputsFromUser);
            }

            return isValid;
        }

        private bool setNumOfDoors(string i_NumOfDoors)
        {
            eNumOfDoors numOfDoors;
            bool isValidinput = false;

            if(!Enum.TryParse(i_NumOfDoors, out numOfDoors))
            {
                throw new FormatException(string.Format("{0} is not parsable to number of doors", numOfDoors));
            }

            isValidinput = Enum.IsDefined(typeof(eNumOfDoors), numOfDoors);     
            if (isValidinput)
            {
                m_NumOfDoors = numOfDoors;
            }

            return isValidinput;
        }

        private bool setColorOfCar(string i_ColorOfCar)
        {
            eColorOfCar colorOfCar;
            bool isValidinput = false;

            if(!Enum.TryParse(i_ColorOfCar, out colorOfCar))
            {
                throw new FormatException(string.Format("{0} is not parsable to color of car.",i_ColorOfCar));
            }

            isValidinput = Enum.IsDefined(typeof(eNumOfDoors), colorOfCar);
            if (isValidinput)
            {
                m_ColorOfCar = colorOfCar;
            }

            return isValidinput;
        }

        public override List<string> GetMessagesAndParams()
        {

            List<string> request = new List<string>();

            request.Add(@"Insert number of doors: 
1.One
2.Two
3.Three
4.Four
"
);
            request.Add(@"Insert color of car:
1.Gray
2.White
3.Green
4.Red
");
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


