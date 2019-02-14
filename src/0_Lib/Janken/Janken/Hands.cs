using System;
using System.Linq;
using System.Collections.Generic;
namespace Janken
{
    public class Hands
    {
        public static Hands Instance { get; } = new Hands();
        private Hands() {}

        public enum Unicode
        {
            Fist = 0x270A,
            Hand,
            Victory,
        };
        /// <summary>Unicode表における一つ次のcodeを返す</summary>
        /// <param name="hand">対象の手</param>
        /// <returns>次の手</returns>
        public Hands.Unicode Next(Hands.Unicode hand)
        {
            // https://stackoverflow.com/questions/642542/how-to-get-next-or-previous-enum-value-in-c-sharp
            // https://stackoverflow.com/questions/11222256/string-does-not-contain-a-definition-for-cast
            System.Collections.Generic.IEnumerable<Hands.Unicode> hands = Enum.GetValues(typeof(Hands.Unicode)).Cast<Hands.Unicode>();
            if (hand == Enum.GetValues(typeof(Hands.Unicode)).Cast<Hands.Unicode>().Last()) { return hands.First(); }
            return hands.Where(e => (int)e > (int)hand).OrderBy(e => e).First();
        }
        /// <summary>Unicode表における一つ前のcodeを返す</summary>
        /// <param name="hand">対象の手</param>
        /// <returns>前の手</returns>
        public Hands.Unicode Previous(Hands.Unicode hand)
        {
            System.Collections.Generic.IEnumerable<Hands.Unicode> hands = Enum.GetValues(typeof(Hands.Unicode)).Cast<Hands.Unicode>();
            if (hand == Enum.GetValues(typeof(Hands.Unicode)).Cast<Hands.Unicode>().First()) { return hands.Last(); }
            return hands.Where(e => (int)e < (int)hand).OrderBy(e => e).Last();
        }
        /// <summary>指定した手に勝てる手を返す</summary>
        /// <param name="hand">対象の手</param>
        /// <returns>勝てる手</returns>
        public Hands.Unicode Winable(Hands.Unicode hand) { return Next(hand); }
        /// <summary>指定した手に負ける手を返す</summary>
        /// <param name="hand">対象の手</param>
        /// <returns>勝てる手</returns>
        public Hands.Unicode Losable(Hands.Unicode hand) { return Previous(hand); }
        /// <summary>指定した手と引き分ける手を返す</summary>
        /// <param name="hand">対象の手</param>
        /// <returns>引き分ける手</returns>
        public Hands.Unicode Drawable(Hands.Unicode hand) { return hand; }
         /// <summary>ランダムな手を返す</summary>
        /// <returns>ランダムな手</returns>
        public Hands.Unicode Random(IRandomNumberGenerator randomNumberGenerator) {
            var hand = (int)Hands.Unicode.Fist + randomNumberGenerator.Next(Enum.GetNames(typeof(Hands.Unicode)).Length);
            return (Hands.Unicode)Enum.ToObject(typeof(Hands.Unicode), hand);
        }
   }
}
