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


    }
}
