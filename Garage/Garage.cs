using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public sealed class Garage
    {
        // Data Members:
        private readonly Dictionary<string, GarageCard> r_Vehicles;

        // Constructors:
        public Garage()
        {
            r_Vehicles = new Dictionary<string, GarageCard>();
        }

        // Properties:
        public Dictionary<string, GarageCard> Vehicles
        {
            get
            {
                return r_Vehicles;
            }
        }
        public bool IsGarageEmpty()
        {
            return r_Vehicles.Count == 0;
        }

        public bool IsInGarage(string i_LicenseNumber)
        {
            return r_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public void AddToGarage(Vehicle i_Vehicle, string i_OwnersName,string i_PhoneNumber)
        {
            r_Vehicles.Add(i_Vehicle.LicenseNumber, new GarageCard(i_OwnersName, i_PhoneNumber, i_Vehicle));          
        }

        public List <string> GetListOfSameStatus(GarageCard.eStatus? i_Staus)
        {
            List<string> filteredLicsenceNumbers = new List<string>();

            if (i_Staus != null)
            {
                foreach (KeyValuePair<string, GarageCard> pair in r_Vehicles)
                {
                    if (pair.Value.Status == i_Staus)
                    {
                        filteredLicsenceNumbers.Add(pair.Key);
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, GarageCard> pair in r_Vehicles)
                {
                    filteredLicsenceNumbers.Add(pair.Key);
                }
            }

            return filteredLicsenceNumbers;
        }

        public List<string> GetListOfAllLicenseNubers()
        {
            List<string> allLicenseNumber = new List<string>();

            foreach (KeyValuePair<string, GarageCard> pair in r_Vehicles)
            {
                allLicenseNumber.Add(pair.Key);
            }

            return allLicenseNumber;
        }

        public void changeVehicleStatus(string i_LicenseNumber, GarageCard.eStatus i_NewStatus)
        {
            GarageCard card;

           if( r_Vehicles.TryGetValue(i_LicenseNumber, out card))
            {
                card.Status = i_NewStatus;
            }
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            GarageCard card;

            if(r_Vehicles.TryGetValue(i_LicenseNumber, out card))
            {
                Wheel wheel;

                for (int i = 0; i<card.VehicleToFix.Wheels.Count; i++)
                {
                    wheel = card.VehicleToFix.Wheels[i];
                    wheel.InflateWheel(card.VehicleToFix.Wheels[i].MaxAirPressure);
                    card.VehicleToFix.Wheels[i] = wheel;
                }              
            }     
        }

        public void FillEnergy(string i_LicenseNumber,float i_AmountToFill)
        {
            GarageCard card;

            if (r_Vehicles.TryGetValue(i_LicenseNumber, out card))
            {
                card.VehicleToFix.Engine.FillUpEnergy(i_AmountToFill);
            }
        }

        //Indexers:
        public GarageCard this[string i_LicenseNumber]
        {
            get
            {
                return r_Vehicles[i_LicenseNumber];
            }

            set
            {
                r_Vehicles[i_LicenseNumber] = value;
            }
        }        
    }
}
