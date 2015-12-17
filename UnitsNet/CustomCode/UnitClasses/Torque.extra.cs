using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Torque
    {
        public static Force operator /(Torque torque, Length length)
        {
            return Force.FromNewtons(torque.NewtonMeters/length.Meters);
        }
    }
}
