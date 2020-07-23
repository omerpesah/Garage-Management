using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        internal ElectricCar(string i_LicenseNumber, string i_ModelName, float i_CurrentBatteryTimePrecent)
        : base(i_LicenseNumber, i_ModelName)
        {
            float currEnergy = i_CurrentBatteryTimePrecent * 2.1f / 100f;
            m_VehicleEngineEnergy = new ElectricalEnergy(2.1f, currEnergy);
        }
    }
}