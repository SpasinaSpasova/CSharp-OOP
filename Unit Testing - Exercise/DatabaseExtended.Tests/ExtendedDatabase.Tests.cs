//using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase exDatabase;
       
       
        [SetUp]
        public void Setup()
        {
            this.exDatabase = new ExtendedDatabase();
           
        }

        [Test]
        public void Add_ThrowsException_WhenCpacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                exDatabase.Add(new Person(i,$"name{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => exDatabase.Add(new Person(17, "name17")));
           
        }
        [Test]
        public void Add_ThrowsException_WhenPersonNameAlreadyExist()
        {
            exDatabase.Add(new Person(1, "name0"));
            
            Assert.Throws<InvalidOperationException>(() => exDatabase.Add(new Person(0, "name0")));

        }
        [Test]
        public void Add_ThrowsException_WhenPersonIDAlreadyExist()
        {
                exDatabase.Add(new Person(0, "name"));
            
            Assert.Throws<InvalidOperationException>(() => exDatabase.Add(new Person(0, "name3")));

        }
        [Test]
        public void Add_CheckCount_WhenPersonIsAdded()
        {
            for (int i = 0; i < 3; i++)
            {
                exDatabase.Add(new Person(i, $"name{i}"));
            }

            Assert.That(exDatabase.Count, Is.EqualTo(3));

        }
        [Test]
        public void Remove_ThrowsException_WhenRemovePerson()
        {
            Assert.Throws<InvalidOperationException>(() => exDatabase.Remove());

        }
        [Test]
        public void Remove_DecreaseCount_WhenRemovePerson()
        {

            for (int i = 0; i < 3; i++)
            {
                exDatabase.Add(new Person(i, $"name{i}"));
            }
            exDatabase.Remove();
            Assert.That(exDatabase.Count, Is.EqualTo(2));
            Assert.Throws<InvalidOperationException>(() => exDatabase.FindById(2));

        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowsException_WhenPersonNameIsNullOrEmpty(string name)
        {
           
            Assert.Throws<ArgumentNullException>(() => exDatabase.FindByUsername(name));

        }
        [Test]
       
        public void FindByUsername_ThrowsException_WhenPersonNameDoesNotExist()
        {
           
            Assert.Throws<InvalidOperationException>(() => exDatabase.FindByUsername("Username"));

        }
        [Test]//????
        public void FindByUsername_ReturnPerson_WhenPersonNameExist()
        {
            Person person = new Person(0101, "Pesho");
            exDatabase.Add(person);
            Person dbPerson = exDatabase.FindByUsername(person.UserName);
            Assert.That(person,Is.EqualTo(dbPerson));

        }


        [Test]
        [TestCase(-20)]
       
        public void FindByID_ThrowsException_WhenPersonIDIsNegative(long id)
        {

            Assert.Throws<ArgumentOutOfRangeException>(() => exDatabase.FindById(id));

        }
        [Test]

        public void FindByID_ThrowsException_WhenPersonIDDoesNotExist()
        {
            
            Assert.Throws<InvalidOperationException>(() => exDatabase.FindById(2222));

        }
        [Test]
        public void FindByID_ReturnPerson_WhenPersonIDExist()
        {
            Person person = new Person(0101, "Pesho");
            exDatabase.Add(person);
            Person dbPerson = exDatabase.FindById(person.Id);
            Assert.That(person, Is.EqualTo(dbPerson));

        }
        [Test]
        public void Ctor_CheckCtor_WhenSetExtendedDatabaseCtor()
        {
            Person[] person = new Person[10];
            for (int i = 0; i < 10; i++)
            {
                person[i] = new Person(i, $"n{i}");
            }
            exDatabase = new ExtendedDatabase(person);
            Assert.That(exDatabase.Count, Is.EqualTo(person.Length));
        }
        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsExceeded()
        {
            Person[] person = new Person[17] ;
            for (int i = 0; i < 17; i++)
            {
                person[i] = new Person(i, $"n{i}");
            }
           
            Assert.Throws<ArgumentException>(()=>exDatabase=new ExtendedDatabase(person));
        }

    }
}