using System;
using System.Runtime.Serialization;

namespace Ex03
{
    public class ValueOutOfRangeException : Exception
    {
        float MaxValue;
        float MinValue;

        public ValueOutOfRangeException()
        {
        }

        public ValueOutOfRangeException(string message, float minValue, float maxValue) : base(message)
        {
        }
    }
}