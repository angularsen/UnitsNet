using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static class Level
    {
        public static UnitsNet.Level Decibels(this double _inputLevel)
        {
            return new UnitsNet.Level(_inputLevel);
        }
    }
}
