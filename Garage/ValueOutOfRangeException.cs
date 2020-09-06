using System;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        // Data Memmbers:
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        // Properties:
        public float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }

        // Constructor:
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) :
            base(string.Format("An error occured while trying insert value. Minimum is {0}, and maximum is {1}", i_MinValue , i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }
    }
}
