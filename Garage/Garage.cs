using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public sealed class Garage
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

        public bool IsInGarage(string i_LicenseNumber)
        {
            return m_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public void AddToGarage(Vehicle i_Vehicle, string i_OwnersName,string i_PhoneNumber)
        {
            m_Vehicles.Add(i_Vehicle.i_LicenseNumber, new GarageCard(i_OwnersName, i_PhoneNumber, i_Vehicle));          
        }

        public List <GarageCard> GetListOfSameStatus(GarageCard.eStatus i_Staus)
        {
            List<GarageCard> filteredCards = new List<GarageCard>();
            foreach(KeyValuePair<string, GarageCard> pair in m_Vehicles)
            {
                if(pair.Value.Status == i_Staus)
                {
                    filteredCards.Add(pair.Value);
                }
            }

            return filteredCards;
        }

        public void changeVehicleStatus(string i_LicenseNumber, GarageCard.eStatus i_NewStatus)
        {
            GarageCard card;
           if( m_Vehicles.TryGetValue(i_LicenseNumber, out card))
            {
                card.Status = i_NewStatus;
            }
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            GarageCard card ;
            if(m_Vehicles.TryGetValue(i_LicenseNumber, out card))
            {
                for (int i = 0; i<card.VehicleToFix.Wheels.Count; i++)
                {
                    Wheel wheel = card.VehicleToFix.Wheels[i];
                    wheel.CurrentAirPressure = card.VehicleToFix.Wheels[i].MaxAirPressure;
                    card.VehicleToFix.Wheels[i] = wheel;
                }              
            }     
        }

        public void FillGas(string i_LicenseNumber, GasEngine.eGasType i_GasType, float i_AmountToFill)
        {
            GarageCard card;
            if (m_Vehicles.TryGetValue(i_LicenseNumber, out card))
            {
                card.VehicleToFix.Engine.FillUpEnergy(i_AmountToFill,i_GasType);
            }
        }
        

        public void ChargeElectricCar(string i_LicenseNumber, float i_NumOfMinutesToCharge)
        {
            GarageCard card;
            if (m_Vehicles.TryGetValue(i_LicenseNumber, out card))
            {
                if (card.VehicleToFix.Engine is ElectricEngine)
                {
                    card.VehicleToFix.Engine.FillUpEnergy(i_NumOfMinutesToCharge, GasEngine.eGasType.None);
                }      
            }
        }

        //Indexers:
        public GarageCard this[string i_LicenseNumber]
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
