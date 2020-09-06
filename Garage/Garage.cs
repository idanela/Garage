using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        // Data Members:
        private Dictionary<string, GarageCard> m_Vehicles;

        // Constructors:
        public Garage()
        {
            m_Vehicles = new Dictionary<string, GarageCard>();
        }

        // Properties:
        public Dictionary<string, GarageCard> Vehicles
        {
            get
            {
                return m_Vehicles;
            }
        }
        public bool IsGarageEmpty()
        {
            return m_Vehicles.Count == 0;
        }
        public bool isInGarage(string i_VehicleIdNumber)
        {
            return m_Vehicles.ContainsKey(i_VehicleIdNumber);
        }

        public void AddToGarage(Vehicle i_Vehicle, string i_OwnersName,string i_PhoneNumber)
        {
            m_Vehicles.Add(i_Vehicle.VehicleIdNumber, new GarageCard(i_OwnersName, i_PhoneNumber, i_Vehicle));          
        }

        public void changeVehicleStatus(string i_VehicleIdNumber, GarageCard.eStatus i_NewStatus)
        {
            GarageCard card;
           if( m_Vehicles.TryGetValue(i_VehicleIdNumber, out card))
            {
                card.Status = i_NewStatus;
            }
        }

        public void InflateWheelsToMax(string i_VehicleIdNumber)
        {
            GarageCard card ;
            if(m_Vehicles.TryGetValue(i_VehicleIdNumber, out card))
            {
                for (int i = 0; i<card.VehicleToFix.Wheels.Count; i++)
                {
                    Wheel wheel = card.VehicleToFix.Wheels[i];
                    wheel.CurrentAirPressure = card.VehicleToFix.Wheels[i].MaxAirPressure;
                    card.VehicleToFix.Wheels[i] = wheel;
                }              
            }     
        }

        public void FillGas(string i_VehicleIdNumber, GasEngine.eGasType i_GasType, float i_AmountToFill)
        {
            GarageCard card;
            if (m_Vehicles.TryGetValue(i_VehicleIdNumber, out card))
            {
               
            }
        }
        

        public void ChargeElectricCar(string i_VehicleIdNumber, float numOfMinutesToCharge)
        {
            GarageCard card;
            if (m_Vehicles.TryGetValue(i_VehicleIdNumber, out card))
            {
                if (card.VehicleToFix.Engine is ElectricEngine)
                {
                    card.VehicleToFix.Engine.
                }
                    
            }
        }




        // Indexers:
        //public Vehicle this[string i_LicenseNumber]
        //{
        //    get
        //    {
        //        return m_Vehicles[i_LicenseNumber];
        //    }
        //    set
        //    {
        //        m_Vehicles[i_LicenseNumber] = value;
        //    }
        }

        // Methods:
        //public void InsertNewVehicle(string i_LicenseNumber, Vehicle i_VehicleToAdd)
        //{
        //    if (!isVehicleInGarage(i_LicenseNumber))
        //    {
        //        Vehicles.Add(i_LicenseNumber, i_VehicleToAdd);
        //    }
        //    else
        //    {
        //        ChangeVehicleStatus(i_LicenseNumber);
        //    }
        //}

        //private Vehicle findVehicle(string i_LicenseNumber)
        //{
        //    return Vehicles[i_LicenseNumber];
        //}

        //public void ChangeVehicleStatus(string i_LicenseNumber)
        //{

        //}

        //private bool isVehicleInGarage(string i_LicenseNumber)
        //{
        //    return Vehicles.ContainsKey(i_LicenseNumber);
        //}
    }
}
