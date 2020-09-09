using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Utilities
    {
        // Methods:
        public static Vehicle CreateUserVehicle(string i_LicenseNumber)
        {
            string model;
            ManufectureVehicle.eVehicleType vehicleType;

            getVehicleType(out vehicleType);
            Console.WriteLine("Please enter the model:");
            model = Utilities.GetUserInput();
            Vehicle vehicle = ManufectureVehicle.CreateVehicle(i_LicenseNumber, model, vehicleType);
            UpdateProperties(vehicle);

            return vehicle;
        }

        private static void getVehicleType(out ManufectureVehicle.eVehicleType o_VehicleType)
        {
            Console.WriteLine("Please enter the type of your vehicle:");
            ShowEnumTypes(typeof(ManufectureVehicle.eVehicleType));

            while (!Enum.TryParse(Utilities.GetUserInput(), out o_VehicleType))
            {
                Console.WriteLine("The only available vehicle types are:");
                ShowEnumTypes(typeof(ManufectureVehicle.eVehicleType));
            }
        }

        //private static void getEngineType(ManufectureVehicle.eVehicleType i_VehicleType, out Engine.eEngineType o_EngineType)
        //{
        //    Console.WriteLine("Please enter the engine type:");
        //    ShowEnumTypes(typeof(Engine.eEngineType));
            
        //    while (!Enum.TryParse(Utilities.GetUserInput(), out o_EngineType))
        //    {
        //        Console.WriteLine("The only available vehicle types are:");
        //        ShowEnumTypes(typeof(Engine.eEngineType));
        //    }
            
        //}

        public static void UpdateProperties(Vehicle i_Vehicle)
        {
            Dictionary<string, object> msgProperties = i_Vehicle.GetMessagesAndParams();
            string messageKey = string.Empty;

            try
            {
                foreach (KeyValuePair<string, object> pair in msgProperties)
                {
                    messageKey = pair.Key;
                    Console.WriteLine(messageKey);
                    i_Vehicle.checkekValidProperty(pair.Value, GetUserInput());
                }
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                i_Vehicle.checkekValidProperty(messageKey, GetUserInput());
            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine(valueOutOfRangeException.Message);
                i_Vehicle.checkekValidProperty(messageKey, GetUserInput());
            }
        }

        public static void ShowEnumTypes(Type i_TypeOfEnum)
        {
            int i = 1;
            string[] vehicleTypes = Enum.GetNames(i_TypeOfEnum);

            foreach (string vehicleType in vehicleTypes)
            {
                Console.WriteLine(string.Format("{0}. {1}", i.ToString() , vehicleType));
                i++;
            }
        }

        public static void GetOwnerDetails(out string o_OwnerName, out string o_OwnerPhoneNumber)
        {
            Console.WriteLine("Please enter your name:");
            o_OwnerName = Utilities.GetUserInput();
            Console.WriteLine("Please enter your phone number:");
            o_OwnerPhoneNumber = Utilities.GetUserInput();
        }

        public static void GetWheelsManufacturer(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please enter the wheel's manufacturer:");
            string manufacturer = GetUserInput();
            i_Vehicle.UpdatManufactererOfWheels(manufacturer);
        }

        //public static void CheckValidStatusInGarage(ref GarageCard.eStatus io_StatusInGarage)
        //{
        //    while (!isValidStatusInGarage(io_StatusInGarage))
        //    {
        //        Console.WriteLine("You can enter only three types of statuses: {0}, {1}, {2}",
        //            GarageCard.eStatus.Fixed,
        //            GarageCard.eStatus.InRepair,
        //            GarageCard.eStatus.paidFor);
        //        Enum.TryParse(GetUserInput(), out io_StatusInGarage);
        //    }
        //}

        //private static bool isValidStatusInGarage(GarageCard.eStatus i_StatusInGarage)
        //{
        //    bool isValidStatus = false;
        //    string[] statusList = Enum.GetNames(typeof(GarageCard.eStatus));

        //    foreach (string status in statusList)
        //    {
        //        if (Enum.GetName(typeof(GarageCard.eStatus), i_StatusInGarage) == status)
        //        {
        //            isValidStatus = true;
        //            break;
        //        }
        //    }

        //    return isValidStatus;
        //}

        public static void EnterLicenseNumber(string msg, out string o_LicenseNumber)
        {
            Console.WriteLine(msg);
            o_LicenseNumber = Utilities.GetUserInput();
        }

        public static string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
