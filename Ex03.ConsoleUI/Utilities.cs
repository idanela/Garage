using System;
using System.Collections.Generic;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal struct Utilities
    {
        // Methods:
        public static void AddNewVehicleToGarage(Garage i_Garage, string i_LicenseNumber)
        {
            string ownerName, ownerPhoneNumber;

            Console.WriteLine("To Insert a new car, please fill all the details below:");
            Vehicle vehicle = Utilities.CreateUserVehicle(i_LicenseNumber);
            Utilities.GetOwnerDetails(out ownerName, out ownerPhoneNumber);
            Utilities.GetWheelsManufacturer(vehicle);
            i_Garage.AddToGarage(vehicle, ownerName, ownerPhoneNumber);
        }

        public static Vehicle CreateUserVehicle(string i_LicenseNumber)
        {
            string model;
            ManufactureVehicle.eVehicleType vehicleType;

            getVehicleType(out vehicleType);
            Console.WriteLine("Please enter the model:");
            model = Utilities.GetUserInput();
            Vehicle vehicle = ManufactureVehicle.CreateVehicle(i_LicenseNumber, model, vehicleType);
            UpdateProperties(vehicle);

            return vehicle;
        }

        private static void getVehicleType(out ManufactureVehicle.eVehicleType o_VehicleType)
        {
            string userInput;
            
            Console.WriteLine("Please enter the type of your vehicle:");
            ShowEnumTypes(typeof(ManufactureVehicle.eVehicleType));
            Enum.TryParse(Utilities.GetUserInput(), out o_VehicleType);

            while (!Enum.IsDefined(typeof(ManufactureVehicle.eVehicleType), o_VehicleType))
            {
                Console.WriteLine("The only available vehicle types are:");
                ShowEnumTypes(typeof(ManufactureVehicle.eVehicleType));
                Enum.TryParse(Utilities.GetUserInput(), out o_VehicleType);
            }
        }

        public static void UpdateProperties(Vehicle i_Vehicle)
        {
            int i = 0;
            List<string> msgProperties = i_Vehicle.GetMessagesAndParams();

            try
            {
                foreach (string message in msgProperties)
                {
                    Console.Write(message);
                    while (!i_Vehicle.CheckAndSetValidProperties(i, GetUserInput()))
                    {
                        Console.WriteLine("The input you have inserted is not valid. Please insert again");
                    }

                    i++;      
                }
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine(valueOutOfRangeException.Message);
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
            }
        }

        public static bool ChooseToFilter()
        {
            string userAnswer;

            Console.WriteLine("Would you like to filter the license numbers with a status? For yes enter 'Y' and for no enter 'N'.");
            userAnswer = GetUserInput();
            while (!isValidAnswer(userAnswer))
            {
                Console.WriteLine("Please enter only 'Y' or 'N'");
                userAnswer = GetUserInput();
            }

            return userAnswer == "Y";
        }

        private static bool isValidAnswer(string i_AnswerFromUser)
        {
            return i_AnswerFromUser == "Y" || i_AnswerFromUser == "N";
        }

        public static void GetOriginalGasType(Vehicle i_Vehicle, ref GasEngine.eGasType io_GasType)
        {
            while (!(i_Vehicle.Engine as GasEngine).ContainSameGasType(io_GasType))
            {
                GasEngine.eGasType vehicleGasType = (i_Vehicle.Engine as GasEngine).GasType;
                Console.WriteLine("You entered wrong gas type. The gas type is {0}. Please try again.", vehicleGasType);
                ShowEnumTypes(typeof(GasEngine.eGasType));
                Enum.TryParse(Utilities.GetUserInput(), out io_GasType);
            }
        }

        public static bool CheckIfElectricVehicle(Vehicle i_Vehicle)
        {
            bool hasElectricVehicle = true;

            if (isGasVehicle(i_Vehicle))
            {
                Console.WriteLine("This vehicle doesn't have electric engine.");
                Thread.Sleep(2000);
                hasElectricVehicle = false;
            }

            return hasElectricVehicle;
        }

        public static bool CheckIfGasVehicle(Vehicle i_Vehicle)
        {
            bool hasGasVehicle = true;

            if (!isGasVehicle(i_Vehicle))
            {
                Console.WriteLine("This vehicle doesn't have gas engine.");
                Thread.Sleep(2000);
                hasGasVehicle = false;
            }

            return hasGasVehicle;
        }

        private static bool isGasVehicle(Vehicle i_Vehicle)
        {
            return i_Vehicle.Engine is GasEngine;
        }

        private static void getValidLicenseNumber(ref string io_LicenseNumber)
        {
            while (!isAllLetterAndNumbers(io_LicenseNumber))
            {
                Console.WriteLine("License number should contain only letters or numbers. Please try again.");
                io_LicenseNumber = GetUserInput();
            }
        }

        private static bool isAllLetterAndNumbers(string i_StrToCheck)
        {
            bool isAllLettersAndNumbers = true;

            foreach (char character in i_StrToCheck)
            {
                if (!Char.IsLetterOrDigit(character))
                {
                    isAllLettersAndNumbers = false;
                    break;
                }
            }

            return isAllLettersAndNumbers;
        }

        public static void GetOwnerDetails(out string o_OwnerName, out string o_OwnerPhoneNumber)
        {
            Console.WriteLine("Please enter your name:");
            o_OwnerName = Utilities.GetUserInput();
            getValidName(ref o_OwnerName);
            Console.WriteLine("Please enter your phone number:");
            o_OwnerPhoneNumber = Utilities.GetUserInput();
            getValidPhoneNumber(ref o_OwnerPhoneNumber);
        }

        private static void getValidName(ref string io_OwnerName)
        {
            while (!isAllLetters(io_OwnerName))
            {
                Console.WriteLine("Name can not contain non-letters characters. Please try again.");
                io_OwnerName = GetUserInput();
            }
        }

        private static void getValidPhoneNumber(ref string io_PhoneNumber)
        {
            while (!isAllDigits(io_PhoneNumber))
            {
                Console.WriteLine("Phone number can contain only digits.");
                io_PhoneNumber = GetUserInput();
            }
        }

        private static bool isAllDigits(string i_StrToCheck)
        {
            bool isAllDigits = true;

            foreach (char character in i_StrToCheck)
            {
                if (!Char.IsDigit(character))
                {
                    isAllDigits = false;
                    break;
                }
            }

            return isAllDigits;
        }

        public static void GetWheelsManufacturer(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please enter the wheel's manufacturer:");
            string manufacturer = GetUserInput();
            getValidName(ref manufacturer);
            i_Vehicle.UpdatManufactererOfWheels(manufacturer);
        }

        
        private static bool isAllLetters(string i_StrToCheck)
        {
            bool isAllLetters = true;

            foreach (char character in i_StrToCheck)
            {
                if (!Char.IsLetter(character))
                {
                    isAllLetters = false;
                    break;
                }
            }

            return isAllLetters;
        }

        public static void CheckVehicleInGarage(Garage i_Garage, ref string io_LicenseNumber)
        {
            while (!i_Garage.IsInGarage(io_LicenseNumber))
            {
                Console.WriteLine("This license number {0} does not exist in the system. Please try again", io_LicenseNumber);
                io_LicenseNumber = Utilities.GetUserInput();
            }
        }

        public static void GetValidOptionMenu(ref UserInterface.eMenuOption io_MenuOption)
        {
            while (!Enum.IsDefined(typeof(UserInterface.eMenuOption), io_MenuOption))
            {
                Console.WriteLine("Please enter only number options from 1 to 8.");
                Enum.TryParse(GetUserInput(), out io_MenuOption);
            }
        }

        public static void EnterLicenseNumber(string msg, out string o_LicenseNumber)
        {
            Console.WriteLine(msg);
            o_LicenseNumber = Utilities.GetUserInput();
            getValidLicenseNumber(ref o_LicenseNumber);
        }

        public static void ShowEnumTypes(Type i_TypeOfEnum)
        {
            int i = 0;
            string[] vehicleTypes = Enum.GetNames(i_TypeOfEnum);

            foreach (string vehicleType in vehicleTypes)
            {
                Console.WriteLine(string.Format("{0}. {1}", (i + 1).ToString(), vehicleType));
                i++;
            }
        }

        public static string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
