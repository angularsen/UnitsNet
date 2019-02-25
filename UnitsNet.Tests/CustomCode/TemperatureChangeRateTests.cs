// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests.CustomCode
{
    public class TemperatureChangeRateTests : TemperatureChangeRateTestsBase
    {
        protected override double DegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1;

        protected override double DecadegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E-1;

        protected override double HectodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E-2;

        protected override double KilodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E-3;

        protected override double DecidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E1;

        protected override double CentidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E2;

        protected override double MillidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E3;

        protected override double MicrodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E6;

        protected override double NanodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E9;

		protected override double DegreesCelsiusPerMinuteInOneDegreeCelsiusPerSecond => 60;
    }
}
