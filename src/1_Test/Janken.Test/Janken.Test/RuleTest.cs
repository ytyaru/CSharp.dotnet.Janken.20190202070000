using NUnit.Framework;
using Moq;
using Janken;
﻿using System; // Enum
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class RuleTest
    {
        [SetUp]
        public void Setup() {}

        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, Rule.Result.Lose)]
        public void Judge_vsNPC_ReturnResult(Hands.Unicode player, Hands.Unicode npc, Rule.Result expected)
        {
            var actual = Rule.Instance.Judge(player, npc);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Rule.Result.Lose, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, Rule.Result.Lose, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, Rule.Result.Lose, Rule.Result.Win)]
        public void Judge_vs2_ReturnResult(Hands.Unicode player, Hands.Unicode npc, Rule.Result playerResult, Rule.Result npcResult)
        {
            var input = new List<Hands.Unicode>() { player, npc };
            var actual = Rule.Instance.Judge(input);
            var expected = new List<Rule.Result>() { playerResult, npcResult };
            Assert.That(expected, Is.EqualTo(actual));
        }
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, Hands.Unicode.Fist, Rule.Result.Draw, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, Hands.Unicode.Hand, Rule.Result.Lose, Rule.Result.Lose, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, Hands.Unicode.Victory, Rule.Result.Win, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Hands.Unicode.Fist, Rule.Result.Lose, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Hands.Unicode.Hand, Rule.Result.Lose, Rule.Result.Win, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Hands.Unicode.Victory, Rule.Result.Draw, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Hands.Unicode.Fist, Rule.Result.Lose, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, Hands.Unicode.Fist, Rule.Result.Win, Rule.Result.Lose, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, Hands.Unicode.Hand, Rule.Result.Draw, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, Hands.Unicode.Victory, Rule.Result.Win, Rule.Result.Lose, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, Hands.Unicode.Fist, Rule.Result.Win, Rule.Result.Lose, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, Hands.Unicode.Hand, Rule.Result.Win, Rule.Result.Lose, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, Hands.Unicode.Victory, Rule.Result.Draw, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Hands.Unicode.Fist, Rule.Result.Win, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Hands.Unicode.Hand, Rule.Result.Draw, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Hands.Unicode.Victory, Rule.Result.Lose, Rule.Result.Lose, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Hands.Unicode.Fist, Rule.Result.Win, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, Hands.Unicode.Fist, Rule.Result.Draw, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, Hands.Unicode.Hand, Rule.Result.Lose, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, Hands.Unicode.Victory, Rule.Result.Lose, Rule.Result.Win, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, Hands.Unicode.Fist, Rule.Result.Lose, Rule.Result.Win, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, Hands.Unicode.Hand, Rule.Result.Draw, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, Hands.Unicode.Victory, Rule.Result.Lose, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Hands.Unicode.Fist, Rule.Result.Draw, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Hands.Unicode.Hand, Rule.Result.Win, Rule.Result.Lose, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Hands.Unicode.Victory, Rule.Result.Win, Rule.Result.Lose, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Hands.Unicode.Fist, Rule.Result.Draw, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, Hands.Unicode.Fist, Rule.Result.Lose, Rule.Result.Lose, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, Hands.Unicode.Hand, Rule.Result.Win, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, Hands.Unicode.Victory, Rule.Result.Draw, Rule.Result.Draw, Rule.Result.Draw)]
        public void Judge_vs3_ReturnResult(Hands.Unicode p1, Hands.Unicode p2, Hands.Unicode p3, Rule.Result r1, Rule.Result r2, Rule.Result r3)
        {
            var input = new List<Hands.Unicode>() { p1, p2, p3 };
            var actual = Rule.Instance.Judge(input);
            var expected = new List<Rule.Result>() { r1, r2, r3 };
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
