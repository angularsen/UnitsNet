using System;
using System.Diagnostics.CodeAnalysis;
using UnitsNet.Units;

namespace UnitsNet.Tests.CustomQuantities
{
    /// <inheritdoc cref="IQuantity"/>
    /// <summary>
    /// Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
    /// </summary>
    public readonly struct HowMuch : IQuantity<HowMuch, HowMuchUnit>
    {
        public HowMuch(double value, HowMuchUnit unit)
        {
            Unit = unit;
            Value = value;
        }

        public static HowMuch From(double value, HowMuchUnit unit)
        {
            return new HowMuch(value, unit);
        }

        public double As(HowMuchUnit unit)
        {
            throw new NotImplementedException();
        }

        public HowMuchUnit Unit { get; }

        public double Value { get; }

        #region IQuantity
        
        public static QuantityInfo<HowMuch, HowMuchUnit> Info { get; } = new(
            nameof(HowMuch),
            HowMuchUnit.Some,
            new UnitDefinition<HowMuchUnit>[]
            {
                new(HowMuchUnit.Some, "Some", BaseUnits.Undefined),
                new(HowMuchUnit.ATon, "Tons", new BaseUnits(mass: MassUnit.Tonne)),
                new(HowMuchUnit.AShitTon, "ShitTons", BaseUnits.Undefined)
            },
            new HowMuch(0, HowMuchUnit.Some),
            new BaseDimensions(0, 1, 0, 0, 0, 0, 0),
            From);

        QuantityInfo<HowMuch, HowMuchUnit> IQuantity<HowMuch, HowMuchUnit>.QuantityInfo
        {
            get => Info;
        }

        QuantityInfo<HowMuchUnit> IQuantity<HowMuchUnit>.QuantityInfo
        {
            get => Info;
        }

        QuantityInfo IQuantity.QuantityInfo
        {
            get => Info;
        }
        
        UnitKey IQuantity.UnitKey
        {
            get => UnitKey.ForUnit(Unit);
        }

        public double As(Enum unit) => Convert.ToDouble(unit);
        public double As(UnitKey unitKey)
        {
            return As(unitKey.ToUnit<HowMuchUnit>());
        }

        public IQuantity ToUnit(Enum unit)
        {
            if (unit is HowMuchUnit howMuchUnit) return new HowMuch(As(unit), howMuchUnit);
            throw new ArgumentException("Must be of type HowMuchUnit.", nameof(unit));
        }

        public IQuantity<HowMuchUnit> ToUnit(HowMuchUnit unit)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Value} {Unit}";
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return $"HowMuch ({format}, {formatProvider})";
        }

#if !NET

        QuantityInfo IQuantity.QuantityInfo
        {
            get { return Info; }
        }

        Enum IQuantity.Unit => Unit;
#endif

        #endregion


        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=(HowMuch left, HowMuch right)
        {
            return left.Value <= right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=(HowMuch left, HowMuch right)
        {
            return left.Value >= right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if less than.</summary>
        public static bool operator <(HowMuch left, HowMuch right)
        {
            return left.Value < right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >(HowMuch left, HowMuch right)
        {
            return left.Value > right.ToUnit(left.Unit).Value;
        }

        // We use obsolete attribute to communicate the preferred equality members to use.
        // CS0809: Obsolete member 'memberA' overrides non-obsolete member 'memberB'.
#pragma warning disable CS0809

        /// <summary>Indicates strict equality of two <see cref="HowMuch"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete(
            "For null checks, use `x is null` syntax to not invoke overloads. For equality checks, use Equals(HowMuch other, HowMuch tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public static bool operator ==(HowMuch left, HowMuch right)
        {
            return left.Equals(right);
        }

        /// <summary>Indicates strict inequality of two <see cref="HowMuch"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete(
            "For null checks, use `x is null` syntax to not invoke overloads. For equality checks, use Equals(HowMuch other, HowMuch tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public static bool operator !=(HowMuch left, HowMuch right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        /// <summary>Indicates strict equality of two <see cref="HowMuch"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete(
            "Use Equals(HowMuch other, HowMuch tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is HowMuch otherQuantity))
                return false;

            return Equals(otherQuantity);
        }

        /// <inheritdoc />
        /// <summary>Indicates strict equality of two <see cref="HowMuch"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete(
            "Use Equals(HowMuch other, HowMuch tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public bool Equals(HowMuch other)
        {
            return new { Value, Unit }.Equals(new { other.Value, other.Unit });
        }

#pragma warning restore CS0809

        public override int GetHashCode()
        {
            return Comparison.GetHashCode(Unit, Value);
        }

        public int CompareTo(object? obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            if (!(obj is HowMuch otherQuantity)) throw new ArgumentException("Expected type HowMuch.", nameof(obj));

            return CompareTo(otherQuantity);
        }

        public int CompareTo(HowMuch other)
        {
            return Value.CompareTo(other.ToUnit(Unit).Value);
        }

        #endregion

        #region IParsable

        public static HowMuch Parse(string str, IFormatProvider? provider)
        {
            return UnitsNetSetup.Default.QuantityParser.Parse<HowMuch, HowMuchUnit>(
                str,
                provider,
                From);
        }

        public static bool TryParse([NotNullWhen(true)] string? str, IFormatProvider? provider, out HowMuch result)
        {
            return UnitsNetSetup.Default.QuantityParser.TryParse<HowMuch, HowMuchUnit>(
                str,
                provider,
                From,
                out result);
        }

        #endregion
    }
}
