using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack = 5;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(5, 6);
    }

    [Test]
    public void When_AxeAttackAndDurabilityProvided_ShouldBeSetCorrectly()
    {

        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.AreEqual(axe.DurabilityPoints, durability);
    }
    [Test]
    public void When_AxeAttacks_ShoudLoseDurabilityPoints()
    {
        axe.Attack(dummy);
        Assert.AreEqual(axe.DurabilityPoints, durability - 1);
    }
    [Test]
    public void When_AxeAttackWithDurabilityPointsZero_ShoudThrowException()
    {
        dummy = new Dummy(3250, 3250);
        InvalidOperationException ex=Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                axe.Attack(dummy);
            }
        });
        Assert.AreEqual(ex.Message, "Axe is broken.");
        
    }
    [Test]
    public void When_AxeAttackIsCallingWithNullDummy_ShoudThrowException()
    {
        
         Assert.Throws<NullReferenceException>(() =>
        {
           
                axe.Attack(null);
            
        });
       

    }

}