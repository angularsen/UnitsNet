using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    /// Extension to the generated Length struct.
    /// Makes it easier to work with Feet/Inches combinations, which are customarily used in the US and UK
    /// to express body height. For example, someone is 5 feet 3 inches tall.
    /// </summary>
    public partial struct Power
    {
        public static Energy operator*(Power power, TimeSpan time)
        {
            return Energy.FromJoules(power.Watts* time.TotalSeconds);
        }
        public static Energy operator *(TimeSpan time, Power power)
        {
            return Energy.FromJoules(power.Watts * time.TotalSeconds);
        }
        public static Force operator/(Power power, Speed speed)
        {
            return Force.FromNewtons(power.Watts / speed.MetersPerSecond);
        }
        public static Torque operator /(Power power, RotationalSpeed rotationalSpeed)
        {
            return Torque.FromNewtonMeters(power.Watts / rotationalSpeed.RadiansPerSecond);
        }
        public static RotationalSpeed operator/(Power power, Torque torque)
        {
            return RotationalSpeed.FromRadiansPerSecond(power.Watts / torque.NewtonMeters);
        }

    }
}
