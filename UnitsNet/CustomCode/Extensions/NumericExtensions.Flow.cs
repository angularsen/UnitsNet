using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static class Flow
    {
        public static UnitsNet.Flow CubicMetersPerSecond(this double _inputFlow)
        {
            return new UnitsNet.Flow(_inputFlow)
        }
    }
}
