using NUnit.Framework;
using Moq;
using Janken;
﻿using System; // Enum
//using System.Linq;
//using System.Collections.Generic;

namespace Tests
{
    public class HandsTest
    {
        [SetUp]
        public void Setup() {}

        [TestCase(Janken.Hands.Unicode.Fist, 0x270A)]
        [TestCase(Janken.Hands.Unicode.Hand, 0x270B)]
        [TestCase(Janken.Hands.Unicode.Victory, 0x270C)]
        public void Unicode_Match_ReferenceValue(Janken.Hands.Unicode actual, int expected)
        {
            Assert.AreEqual(expected, (int)actual);
        }

        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Hand)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Victory)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Fist)]
        public void Next_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            var actual = Janken.Hands.Instance.Next(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Victory)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Fist)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Hand)]
        public void Previous_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            var actual = Janken.Hands.Instance.Previous(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Hand)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Victory)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Fist)]
        public void Winable_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            var actual = Janken.Hands.Instance.Winable(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Victory)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Fist)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Hand)]
        public void Losable_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            var actual = Janken.Hands.Instance.Losable(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Fist)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Hand)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Victory)]
        public void Drawable_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            var actual = Janken.Hands.Instance.Drawable(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, Janken.Hands.Unicode.Fist)]
        [TestCase(1, Janken.Hands.Unicode.Hand)]
        [TestCase(2, Janken.Hands.Unicode.Victory)]
        public void Random_Match_ReturnNextValue(int input, Janken.Hands.Unicode expected)
        {
            var mock = new Mock<IRandomNumberGenerator>();
            mock.Setup(x => x.Next(Enum.GetNames(typeof(Hands.Unicode)).Length)).Returns(input);
            var actual = Janken.Hands.Instance.Random(mock.Object);
           Assert.AreEqual(expected, actual);
        }
    }
}
