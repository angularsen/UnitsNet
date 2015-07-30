using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class Volume
    {
        public static UnitsNet.Volume CubicMeter(this double _inputVolume)
        {
            return new UnitsNet.Volume(_inputVolume);
        }

        public static UnitsNet.Volume CubicCentimeters(this double _inputVolume)
        {
            return new UnitsNet.Volume(_inputVolume * 0.000001);
        }

        public static UnitsNet.Volume CubicKilometers(this double _inputVolume)
        {
            return new UnitsNet.Volume(_inputVolume * 1000000000);
        }

        public static UnitsNet.Volume CubicMiles(this double _inputVolume)
        {
            return new UnitsNet.Volume(_inputVolume * 4168181830);
        }

        public static UnitsNet.Volume CubicYards(this double _inputVolume)
        {
            return new UnitsNet.Volume(_inputVolume * 0.764554858);
        }
    }
}
