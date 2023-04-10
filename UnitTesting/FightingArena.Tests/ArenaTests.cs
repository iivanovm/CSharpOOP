namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {

        private const int warriorNum = 10;
        private string name;
        private int damage;
        private int hp;
        private Warrior warrior;
        private Warrior w1;
        private Warrior w2;
        private Warrior[] warriors;
        private Arena arena;
        private int minD = 30;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            HashSet<Warrior> warriorsH = new HashSet<Warrior>();
            name = "Piakchu";
            damage = 90;
            hp = 100;
            warrior = new Warrior(name, damage, hp);
            w1 = new Warrior("Bomb", 35, 100);
            w2 = new Warrior("Xenakan", 60, 100);
            for (int i = 0; i < warriorNum; i++)
            {
                Warrior autowarrior = new Warrior("autoW" + i.ToString(), minD + i, 40 + 1);
                warriorsH.Add(autowarrior);
            }
            warriorsH.Add(w1);
            warriorsH.Add(w2);
            warriors = warriorsH.ToArray();
        }
        [Test]
        public void TestAremaCount()
        {
            int expectedResult = 0;
            Assert.AreEqual(expectedResult, arena.Count);
            arena.Enroll(w1);
            expectedResult = 1;
            Assert.AreEqual(expectedResult, arena.Count);
            arena.Enroll(w2);
            expectedResult = 2;
            Assert.AreEqual(expectedResult, arena.Count);
        }
        [Test]
        public void TestArenaEnrollSameWarrior()
        {
            arena.Enroll(w1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(w1);
            }, "Warrior is already enrolled for the fights!");
        }
        [Test]
        public void TestArenaAttackNameOrWarNameIsNull()
        {
            string attackName = "";
            string defenderName = "w1";

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attackName, defenderName);
            }, $"There is no fighter with name {attackName} enrolled for the fights!");

        }
        [Test]
        public void TestArenaAttackNameOrDefNameIsNull()
        {
            string attackName = "w2";
            string defenderName = "";

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attackName, defenderName);
            }, $"There is no fighter with name {defenderName} enrolled for the fights!");

        }
        [Test]
        public void TestArenaAttackl()
        {
            Arena armour = new Arena();
            for (int i = 0; i < warriors.Length; i++)
            {
                armour.Enroll(warriors[i]);
            }
            armour.Fight("Bomb", "Xenakan");
            int expectedResult = 40;
            Assert.AreEqual(expectedResult, w1.HP);
            int war2expectResult = 65;
            Assert.AreEqual(war2expectResult, w2.HP);
        }
    }
}
