using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Utilities
    {
        // Methods:
        public static void CheckValidEngineAndVehicleTypes(
            ref Engine.eEngineType io_EngineType,
            ref ManufectureVehicle.eVehicleType io_VehicleType)
        {
            while (!isValidEngineType(io_EngineType))
            {
                Console.WriteLine("The only availavle engine types are: {0}, {1}", 
                    Engine.eEngineType.Electric,
                    Engine.eEngineType.Gas);
            }

            while (!isValidVehicleType(io_VehicleType))
            {
                Console.WriteLine("The only availavle vehicle types are: {0}, {1}, {2}",
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
            ushort numOfDoors = UInt16.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the color of the car:");
            Car.eColorOfCar colorOfCar;
            Enum.TryParse(Console.ReadLine(), out colorOfCar);
            Utilities.CheckValidCarProperties(i_Car, ref numOfDoors, ref colorOfCar);
            // i_Car.UpdateCarProperties
        }

        public static void GetBikeProperties(Vehicle i_Bike)
        {
            Console.WriteLine("Please enter the license type:");
            string licenseType = Console.ReadLine();
            Console.WriteLine("Please enter the engine volume:");
            int EngineVolume = int.Parse(Console.ReadLine());
            Utilities.CheckValidBikeProperties(i_Bike, ref licenseType);
        }


        public static void GetTruckProperties(Vehicle i_Truck)
        {
            Console.WriteLine("Please enter the load volume of your truck:");
            float loadVolume = float.Parse(Console.ReadLine());
            Console.WriteLine("Does the truck contains dangerous carry? Enter 'Y' for yes or 'N' for no.");
            string answer = Console.ReadLine();
            bool containDangerousCarry = answer == "Y";
        }

        public static void CheckValidCarProperties(Vehicle i_Car, ref ushort io_NumOfDoors, ref Car.eColorOfCar io_ColorOfCar)
        {
            while (!isValidNumOfDoors(io_NumOfDoors))
            {
                Console.WriteLine("The range of number of doors is between {0} to {1}", 2, 5);
                io_NumOfDoors = ushort.Parse(Console.ReadLine());
            }

            while (!isValidColorOfCar(io_ColorOfCar))
            {
                Console.WriteLine("The range of optional colors are {0}, {1}, {2}, {3}",
                    Car.eColorOfCar.Gray,
                    Car.eColorOfCar.Green,
                    Car.eColorOfCar.Red,
                    Car.eColorOfCar.White);
                Enum.TryParse(Console.ReadLine(), out io_ColorOfCar);
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

        public static void CheckValidBikeProperties(Vehicle i_Bike, ref string io_LicenseType)
        {
            while (!isValidLicenseType(ref io_LicenseType))
            {
                Console.WriteLine("The details you entered are not valid. Please try again.");
            }
        }

        private static bool isValidLicenseType(ref string io_LicenseType)
        {
            bool isValidNumOfDoors = false;

            string[] licenseTypes = Enum.GetNames(typeof(eLicenseType))


            return isValidNumOfDoors;
        }
    }
}
