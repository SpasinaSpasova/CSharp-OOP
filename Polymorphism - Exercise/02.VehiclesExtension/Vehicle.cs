using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuel;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double fuelTank, double airConditionalValue)
        {
            FuelTank = fuelTank;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditionalValue = airConditionalValue;
        }

        public double FuelQuantity 
        {
            get => this.fuel;
             set
            {
                if (value>this.FuelTank)
                {
                    this.FuelTank = 0;
                }
                else
                {
                    this.fuel = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }
        public double FuelTank { get; private set; }
        protected double AirConditionalValue { get; set; }

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
            if (amount<=0)
            {
                throw new ArgumentException("Fuel must be a positive number");

            }
            if (amount+FuelQuantity>FuelTank)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            this.FuelQuantity += amount;
        }
    }
}
