
namespace Ex03.GarageLogic
{
    public class GarageCard
    {
        public enum eStatus
        {
            InRepair,
            Fixed,
            paidFor
        }

        //Data members
        private Vehicle m_VehicleToFix;
        private readonly string r_OwnersName;
        private readonly string r_PhoneNumber;
        private eStatus m_StatusInGarage;

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
                m_StatusInGarage = value;
            }
        }


    }
}
