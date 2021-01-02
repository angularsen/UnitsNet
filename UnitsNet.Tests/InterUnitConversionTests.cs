// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class InterUnitConversionTests
    {
        [Fact]
        public void KilogramForceToKilogram()
        {
            var force = Force<double>.FromKilogramsForce(1);
            var mass = Mass<double>.FromGravitationalForce(force);
            Assert.Equal(mass.Kilograms, force.KilogramsForce);
        }

        [Fact]
        public void KilogramToKilogramForce()
        {
            var mass = Mass<double>.FromKilograms(1);
            var force = Force<double>.FromKilogramsForce(mass.Kilograms);
            Assert.Equal(mass.Kilograms, force.KilogramsForce);
        }
    }
}
