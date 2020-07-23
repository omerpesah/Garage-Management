using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        private readonly List<string> r_VehiclesCollection;

        public VehicleCreator()
        {
            r_VehiclesCollection = new List<string>();
            r_VehiclesCollection.Add("Fuel Motrobike");
            r_VehiclesCollection.Add("Electric Motrobike");
            r_VehiclesCollection.Add("Fuel Car");
            r_VehiclesCollection.Add("Electric Car");
            r_VehiclesCollection.Add("Fuel Truck");
        }

        public List<string> GetVehiclesCollection()
        {
            return r_VehiclesCollection;
        }

        public Vehicle GetVehicle(string i_ModelName, string i_LicenseNumber, string i_VehicleType, float i_CurrEnergyPrecent)
        {
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case "Fuel Motrobike":
                    vehicle = new FuelMotrobike(i_LicenseNumber, i_ModelName, i_CurrEnergyPrecent);
                    break;
                case "Electric Motrobike":
                    vehicle = new ElectricMotrobike(i_LicenseNumber, i_ModelName, i_CurrEnergyPrecent);
                    break;
                case "Fuel Car":
                    vehicle = new FuelCar(i_LicenseNumber, i_ModelName, i_CurrEnergyPrecent);
                    break;
                case "Electric Car":
                    vehicle = new ElectricCar(i_LicenseNumber, i_ModelName, i_CurrEnergyPrecent);
                    break;
                case "Fuel Truck":
                    vehicle = new FuelTruck(i_LicenseNumber, i_ModelName, i_CurrEnergyPrecent);
                    break;
                default:
                    throw new FormatException("Vehicle type doesn't exist");
            }

            return vehicle;
        }
    }
}