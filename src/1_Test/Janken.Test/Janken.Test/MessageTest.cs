using NUnit.Framework;
using Moq;
using Janken;
﻿using System; // Enum
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class MessageTest
    {
        [SetUp]
        public void Setup() {}

        [Test]
        public void Start_Match_ReturnValue()
        {
            var actual = Janken.Message.Instance.Start();
            Assert.AreEqual("===== じゃんけん開始 =====", actual);
        }
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, "You✊ ✊NPC")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, "You✊ ✋NPC")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, "You✊ ✌NPC")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, "You✋ ✊NPC")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, "You✋ ✋NPC")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, "You✋ ✌NPC")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, "You✌ ✊NPC")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, "You✌ ✋NPC")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, "You✌ ✌NPC")]
        public void Hand_vsNPC_ReturnMessage(Hands.Unicode player, Hands.Unicode npc, string expected)
        {
            var actual = Janken.Message.Instance.Hand(player, npc);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, "✊✊")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, "✊✋")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, "✊✌")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, "✋✊")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, "✋✋")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, "✋✌")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, "✌✊")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, "✌✋")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, "✌✌")]
        public void Hand_vs2_ReturnMessage(Hands.Unicode p1, Hands.Unicode p2, string expected)
        {
            List<Hands.Unicode> participants = new List<Hands.Unicode>() { p1, p2 };
            var actual = Janken.Message.Instance.Hand(participants);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, Hands.Unicode.Fist, "✊✊✊")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, Hands.Unicode.Hand, "✊✊✋")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, Hands.Unicode.Victory, "✊✊✌")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Hands.Unicode.Fist, "✊✋✊")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Hands.Unicode.Hand, "✊✋✋")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Hands.Unicode.Victory, "✊✋✌")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Hands.Unicode.Fist, "✊✋✊")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, Hands.Unicode.Fist, "✊✌✊")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, Hands.Unicode.Hand, "✊✌✋")]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, Hands.Unicode.Victory, "✊✌✌")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, Hands.Unicode.Fist, "✋✊✊")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, Hands.Unicode.Hand, "✋✊✋")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, Hands.Unicode.Victory, "✋✊✌")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Hands.Unicode.Fist, "✋✋✊")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Hands.Unicode.Hand, "✋✋✋")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Hands.Unicode.Victory, "✋✋✌")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Hands.Unicode.Fist, "✋✋✊")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, Hands.Unicode.Fist, "✋✌✊")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, Hands.Unicode.Hand, "✋✌✋")]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, Hands.Unicode.Victory, "✋✌✌")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, Hands.Unicode.Fist, "✌✊✊")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, Hands.Unicode.Hand, "✌✊✋")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, Hands.Unicode.Victory, "✌✊✌")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Hands.Unicode.Fist, "✌✋✊")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Hands.Unicode.Hand, "✌✋✋")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Hands.Unicode.Victory, "✌✋✌")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Hands.Unicode.Fist, "✌✋✊")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, Hands.Unicode.Fist, "✌✌✊")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, Hands.Unicode.Hand, "✌✌✋")]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, Hands.Unicode.Victory, "✌✌✌")]
        public void Judge_vs3_ReturnMessage(Hands.Unicode p1, Hands.Unicode p2, Hands.Unicode p3, string expected)
        {
            var participants = new List<Hands.Unicode>() { p1, p2, p3 };
            var actual = Janken.Message.Instance.Hand(participants);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Rule.Result.Draw, "Draw")]
        [TestCase(Rule.Result.Win, "Win!")]
        [TestCase(Rule.Result.Lose, "Lose...")]
        public void Result_Match_ReturnMessage(Rule.Result input, string expected)
        {
            var actual = Janken.Message.Instance.Result(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
