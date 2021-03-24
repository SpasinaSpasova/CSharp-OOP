using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
      

        [SetUp]
        public void Setup()
        {
           car = new Car("Make","Model",10.0,100.0);
            
        }

        [Test]
        public void CheckPropMake_WhenWeSetCar()
        {
            Assert.That(car.Make, Is.EqualTo("Make"));
        }
        [Test]
        public void CheckPropModel_WhenWeSetCar()
        {
            Assert.That(car.Model, Is.EqualTo("Model"));
        }
        [Test]
        public void CheckPropFuelConsumption_WhenWeSetCar()
        {
            Assert.That(car.FuelConsumption, Is.EqualTo(10.00));
        }
        [Test]
        public void CheckPropFuelCapacity_WhenWeSetCar()
        {
            Assert.That(car.FuelCapacity, Is.EqualTo(100.00));
        }
        [Test]
        public void CheckPropFuelAmount_WhenWeSetCar()
        {
            Assert.That(car.FuelAmount, Is.EqualTo(0.0));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CheckPropMake_ThrowsEcxeption_WhenMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, "model", 10.00, 100.00));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CheckPropModel_ThrowsEcxeption_WhenModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("make", model, 10.00, 100.00));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-15)]
        public void CheckPropFuelConsumption_ThrowsEcxeption_WhenFuelConsumptionIsZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("make", "model", fuelConsumption, 100.00));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-15)]
        public void CheckPropFuelCapacity_ThrowsEcxeption_WhenFuelCapacityIsZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("make", "model", 10.00, fuelCapacity));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-15)]
        public void CheckRefuelMethod_ThrowsEcxeption_WhenFuelToFillIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }
        [Test]
        [TestCase(50)]
        public void CheckRefuelMethod_WhenFuelIsCorrect(double fuel)
        {
            car.Refuel(fuel);
            Assert.That(car.FuelAmount, Is.EqualTo(50));
        }

        [Test]
     
        public void CheckRefuelMethod_WhenFuelAmountIsGreater_ShouldBecomeEqualToFuelCapacity()
        {
            car.Refuel(150);
            Assert.That(car.FuelAmount, Is.EqualTo(100));
        }

        [Test]

        public void CheckDriveMethod_WhenFuelNeededIsLessOrEqualToFuelAmount_ShouldDecreaseFuelAmount()
        {
            car.Refuel(120);
            car.Drive(5);
            Assert.That(car.FuelAmount, Is.EqualTo(99.5));
        }
        [Test]

        public void CheckDriveMethod_ThrowsException_WhenFuelNeededIsGreater()
        {
            car.Refuel(120);
            
            Assert.Throws<InvalidOperationException>(() => car.Drive(1200));
        }

    }
}