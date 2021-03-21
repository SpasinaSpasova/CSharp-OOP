using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (var item in properties)
            {
                MyValidationAttribute[] attributes = item.GetCustomAttributes().Cast<MyValidationAttribute>()
                    .ToArray();
                object value = item.GetValue(obj);

                foreach (var atr in attributes)
                {
                    bool isValid = atr.IsValid(value);
                    if (!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
