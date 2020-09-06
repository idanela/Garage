using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        // Data Memebers:
        private readonly Garage r_Garage = new Garage();

        // Properties:
        public Garage Garage
        {
            get
            {
                return r_Garage;
            }
        }

        // Enums:
        private enum eMenuOption
        {
            InsertNewCar = 1,
            ShowLicenseNumberList,
            ChangeCarStatus,
            InflateWheel,
            FillGasEngine,
            ChargeElectricEngine,
            ShowVehicleDetails
        }

        // Methods:
        public static void ManageGarage()
        {

        }

        private static void runGarage()
        {

        }

        private static void menu(eMenuOption i_OptionFromMenu)
        {
            switch (i_OptionFromMenu)
            {
                case eMenuOption.InsertNewCar:
                    // Insert new car and check if they try to insert a vehicle that is already in the garage.
                    break;
                case eMenuOption.ShowLicenseNumberList:
                    break;
                case eMenuOption.ChangeCarStatus:
                    break;
                case eMenuOption.InflateWheel:
                    break;
                case eMenuOption.FillGasEngine:
                    break;
                case eMenuOption.ChargeElectricEngine:
                    break;
                case eMenuOption.ShowVehicleDetails:
                    break;
            }
        }

        private static void showMenuOptions()
        {
            string menuOptions = string.Format(
                @"
1. Insert a new car.
2. Show license number of all vehicles.
3. Change car status (unfixed/fixed/paid).
4. Inflate wheels.
5. Fill gas in vehicle.
6. Charge vehicle.
7. Show vehicle details.");

            Console.WriteLine(menuOptions);
        }

        private void insertNewCar()
        {
            string ownerName, ownerPhoneNumber;
            string licenseNumber;

            Console.WriteLine("For add a new car please type first the license number:");
            licenseNumber = Utilities.GetUserInput();
            if (r_Garage.IsGarageEmpty())
            {
                Console.WriteLine("To Insert a new car, please fill all the details below:");
                Vehicle vehicle = CreateUserVehicle(licenseNumber);
                getOwnerDetails(out ownerName, out ownerPhoneNumber);
                r_Garage.AddToGarage(vehicle, ownerName, ownerPhoneNumber);
            }
            else
            {
                if (r_Garage.isInGarage(licenseNumber))
                {
                    Console.Write("Vehicle with license number {0} is already in the garage.", licenseNumber);
                    r_Garage.changeVehicleStatus(licenseNumber, GarageCard.eStatus.InRepair);
                }
            }
        }

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

        private static void getOwnerDetails(out string o_OwnerName, out string o_OwnerPhoneNumber)
        {
            Console.WriteLine("Please enter your name:");
            o_OwnerName = Utilities.GetUserInput();
            Console.WriteLine("Please enter your name:");
            o_OwnerPhoneNumber = Utilities.GetUserInput();
        }

        private static void showLicenseNumberList()
        {
            Console.WriteLine("To show license number of all vehicles, please enter a vehicle's status to filter:");
            string statusFilter = Utilities.GetUserInput();

            // if i_StatusFilter == "fixed"
            // Garage.ShowFixedVehiclesLicenseNumber()

            // else if i_StatusFilter == "unfixed"
            // Garage.ShowUnfixedVehiclesLicenseNumber()

            // else
            // Garga.ShowAllVehiclesLicenseNumber()
        }

        private static void changeStatus()
        {
            Console.WriteLine("To change a vehicle's status, please enter a license number:");
            string licenseNumber = Utilities.GetUserInput();
            Console.WriteLine("Please enter a vehicle's new status (unfixed/fix/paid):");
            string newStatus = Utilities.GetUserInput();
            // Garage[Car with the same i_LicenseNumber].ChangeStatus(i_NewStatus);
        }

        private static void inflateWheel()
        {
            Console.WriteLine("To inflate the wheels, please enter a license number:");
            string licenseNumber = Utilities.GetUserInput();
            // Inflate wheel in the car with i_LicenseNumber.
        }

        private static void fillGas()
        {
            float amountOfGasToFill;
            GasEngine.eGasType gasType;

            Console.WriteLine("To fill with gas, please enter a license number:");
            string licenseNumber = Utilities.GetUserInput();
            Console.WriteLine("Please enter a amount of gas to fill:");
            float.TryParse(Utilities.GetUserInput(), out amountOfGasToFill);
            Console.WriteLine("Please enter the type of gas:");
            GasEngine.eGasType.TryParse(Utilities.GetUserInput(), out gasType);
            // Garage[Car[i_LicenseNumber]].FillUpEnergy(i_AmoubtOfGasToFill, i_GasType)
        }

        private static void chargeCar(string i_LicenseNumber, float i_AmountOfCharge)
        {
            float amountOfCharge;
            GasEngine.eGasType gasType;

            Console.WriteLine("To fill with gas, please enter a license number:");
            string licenseNumber = Utilities.GetUserInput();
            Console.WriteLine("Please enter a amount of charging (in hours):");
            float.TryParse(Utilities.GetUserInput(), out amountOfCharge);
            // Garage[Car[i_LicenseNumber]].FillUpEnergy(i_AmoubtOfGasToFill, null)
        }

        private static void showVehiclesDetails()
        {
            // Show all details.
        }

        private static void enterLicnseNumber(string msg)
        {
            Console.WriteLine(msg);
            string licenseNumber = Utilities.GetUserInput();
        }
    }
}
