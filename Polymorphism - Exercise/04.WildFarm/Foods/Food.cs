﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get;  set; }
    }
}
