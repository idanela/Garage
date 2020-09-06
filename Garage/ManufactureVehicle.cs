using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ManufectureVehicle
    {
        // Enums:
        public enum eVehicleType
        {
            ElectricBike,
            Bike,
            ElectricCar,
            Car,
            Truck
        }

        // Constructors:
        public static Vehicle CreateVehicle(
            string i_LicenseNumber, 
            string i_Model,
            Engine.eEngineType i_EngineType, 
            eVehicleType i_VehicleType)
        {
            Vehicle vehicleToCreate = null; // Delete "= null"!!

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricBike:
                    vehicleToCreate = new Bike(
                        i_LicenseNumber, 5, i_Model, "aa", i_LicenseNumber, 0, new List<Wheel>(),
                        createEngine(i_EngineType, ElectricEngine.k_BikeBatteryTime, GasEngine.eGasType.Octan95) as ElectricEngine);
                    break;
                case eVehicleType.Bike:
                    break;
                case eVehicleType.ElectricCar:
                    break;
                case eVehicleType.Car:
                    break;
                case eVehicleType.Truck:
                    break;
            }

            return vehicleToCreate;
        }

        private static Engine createEngine(Engine.eEngineType i_EngineType, float i_MaxCapacity, GasEngine.eGasType i_GasType)
        {
            Engine engine = null;

            if (i_EngineType == Engine.eEngineType.Electric)
            {
                engine = new ElectricEngine(i_MaxCapacity);
            }
            else
            {
                engine = new GasEngine(i_MaxCapacity, i_GasType);
            }
            
            return engine;
        }
    }
}
