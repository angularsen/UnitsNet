using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.Extension
{
    public static class Area
    {
        // Metric

        public static UnitsNet.Area MetersSquared(this double _inputArea)
        {
            return new UnitsNet.Area(_inputArea);
        }

        public static UnitsNet.Area KilometersSquared(this double _inputArea)
        {
            return new UnitsNet.Area(_inputArea * 1000000);
        }

        public static UnitsNet.Area CentimeterSquared(this double _inputArea)
        {
            return new UnitsNet.Area(_inputArea * 0.0001);
        }

        // Withheld mm because the error margin would be huge.


        // Imperial

        public static UnitsNet.Area MilesSquared(this double _inputArea)
        {
            return new UnitsNet.Area(_inputArea * 2589990);
        }

        public static UnitsNet.Area YardsSquared(this double _inputArea)
        {
            return new UnitsNet.Area(_inputArea * 0.836127);
        }
    }
}
