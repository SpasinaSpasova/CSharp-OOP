using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double busAirConditional = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double fuelTank)
            : base(fuelQuantity, fuelConsumption, fuelTank, busAirConditional)
        {

        }

        public void TurnOn()
        {
            this.AirConditionalValue = busAirConditional ;

        }
        public void TurnOff()
        {
            this.AirConditionalValue = 0;
        }
    }
}
