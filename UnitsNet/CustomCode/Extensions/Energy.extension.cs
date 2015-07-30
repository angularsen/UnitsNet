using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class Energy
    {
        public static UnitsNet.Energy Joules(this double _inputEnergy)
        {
            return new UnitsNet.Energy(_inputEnergy);
        }

        public static UnitsNet.Energy KiloJoules(this double _inputEnergy)
        {
            return new UnitsNet.Energy(_inputEnergy * 1000);
        }
    }
}
