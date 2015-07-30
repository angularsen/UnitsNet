using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class Frequency
    {
        public static UnitsNet.Frequency Hertz(this double _inputFrequency)
        {
            return new UnitsNet.Frequency(_inputFrequency);
        }

        public static UnitsNet.Frequency MegaHertz(this double _inputFrequency)
        {
            return new UnitsNet.Frequency(_inputFrequency * 1000000);
        }

        public static UnitsNet.Frequency GigaHertz(this double _inputFrequency)
        {
            return new UnitsNet.Frequency(_inputFrequency * 1000000000)
        }
    }
}
