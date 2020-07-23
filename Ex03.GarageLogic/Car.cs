using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_CarColor;
        protected eNumberOfDoors m_NumberOfDoors;

        internal Car(string i_LicenseNumber, string i_ModelName) : base(i_LicenseNumber, i_ModelName)
        {
            SetupWheels(4, 32);
            m_GarageVehicleUtils = new GarageVehicleUtils();
        }

        public override GarageVehicleUtils GetDataToInput()
        {
            m_GarageVehicleUtils.Details.Add("Color of car [Red, White, Black, Silver]: ");
            m_GarageVehicleUtils.Details.Add("Number of doors [Two, Three, Four, Five]: ");
            m_GarageVehicleUtils.Details.Add("Wheel Manfactuer: ");
            m_GarageVehicleUtils.Details.Add("Wheel current Psi: ");

            return m_GarageVehicleUtils;
        }

        public override void SetVehicleData()
        {
            m_CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), m_GarageVehicleUtils.UserInput[0]);
            m_NumberOfDoors = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), m_GarageVehicleUtils.UserInput[1]);
            if (!Enum.IsDefined(typeof(eCarColor), m_CarColor))
            {
                throw new FormatException("Wrong Color of car, please select from the list");
            }

            if (!Enum.IsDefined(typeof(eNumberOfDoors), m_NumberOfDoors))
            {
                throw new FormatException("Wrong Number of door, please select from the list");
            }
        }

        public eCarColor Color
        {
            get
            {
                return m_CarColor;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
        }

        public override string ToString()
        {
            StringBuilder carInfo = new StringBuilder();
            carInfo.AppendLine(string.Format("{0}", base.ToString()));
            carInfo.AppendLine(string.Format("This car has {0} doors and its color is {1}", m_NumberOfDoors, m_CarColor));
            return carInfo.ToString();
        }
    }
} 
