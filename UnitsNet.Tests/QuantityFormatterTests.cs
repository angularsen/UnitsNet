// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityFormatterTests
    {
        [Theory]
        [InlineData("C")]
        [InlineData("C0")]
        [InlineData("C1")]
        [InlineData("C2")]
        [InlineData("C3")]
        [InlineData("C4")]
        [InlineData("C5")]
        [InlineData("C6")]
        [InlineData("c")]
        [InlineData("c0")]
        [InlineData("c1")]
        [InlineData("c2")]
        [InlineData("c3")]
        [InlineData("c4")]
        [InlineData("c5")]
        [InlineData("c6")]
        [InlineData("E")]
        [InlineData("E0")]
        [InlineData("E1")]
        [InlineData("E2")]
        [InlineData("E3")]
        [InlineData("E4")]
        [InlineData("E5")]
        [InlineData("E6")]
        [InlineData("e")]
        [InlineData("e0")]
        [InlineData("e1")]
        [InlineData("e2")]
        [InlineData("e3")]
        [InlineData("e4")]
        [InlineData("e5")]
        [InlineData("e6")]
        [InlineData("F")]
        [InlineData("F0")]
        [InlineData("F1")]
        [InlineData("F2")]
        [InlineData("F3")]
        [InlineData("F4")]
        [InlineData("F5")]
        [InlineData("F6")]
        [InlineData("f")]
        [InlineData("f0")]
        [InlineData("f1")]
        [InlineData("f2")]
        [InlineData("f3")]
        [InlineData("f4")]
        [InlineData("f5")]
        [InlineData("f6")]
        [InlineData("N")]
        [InlineData("N0")]
        [InlineData("N1")]
        [InlineData("N2")]
        [InlineData("N3")]
        [InlineData("N4")]
        [InlineData("N5")]
        [InlineData("N6")]
        [InlineData("n")]
        [InlineData("n0")]
        [InlineData("n1")]
        [InlineData("n2")]
        [InlineData("n3")]
        [InlineData("n4")]
        [InlineData("n5")]
        [InlineData("n6")]
        [InlineData("P")]
        [InlineData("P0")]
        [InlineData("P1")]
        [InlineData("P2")]
        [InlineData("P3")]
        [InlineData("P4")]
        [InlineData("P5")]
        [InlineData("P6")]
        [InlineData("p")]
        [InlineData("p0")]
        [InlineData("p1")]
        [InlineData("p2")]
        [InlineData("p3")]
        [InlineData("p4")]
        [InlineData("p5")]
        [InlineData("p6")]
        [InlineData("R")]
        [InlineData("R0")]
        [InlineData("R1")]
        [InlineData("R2")]
        [InlineData("R3")]
        [InlineData("R4")]
        [InlineData("R5")]
        [InlineData("R6")]
        [InlineData("r")]
        [InlineData("r0")]
        [InlineData("r1")]
        [InlineData("r2")]
        [InlineData("r3")]
        [InlineData("r4")]
        [InlineData("r5")]
        [InlineData("r6")]
        public static void StandardNumericFormatStrings_Equals_ValueWithFormatStringAndAbbreviation(string format)
        {
            var length = Length.FromMeters(123456789.987654321);

            var expected = string.Format(CultureInfo.CurrentCulture, $"{{0:{format}}} {{1:a}}", length.Value, length);
            Assert.Equal(expected, QuantityFormatter.Format(length, format));
        }

        [Fact]
        public static void StandardNumericFormatStringsAsPartOfLongerFormatStringsWork()
        {
            var length = Length.FromMeters(123.321);
            var expected = "The distance is 123.3 m";
            var actual = $"The distance is {length.ToString("F1", CultureInfo.InvariantCulture)}";
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("000")]
        [InlineData("0.00")]
        [InlineData("#####")]
        [InlineData("#.##")]
        [InlineData("##,#")]
        [InlineData("#,#,,")]
        [InlineData("%#0.00")]
        [InlineData("##.0 %")]
        [InlineData("#0.00‰")]
        [InlineData("#0.0e0")]
        [InlineData("0.0##e+00")]
        [InlineData("0.0e+00")]
        [InlineData(@"\###00\#")]
        [InlineData("#0.0#;(#0.0#);-\0-")]
        [InlineData("#0.0#;(#0.0#)")]
        public static void CustomNumericFormatStrings_Equals_ValueWithFormatStringAndAbbreviation(string format)
        {
            var length = Length.FromMeters(123456789.987654321);

            var expected = string.Format(CultureInfo.CurrentCulture, $"{{0:{format}}} {{1:a}}", length.Value, length);
            Assert.Equal(expected, QuantityFormatter.Format(length, format));
        }
    }
}
