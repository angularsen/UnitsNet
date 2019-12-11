// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class LevelTests : LevelTestsBase
    {
        protected override double DecibelsInOneDecibel => 1;

        protected override double NepersInOneDecibel => 0.115129254;

        protected override void AssertLogarithmicAddition()
        {
            Level v = Level.FromDecibels(40);
            AssertEx.EqualTolerance(43.0102999566, (v + v).Decibels, DecibelsTolerance);
        }

        protected override void AssertLogarithmicSubtraction()
        {
            Level v = Level.FromDecibels(40);
            AssertEx.EqualTolerance(49.5424250944, (Level.FromDecibels(50) - v).Decibels, DecibelsTolerance);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(-1, 1)]
        public void InvalidQuantity_ExpectArgumentOutOfRangeException(double quantity, double reference)
        {
            // quantity can't be zero or less than zero if reference is positive.
            Assert.Throws<ArgumentOutOfRangeException>(() => new Level(quantity, reference));
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(10, -1)]
        public void InvalidReference_ExpectArgumentOutOfRangeException(double quantity, double reference)
        {
            // reference can't be zero or less than zero if quantity is postive.
            Assert.Throws<ArgumentOutOfRangeException>(() => new Level(quantity, reference));
        }
    }
}
