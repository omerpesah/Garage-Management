using System;

namespace Ex03.GarageLogic
{
    public class ElectricalEnergy : VehicleEngineEnergy
    {
        public ElectricalEnergy(float i_MaximumBatteryTime, float i_CurrentBatteryTime)
            : base(i_MaximumBatteryTime, i_CurrentBatteryTime)
        {
        }

        public void BatteryCharge(float i_TimeToCharge)
        {
            if (i_TimeToCharge + CurrentQuantity <= m_MaximumQuantity && i_TimeToCharge >= 0)
            {
                CurrentQuantity += i_TimeToCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaximumQuantity - CurrentQuantity, 0);
            }
        }

        public override string ToString()
        {
            return string.Format("Energy system type: Electric , Current Battery: {0}h", CurrentQuantity);
        }
    }
}