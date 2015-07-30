using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitsNet;

namespace UnitsNet.Extension
{
    public static class Acceleration
    {
        public static UnitsNet.Acceleration MetersPerSecondSquared(this int _inputAcceleration)
        {
            return new UnitsNet.Acceleration(_inputAcceleration);
        }

        public static UnitsNet.Acceleration KilometersPerSecondSquared(this int _inputAcceleration)
        {
            return new UnitsNet.Acceleration(_inputAcceleration * 1000);
        }

        public static UnitsNet.Acceleration MilesPerHourSquared(this int _inputAcceleration)
        {
            return new UnitsNet.Acceleration(_inputAcceleration * 0.00012417777777778);
        }
    }
}
