using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static class Mass
    {
        public static UnitsNet.Mass Kilograms(this double _inputMass)
        {
            return new UnitsNet.Mass(_inputMass);
        }

        public static UnitsNet.Mass Grams(this double _inputMass)
        {
            return new UnitsNet.Mass(_inputMass / 1000);
        }

    }
}
