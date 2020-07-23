using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;
        private string m_NameOfManufacturer;

        public Wheel(float i_MaxAirPressure)
        {
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public void InflatingWheelToMax(float i_FillAir)
        {
            if (m_CurrentAirPressure + i_FillAir <= r_MaxAirPressure && i_FillAir >= 0)
            {
                m_CurrentAirPressure += i_FillAir;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaxAirPressure - m_CurrentAirPressure, 0);
            }
        }

        public string NameOfManufacturer
        {
            get
            {
                return m_NameOfManufacturer;
            }

            set
            {
                    m_NameOfManufacturer = value;
            }
        }

        public float CurrPsi
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                PressureValidation(value);
            }
        }

        public void PressureValidation(float i_Value)
        {
            if (i_Value <= MaxAirPressure)
            {
                m_CurrentAirPressure = i_Value;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure);
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public override string ToString()
        {
            StringBuilder wheelInfo = new StringBuilder();
            wheelInfo.AppendLine(string.Format("The wheel manufacturer is :{0}", m_NameOfManufacturer));
            wheelInfo.AppendLine(string.Format("The maximum air pressure of the wheel is: {0}", r_MaxAirPressure));
            wheelInfo.AppendLine(string.Format("The current air pressure of the wheel is {0}", m_CurrentAirPressure));
            return wheelInfo.ToString();
        }
    }
}
