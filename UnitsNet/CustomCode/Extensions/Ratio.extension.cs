using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class Ratio
    {
        public static UnitsNet.Ratio DecimalFraction(this double _inputRatio)
        {
            return new UnitsNet.Ratio(_inputRatio);
        }
    }
}
