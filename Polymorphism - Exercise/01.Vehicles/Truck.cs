using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption, 1.6)
        {
        }
        public override void Refueled(double amount)
        {
            base.Refueled(amount*0.95);
        }
    }
}
