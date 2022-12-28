// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests
{
    public class InformationTests : InformationTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override decimal BitsInOneBit => 1m;

        protected override decimal BytesInOneBit => 0.125m;

        protected override decimal ExabitsInOneBit => 1e-18m;

        protected override decimal ExabytesInOneBit => 0.125m*1e-18m;

        protected override decimal ExbibitsInOneBit => 1m/(decimal)Math.Pow(1024, 6);

        protected override decimal ExbibytesInOneBit => 1m/8m/(decimal)Math.Pow(1024, 6);

        protected override decimal GibibitsInOneBit => 1m/(decimal)Math.Pow(1024, 3);

        protected override decimal GibibytesInOneBit => 1m/8m/(decimal)Math.Pow(1024, 3);

        protected override decimal GigabitsInOneBit => 1e-9m;

        protected override decimal GigabytesInOneBit => 0.125m*1e-9m;

        protected override decimal KibibitsInOneBit => 1m/1024m;

        protected override decimal KibibytesInOneBit => 1m/8/1024m;

        protected override decimal KilobitsInOneBit => 0.001m;

        protected override decimal KilobytesInOneBit => 0.000125m;

        protected override decimal MebibitsInOneBit => 1m/(decimal)Math.Pow(1024, 2);

        protected override decimal MebibytesInOneBit => 1m/8m/(decimal)Math.Pow(1024, 2);

        protected override decimal MegabitsInOneBit => 1e-6m;

        protected override decimal MegabytesInOneBit => 0.125m*1e-6m;

        protected override decimal PebibitsInOneBit => 1m/(decimal)Math.Pow(1024, 5);

        protected override decimal PebibytesInOneBit => 1m/8m/(decimal)Math.Pow(1024, 5);

        protected override decimal PetabitsInOneBit => 1e-15m;

        protected override decimal PetabytesInOneBit => 0.125m*1e-15m;

        protected override decimal TebibitsInOneBit => 1m/(decimal)Math.Pow(1024, 4);

        protected override decimal TebibytesInOneBit => 1m/8m/(decimal)Math.Pow(1024, 4);

        protected override decimal TerabitsInOneBit => 1e-12m;

        protected override decimal TerabytesInOneBit => 0.125m*1e-12m;

        [Fact]
        public void OneKBHas1000Bytes()
        {
            Assert.Equal(1000, Information.FromKilobytes(1).Bytes);
        }
    }
}
