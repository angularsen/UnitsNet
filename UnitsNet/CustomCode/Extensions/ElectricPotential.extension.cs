using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class ElectricPotential
    {
        public static UnitsNet.ElectricPotential Volts(this double _inputPotential)
        {
            return new UnitsNet.ElectricPotential(_inputPotential);
        }
    }
}
