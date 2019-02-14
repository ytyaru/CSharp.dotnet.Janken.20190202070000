using System;
using Janken;
namespace Janken.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Janken.Game.Instance.Play();
        }
    }
}
