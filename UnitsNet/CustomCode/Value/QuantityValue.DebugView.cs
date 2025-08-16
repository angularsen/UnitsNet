using System.Diagnostics;
using System.Numerics;

namespace UnitsNet;

public partial struct QuantityValue
{
    internal readonly struct QuantityValueDebugView(QuantityValue value)
    {
        public BigInteger A => value.Numerator;
        public BigInteger B => value.Denominator;
        public bool IsReduced => A.IsZero || B.IsZero || BigInteger.GreatestCommonDivisor(A, B).IsOne;
#if NET
        public long NbBits => A.GetBitLength() + B.GetBitLength();
#else
        public long NbBits => (A.IsZero ? 0 : (int)BigInteger.Log(BigInteger.Abs(A), 2) + 1) +
                              (B.IsZero ? 0 : (int)(BigInteger.Log(B, 2) + 1));
#endif
        public StringFormatsView StringFormats => new(value);
        public NumericFormatsView ValueFormats => new(value);

        [DebuggerDisplay("{ShortFormat}")]
        internal readonly struct StringFormatsView(QuantityValue value)
        {
            public string GeneralFormat => value.ToString("G");

            public string ShortFormat => value.ToString("S");

            public string SimplifiedFraction
            {
                get
                {
                    var (numerator, denominator) = Reduce(value);
                    return $"{numerator}/{denominator}";
                }
            }
        }

        [DebuggerDisplay("{Double}")]
        internal readonly struct NumericFormatsView(QuantityValue value)
        {
            public int Integer => (int)value;
            public long Long => (long)value;
            public decimal Decimal => value.ToDecimal();
            public double Double => value.ToDouble();
        }
    }
}