using System;
using System.Linq;
using System.Collections.Generic;

namespace Janken
{
    public class RandomNumberGenerator : IRandomNumberGenerator {
        /// <summary>乱数を返す</summary>
        /// <returns>>0〜Intteger.MaxValue</returns>
        public int Next() { return this.Next(0, Int32.MaxValue); }
        /// <summary>乱数を返す</summary>
        /// <param name="max">返却値の最大値</param>
        /// <returns>>0〜max</returns>
        public int Next(int max) { return this.Next(0, max); }
        /// <summary>乱数を返す</summary>
        /// <param name="min">返却値の最小値</param>
        /// <param name="max">返却値の最大値</param>
        /// <returns>>min〜max</returns>
        public int Next(int min, int max) { return this.Random.Next(min, max); }
        /// <summary>乱数インスタンスを返す</summary>
        /// <returns>>乱数インスタンス</returns>
        private System.Random Random { get { return new System.Random((int)DateTime.Now.Ticks); } }
    }
}
﻿
