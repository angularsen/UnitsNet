// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct CloudCover
    {
        /// <summary>
        /// Returns the oktas as a 32-bit integer.
        /// </summary>
        public int IntegerOktas => Convert.ToInt32(Oktas);
    }
}
