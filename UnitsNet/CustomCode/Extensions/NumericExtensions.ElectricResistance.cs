using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static partial class ElectricResistance
    {
        public static UnitsNet.ElectricResistance Ohms(this double _inputResistance)
        {
            return new UnitsNet.ElectricResistance(_inputResistance);
        }

        public static UnitsNet.ElectricResistance KiloOhms(this double _inputResistance)
        {
            return new UnitsNet.ElectricResistance(_inputResistance * 1000);
        }
    }
}
