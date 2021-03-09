using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    interface IBuyer
    {
        int Food { get; }
        int BuyFood();
    }
}
