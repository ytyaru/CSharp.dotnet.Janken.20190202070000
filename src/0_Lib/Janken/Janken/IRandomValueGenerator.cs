using System;
using System.Linq;
using System.Collections.Generic;

namespace Janken
{
    public interface IRandomNumberGenerator {
        int Next();
        int Next(int max);
        int Next(int min, int max);
    }
}
﻿
