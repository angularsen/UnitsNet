using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static partial class RotationalSpeed
    {
        public static UnitsNet.RotationalSpeed RevolitionsPerMinute(this double _inputRotSpeed)
        {
            return new UnitsNet.RotationalSpeed(_inputRotSpeed);
        }
        
        // Alias for RevolutionsPerMinute
        public static UnitsNet.RotationalSpeed RPM(this double _inputRotSpeed)
        {
            return _inputRotSpeed.RevolitionsPerMinute();
        }
    }
}
