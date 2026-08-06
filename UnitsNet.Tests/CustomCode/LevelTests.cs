// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests
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

        [Fact]
        public void LogarithmicAddition_OfTwoLevels_CombinesThemInLinearSpace()
        {
            // The values from https://github.com/angularsen/UnitsNet/issues/1569, which read
            // 4.18 dB as wrong on the assumption that adding levels adds their decibel numbers.
            // Adding two levels combines them in linear power space, so the result is
            // 10 * log10(10^0.16 + 10^0.07).
            Level sum = Level.FromDecibels(1.6) + Level.FromDecibels(0.7);

            var expected = 10 * Math.Log10(Math.Pow(10, 0.16) + Math.Pow(10, 0.07));
            AssertEx.EqualTolerance(expected, sum.Decibels, DecibelsTolerance);
            AssertEx.EqualTolerance(4.18357203248652, sum.Decibels, DecibelsTolerance);
        }

        [Fact]
        public void LogarithmicSubtraction_OfEqualLevels_ReturnsNegativeInfinity()
        {
            // Removing a level from itself leaves no power at all, and log10(0) is -infinity.
            // Pinned because it is returned silently rather than signalled.
            Level v = Level.FromDecibels(40);

            Assert.Equal(double.NegativeInfinity, (double)(v - v).Decibels);
        }

        [Fact]
        public void LogarithmicSubtraction_WhenSubtrahendIsLarger_ReturnsNaN()
        {
            // The linear difference is negative here, and log10 of a negative number is undefined.
            // The constructor rejects that case with ArgumentOutOfRangeException; this operator
            // returns NaN silently instead. Pinned as current behaviour, not endorsed as correct.
            Level smaller = Level.FromDecibels(0.7);
            Level larger = Level.FromDecibels(1.6);

            Assert.Equal(double.NaN, (double)(smaller - larger).Decibels);
        }
    }
}
