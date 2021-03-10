using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double fuelTank) : base(fuelQuantity, fuelConsumption, fuelTank, 1.6)
        {
        }

        public override void Refueled(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");

            }
            if (amount + FuelQuantity > FuelTank)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            FuelQuantity += amount*0.95;
        }
    }
}
