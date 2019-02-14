using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Janken
{
    public class Message
    {
        public static Message Instance { get; } = new Message();
        private Message() {}

        /// <summary>ゲーム開始メッセージを返す</summary>
        /// <returns>ゲーム開始メッセージ</returns>
        public string Start() { return "===== じゃんけん開始 ====="; } // Start Rock–paper–scissors
        /// <summary>手を返す</summary>
        /// <param name="player">Playerの手</param>
        /// <param name="npc">NPCの手</param>
        /// <returns>手</returns>
        public string Hand(Hands.Unicode player, Hands.Unicode npc) { return "You" + Convert.ToChar((int)player) + " " + Convert.ToChar((int)npc) + "NPC"; }
        /// <summary>手を返す</summary>
        /// <param name="participants">手</param>
        /// <returns>手</returns>
        public string Hand(List<Hands.Unicode> participants) {
            StringBuilder builder = new StringBuilder();
            foreach (Hands.Unicode p in participants) {
                builder.Append(Convert.ToChar((int)p));
            }
            return builder.ToString();
        }
        /// <summary>勝敗メッセージを返す</summary>
        /// <param name="result">勝敗</param>
        /// <returns>勝敗メッセージ</returns>
        public string Result(Rule.Result result) {
            if (result == Rule.Result.Draw) { return "Draw"; }
            else if (result == Rule.Result.Win) { return "Win!"; }
            else if (result == Rule.Result.Lose) { return "Lose..."; }
            else { throw new Exception("Not Exist Rule.Result"); }
        }
    }
}
