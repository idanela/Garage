using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal struct UserInterface
    {
        // Data Memebers:
        private static readonly Garage r_Garage = new Garage();

        // Properties:
        public Garage Garage
        {
            get
            {
                return r_Garage;
            }
        }

        // Enums:
        internal enum eMenuOption
        {
            InsertNewCar = 1,
            ShowLicenseNumberList,
            ChangeVehicleStatus,
            InflateWheel,
            FillGasEngine,
            ChargeElectricEngine,
            ShowVehicleDetails,
            Exit
        }

        // Methods:
        public static void ManageGarage()
        {
            runGarage();
        }

        private static void runGarage()
        {
            bool wantToExitProgram = false;
            eMenuOption menuOption;

            while (!wantToExitProgram)
            {
                Console.WriteLine("Please choose an option you want to use from the menu below.");
                showMenuOptions();
                Console.Write("Your option to choose: ");
                Enum.TryParse(Utilities.GetUserInput(), out menuOption);
                Utilities.GetValidOptionMenu(ref menuOption);
                if (r_Garage.IsGarageEmpty() && menuOption != eMenuOption.InsertNewCar && menuOption != eMenuOption.Exit)
                {
                    Console.WriteLine("The garage is currently empty. Please insert a vehicle to choose that option.");
                }
                else
                { 
                    menu(menuOption, ref wantToExitProgram);
                }
            }
        }

        private static void menu(eMenuOption i_OptionFromMenu, ref bool i_WantToExitProgram)
        {
            switch (i_OptionFromMenu)
            {
                case eMenuOption.InsertNewCar:
                    insertNewCar();
                    break;
                case eMenuOption.ShowLicenseNumberList:
                    showLicenseNumberList();
                    break;
                case eMenuOption.ChangeVehicleStatus:
                    changeStatus();
                    break;
                case eMenuOption.InflateWheel:
                    inflateWheel();
                    break;
                case eMenuOption.FillGasEngine:
                    fillGas();
                    break;
                case eMenuOption.ChargeElectricEngine:
                    chargeCar();
                    break;
                case eMenuOption.ShowVehicleDetails:
                    showVehiclesDetails();
                    break;
                case eMenuOption.Exit:
                    i_WantToExitProgram = true;
                    break;
            }
        }

        private static void showMenuOptions()
        {
            string menuOptions = string.Format(
@"1. Insert a new vehicle.
2. Show license number of all vehicles.
3. Change car status (unfixed/fixed/paid).
4. Inflate wheels.
5. Fill gas in vehicle.
6. Charge vehicle.
7. Show vehicle details.
8. Exit.");

            Console.WriteLine(menuOptions);
        }

        private static void insertNewCar()
        {
            string licenseNumber;

            Utilities.EnterLicenseNumber("To add a new car please type first the license number:", out licenseNumber);
            if (r_Garage.IsGarageEmpty())
            {
                Utilities.AddNewVehicleToGarage(r_Garage, licenseNumber);
            }
            else
            {
                if (r_Garage.IsInGarage(licenseNumber))
                {
                    Console.Write("Vehicle with license number {0} is already in the garage.", licenseNumber);
                    r_Garage.changeVehicleStatus(licenseNumber, GarageCard.eStatus.InRepair);
                }
                else
                {
                    Utilities.AddNewVehicleToGarage(r_Garage, licenseNumber);
                }
            }
        }

        private static void showLicenseNumberList()
        {
            string userInput;
            List<string> licenseNUmbers;
            GarageCard.eStatus statusInGarage;

            if (Utilities.ChooseToFilter())
            {
                Console.WriteLine("To show license number of all vehicles, please enter a vehicle's status to filter:");
                Utilities.ShowEnumTypes(typeof(GarageCard.eStatus));
                Enum.TryParse(Utilities.GetUserInput(), out statusInGarage);

                while (!Enum.IsDefined(typeof(GarageCard.eStatus), statusInGarage))
                {
                    Console.WriteLine("The main options to choose from are:");
                    Utilities.ShowEnumTypes(typeof(GarageCard.eStatus));
                    Enum.TryParse(Utilities.GetUserInput(), out statusInGarage);
                }

                licenseNUmbers = r_Garage.GetListOfSameStatus(statusInGarage);
            }
            else
            {
                licenseNUmbers = r_Garage.GetListOfSameStatus(null);
            }

            if (licenseNUmbers.Count == 0)
            {
                Console.WriteLine("Currently, there are no vehicles with this status. Please try again.");
            }
            else
            {
                Console.WriteLine("The license numbers of the vehicles in the garage are:");
                foreach (string licenseNUmber in licenseNUmbers)
                {
                    Console.WriteLine(licenseNUmber);
                }
            }
        }

        private static void changeStatus()
        {
            string licenseNumber;
            GarageCard.eStatus newStatusInGarage;

            Utilities.EnterLicenseNumber("To change a vehicle's status, please enter a license number:", out licenseNumber);
            Utilities.CheckVehicleInGarage(r_Garage, ref licenseNumber);
            Console.WriteLine("Please enter a vehicle's new status:");
            Utilities.ShowEnumTypes(typeof(GarageCard.eStatus));
            Enum.TryParse(Utilities.GetUserInput(), out newStatusInGarage);
            while (!Enum.IsDefined(typeof(GarageCard.eStatus), newStatusInGarage))
            {
                Console.WriteLine("You can enter only three types of status:");
                Utilities.ShowEnumTypes(typeof(GarageCard.eStatus));
                Enum.TryParse(Utilities.GetUserInput(), out newStatusInGarage);
            }
            
            r_Garage.changeVehicleStatus(licenseNumber, newStatusInGarage);
        }

        private static void inflateWheel()
        {
            string licenseNumber;

            Utilities.EnterLicenseNumber("To inflate the wheels, please enter a license number:", out licenseNumber);
            Utilities.CheckVehicleInGarage(r_Garage, ref licenseNumber);
            while (!r_Garage.IsInGarage(licenseNumber))
            {
                Console.WriteLine("This license number {0} does not exist in the system. Please try again", licenseNumber);
                licenseNumber = Utilities.GetUserInput();
            }

            try
            {
                r_Garage.InflateWheelsToMax(licenseNumber);
            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine(valueOutOfRangeException.Message);
            }
            
        }

        private static void fillGas()
        {
            string licenseNumber;
            float amountOfGasToFill, currentAmountOfFill, leftToFill;
            GasEngine.eGasType gasType;

            Utilities.EnterLicenseNumber("To fill with gas, please enter a license number:", out licenseNumber);
            Utilities.CheckVehicleInGarage(r_Garage, ref licenseNumber);

            if (Utilities.CheckIfGasVehicle(r_Garage[licenseNumber].VehicleToFix))
            {
                currentAmountOfFill = r_Garage[licenseNumber].VehicleToFix.Engine.CurrentAmountOfEnergy;
                try
                {
                    Console.WriteLine("Please enter a amount of gas to fill:");
                    float.TryParse(Utilities.GetUserInput(), out amountOfGasToFill);
                    Console.WriteLine("Please enter the type of gas:");
                    Utilities.ShowEnumTypes(typeof(GasEngine.eGasType));
                    Enum.TryParse(Utilities.GetUserInput(), out gasType);
                    while (!Enum.IsDefined(typeof(GasEngine.eGasType), gasType))
                    {
                        Console.WriteLine("Please enter only available option.");
                        Utilities.ShowEnumTypes(typeof(GasEngine.eGasType));
                        Enum.TryParse(Utilities.GetUserInput(), out gasType);
                    }
                    Utilities.GetOriginalGasType(r_Garage[licenseNumber].VehicleToFix, ref gasType);
                    r_Garage.FillEnergy(licenseNumber, amountOfGasToFill);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    leftToFill = valueOutOfRangeException.MaxValue - currentAmountOfFill;
                    Console.WriteLine("The amount of gas is above the maximum. The amount of gas that left to fill is {0}", leftToFill);
                    throw valueOutOfRangeException;
                }
            }
        }

        private static void chargeCar()
        {
            string licenseNumber;
            float amountOfCharge, currentAmountOfCharge, leftToCharge;
            
            Utilities.EnterLicenseNumber("To charge the battery, please enter a license number:", out licenseNumber);
            Utilities.CheckVehicleInGarage(r_Garage, ref licenseNumber);

            if (Utilities.CheckIfElectricVehicle(r_Garage[licenseNumber].VehicleToFix))
            {
                currentAmountOfCharge = r_Garage[licenseNumber].VehicleToFix.Engine.CurrentAmountOfEnergy;
                try
                {
                    Console.WriteLine("Please enter a amount of charging (in hours):");
                    float.TryParse(Utilities.GetUserInput(), out amountOfCharge);
                    r_Garage.FillEnergy(licenseNumber, amountOfCharge);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    leftToCharge = valueOutOfRangeException.MaxValue - currentAmountOfCharge;
                    Console.WriteLine("The amount of hours to charge is above the maximum. The amount that left to charge is {0} hours", leftToCharge);
                }
            }
        }

        private static void showVehiclesDetails()
        {
            // Show all details.
            Console.WriteLine("All the vehicle's details in the garage are:");
            foreach (KeyValuePair<string, GarageCard> keyValuePair in r_Garage.Vehicles)
            {
                Console.WriteLine(r_Garage[keyValuePair.Key]);
            }
        }
    }
}
