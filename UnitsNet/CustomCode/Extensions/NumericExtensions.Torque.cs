using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static partial class Torque
    {
        public static UnitsNet.Torque NewtonMeters(this double _inputTorque)
        {
            return new UnitsNet.Torque(_inputTorque);
        }
    }
}
