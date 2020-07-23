using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Motrobike : Vehicle
    {
        protected eLicenseType m_LicenseType;
        protected int m_EngineCapacityInCc;

        internal Motrobike(string i_ModelName, string i_LicenseNumber)
            : base(i_ModelName, i_LicenseNumber)
        {
            SetupWheels(2, 30);
            m_GarageVehicleUtils = new GarageVehicleUtils();
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacityInCc;
            }

            set
            {
                m_EngineCapacityInCc = value;
            }
        }

        public override GarageVehicleUtils GetDataToInput()
        {
            m_GarageVehicleUtils.Details.Add("Capacity Engine in Cc: ");
            m_GarageVehicleUtils.Details.Add("License Type (A1,A2,A,B): ");
            m_GarageVehicleUtils.Details.Add("Wheel Manfactuer: ");
            m_GarageVehicleUtils.Details.Add("Wheel current Psi: ");
            return m_GarageVehicleUtils;
        }

        public override void SetVehicleData()
        {
            m_EngineCapacityInCc = int.Parse(m_GarageVehicleUtils.UserInput[0]);
            m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), m_GarageVehicleUtils.UserInput[1]);
            if (!Enum.IsDefined(typeof(eLicenseType), m_LicenseType))
            {
                throw new FormatException("Wrong License type, please select type from the list");
            }
        }

        public override string ToString()
        {
            StringBuilder MotrobikeInfo = new StringBuilder();
            MotrobikeInfo.AppendLine(string.Format("{0}", base.ToString()));
            MotrobikeInfo.AppendLine(string.Format("The Motrobike license type is: {0}", m_LicenseType));
            MotrobikeInfo.AppendLine(string.Format("The Motrobike engine capacity is: {0}", m_EngineCapacityInCc));
            return MotrobikeInfo.ToString();
        }
    }
}