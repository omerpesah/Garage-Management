using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        internal FuelCar(string i_LicenseNumber, string i_ModelName, float i_CurrentTrunkVolumePrecent)
            : base(i_LicenseNumber, i_ModelName)
        {
            float currEnergy = i_CurrentTrunkVolumePrecent * 60f / 100;
            m_VehicleEngineEnergy = new FuelEnergy(eFuelType.Octan96, 60f, i_CurrentTrunkVolumePrecent);
        }
    }
}