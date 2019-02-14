using NUnit.Framework;
using Moq;
using Janken;
﻿using System; // Enum
//using System.Linq;
//using System.Collections.Generic;

namespace Tests
{
    public class GameTest
    {
        [SetUp]
        public void Setup() {}

        [Test]
        public void Play_Start_void() {
            Game.Instance.Play();
        }
    }
}
