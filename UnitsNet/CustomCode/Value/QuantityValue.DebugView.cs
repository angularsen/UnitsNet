using System.Globalization;

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
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly QuantityValue _value = value;

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly CultureInfo _currentCulture = CultureInfo.CurrentCulture;

            public string GeneralFormat => _value.ToString("G", _currentCulture);

            public string ShortFormat => _value.ToString("S", _currentCulture);

            public string SimplifiedFraction
            {
                get
                {
                    (BigInteger numerator, BigInteger denominator) = Reduce(_value);
                    return $"{numerator}/{denominator}";
                }
            }
        }

        [DebuggerDisplay("{Double}")]
        internal readonly struct NumericFormatsView(QuantityValue value)
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly QuantityValue _value = value;

            public int Integer => (int)_value;
            public long Long => (long)_value;
            public decimal Decimal => _value.ToDecimal();
            public double Double => _value.ToDouble();
        }
    }
}
