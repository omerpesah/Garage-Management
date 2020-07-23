using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelMotrobike : Motrobike
    {
        internal FuelMotrobike(string i_ModelName, string i_LicenseNumber, float i_CurrentTrunkVolumePrecent)
            : base(i_LicenseNumber, i_ModelName)
        {
            float currPrecent = i_CurrentTrunkVolumePrecent * 7f / 100;
            m_VehicleEngineEnergy = new FuelEnergy(eFuelType.Octan95, 7f, currPrecent);
        }
    }
}
