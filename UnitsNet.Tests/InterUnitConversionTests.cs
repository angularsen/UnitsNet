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
            Force force = Force.FromKilogramsForce(1);
            Mass mass = Mass.FromGravitationalForce(force);
            Assert.Equal(mass.Kilograms, force.KilogramsForce);
        }

        [Fact]
        public void KilogramToKilogramForce()
        {
            Mass mass = Mass.FromKilograms(1);
            Force force = Force.FromKilogramsForce(mass.Kilograms);
            Assert.Equal(mass.Kilograms, force.KilogramsForce);
        }
    }
}
