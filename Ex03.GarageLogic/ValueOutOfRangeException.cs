using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float m_MaxValue;
        private readonly float m_MinValue;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue) 
            : base(string.Format("Out of the range Exception must be between {0} and {1}, please try again.", i_MinValue, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }
    }
}
