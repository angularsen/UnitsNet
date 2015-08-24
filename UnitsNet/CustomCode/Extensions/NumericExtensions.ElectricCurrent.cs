using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static partial class ElectricCurrent
    {
        public static UnitsNet.ElectricCurrent Amperes(this double _inputCurrent)
        {
            return new UnitsNet.ElectricCurrent(_inputCurrent);
        }

        // Alias for Amperes
        public static UnitsNet.ElectricCurrent Amps(this double _inputCurrent)
        {
            return new UnitsNet.ElectricCurrent(_inputCurrent);
        }

        public static UnitsNet.ElectricCurrent MilliAmperes(this double _inputCurrent)
        {
            return new UnitsNet.ElectricCurrent(_inputCurrent * 0.001);
        }
        // Alias for MilliAmperes
        public static UnitsNet.ElectricCurrent MilliAmps(this double _inputCurrent)
        {
            return new UnitsNet.ElectricCurrent(_inputCurrent * 0.001);
        }
    }
}
