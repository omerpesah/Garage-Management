using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotrobike : Motrobike
    {
        internal ElectricMotrobike(string i_ModelName, string i_LicenseNumber, float i_CurrentBatteryTimePrecent)
            : base(i_ModelName, i_LicenseNumber)
        {
            float currEnergy = i_CurrentBatteryTimePrecent * 1.2f / 100;
            m_VehicleEngineEnergy = new ElectricalEnergy(1.2f, currEnergy);
        }
    }
}