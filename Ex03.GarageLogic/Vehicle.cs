using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected VehicleEngineEnergy m_VehicleEngineEnergy = null;
        protected List<Wheel> m_Wheels = null;
        protected GarageVehicleUtils m_GarageVehicleUtils;
        private readonly string r_ModelName = string.Empty;
        private readonly string r_LicenseNumber = string.Empty;

        internal Vehicle(string i_ModelName, string i_LicenseNumber)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_Wheels = new List<Wheel>();
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public VehicleEngineEnergy Energy
        {
            get
            {
                return m_VehicleEngineEnergy;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public abstract void SetVehicleData();

        public abstract GarageVehicleUtils GetDataToInput();

        protected void SetupWheels(int i_NumOfWheels, int i_MaxAirPressure)
        {
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public bool CheckLicense(string i_LicenseToCheck)
        {
            return r_LicenseNumber == i_LicenseToCheck;
        }

        public override bool Equals(object obj)
        {
            bool toCompare = false;
            Vehicle vehicleToCompare = obj as Vehicle;

            if (vehicleToCompare != null)
            {
                toCompare = vehicleToCompare.r_LicenseNumber == this.r_LicenseNumber;
            }

            return toCompare;
        }

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            int currentIndex = 1;
            vehicleInfo.AppendLine(string.Format("Licence Number: {0}", r_LicenseNumber));
            vehicleInfo.AppendLine(string.Format("Model Name: {0}", r_ModelName));
            vehicleInfo.AppendLine(string.Format("Engine energy: {0}", m_VehicleEngineEnergy.ToString()));
            vehicleInfo.AppendLine(string.Format("Number of wheels: {0}", m_Wheels.Count));
            vehicleInfo.AppendLine("wheels Details:");
            foreach (Wheel currentWheel in m_Wheels)
            {
                vehicleInfo.AppendLine(string.Format("wheel {0}: {1}", currentIndex, currentWheel.ToString()));
                currentIndex++;
            }

            return vehicleInfo.ToString();
        }

        public override int GetHashCode()
        {
            return r_LicenseNumber.GetHashCode();
        }
    }
}