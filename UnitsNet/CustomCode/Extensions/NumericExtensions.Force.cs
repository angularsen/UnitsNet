using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static partial class Force
    {
        public static UnitsNet.Force Newtons(this double _inputForce)
        {
            return new UnitsNet.Force(_inputForce);
        }
    }
}
