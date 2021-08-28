using System;
using System.Runtime.Serialization;

namespace Ex03
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxVal;
        private readonly float r_MinVal;

        public ValueOutOfRangeException(float i_MaxVal, float i_MinVal)
           : base(string.Format("Error:Value must be between {0} to {1}", i_MinVal, i_MaxVal))
        { 
            r_MaxVal = i_MaxVal;
            r_MinVal = i_MinVal;
        }
    }
}
