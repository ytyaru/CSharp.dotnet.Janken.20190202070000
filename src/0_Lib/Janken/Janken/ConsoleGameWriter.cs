using System;
using System.Linq;
using System.Collections.Generic;

namespace Janken
{
    public class ConsoleGameWriter : IGameWriter
    {
        public void Start(string message) { System.Console.WriteLine(message); }
        public void Hand(string message) { System.Console.WriteLine(message); }
        public void Result(string message) { System.Console.WriteLine(message); }
   }
}
