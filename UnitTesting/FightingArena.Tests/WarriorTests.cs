namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;
        private Warrior warrior;
        private Warrior w1;
        private Warrior w2;


        [SetUp]
        public void SetUp()
        {
            name = "Piakchu";
            damage = 90;
            hp = 100;
            warrior = new Warrior(name, damage, hp);
            w1 = new Warrior("Bomb", 35, 100);
            w2 = new Warrior("Xenakan", 100, 100);
        }
        [Test]
        public void WarriorShouldBeCreateCurrectConstructor()
        {
            string expectedName = "Piakchu";
            int expectedDamage = 90;
            int expectedHp = 100;
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("              ")]
        public void WarriorShouldWarriorNameIsInvalid(string Name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior nameTestW = new Warrior(Name, damage, hp);
            }, "Name should not be empty or whitespace!");
        }
        [TestCase("Konan")]
        [TestCase("Modalan")]
        [TestCase("Persey")]
        public void WarriorShouldSetWarriorName(string excpectedResult)
        {
            Warrior nameofwarr = new Warrior(excpectedResult, damage, hp);
            Assert.AreEqual(excpectedResult, nameofwarr.Name);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void WarriorDamageWhenDamageIsZeroOrNegative(int damage)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warriorDamageTest = new Warrior(name, damage, hp);
            }, "Damage value should be positive!");
        }
        [TestCase(35)]
        [TestCase(50)]
        [TestCase(1000)]
        public void WarriorDamageSetterTest(int expectedResult)
        {
            Warrior warriorDsetter = new Warrior(name, expectedResult, hp);
            Assert.AreEqual(expectedResult, warriorDsetter.Damage);

        }
        [TestCase(-1)]
        [TestCase(-1000)]
        public void WarriorHPWhenDamageIsZeroOrNegative(int hp)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warriorDamageTest = new Warrior(name, damage, hp);
            }, "HP should not be negative!");
        }
        [TestCase(35)]
        [TestCase(50)]
        [TestCase(1000)]
        public void WarriorHPSetterTest(int hp)
        {
            Warrior warriorDsetter = new Warrior(name, damage, hp);
            Assert.AreEqual(hp, warriorDsetter.HP);

        }
        [TestCase(5)]
        [TestCase(0)]
        [TestCase(35)]
        public void WarriorCheckAttackWithMinAttackPoint(int hp)
        {
            w1 = new Warrior("Bomb", 60, hp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                w1.Attack(w2);
            }, "Your HP is too low in order to attack other warriors!");
        }
        [TestCase(5)]
        [TestCase(0)]
        [TestCase(30)]
        public void Warrior2CheckAttackWithMinAttackPoint(int hp)
        {
            Warrior wattact = new Warrior("Asss", 60, hp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                w1.Attack(wattact);
            }, $"Enemy HP must be greater than 30 in order to attack him!");
        }
        [TestCase(10)]
        [TestCase(1)]
        public void WarriorCheckAttackWithLowerHP(int hp)
        {
            Warrior wattact = new Warrior("Asss", 60, hp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                w2.Attack(wattact);
            }, $"You are trying to attack too strong enemy");
        }
        [Test]
        public void WarriorCheckAttackWhenHPisGreatDamage()
        {
            Warrior war1 = new Warrior("Gosho", 40, 80);
            Warrior war2 = new Warrior("Pesho", 50, 80);
            war1.Attack(war2);
            int expectedResult = 30;
            Assert.AreEqual(expectedResult, war1.HP);
            int war2expectResult = 40;
            Assert.AreEqual(war2expectResult, war2.HP);
        }
        [Test]
        public void WarriorCheckAttackWhenHPisGreatDamageOpponent()
        {
            Warrior war1 = new Warrior("Gosho", 240, 80);
            Warrior war2 = new Warrior("Pesho", 50, 80);
            war1.Attack(war2);
            int expectedResult = 30;
            Assert.AreEqual(expectedResult, war1.HP);
            int expectResultH = 0;
            Assert.AreEqual(expectResultH, war2.HP);
        }
    }
}