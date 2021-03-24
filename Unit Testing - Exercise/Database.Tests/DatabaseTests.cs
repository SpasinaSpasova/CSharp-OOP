using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        
        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database();
           
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);

            }
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }
        [Test]
        public void Add_CheckAddedIncreaseCount_WhenWeUseAddMethod()
        {
            database.Add(17);
            Assert.That(database.Count,Is.EqualTo(1));
        }
        [Test]
        public void Remove_ThrowsExeption_WhenWeUseRemoveMethod()
        {
             
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void Remove_CheckAddedDecreaseCount_WhenWeUseRemoveMethod()
        {
            for (int i = 0; i < 5; i++)
            {
                database.Add(i);
            }
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(4));
        }
        [Test]
        public void Fetch_CheckThatMethodsReturnCopyArray_WhenWeUseFatchMethod()
        {
            int[] Arr = new int[5];
            int[] cpyArr = new int[5];
            for (int i = 0; i < 5; i++)
            {
                database.Add(i);

            }
            Arr=database.Fetch();
            database.Remove();
            cpyArr = database.Fetch();
            CollectionAssert.AreNotEqual(cpyArr, Arr);
        }
        [Test]
        public void Add_CheckThatArrayHasElement_WhenWeAdd()
        {
            int[] Arr = new int[5];
            int[] cpyArr = new int[5];
            for (int i = 0; i < 5; i++)
            {
                database.Add(i);

            }
            Arr = database.Fetch();
            Assert.That(Arr.Contains(2), Is.True);
        }
       [Test]
       public void Ctor_CheckThatCtorIsWorking_WhenWeSetCtor()
        {
            int[] Arr = new int[] { 1,2,3};
            database = new Database.Database(Arr);
            
            Assert.That(Arr.Length, Is.EqualTo(database.Count));
        }
    }
}