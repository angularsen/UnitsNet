// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using Xunit;
using Xunit.Abstractions;

namespace UnitsNet.Tests
{
    public class UnitLocalizedNameTests
    {
        private readonly ITestOutputHelper _output;
        private const string AmericanCultureName = "en-US";
        private const string FrenchCultureName = "fr-FR";

        private static readonly IFormatProvider AmericanCulture = new CultureInfo(AmericanCultureName);
        private static readonly IFormatProvider FrenchCulture = new CultureInfo(FrenchCultureName);

        public UnitLocalizedNameTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void LengthToStringFormatting()
        {
            //WIP LTU : to working yet
            //var exepected = "Mètre";
            //string actual = Length.GetSingularName(LengthUnit.Meter, FrenchCulture);
            //Assert.Equal(exepected, actual);
        }
    }
}
