using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private int attackPoints;
        private int durabilityPoints;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            attackPoints = 10;
            durabilityPoints = 10;
            dummy = new Dummy(100, 100);
            axe = new Axe(attackPoints, durabilityPoints);
        }
        [Test]
        public void CheckAxeSetAttackPoints()
        {
            Assert.AreEqual(attackPoints, axe.AttackPoints);
        }
        [Test]
        public void CheckAxeSetdurabilityPoints()
        {
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
        }
        [Test]
        public void CheckAxeAttack()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }
            Assert.AreEqual(durabilityPoints - 5, axe.DurabilityPoints);
        }
        [Test]
        public void CheckAxeIsDeadWhenDurabiltyisNegative()
        {
            axe = new Axe(10, -5);
            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }
        [Test]
        public void CheckAxeIsDeadWhenDurabiltyisZero()
        {
            axe = new Axe(10, 0);
            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }
    }
}