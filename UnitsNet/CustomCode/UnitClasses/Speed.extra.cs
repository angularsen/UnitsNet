using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Speed
    {

        public static Acceleration operator /(Speed speed, TimeSpan timeSpan)
        {
            return Acceleration.FromMeterPerSecondSquared(speed.MetersPerSecond / timeSpan.TotalSeconds);
        }
        public static Length operator*(Speed speed, TimeSpan timeSpan)
        {
            return Length.FromMeters(speed.MetersPerSecond * timeSpan.TotalSeconds);
        }
    }
}
