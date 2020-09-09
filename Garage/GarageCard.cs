using System;
namespace Ex03.GarageLogic
{
    public sealed class GarageCard
    {
        public enum eStatus
        {
            InRepair = 1,
            Fixed,
            PaidFor
        }

        //Data members
        private Vehicle m_VehicleToFix;
        private readonly string r_OwnersName;
        private readonly string r_PhoneNumber;
        private  eStatus m_StatusInGarage;

        public GarageCard(string i_OwnersName, string i_PhoneNumber, Vehicle i_CarToFix)
        {
            r_OwnersName = i_OwnersName;
            r_PhoneNumber = i_PhoneNumber;
            m_VehicleToFix = i_CarToFix;
            m_StatusInGarage = eStatus.InRepair; 

        }

        //Properties
        public string OwnersName
        {
            get
            {
                return r_OwnersName;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return r_PhoneNumber;
            }
        }

        public Vehicle VehicleToFix
        {
            get
            {
                return m_VehicleToFix;
            }
        }

        public eStatus Status
        {
            get
            {
                return m_StatusInGarage;
            }

            set
            {
                if (!Enum.IsDefined(typeof(eStatus), value))
                {
                    throw new ArgumentException("value is not one of the options ");
                }

                m_StatusInGarage = value;
            }
        }

        public override string ToString()
        {
            return string.Format(@"
Owners name: {0}
Phone number: {1}
Vehicle status:{2}
Vehicle detail:
", OwnersName, PhoneNumber, Status) + VehicleToFix.ToString();
        }

    }
}
