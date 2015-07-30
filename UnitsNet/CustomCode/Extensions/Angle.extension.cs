using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class Angle
    {
        public static UnitsNet.Angle Degrees(this double _inputAngle)
        {
            return new UnitsNet.Angle(_inputAngle);
        }

        public static UnitsNet.Angle Radians(this double _inputAngle)
        {
            return new UnitsNet.Angle((_inputAngle * Math.PI) / 180);
        }

        public static UnitsNet.Angle Turns(this double _inputAngle)
        {
            return new UnitsNet.Angle(_inputAngle * 0.00277777778);
        }

        public static UnitsNet.Angle Grads(this double _inputAngle)
        {
            return new UnitsNet.Angle(_inputAngle * 1.111111111);
        }
    }
}
