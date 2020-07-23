using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManagement
    {
        private readonly Dictionary<string, Client> r_Clients;

        public GarageManagement()
        {
            r_Clients = new Dictionary<string, Client>();
        }

        public List<string> GetAllVehiclsStatus()
        {
            return new List<string>(r_Clients.Keys);
        }

        public List<string> GetListVehiclsStatus(eVehicleStatus i_VehiclesStatus)
        {
            List<string> listOfVehicles = new List<string>();

            foreach (Client client in r_Clients.Values)
            {
                if (client.Status == i_VehiclesStatus)
                {
                    listOfVehicles.Add(client.Vehicle.LicenseNumber);
                }
            }

            return listOfVehicles;
        }

        public void AddNewClient(Vehicle i_Vehicle, string i_Name, string i_PhoneNumber)
        {
            if (r_Clients.ContainsKey(i_Vehicle.LicenseNumber))
            {
                ChangeVehicleStatus(i_Vehicle.LicenseNumber, eVehicleStatus.InRepair);
                throw new ArgumentException("Vehicle already exist! Vehicle status changed to [In repair]");
            }
            else
            {
                r_Clients.Add(i_Vehicle.LicenseNumber, new Client(i_Name, i_PhoneNumber, i_Vehicle));
            }
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VehicleStatusToChange)
        {
            Client clients = GetClient(i_LicenseNumber);
            clients.Status = i_VehicleStatusToChange;
        }

        public Client GetClient(string i_LicenseID)
        {
            Client o_Client;
            bool isExists = r_Clients.TryGetValue(i_LicenseID, out o_Client);
            if (isExists)
            {
                return o_Client;
            }
            else
            {
                throw new ArgumentException("License number does not exist");
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, int i_AmountOfMinToCharge)
        {
            Client client = GetClient(i_LicenseNumber);
            float chargeNumberInHour = i_AmountOfMinToCharge / 60f;
            ElectricalEnergy electricEnergySystem = client.Vehicle.Energy as ElectricalEnergy;

            if (electricEnergySystem != null)
            {
                electricEnergySystem.BatteryCharge(chargeNumberInHour);
            }
            else
            {
                throw new FormatException("This vehicle has no electrical system");
            }
        }

        public void FillFuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountOfFuelToFill)
        {
            Client client = GetClient(i_LicenseNumber);
            FuelEnergy fuelEnergy = client.Vehicle.Energy as FuelEnergy;

            if (fuelEnergy != null)
            {
                fuelEnergy.MakeFueling(i_AmountOfFuelToFill, i_FuelType);
            }
            else
            {
                throw new FormatException("This vehicle has no fuel system");
            }
        }

        public void FillAirToMaxPsi(string i_LicenseNum)
        {
            Client client = GetClient(i_LicenseNum);

            foreach (Wheel wheel in client.Vehicle.Wheels)
            {
                wheel.InflatingWheelToMax(wheel.MaxAirPressure - wheel.CurrPsi);
            }
        }
    }
}
