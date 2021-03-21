using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private int health = 5;
    private int experience = 10;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(health, experience);
    }
    [Test]
    public void When_HealthIsProvided_ShouldBeSetCorectly()
    {
        Assert.AreEqual(dummy.Health, health);
    }
    [Test]
    public void When_Attacked_ShouldDecreaseHealth()
    {
        dummy.TakeAttack(3);
        Assert.AreEqual(dummy.Health, health-3);
    }
    [Test]
    public void When_HealthIsPositive_ShouldBeAlive()
    {
      
        Assert.AreEqual(dummy.IsDead(), false) ;
    }
    [Test]
    public void When_HealthIsZero_ShouldBeAlive()
    {
        dummy = new Dummy(0, experience);
        Assert.AreEqual(dummy.IsDead(), true);
    }
    [Test]
    public void When_HealthIsNegative_ShouldBeAlive()
    {
        dummy = new Dummy(-5, experience);
        Assert.AreEqual(dummy.IsDead(), true);

    }
    [Test]
    public void When_DummyIsDead_ShouldBeThrowException()
    {
        dummy = new Dummy(-5, experience);
        Assert.That(() =>
        {
            dummy.TakeAttack(3);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
     
    }
    [Test]
    public void When_DummyIsDead_ShouldGiveExperience()
    {
        dummy = new Dummy(-5, experience);
        Assert.That(dummy.GiveExperience(),Is.EqualTo(experience));
       

    }
    [Test]
    public void When_DummyIsAlive_ShouldThrow()
    {

        Assert.That(() =>
        {
            dummy.GiveExperience();
        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));


    }
}
