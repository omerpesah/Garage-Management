using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class VehicleEngineEnergy
    {
        protected float m_MaximumQuantity;
        protected float m_CurrentQuantity;

        protected VehicleEngineEnergy(float i_MaximumTankrVolume, float i_CurrentTankVolume)
        {
            this.m_MaximumQuantity = i_MaximumTankrVolume;
            this.m_CurrentQuantity = i_CurrentTankVolume;
        }

        public float CurrentQuantity
        {
            get
            {
                return m_CurrentQuantity;
            }

            set
            {
                m_CurrentQuantity = value;
            }
        }
    }
}