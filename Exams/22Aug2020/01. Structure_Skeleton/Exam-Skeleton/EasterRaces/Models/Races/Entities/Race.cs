using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name,int laps)
        {
            this.Laps = laps;
            this.Name = name;
            drivers = new List<IDriver>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver is null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate,driver.Name));

            }
            if (Drivers.Contains(driver))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name));

            }
            drivers.Add(driver);
        }
    }
}
