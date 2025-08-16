using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using UnitsNet;
using UnitsNet.Debug;
using UnitsNet.Units;

namespace UnitsNetSetup.Configuration;

internal static class ConfigureWithCustomQuantities
{
    /// <summary>
    ///     Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
    /// </summary>
    public enum HowMuchUnit
    {
        Some,
        ATon,
        AShitTon
    }

    /// <inheritdoc cref="IQuantity" />
    /// <summary>
    ///     Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
    /// </summary>
    [DebuggerDisplay(QuantityDebugProxy.DisplayFormat)]
    [DebuggerTypeProxy(typeof(QuantityDebugProxy))]
    public readonly struct HowMuch : IArithmeticQuantity<HowMuch, HowMuchUnit>, IEquatable<HowMuch>, IComparable<HowMuch>
    {
        public HowMuchUnit Unit { get; }

        public QuantityValue Value { get; }

        public HowMuch(QuantityValue value, HowMuchUnit unit)
        {
            Unit = unit;
            Value = value;
        }

        public static HowMuch From(QuantityValue value, HowMuchUnit unit)
        {
            return new HowMuch(value, unit);
        }

        // public QuantityValue As(HowMuchUnit unit)
        // {
        //     return UnitConverter.Default.ConvertValue(this, unit);
        // }

        // public HowMuch ToUnit(HowMuchUnit unit)
        // {
        //     return new HowMuch(As(unit), unit);
        // }

        public static HowMuch Zero { get; } = new(0, HowMuchUnit.Some);

        public static readonly QuantityInfo<HowMuch, HowMuchUnit> Info = new(
            HowMuchUnit.Some,
            new UnitDefinition<HowMuchUnit>[]
            {
                new(HowMuchUnit.Some, "Some", BaseUnits.Undefined),
                new(HowMuchUnit.ATon, "Tons", new BaseUnits(mass: MassUnit.Tonne), QuantityValue.FromTerms(1, 10)),
                new(HowMuchUnit.AShitTon, "ShitTons", BaseUnits.Undefined, QuantityValue.FromTerms(1, 100))
            },
            new BaseDimensions(0, 1, 0, 0, 0, 0, 0),
            // providing a resource manager for the unit abbreviations (optional)
            Properties.CustomQuantities_HowMuch.ResourceManager); 

        #region IQuantity

        public BaseDimensions Dimensions
        {
            get => BaseDimensions.Dimensionless;
        }

        // Enum IQuantity.Unit
        // {
        //     get => Unit;
        // }

        QuantityInfo<HowMuchUnit> IQuantity<HowMuchUnit>.QuantityInfo
        {
            get => Info;
        }

        // QuantityInfo IQuantity.QuantityInfo
        // {
        //     get => Info;
        // }

        QuantityInfo<HowMuch, HowMuchUnit> IQuantity<HowMuch, HowMuchUnit>.QuantityInfo
        {
            get => Info;
        }

        // QuantityValue IQuantity.As(Enum unit)
        // {
        //     if (unit is HowMuchUnit howMuchUnit) return As(howMuchUnit);
        //     throw new ArgumentException("Must be of type HowMuchUnit.", nameof(unit));
        // }
        //
        // IQuantity IQuantity.ToUnit(Enum unit)
        // {
        //     if (unit is HowMuchUnit howMuchUnit) return ToUnit(howMuchUnit);
        //     throw new ArgumentException("Must be of type HowMuchUnit.", nameof(unit));
        // }

        // QuantityValue IQuantity.As(UnitSystem unitSystem)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // HowMuch IQuantity<HowMuch, HowMuchUnit>.ToUnit(UnitSystem unitSystem)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // IQuantity<HowMuchUnit> IQuantity<HowMuchUnit>.ToUnit(UnitSystem unitSystem)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // IQuantity IQuantity.ToUnit(UnitSystem unitSystem)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // IQuantity<HowMuchUnit> IQuantity<HowMuchUnit>.ToUnit(HowMuchUnit unit)
        // {
        //     return ToUnit(unit);
        // }
        
        public override string ToString()
        {
            return ToString("G", null);
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return QuantityFormatter.Default.Format(this, format, formatProvider);
        }

        // public string ToString(IFormatProvider? provider)
        // {
        //     return ToString("G", provider);
        // }

        UnitKey IQuantity.UnitKey
        {
            get => UnitKey.ForUnit(Unit);
        }

        #endregion

        #region Equality members

        public bool Equals(HowMuch other)
        {
            return Value.Equals(other.As(Unit));
        }

        public override bool Equals(object? obj)
        {
            return obj is HowMuch other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(typeof(HowMuch), this.As(Info.BaseUnitInfo.Value));
            // return HashCode.Combine(typeof(HowMuch), As(Info.BaseUnitInfo.Value));
        }

        public int CompareTo(HowMuch other)
        {
            return Value.CompareTo(other.As(Unit));
        }

        #endregion

        #region Implementation of IEqualityOperators<HowMuch,HowMuch,bool>

        public static bool operator ==(HowMuch left, HowMuch right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HowMuch left, HowMuch right)
        {
            return !left.Equals(right);
        }

        #endregion

        #region Implementation of IComparisonOperators<HowMuch,HowMuch,bool>

        // public static bool operator >(HowMuch left, HowMuch right)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public static bool operator >=(HowMuch left, HowMuch right)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public static bool operator <(HowMuch left, HowMuch right)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public static bool operator <=(HowMuch left, HowMuch right)
        // {
        //     throw new NotImplementedException();
        // }

        #endregion

        #region Implementation of IParsable<HowMuch>

        // public static HowMuch Parse(string s, IFormatProvider? provider)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out HowMuch result)
        // {
        //     throw new NotImplementedException();
        // }

        #endregion

        #region Implementation of IAdditionOperators<HowMuch,HowMuch,HowMuch>

        public static HowMuch operator +(HowMuch left, HowMuch right)
        {
            return new HowMuch(left.Value + right.As(left.Unit), left.Unit);
        }

        #endregion

        #region Implementation of ISubtractionOperators<HowMuch,HowMuch,HowMuch>

        public static HowMuch operator -(HowMuch left, HowMuch right)
        {
            return new HowMuch(left.Value - right.As(left.Unit), left.Unit);
        }

        #endregion

        #region Implementation of IMultiplyOperators<HowMuch,QuantityValue,HowMuch>

        public static HowMuch operator *(HowMuch left, QuantityValue right)
        {
            return new HowMuch(left.Value * right, left.Unit);
        }

        #endregion

        #region Implementation of IDivisionOperators<HowMuch,QuantityValue,HowMuch>

        public static HowMuch operator /(HowMuch left, QuantityValue right)
        {
            return new HowMuch(left.Value / right, left.Unit);
        }

        #endregion

        #region Implementation of IUnaryNegationOperators<HowMuch,HowMuch>

        public static HowMuch operator -(HowMuch value)
        {
            return new HowMuch(-value.Value, value.Unit);
        }

        #endregion
    }

    public static void Configure()
    {
        UnitsNet.UnitsNetSetup.ConfigureDefaults(builder =>
            // selecting only the required quantities (the rest are not needed for this example)
            builder.WithQuantities([Mass.Info, Length.Info])
            // adding the list of our custom quantities
            .WithAdditionalQuantities([HowMuch.Info])
                // (optionally) configuring custom conversion options (unit-conversion caching, implicit conversion etc.)
                .WithConverterOptions(new QuantityConverterBuildOptions(defaultCachingMode:ConversionCachingMode.None)
                    .WithCustomCachingOptions<HowMuch>(new ConversionCacheOptions(ConversionCachingMode.All))
                    // configuring an "implicit" conversion function between the "HowMuch" and "Mass":
                    .WithImplicitConversionOptions(options => options.SetCustomConversion<HowMuch, Mass>()
                        // 1. since the BaseDimensions are compatible the relationship "1 ATon" = "1 Ton" would be inferred automatically (as they both have the same BaseUnits)
                        // alternatively we could specify it manually (using a conversion coefficient or a "ConversionExpression"):
                        // .SetCustomConversion(HowMuchUnit.AShitTon, MassUnit.Tonne, conversionCoefficient: 1)
                        // 2. based on this relationship, all other MassUnit <-> HowMuchUnit conversions can be inferred automatically,
                        // but if we want to: we can customize the default units to use when converting in either directions:
                        .SetConversionUnits(MassUnit.ShortHundredweight, HowMuchUnit.Some, mapBothDirections:false)
                        // .SetConversionUnits(MassUnit.LongHundredweight, HowMuchUnit.Some, mapBothDirections:false)
                    )));
    }

    [SuppressMessage("ReSharper", "LocalizableElement")]
    public static void OutputHowMuch()
    {
        var some = new HowMuch(1, HowMuchUnit.Some);
        var aTon = new HowMuch(1, HowMuchUnit.ATon);
        var aShitTon = new HowMuch(1, HowMuchUnit.AShitTon);

        Console.WriteLine($"1 Some = {some.As(HowMuchUnit.ATon)} Tons");
        Console.WriteLine($"1 Some = {some.As(HowMuchUnit.AShitTon)} ShitTons");
        Console.WriteLine($"1 Ton = {aTon.As(HowMuchUnit.Some)} Some");
        Console.WriteLine($"1 Ton = {aTon.As(HowMuchUnit.AShitTon)} ShitTons");
        Console.WriteLine($"1 ShitTon = {aShitTon.As(HowMuchUnit.Some)} Some");
        Console.WriteLine($"1 ShitTon = {aShitTon.As(HowMuchUnit.ATon)} Tons");
        Console.WriteLine($"1 ShitTon = {aShitTon.ToUnit(HowMuchUnit.ATon)}"); // the abbreviation ("at") is mapped from the resource dictionary

        HowMuch sameAsATon = (some + (aTon / 3).ToUnit(HowMuchUnit.AShitTon) - some) * 3;
        Console.WriteLine($"sameAsATon == aTon is {sameAsATon == aTon}"); // outputs "True"

        Mass aTonOfMass = UnitConverter.Default.ConvertTo(aTon.Value, aTon.Unit, Mass.Info);
        Console.WriteLine($"aTonOfMass = {aTonOfMass}");

        Mass shortHundredWeight = aTonOfMass.ToUnit(MassUnit.ShortHundredweight);
        HowMuch aToneAsSome = UnitConverter.Default.ConvertTo(shortHundredWeight.Value, shortHundredWeight.Unit, HowMuch.Info);
        Console.Out.WriteLine($"aToneAsSome = {aToneAsSome}");
        Console.Out.WriteLine($"aTon == aToneAsSome is {aTon == aToneAsSome}"); // outputs "True"
        
        HowMuch[] someItems = [some, aTon, aShitTon];
        Console.Out.WriteLine("someItems.Min() = {0}", someItems.Min());
        Console.Out.WriteLine("someItems.Max() = {0}", someItems.Max());
        Console.Out.WriteLine("someItems.Sum() = {0}", someItems.Sum());
        Console.Out.WriteLine("someItems.Sum(HowMuchUnit.ATon) = {0}", someItems.Sum(HowMuchUnit.ATon));
        Console.Out.WriteLine("someItems.Average() = {0}", someItems.Average());
        Console.Out.WriteLine("someItems.Average(HowMuchUnit.ATon) = {0}", someItems.Average(HowMuchUnit.ATon));
        Console.Out.WriteLine("someItems.Average(MassUnit.Kilogram) = {0}", UnitConverter.Default.ConvertTo(someItems.Average(), MassUnit.Kilogram));
    }
}
