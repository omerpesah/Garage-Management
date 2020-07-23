using System.Text;

namespace Ex03.GarageLogic
{
    public class Client
    {
        private eVehicleStatus m_VehicleStatus;
        private string m_CustomerName = string.Empty;
        private string m_CustomerPhoneNumber = string.Empty;
        private Vehicle m_CustomerVehicle;

        public Client(string i_CustomerName, string i_customerPhoneNumber, Vehicle i_cutomerVehicle)
        {
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_CustomerName = i_CustomerName;
            m_CustomerPhoneNumber = i_customerPhoneNumber;
            m_CustomerVehicle = i_cutomerVehicle;
        }

        public eVehicleStatus Status
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public string Name
        {
            get
            {
                return m_CustomerName;
            }

            set
            {
                m_CustomerName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_CustomerPhoneNumber;
            }

            set
            {
                m_CustomerPhoneNumber = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_CustomerVehicle;
            }

            set
            {
                m_CustomerVehicle = value;
            }
        }

        public override int GetHashCode()
        {
            return m_CustomerPhoneNumber.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder customerInfo = new StringBuilder();
            customerInfo.AppendLine(string.Format("{0}", m_CustomerVehicle.ToString()));
            customerInfo.AppendLine(string.Format("Customer name: {0}", m_CustomerName));
            customerInfo.AppendLine(string.Format("Customer phone number: {0}", m_CustomerPhoneNumber));
            customerInfo.AppendLine(string.Format("Customer vehicle status: {0}", m_VehicleStatus));
            return customerInfo.ToString();
        }
    }
}
