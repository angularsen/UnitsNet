using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.CustomCode.Extensions
{
    public static class Speed
    {
        public static UnitsNet.Acceleration MetersPerSecond(this int _inputSpeed)
        {
            return new UnitsNet.Acceleration(_inputSpeed);
        }

        public static UnitsNet.Acceleration KilometersPerSecond(this int _inputSpeed)
        {
            return new UnitsNet.Acceleration(_inputSpeed * 1000);
        }

        public static UnitsNet.Acceleration KilometersPerHour(this int _inputSpeed)
        {
            return new UnitsNet.Acceleration(_inputSpeed * 0.2777778);
        }

        public static UnitsNet.Acceleration MilesPerHour(this int _inputSpeed)
        {
            return new UnitsNet.Acceleration(_inputSpeed * 0.4470);
        }
    }
}
