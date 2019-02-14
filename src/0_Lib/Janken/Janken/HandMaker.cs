using System;
using System.Linq;
using System.Collections.Generic;

namespace Janken
{
    public class HandMaker {
        public static HandMaker Instance { get; } = new HandMaker();
        private HandMaker() {}

        /// <summary>ランダムな手を返す</summary>
        /// <returns>ランダムな手</returns>
        public Hands.Unicode Random() {            
            return Hands.Instance.Random(new RandomNumberGenerator());
        }
    }
}
