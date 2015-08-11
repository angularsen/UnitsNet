using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitsNet;
namespace UnitsNet.NumericExtensions
{
    public static class Volume
    {
        public static UnitsNet.Volume CubicMeter(this double _inputVolume)
        {
            return new UnitsNet.Volume(_inputVolume);
        }

        public static UnitsNet.Volume CubicCentimeters(this double _inputVolume)
        {
            return UnitsNet.Volume.FromCubicCentimeters(_inputVolume);
        }

        public static UnitsNet.Volume CubicKilometers(this double _inputVolume)
        {
        return UnitsNet.Volume.FromCubicCentimeters(_inputVolume);
        }

        public static UnitsNet.Volume CubicMiles(this double _inputVolume)
        {
            return UnitsNet.Volume.FromCubicCentimeters(_inputVolume);
        }

        public static UnitsNet.Volume CubicYards(this double _inputVolume)
        {
            return UnitsNet.Volume.FromCubicCentimeters(_inputVolume);
        }
    }
}
