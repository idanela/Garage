using System;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        // Data Memmbers:
        private readonly float r_MaxValue;

        // Properties:
        public float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }
        
        // Constructor:
        public ValueOutOfRangeException(float i_MaxValue) :
            base(string.Format("An error occured while trying insert value {0}. The value is out of range", i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
        }
    }
}
