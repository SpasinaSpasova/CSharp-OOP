using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int MinValue;
        private readonly int MaxValue;
        private readonly bool Inclusive;
        public MyRangeAttribute(int minValue, int maxValue,bool inclusive=false)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Inclusive = inclusive;
        }


        public override bool IsValid(object obj)
        {
            int number = (int)obj;
            if (Inclusive)
            {
                return number >= MinValue && number <= MaxValue;
            }
            return number > MinValue && number < MaxValue;
        }
    }
}
