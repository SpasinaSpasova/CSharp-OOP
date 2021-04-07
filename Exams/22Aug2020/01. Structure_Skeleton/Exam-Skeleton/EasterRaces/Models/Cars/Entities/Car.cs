using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private int minValue;
        private int maxValue;
        private string model;
        private int horsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            minValue = minHorsePower;
            maxValue = maxHorsePower;
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < minValue || value > maxValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
