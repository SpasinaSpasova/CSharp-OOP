using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double fuelTank)
            : base(fuelQuantity, fuelConsumption, fuelTank, 0.9)
        {
        }
    }
}
