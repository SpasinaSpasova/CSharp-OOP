using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;
        public ChampionshipController()
        {
            cars = new CarRepository();
            drivers = new DriverRepository();
            races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = cars.GetByName(carModel);
            IDriver driver = drivers.GetByName(driverName);
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);
            IDriver driver = drivers.GetByName(driverName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
                cars.Add(car);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
                cars.Add(car);
            }
            type = type + "Car";
            return String.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            IDriver driver = new Driver(driverName);
            drivers.Add(driver);
            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            IRace race = new Race(name, laps);
            races.Add(race);
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));

            }
            races.Remove(race);
            var winners = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();
            return $"Driver {winners[0].Name} wins {raceName} race." + Environment.NewLine +
                   $"Driver {winners[1].Name} is second in {raceName} race." + Environment.NewLine +
                   $"Driver {winners[2].Name} is third in {raceName} race.";

        }
    }
}
