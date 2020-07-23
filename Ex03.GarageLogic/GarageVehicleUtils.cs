using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageVehicleUtils
    {
        private List<string> m_VehicleDetails = new List<string>();
        private List<string> m_UserInputDetails = new List<string>();
        private string m_ModelName = string.Empty;
        private string m_LicenseNumber = string.Empty;
        private float m_EnergyPercent;

        public List<string> Details
        {
            get
            {
                return m_VehicleDetails;
            }
        }

        public List<string> UserInput
        {
            get
            {
                return m_UserInputDetails;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
                checkModelValidation();
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
                checkLicenseValidation();
            }
        }

        public float Energy
        {
            get
            {
                return m_EnergyPercent;
            }

            set
            {
                m_EnergyPercent = value;
                checkEnergyPercentVaild();
            }
        }

        private bool checkLicenseValidation()
        {
            bool isVerified = true;

            if (m_LicenseNumber.Equals(string.Empty))
            {
                throw new FormatException("Empty Field License Please try again");
            }

            foreach (char charToCheck in m_LicenseNumber)
            {
                if (!char.IsDigit(charToCheck))
                {
                    isVerified = false;
                }
            }

            return isVerified;
        }

        private bool checkModelValidation()
        {
            if (!m_ModelName.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                throw new FormatException("Empty Field! Please try again");
            }
        }

        private bool checkEnergyPercentVaild()
        {
            if (m_EnergyPercent >= 0 && m_EnergyPercent <= 100)
            {
                return true;
            }
            else
            {
                throw new ValueOutOfRangeException(100, 0);
            }
        }
    }
}