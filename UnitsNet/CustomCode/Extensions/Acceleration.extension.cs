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

        public static UnitsNet.Acceleration KilometersPerSecond(this int _inputAcceleration)
        {
            return new UnitsNet.Acceleration(_inputAcceleration * 1000);
        }

        public static UnitsNet.Acceleration KilometersPerHour(this int _inputAcceleration)
        {
            return new UnitsNet.Acceleration(_inputAcceleration * 0.27777777777778);
        }

        public static UnitsNet.Acceleration MilesPerHour(this int _inputAcceleration)
        {
            return new UnitsNet.Acceleration(_inputAcceleration * 0.44704);
        }
    }
}
