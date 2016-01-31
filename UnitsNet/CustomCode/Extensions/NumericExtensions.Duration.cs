using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static partial class Duration
    {
        public static UnitsNet.Duration Seconds(this double _inputDuration)
        {
            return new UnitsNet.Duration(_inputDuration);
        }

        public static UnitsNet.Duration Minutes(this double _inputDuration)
        {
            return new UnitsNet.Duration(_inputDuration * 60);
        }

        public static UnitsNet.Duration Hours(this double _inputDuration)
        {
            return new UnitsNet.Duration(_inputDuration * 60 * 60);
        }

        public static UnitsNet.Duration Days(this double _inputDuration)
        {
            return new UnitsNet.Duration(_inputDuration * 60 * 60 * 24);
        }

        public static UnitsNet.Duration Weeks(this double _inputDuration)
        {
            return new UnitsNet.Duration(_inputDuration * 60 * 60 * 24 * 7);
        }
    }
}
