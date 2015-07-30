using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class Power
    {
        public static UnitsNet.Power Watts(this int _inputPower)
        {
            return new UnitsNet.Power(_inputPower);
        }
        public static UnitsNet.Power KiloWatts(this int _inputPower)
        {
            return new UnitsNet.Power(_inputPower * 1000);
        }
    }
}
