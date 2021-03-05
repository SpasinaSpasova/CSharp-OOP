using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public static class Validation
    {
        public static void ThrowIsInvalidSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }

        }
    }
}
