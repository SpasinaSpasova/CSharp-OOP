
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Name", 40, 50);
        }

        [Test]
        public void CheckNameProp_WhenWeSetName()
        {
            Assert.That(warrior.Name, Is.EqualTo("Name"));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]

        public void CheckNameProp_ThrowsException_WhenWeSetNameIsNullOrEmpty(string name)
        {

            Assert.Throws<ArgumentException>(() =>
            warrior = new Warrior(name, 40, 50));
        }

        [Test]
        public void CheckDamageProp_WhenWeSetDamage()
        {
            Assert.That(warrior.Damage, Is.EqualTo(40));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-20)]

        public void CheckDamageProp_ThrowsException_WhenWeSetDamageWithNegativeAndZeroValue(int damage)
        {

            Assert.Throws<ArgumentException>(() =>
            warrior = new Warrior("Name", damage, 50));
        }
        [Test]
        public void CheckHPProp_WhenWeSetHP()
        {
            Assert.That(warrior.HP, Is.EqualTo(50));
        }
        [Test]

        [TestCase(-20)]

        public void CheckHPProp_ThrowsException_WhenWeSetHPWithNegativeValue(int hp)
        {

            Assert.Throws<ArgumentException>(() =>
            warrior = new Warrior("Name", 40, hp));
        }


        [Test]

        [TestCase(20)]
        [TestCase(30)]

        public void AttackCheckPropHP_ThrowsException_WhenWeSetHPWithLessOrEqualToMinValue(int hp)
        {
            warrior = new Warrior("Name", 20, hp);
            Assert.Throws<InvalidOperationException>(() =>
               warrior.Attack(new Warrior("Name", 40, hp)));
        }
        [Test]

        [TestCase(20)]
        [TestCase(30)]

        public void AttackCheckWarriorHP_ThrowsException_WhenWeSetHPWithLessOrEqualToMinValue(int hp)
        {
            Warrior newWarrior = new Warrior("warrior", 20, hp);
            Assert.Throws<InvalidOperationException>(() =>
               warrior.Attack(newWarrior));
        }


       
        [Test]
        public void AttackCheckWarriorHp_ThrowsException_WhenHPIsLessThanDamage()
        {
            Warrior newWarrior = new Warrior("warrior", 55, 100);
            Assert.Throws<InvalidOperationException>(() =>
               warrior.Attack(newWarrior));
          
        }
        [Test]
        public void AttackChangeHp_WhenAttackMethodIsValid()
        {
            Warrior newWarrior = new Warrior("warrior", 45, 100);
            warrior.Attack(newWarrior);
            Assert.That(warrior.HP,Is.EqualTo(5));
            Assert.That(newWarrior.HP, Is.EqualTo(60));
        }
        [Test]
        public void AttackChangeHpToZero_WhenAttackMethodIsValid()
        {
            warrior = new Warrior("n", 45, 50);
            Warrior newWarrior = new Warrior("warrior", 45,40);
            warrior.Attack(newWarrior);
            Assert.That(newWarrior.HP, Is.EqualTo(0));
        }
       
    }
}
