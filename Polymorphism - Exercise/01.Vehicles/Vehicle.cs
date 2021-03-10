using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionalValue)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditionalValue = airConditionalValue;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }
        private double AirConditionalValue { get; set; }

        public void Drive(double distance)
        {
            double neededFuel = distance * (FuelConsumption + AirConditionalValue);

            if (neededFuel > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= neededFuel;
        }

        public virtual void Refueled(double amount)
        {
            this.FuelQuantity += amount;
        }
    }
}
