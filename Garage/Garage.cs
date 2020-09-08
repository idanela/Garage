using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public sealed class Garage
    {
        // Data Members:
        private readonly Dictionary<string, GarageCard> R_Vehicles;

        // Constructors:
        public Garage()
        {
            R_Vehicles = new Dictionary<string, GarageCard>();
        }

        // Properties:
        public Dictionary<string, GarageCard> Vehicles
        {
            get
            {
                return R_Vehicles;
            }
        }
        public bool IsGarageEmpty()
        {
            return R_Vehicles.Count == 0;
        }

        public bool IsInGarage(string i_LicenseNumber)
        {
            return R_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public void AddToGarage(Vehicle i_Vehicle, string i_OwnersName,string i_PhoneNumber)
        {
            R_Vehicles.Add(i_Vehicle.LicenseNumber, new GarageCard(i_OwnersName, i_PhoneNumber, i_Vehicle));          
        }

        public List <string> GetListOfSameStatus(GarageCard.eStatus? i_Staus)
        {
            List<string> filteredLicsenceNubers = new List<string>();
            if (i_Staus != null)
            {
                foreach (KeyValuePair<string, GarageCard> pair in R_Vehicles)
                {
                    if (pair.Value.Status == i_Staus)
                    {
                        filteredLicsenceNubers.Add(pair.Key);
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, GarageCard> pair in R_Vehicles)
                {
                    filteredLicsenceNubers.Add(pair.Key);
                }
            }

            return filteredLicsenceNubers;
        }

        public List<string> GetListOfAllLicenseNubers()
        {
            List<string> allLicenseNumber = new List<string>();
            foreach (KeyValuePair<string, GarageCard> pair in R_Vehicles)
            {
                allLicenseNumber.Add(pair.Key);
            }

            return allLicenseNumber;
        }

        public void changeVehicleStatus(string i_LicenseNumber, GarageCard.eStatus i_NewStatus)
        {
            GarageCard card;
           if( R_Vehicles.TryGetValue(i_LicenseNumber, out card))
            {
                card.Status = i_NewStatus;
            }
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            GarageCard card ;
            if(R_Vehicles.TryGetValue(i_LicenseNumber, out card))
            {
                Wheel wheel;

                for (int i = 0; i<card.VehicleToFix.Wheels.Count; i++)
                {
                    wheel = card.VehicleToFix.Wheels[i];
                    wheel.CurrentAirPressure = card.VehicleToFix.Wheels[i].MaxAirPressure;
                    card.VehicleToFix.Wheels[i] = wheel;
                }              
            }     
        }

        public void FillEnergy(string i_LicenseNumber,float i_AmountToFill)
        {
            GarageCard card;

            if (R_Vehicles.TryGetValue(i_LicenseNumber, out card))
            {
                card.VehicleToFix.Engine.FillUpEnergy(i_AmountToFill);
            }
        }

        //Indexers:
        public GarageCard this[string i_LicenseNumber]
        {
            get
            {
                return R_Vehicles[i_LicenseNumber];
            }

            set
            {
                R_Vehicles[i_LicenseNumber] = value;
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
