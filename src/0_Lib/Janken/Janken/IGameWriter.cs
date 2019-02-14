using System;
using System.Linq;
using System.Collections.Generic;
namespace Janken
{
    public interface IGameWriter
    {
        void Start(string message);
        void Hand(string message);
        void Result(string message);
   }
}
