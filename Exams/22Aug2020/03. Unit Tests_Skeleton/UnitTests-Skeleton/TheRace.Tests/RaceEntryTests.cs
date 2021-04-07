using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver driver;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            driver = new UnitDriver("spasina", new UnitCar("s", 100, 500));
        }

        [Test]
        public void CheckZeroCounter()
        {
            Assert.That(raceEntry.Counter, Is.EqualTo(0));
        }
        [Test]
        public void CheckCounterIncreese()
        {
            raceEntry.AddDriver(driver);
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddThrowsNullDriver()
        {

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }
        [Test]
        public void AddThrowsExistingDriver()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));

        }
        [Test]
        public void SuccessAdd()
        {
           string result= raceEntry.AddDriver(driver);
           string expected= $"Driver {driver.Name} added in race.";
            Assert.That(result, Is.EqualTo(expected));


        }

        [Test]
        public void CalculateAverageHorsePowerThrows()
        {
        
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());

        }

        [Test]
        public void CalculateAverageHorsePowerWork()
        {
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(new UnitDriver("ves",new UnitCar("v",100,200)));
            double average = raceEntry.CalculateAverageHorsePower();
            Assert.That(average, Is.EqualTo(100));

        }
    }
}