// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests
{
    public class InformationTests : InformationTestsBase
    {
        protected override double BitsInOneBit => 1;

        protected override double BytesInOneBit => 0.125;

        protected override double OctetsInOneBit => 0.125;

        protected override double ExabitsInOneBit => 1e-18;

        protected override double ExabytesInOneBit => 0.125*1e-18;

        protected override double ExaoctetsInOneBit => 0.125*1e-18;

        protected override double ExbibitsInOneBit => 1d/Math.Pow(1024, 6);

        protected override double ExbibytesInOneBit => 1d/8/Math.Pow(1024, 6);

        protected override double ExbioctetsInOneBit => 1d/8/Math.Pow(1024, 6);

        protected override double GibibitsInOneBit => 1d/Math.Pow(1024, 3);

        protected override double GibibytesInOneBit => 1d/8/Math.Pow(1024, 3);

        protected override double GibioctetsInOneBit => 1d/8/Math.Pow(1024, 3);

        protected override double GigabitsInOneBit => 1e-9;

        protected override double GigabytesInOneBit => 0.125*1e-9;

        protected override double GigaoctetsInOneBit => 0.125*1e-9;

        protected override double KibibitsInOneBit => 1d/1024;

        protected override double KibibytesInOneBit => 1d/8/1024;

        protected override double KibioctetsInOneBit => 1d/8/1024;

        protected override double KilobitsInOneBit => 0.001;

        protected override double KilobytesInOneBit => 0.000125;

        protected override double KilooctetsInOneBit => 0.000125;

        protected override double MebibitsInOneBit => 1d/Math.Pow(1024, 2);

        protected override double MebibytesInOneBit => 1d/8/Math.Pow(1024, 2);

        protected override double MebioctetsInOneBit => 1d/8/Math.Pow(1024, 2);

        protected override double MegabitsInOneBit => 1e-6;

        protected override double MegabytesInOneBit => 0.125*1e-6;

        protected override double MegaoctetsInOneBit  => 0.125*1e-6;

        protected override double PebibitsInOneBit => 1d/Math.Pow(1024, 5);

        protected override double PebibytesInOneBit => 1d/8/Math.Pow(1024, 5);

        protected override double PebioctetsInOneBit => 1d/8/Math.Pow(1024, 5);

        protected override double PetabitsInOneBit => 1e-15;

        protected override double PetabytesInOneBit => 0.125*1e-15;

        protected override double PetaoctetsInOneBit => 0.125*1e-15;

        protected override double TebibitsInOneBit => 1d/Math.Pow(1024, 4);

        protected override double TebibytesInOneBit => 1d/8/Math.Pow(1024, 4);

        protected override double TebioctetsInOneBit => 1d/8/Math.Pow(1024, 4);

        protected override double TerabitsInOneBit => 1e-12;

        protected override double TerabytesInOneBit => 0.125*1e-12;

        protected override double TeraoctetsInOneBit => 0.125*1e-12;

        [Fact]
        public void OneKBHas1000Bytes()
        {
            Assert.Equal(1000, Information.FromKilobytes(1).Bytes);
        }
    }
}
