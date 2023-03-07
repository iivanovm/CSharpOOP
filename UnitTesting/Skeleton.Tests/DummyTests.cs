using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int health;
        private int experience;
        private int healthExpr;
        private int experienceExpr;
        private Dummy dummy;
        private Dummy dummyExpr;

        [SetUp]
        public void SetUp()
        {
            health = 50;
            experience=10;
            healthExpr = 0;
            experienceExpr = 50;

            dummy= new Dummy(health, experience);
        }

        [Test]
        public void CheckDummySetHealth()
        {
            Assert.AreEqual(health, dummy.Health);
        }

        [Test]
        public void CheckDummyTakeAttack()
        {
            dummy.TakeAttack(1);
            Assert.AreEqual(health-1, dummy.Health);
        }

        [Test]
        public void CheckDummyTakeDamageWhenHealthIsZero()
        {
            dummy.TakeAttack(50);
            Assert.AreEqual(health-50,dummy.Health,"Check Healt is ok");
            Assert.Throws<InvalidOperationException>((() =>
            {
                dummy.TakeAttack(50);
            }));
        }

        [Test]
        public void CheckDummyTakeDamageWhenHealthIsNegative()
        {
            dummy.TakeAttack(51);
            Assert.AreEqual(health - 51, dummy.Health, "Check Healt is ok");
            Assert.Throws<InvalidOperationException>((() =>
            {
                dummy.TakeAttack(51);
            }));
        }
        [Test]
        public void CeckDummyExpirience()
        {
            dummyExpr = new Dummy(healthExpr, experienceExpr);
            Assert.AreEqual(healthExpr, dummyExpr.Health);
            Assert.AreEqual(experienceExpr, dummyExpr.GiveExperience());
        }

        [Test]
        public void CheckDummyExpirienceRetrunInfo()
        {
            dummyExpr = new Dummy(20, 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummyExpr.GiveExperience();
            });
        }
        
    }
}