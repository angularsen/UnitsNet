using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Volume
    {

        public static Mass operator*(Volume volume, Density density)
        {
            return Mass.FromKilograms(volume.CubicMeters * density.KilogramsPerCubicMeter);
        }
        public static Area operator/(Volume volume, Length length)
        {
            return Area.FromSquareMeters(volume.CubicMeters / length.Meters);
        }
        public static Length operator /(Volume volume, Area area)
        {
            return Length.FromMeters(volume.CubicMeters / area.SquareMeters);
        }

    }
}
