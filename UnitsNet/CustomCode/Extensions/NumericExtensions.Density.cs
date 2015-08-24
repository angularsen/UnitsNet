using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static partial class Density
    {
        public static UnitsNet.Density KilogramsPerCubicMeter(this double _inputDensity)
        {
            return new UnitsNet.Density(_inputDensity);
        }

        //TODO: Automate generation using powershell
    }
}
