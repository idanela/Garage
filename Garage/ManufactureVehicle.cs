
namespace Ex03.GarageLogic
{
    public struct ManufactureVehicle
    {
        // Enums:
        public enum eVehicleType
        {
            ElectricBike = 1,
            Bike,
            ElectricCar,
            Car,
            Truck
        }

        // Constructors:
        public static Vehicle CreateVehicle(string i_LicenseNumber, string i_Model, eVehicleType i_VehicleType)
        {
            Engine engineOfVehicle;
            Vehicle vehicleToCreate = null; 

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricBike:
                    engineOfVehicle = createEngine(Engine.eEngineType.Electric, ElectricEngine.k_BikeBatteryTime);
                    vehicleToCreate = new Bike(i_Model, i_LicenseNumber, engineOfVehicle);
                    break;
                case eVehicleType.Bike:
                    engineOfVehicle = createEngine(Engine.eEngineType.Gas, GasEngine.k_BikeTank, GasEngine.eGasType.Octan95);
                    vehicleToCreate = new Bike(i_Model, i_LicenseNumber, engineOfVehicle);
                    break;
                case eVehicleType.ElectricCar:
                    engineOfVehicle = createEngine(Engine.eEngineType.Electric, ElectricEngine.k_CarBatteryTime);
                    vehicleToCreate = new Car(i_Model, i_LicenseNumber, engineOfVehicle);
                    break;
                case eVehicleType.Car:
                    engineOfVehicle = createEngine(Engine.eEngineType.Gas, GasEngine.k_CarTank, GasEngine.eGasType.Octan96);
                    vehicleToCreate = new Car(i_Model, i_LicenseNumber, engineOfVehicle);
                    break;
                case eVehicleType.Truck:
                    engineOfVehicle = createEngine(Engine.eEngineType.Gas, GasEngine.k_TruckTank, GasEngine.eGasType.Soler);
                    vehicleToCreate = new Truck(i_Model, i_LicenseNumber, engineOfVehicle);
                    break;
            }

            return vehicleToCreate;
        }

        private static Engine createEngine(
            Engine.eEngineType i_EngineType, 
            float i_MaxCapacity, 
            GasEngine.eGasType? i_GasType = null)
        {
            Engine engine = null;

            if (i_EngineType == Engine.eEngineType.Electric)
            {
                engine = new ElectricEngine(i_MaxCapacity);
            }
            else
            {
                engine = new GasEngine(i_MaxCapacity, (GasEngine.eGasType) i_GasType);
            }
            
            return engine;
        }
    }
}
