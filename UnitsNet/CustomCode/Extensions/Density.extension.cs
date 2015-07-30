using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class Density
    {
        public static UnitsNet.Density KilogramsPerCubicMeter(this double _inputDensity)
        {
            return new UnitsNet.Density(_inputDensity);
        }

        public static UnitsNet.Density GramsPerCubicMeter(this double _inputDensity)
        {
            return new UnitsNet.Density(_inputDensity * 1000);
        }
    }
}
