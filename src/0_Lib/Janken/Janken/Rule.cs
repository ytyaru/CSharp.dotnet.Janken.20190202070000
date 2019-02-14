using System;
using System.Linq;
using System.Collections.Generic;
namespace Janken
{
    public class Rule
    {
        public static Rule Instance { get; } = new Rule();
        private Rule() {}

        /// <summary>ゲームの結果</summary>
        public enum Result { Win, Lose, Draw };

        /// <summary>ゲームの勝敗判定を返す（Player vs NPC）</summary>
        /// <param name="player">プレーヤの手</param>
        /// <param name="npc">NPCの手</param>
        /// <returns>プレーヤの勝敗結果</returns>
        public Rule.Result Judge(Hands.Unicode player, Hands.Unicode npc) {
            if (player == npc) { return Rule.Result.Draw; }
            else if (player == Hands.Instance.Winable(npc)) { return Rule.Result.Win; }
            else { return Rule.Result.Lose; }
        }

        /// <summary>ゲームの勝敗判定を返す</summary>
        /// <param name="participants">参加者の手</param>
        /// <returns>プレーヤの勝敗結果</returns>
        public List<Rule.Result> Judge(List<Hands.Unicode> participants) {
            IEnumerable<Hands.Unicode> distinct = participants.Distinct(); // 出された全種類の手
            System.Console.WriteLine("participants.Count: " + participants.Count);
            System.Console.WriteLine("distinct.Count(): " + distinct.Count());
            // Draw
            //   全員が同じ手を出した
            if (1 == distinct.Count()) { return Enumerable.Repeat(Rule.Result.Draw, participants.Count).ToList(); }
            //   全種類の手が出た
            else if (Enum.GetNames(typeof(Hands.Unicode)).Length == distinct.Count()) { return Enumerable.Repeat(Rule.Result.Draw, participants.Count).ToList(); }
            // Win/Lose（二種類の手が出た）
            else {
                Hands.Unicode winable;
                Hands.Unicode losable;
                if (distinct.ElementAt(0) == Hands.Instance.Winable(distinct.ElementAt(1))) {
                    winable = distinct.ElementAt(0);
                    losable = distinct.ElementAt(1);
                } else {
                    winable = distinct.ElementAt(1);
                    losable = distinct.ElementAt(0);
                }
                List<Rule.Result> results = new List<Rule.Result>();
                foreach (Hands.Unicode p in participants) {
                    if (p == winable) { results.Add(Rule.Result.Win); }
                    else { results.Add(Rule.Result.Lose); }
                }
                return results;
            }
        }
   }
}
