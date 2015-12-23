using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct RotationalSpeed
    {
        public static Angle operator *(RotationalSpeed rotationalSpeed, TimeSpan timeSpan)
        {
            return Angle.FromRadians(rotationalSpeed.RadiansPerSecond * timeSpan.TotalSeconds);
        }
    }
}
