using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class SmartPhone : ICallable, IBrowserable
    {
        public string Call(string number)
        {
            return $"Calling... {number}";
        }
        public string Browse(string url)
        {
            return $"Browsing: {url}!";
        }

    }
}