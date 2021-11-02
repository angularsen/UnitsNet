// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;

namespace ConsoleNet6
{
    public enum LengthUnit
    {
        Meter,
        Centimeter
    }

    [RequiresPreviewFeatures]
    public struct Length : IQuantity<Length>
    {
        public Length(double value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public double Value { get; }
        public LengthUnit Unit { get; }

        public static Length AdditiveIdentity => Zero;

        public static Length Zero => new Length(0, LengthUnit.Meter);

        public static Length Parse(string s, IFormatProvider? provider)
        {
            if (!TryParse(s, provider, out var length)) throw new ArgumentException(nameof(s));
            return length;
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Length result)
        {
            if (s == null)
            {
                result = default;
                return false;
            }

            var m = Regex.Match(s, @"(?<value>[+-]?\d+(?:\.\d+)?) (?<unit>cm|m)");
            result = m.Success
                ? new Length(
                    double.Parse(m.Groups["value"].Value),
                    m.Groups["unit"].Value switch {
                        "m" => LengthUnit.Meter,
                        "cm" => LengthUnit.Centimeter,
                        _ => throw new ArgumentException()
                    })
            : default;

            return m.Success;
        }

        public double As(LengthUnit unit)
        {
            if (unit == Unit) return Value;
            if (Unit == LengthUnit.Meter && unit == LengthUnit.Centimeter) return Value * 100;
            if (Unit == LengthUnit.Centimeter && unit == LengthUnit.Meter) return Value / 100;
            throw new NotImplementedException();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            if (obj is not Length other) throw new ArgumentException(nameof(obj));
            return CompareTo(other);
        }

        public int CompareTo(Length other)
        {
            return Value.CompareTo(other.As(Unit));
        }

        public bool Equals(Length other)
        {
            return Value.Equals(other.As(Unit));
        }

        public static Length operator +(Length left, Length right)
        {
            return new Length(left.Value + right.As(left.Unit), left.Unit);
        }

        public static bool operator ==(Length left, Length right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Length left, Length right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Length left, Length right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Length left, Length right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Length left, Length right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Length left, Length right)
        {
            return left.CompareTo(right) >= 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Length other) return false;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return new { Value, Unit }.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} {1}", Value, Unit);
        }
    }
}
