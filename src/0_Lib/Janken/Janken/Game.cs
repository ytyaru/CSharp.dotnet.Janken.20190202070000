using System;
using System.Linq;
using System.Collections.Generic;
namespace Janken
{
    public class Game
    {
        public static Game Instance { get; } = new Game();
        public IGameWriter writer { get; set; }
        private Game() {
            this.writer = new ConsoleGameWriter();
        }

        public void Play() {
            this.writer.Start(Message.Instance.Start());
            Hands.Unicode player = HandMaker.Instance.Random();
            Hands.Unicode npc = HandMaker.Instance.Random();
            this.writer.Hand(Message.Instance.Hand(player, npc));
            Rule.Result result = Rule.Instance.Judge(player, npc);
            this.writer.Result(Message.Instance.Result(result));
        }
   }
}
