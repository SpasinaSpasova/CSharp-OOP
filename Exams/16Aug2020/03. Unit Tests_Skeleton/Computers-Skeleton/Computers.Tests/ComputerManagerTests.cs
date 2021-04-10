using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            computer = new Computer("A2", "Dell", 1250);
        }

        [Test]
        public void CtorCheck()
        {
            Assert.That(computerManager, Is.Not.Null);
        }
        [Test]
        public void CountCheckIsZero()
        {
            Assert.That(computerManager.Count, Is.Zero);
        }
        [Test]
        public void CountCheckWorks()
        {
            computerManager.AddComputer(computer);
            Assert.AreEqual(computerManager.Count, 1);
        }
        [Test]
        public void AddThrowNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
        }
        [Test]
        public void AddThrowExistComp()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }
        [Test]
        public void AddWorks()
        {
            computerManager.AddComputer(computer);
            Assert.That(computerManager.Computers.Count, Is.EqualTo(1));
        }
        [Test]
        public void RemoveThrowNullForModel()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, "dell"));

        }
        [Test]
        public void RemoveThrowNullForManuf()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("c2", null));

        }
        [Test]
        public void RemoveDecreeseCount()
        {
            computerManager.AddComputer(computer);
            computerManager.RemoveComputer("A2", "Dell");
            Assert.AreEqual(computerManager.Count, 0);


        }
        [Test]
        public void RemoveReturnRemoved()
        {
            computerManager.AddComputer(computer);
            var removed=computerManager.RemoveComputer("A2", "Dell");
            Assert.AreEqual(computer, removed);

        }
        [Test]
        public void GetCompThrowNullForModel()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("c2", null));

        }
        [Test]
        public void GetCompThrowNullForManuf()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "Dell"));

        }
        [Test]
        public void GetCompDoesNotExist()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("s","s2",200));
            computerManager.AddComputer(new Computer("d", "d2", 300));
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("v2", "D2"));

        }
        [Test]
        public void GetCompWorks()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("s", "s2", 200));
            computerManager.AddComputer(new Computer("d", "d2", 300));
            Assert.That( computerManager.GetComputer("A2", "Dell"),Is.EqualTo(computer));

        }
        [Test]
        public void GetComputersByManufacturerThrows()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("s", "s2", 200));
            computerManager.AddComputer(new Computer("d", "d2", 300));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));
        }
        [Test]
        public void GetComputersByManufacturerReturnCollection()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("s", "s2", 200));
            computerManager.AddComputer(new Computer("d", "d2", 300));
            string manufacturer = "s";
            var collection=computerManager.Computers.Where(c => c.Manufacturer == manufacturer)
                .ToList();
            Assert.AreEqual(collection, computerManager.GetComputersByManufacturer("s"));
        }
    }
}