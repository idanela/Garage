using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        // Data Members:
        private Dictionary<string, Vehicle> m_Vehicles;

        // Constructors:
        public Garage()
        {
            m_Vehicles = new Dictionary<string, Vehicle>();
        }

        // Properties:
        public Dictionary<string, Vehicle> Vehicles
        {
            get
            {
                return m_Vehicles;
            }
        }

        // Indexers:
        public Vehicle this[string i_LicenseNumber]
        {
            get
            {
                return m_Vehicles[i_LicenseNumber];
            }
            set
            {
                m_Vehicles[i_LicenseNumber] = value;
            }
        }

        // Methods:
        public void InsertNewVehicle(string i_LicenseNumber, Vehicle i_VehicleToAdd)
        {
            if (!isVehicleInGarage(i_LicenseNumber))
            {
                Vehicles.Add(i_LicenseNumber, i_VehicleToAdd);
            }
            else
            {
                ChangeVehicleStatus(i_LicenseNumber);
            }
        }

        private Vehicle findVehicle(string i_LicenseNumber)
        {
            return Vehicles[i_LicenseNumber];
        }

        public void ChangeVehicleStatus(string i_LicenseNumber)
        {

        }

        private bool isVehicleInGarage(string i_LicenseNumber)
        {
            return Vehicles.ContainsKey(i_LicenseNumber);
        }
    }
}
