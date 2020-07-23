using System;

namespace Ex03.GarageLogic
{
    public class FuelEnergy : VehicleEngineEnergy
    {
        private readonly eFuelType r_FuelType;

        internal FuelEnergy(eFuelType i_FuelType, float i_MaximumTankrVolume, float i_CurrentTankVolume)
        : base(i_MaximumTankrVolume, i_CurrentTankVolume)
        {
            r_FuelType = i_FuelType;
        }

        public void MakeFueling(float i_LitersForFueling, eFuelType i_FuelType)
        {
            if (i_FuelType == r_FuelType)
            {
                if (i_LitersForFueling + CurrentQuantity <= m_MaximumQuantity && i_LitersForFueling >= 0 && i_FuelType == r_FuelType)
                {
                    CurrentQuantity += i_LitersForFueling;
                }
                else
                {
                    throw new ValueOutOfRangeException(m_MaximumQuantity - CurrentQuantity, 0);
                }
            }
            else
            {
                throw new ArgumentException("Fuel type does't match");
            }
        }

        public override string ToString()
        {
            return string.Format("Energy system type: fuel, Current fuel: {0}L, Fuel type: {1}", CurrentQuantity, r_FuelType);
        }
    }
}