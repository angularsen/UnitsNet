// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class InformationTests : InformationTestsBase
    {
        protected override double BitsInOneBit => 1d;

        protected override double BytesInOneBit => 0.125d;

        protected override double ExabitsInOneBit => 1e-18d;

        protected override double ExabytesInOneBit => 0.125d*1e-18d;

        protected override double ExbibitsInOneBit => 1d/Math.Pow(1024, 6);

        protected override double ExbibytesInOneBit => 1/8d/Math.Pow(1024, 6);

        protected override double GibibitsInOneBit => 1d/Math.Pow(1024, 3);

        protected override double GibibytesInOneBit => 1d/8/Math.Pow(1024, 3);

        protected override double GigabitsInOneBit => 1e-9d;

        protected override double GigabytesInOneBit => 0.125d*1e-9d;

        protected override double KibibitsInOneBit => 1d/1024d;

        protected override double KibibytesInOneBit => 1d/8/1024d;

        protected override double KilobitsInOneBit => 0.001d;

        protected override double KilobytesInOneBit => 0.000125d;

        protected override double MebibitsInOneBit => 1d/Math.Pow(1024, 2);

        protected override double MebibytesInOneBit => 1d/8/Math.Pow(1024, 2);

        protected override double MegabitsInOneBit => 1e-6d;

        protected override double MegabytesInOneBit => 0.125d*1e-6d;

        protected override double PebibitsInOneBit => 1d/Math.Pow(1024, 5);

        protected override double PebibytesInOneBit => 1d/8/Math.Pow(1024, 5);

        protected override double PetabitsInOneBit => 1e-15d;

        protected override double PetabytesInOneBit => 0.125d*1e-15d;

        protected override double TebibitsInOneBit => 1d/Math.Pow(1024, 4);

        protected override double TebibytesInOneBit => 1d/8/Math.Pow(1024, 4);

        protected override double TerabitsInOneBit => 1e-12d;

        protected override double TerabytesInOneBit => 0.125d*1e-12d;

// ReSharper disable once InconsistentNaming
        [Fact]
        public void OneKBHas1000Bytes()
        {
            Assert.Equal(1000, Information.FromKilobytes(1).Bytes);
        }

        [Fact]
        public void MaxValueIsCorrectForUnitWithBaseTypeDecimal()
        {
            Assert.Equal((double) decimal.MaxValue, Information.MaxValue.Bits);
        }

        [Fact]
        public void MinValueIsCorrectForUnitWithBaseTypeDecimal()
        {
            Assert.Equal((double) decimal.MinValue, Information.MinValue.Bits);
        }
    }
}
