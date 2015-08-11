using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static class Torque
    {
        public static UnitsNet.Torque NewtonMeters(this double _inputTorque)
        {
            return new Torque(_inputTorque);
        }
    }
}
