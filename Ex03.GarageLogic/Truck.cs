using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        protected bool m_CarryingHazardousMaterials = false;
        protected float m_LoadVolume;

        internal Truck(string i_ModelName, string i_LicenseNumber)
            : base(i_ModelName, i_LicenseNumber)
        {
            SetupWheels(16, 28);
            m_GarageVehicleUtils = new GarageVehicleUtils();
        }

        public override GarageVehicleUtils GetDataToInput()
        {
            m_GarageVehicleUtils.Details.Add("Carrying hazardous materials  [True/False]: ");
            m_GarageVehicleUtils.Details.Add("Load volume: ");
            m_GarageVehicleUtils.Details.Add("Wheel Manfactuer: ");
            m_GarageVehicleUtils.Details.Add("Wheel current Psi: ");
            return m_GarageVehicleUtils;
        }

        public override void SetVehicleData()
        {
            if (m_GarageVehicleUtils.UserInput[0].Equals("True") || m_GarageVehicleUtils.UserInput[0].Equals("False"))
            {
                m_CarryingHazardousMaterials = bool.Parse(m_GarageVehicleUtils.UserInput[0]);
            }
            else
            {
                throw new FormatException("Unrecognized boolean value");
            }
            if (!float.TryParse(m_GarageVehicleUtils.UserInput[1], out m_LoadVolume))
            {
                throw new FormatException("Load Volume");

            }
        }

        public override string ToString()
        {
            StringBuilder truckInfo = new StringBuilder();
            truckInfo.AppendLine(string.Format("{0}", base.ToString()));
            truckInfo.AppendLine(string.Format("This Truck has fuel system"));
            truckInfo.AppendLine(string.Format("Is the truck Danderous capcity: {0}", m_CarryingHazardousMaterials));
            truckInfo.AppendLine(string.Format("The Truck volume is: {0}", m_LoadVolume));

            return base.ToString();
        }
    }
}