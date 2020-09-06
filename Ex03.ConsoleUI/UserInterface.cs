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

        public static Vehicle CreateUserVehicle()
        {
            string model;
            string licenseNumber;
            Engine.eEngineType engineType;
            ManufectureVehicle.eVehicleType vehicleType;

            
            Console.WriteLine("Please enter the engine type:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter the model:");
            model = Console.ReadLine();
            Console.WriteLine("Please enter the license number:");
            Engine.eEngineType.TryParse(Console.ReadLine(), out engineType);
            Console.WriteLine("Please enter the type of your vehicle:");
            ManufectureVehicle.eVehicleType.TryParse(Console.ReadLine(), out vehicleType);
            Utilities.CheckValidEngineAndVehicleTypes(ref engineType, ref vehicleType);
            

            Vehicle vehicle = ManufectureVehicle.CreateVehicle(licenseNumber, model, engineType, vehicleType);
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

        private void insertNewCar()
        {
            Console.WriteLine("To Insert a new car, please fill all the details below:");
            Vehicle vehicle = CreateUserVehicle();

            r_Garage.InsertNewVehicle(vehicle.i_LicenseNumber, vehicle);
            // if i_LicenseNumber is in Garage[Car with the same license number]
            // Send msg to the user, that the car is already in the garage.
            // Put the current vehicle to "fix" status.
            // else Put the current vehicle to "fix" status. 
        }

        private static void showLicenseNumberList()
        {
            Console.WriteLine("To show license number of all vehicles, please enter a vehicle's status to filter:");
            string statusFilter = getUserInput();

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
            string licenseNumber = getUserInput();
            Console.WriteLine("Please enter a vehicle's new status (unfixed/fix/paid):");
            string newStatus = getUserInput();
            // Garage[Car with the same i_LicenseNumber].ChangeStatus(i_NewStatus);
        }

        private static void inflateWheel()
        {
            Console.WriteLine("To inflate the wheels, please enter a license number:");
            string licenseNumber = getUserInput();
            // Inflate wheel in the car with i_LicenseNumber.
        }

        private static void fillGas()
        {
            float amountOfGasToFill;
            GasEngine.eGasType gasType;

            Console.WriteLine("To fill with gas, please enter a license number:");
            string licenseNumber = getUserInput();
            Console.WriteLine("Please enter a amount of gas to fill:");
            float.TryParse(getUserInput(), out amountOfGasToFill);
            Console.WriteLine("Please enter the type of gas:");
            GasEngine.eGasType.TryParse(getUserInput(), out gasType);
            // Garage[Car[i_LicenseNumber]].FillUpEnergy(i_AmoubtOfGasToFill, i_GasType)
        }

        private static void chargeCar(string i_LicenseNumber, float i_AmountOfCharge)
        {
            float amountOfCharge;
            GasEngine.eGasType gasType;

            Console.WriteLine("To fill with gas, please enter a license number:");
            string licenseNumber = getUserInput();
            Console.WriteLine("Please enter a amount of charging (in hours):");
            float.TryParse(getUserInput(), out amountOfCharge);
            // Garage[Car[i_LicenseNumber]].FillUpEnergy(i_AmoubtOfGasToFill, null)
        }

        private static void showVehiclesDetails()
        {
            // Show all details.
        }

        private static void enterLicnseNumber(string msg)
        {
            Console.WriteLine(msg);
            string licenseNumber = getUserInput();
        }

        private static string getUserInput()
        {
            return Console.ReadLine();
        }
    }
}
