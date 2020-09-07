using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Utilities
    {
        // Methods:
        public static Vehicle CreateUserVehicle(string i_LicenseNumber)
        {
            string model;
            Engine.eEngineType engineType;
            ManufectureVehicle.eVehicleType vehicleType;

            Console.WriteLine("Please enter the type of your vehicle:");
            ManufectureVehicle.eVehicleType.TryParse(Utilities.GetUserInput(), out vehicleType);
            Console.WriteLine("Please enter the model:");
            model = Utilities.GetUserInput();
            Console.WriteLine("Please enter the engine type:");
            Engine.eEngineType.TryParse(Utilities.GetUserInput(), out engineType);
            Utilities.CheckValidEngineAndVehicleTypes(ref engineType, ref vehicleType);


            Vehicle vehicle = ManufectureVehicle.CreateVehicle(i_LicenseNumber, model, engineType, vehicleType);
            UpdateProperties(vehicle);

            return vehicle;
        }

        public static void UpdateProperties(Vehicle i_Vehicle)
        {
            // i_Vehicle.UpdateProperties();
            if (i_Vehicle is Car)
            {
                Utilities.GetCarProperties(i_Vehicle);
            }
            else if (i_Vehicle is Bike)
            {
                Utilities.GetBikeProperties(i_Vehicle);
            }
            else
            {
                // Is a truck.
                Utilities.GetTruckProperties(i_Vehicle);
            }
        }

        public static void GetOwnerDetails(out string o_OwnerName, out string o_OwnerPhoneNumber)
        {
            Console.WriteLine("Please enter your name:");
            o_OwnerName = Utilities.GetUserInput();
            Console.WriteLine("Please enter your phone number:");
            o_OwnerPhoneNumber = Utilities.GetUserInput();
        }

        public static string GetWheelsManufacturer(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please enter the wheel's manufacturer:");
            // Update Wheels return GetUserInput();
            return null; // Delete me!
        }

        public static void CheckValidEngineAndVehicleTypes(
            ref Engine.eEngineType io_EngineType,
            ref ManufectureVehicle.eVehicleType io_VehicleType)
        {
            while (!isValidEngineType(io_EngineType))
            {
                Console.WriteLine("The only available engine types are: {0}, {1}", 
                    Engine.eEngineType.Electric,
                    Engine.eEngineType.Gas);
            }

            while (!isValidVehicleType(io_VehicleType))
            {
                Console.WriteLine("The only available vehicle types are: {0}, {1}, {2}",
                    ManufectureVehicle.eVehicleType.Car,
                    ManufectureVehicle.eVehicleType.Bike,
                    ManufectureVehicle.eVehicleType.Truck);
            }
        }

        private static bool isValidEngineType(Engine.eEngineType i_EngineType)
        {
            bool isValidEngineType = false;
            string[] engineTypes = Enum.GetNames(typeof(Engine.eEngineType));

            foreach (string engineType in engineTypes)
            {
                if (Enum.GetName(typeof(Engine.eEngineType), i_EngineType) == engineType)
                {
                    isValidEngineType = true;
                    break;
                }
            }

            return isValidEngineType;
        }

        private static bool isValidVehicleType(ManufectureVehicle.eVehicleType i_VehicleType)
        {
            bool isValidVehicleType = false;
            string[] engineTypes = Enum.GetNames(typeof(Engine.eEngineType));

            foreach (string engineType in engineTypes)
            {
                if (Enum.GetName(typeof(ManufectureVehicle.eVehicleType), i_VehicleType) == engineType)
                {
                    isValidVehicleType = true;
                    break;
                }
            }

            return isValidVehicleType;
        }

        public static void GetCarProperties(Vehicle i_Car)
        {
            Console.WriteLine("Please enter the number of doors:");
            ushort numOfDoors = ushort.Parse(GetUserInput());
            Console.WriteLine("Please enter the color of the car:");
            Car.eColorOfCar colorOfCar;
            Enum.TryParse(GetUserInput(), out colorOfCar);
            Utilities.CheckValidCarProperties(i_Car, ref numOfDoors, ref colorOfCar);
            i_Car.UpdateProperties(numOfDoors, colorOfCar);
        }

        public static void GetBikeProperties(Vehicle i_Bike)
        {
            Console.WriteLine("Please enter the license type:");
            Bike.eLicenceType licenseType;
            Enum.TryParse(GetUserInput(), out licenseType);
            Console.WriteLine("Please enter the engine volume:");
            int engineVolume = int.Parse(GetUserInput());
            Utilities.CheckValidBikeProperties(i_Bike, ref licenseType);
            i_Bike.UpdateProperties(licenseType, engineVolume);
        }


        public static void GetTruckProperties(Vehicle i_Truck)
        {
            Console.WriteLine("Please enter the load volume of your truck:");
            float loadVolume = float.Parse(GetUserInput());
            Console.WriteLine("Does the truck contains dangerous carry? Enter 'Y' for yes or 'N' for no.");
            string answer = GetUserInput();
            checkValidTruckProperties(ref answer);
            bool containDangerousCarry = answer == "Y";
            i_Truck.UpdateProperties(containDangerousCarry, loadVolume);
        }

        public static void CheckValidCarProperties(Vehicle i_Car, ref ushort io_NumOfDoors, ref Car.eColorOfCar io_ColorOfCar)
        {
            while (!isValidNumOfDoors(io_NumOfDoors))
            {
                Console.WriteLine("The range of number of doors is between {0} to {1}", 2, 5);
                io_NumOfDoors = UInt16.Parse(GetUserInput());
            }

            while (!isValidColorOfCar(io_ColorOfCar))
            {
                Console.WriteLine("The range of optional colors are {0}, {1}, {2}, {3}",
                    Car.eColorOfCar.Gray,
                    Car.eColorOfCar.Green,
                    Car.eColorOfCar.Red,
                    Car.eColorOfCar.White);
                Enum.TryParse(GetUserInput(), out io_ColorOfCar);
            }
        }

        private static bool isValidNumOfDoors(ushort i_NumOfDoors)
        {
            return i_NumOfDoors > 2 || i_NumOfDoors < 5;
        }

        private static bool isValidColorOfCar(Car.eColorOfCar i_ColorOfCar)
        {
            bool isValidColor = false;
            string[] colorsOfCar = Enum.GetNames(typeof(Car.eColorOfCar));

            foreach (string color in colorsOfCar)
            {
                if (Enum.GetName(typeof(Car.eColorOfCar), i_ColorOfCar) == color)
                {
                    isValidColor = true;
                    break;
                }
            }

            return isValidColor;
        }

        public static void CheckValidBikeProperties(Vehicle i_Bike, ref Bike.eLicenceType io_LicenseType)
        {
            while (!isValidLicenseType(io_LicenseType))
            {
                Console.WriteLine("The details you entered are not valid. Please try again.");
                Enum.TryParse(GetUserInput(), out io_LicenseType);
            }
        }

        private static bool isValidLicenseType(Bike.eLicenceType i_LicenseType)
        {
            bool isValidNumOfDoors = false;
            string[] licenseTypes = Enum.GetNames(typeof(Bike.eLicenceType));

            foreach (string licenseType in licenseTypes)
            {
                if (Enum.GetName(typeof(Bike.eLicenceType),i_LicenseType) == licenseType))
                {
                    isValidNumOfDoors = true;
                }
            }

            return isValidNumOfDoors;
        }

        private static void checkValidTruckProperties(ref string io_ContainDangerousCarry)
        {
            while (isValidContainDangerousAnswer(io_ContainDangerousCarry))
            {
                Console.WriteLine("You can enter only 'Y' or 'N' for answer. Please try again.");
                io_ContainDangerousCarry = Console.ReadLine();
            }
        }

        private static bool isValidContainDangerousAnswer(string io_ContainDangerousCarry)
        {
            return io_ContainDangerousCarry == "Y" || io_ContainDangerousCarry == "N";
        }

        public static void CheckValidStatusInGarage(ref GarageCard.eStatus io_StatusInGarage)
        {
            while (!isValidStatusInGarage(io_StatusInGarage))
            {
                Console.WriteLine("You can enter only three types of statuses: {0}, {1}, {2}",
                    GarageCard.eStatus.Fixed,
                    GarageCard.eStatus.InRepair,
                    GarageCard.eStatus.paidFor);
                Enum.TryParse(GetUserInput(), out io_StatusInGarage);
            }
        }

        private static bool isValidStatusInGarage(GarageCard.eStatus i_StatusInGarage)
        {
            bool isValidStatus = false;
            string[] statusList = Enum.GetNames(typeof(GarageCard.eStatus));

            foreach (string status in statusList)
            {
                if (Enum.GetName(typeof(GarageCard.eStatus), i_StatusInGarage) == status)
                {
                    isValidStatus = true;
                    break;
                }
            }

            return isValidStatus;
        }

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
