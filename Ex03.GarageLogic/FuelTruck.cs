using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelTruck : Truck
    {
        internal FuelTruck(string i_ModelName, string i_LicenseNumber, float i_CurrentTrunkVolumePrecent)
           : base(i_ModelName, i_LicenseNumber)
        {
            float currEnergy = i_CurrentTrunkVolumePrecent * 120f / 100;
            m_VehicleEngineEnergy = new FuelEnergy(eFuelType.Soler, 120, currEnergy);
        }
    }
}