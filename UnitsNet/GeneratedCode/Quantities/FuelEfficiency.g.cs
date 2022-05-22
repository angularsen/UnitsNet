//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run generate-code.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

#nullable enable

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <inheritdoc />
    /// <summary>
    ///     Fuel efficiency is a form of thermal efficiency, meaning the ratio from effort to result of a process that converts chemical potential energy contained in a carrier (fuel) into kinetic energy or work. Fuel economy is stated as "fuel consumption" in liters per 100 kilometers (L/100 km). In countries using non-metric system, fuel economy is expressed in miles per gallon (mpg) (imperial galon or US galon).
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Fuel_efficiency
    /// </remarks>
    [DataContract]
    public partial struct FuelEfficiency : IQuantity<FuelEfficiencyUnit>, IComparable, IComparable<FuelEfficiency>, IConvertible, IFormattable
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        [DataMember(Name = "Value", Order = 0)]
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        [DataMember(Name = "Unit", Order = 1)]
        private readonly FuelEfficiencyUnit? _unit;

        static FuelEfficiency()
        {
            BaseDimensions = BaseDimensions.Dimensionless;
            BaseUnit = FuelEfficiencyUnit.LiterPer100Kilometers;
            Units = Enum.GetValues(typeof(FuelEfficiencyUnit)).Cast<FuelEfficiencyUnit>().ToArray();
            Zero = new FuelEfficiency(0, BaseUnit);
            Info = new QuantityInfo<FuelEfficiencyUnit>("FuelEfficiency",
                new UnitInfo<FuelEfficiencyUnit>[]
                {
                    new UnitInfo<FuelEfficiencyUnit>(FuelEfficiencyUnit.KilometerPerLiter, "KilometersPerLiters", BaseUnits.Undefined),
                    new UnitInfo<FuelEfficiencyUnit>(FuelEfficiencyUnit.LiterPer100Kilometers, "LitersPer100Kilometers", BaseUnits.Undefined),
                    new UnitInfo<FuelEfficiencyUnit>(FuelEfficiencyUnit.MilePerUkGallon, "MilesPerUkGallon", BaseUnits.Undefined),
                    new UnitInfo<FuelEfficiencyUnit>(FuelEfficiencyUnit.MilePerUsGallon, "MilesPerUsGallon", BaseUnits.Undefined),
                },
                BaseUnit, Zero, BaseDimensions);

            DefaultConversionFunctions = new UnitConverter();
            RegisterDefaultConversions(DefaultConversionFunctions);
        }

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public FuelEfficiency(double value, FuelEfficiencyUnit unit)
        {
            _value = Guard.EnsureValidNumber(value, nameof(value));
            _unit = unit;
        }

        /// <summary>
        /// Creates an instance of the quantity with the given numeric value in units compatible with the given <see cref="UnitSystem"/>.
        /// If multiple compatible units were found, the first match is used.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unitSystem">The unit system to create the quantity with.</param>
        /// <exception cref="ArgumentNullException">The given <see cref="UnitSystem"/> is null.</exception>
        /// <exception cref="ArgumentException">No unit was found for the given <see cref="UnitSystem"/>.</exception>
        public FuelEfficiency(double value, UnitSystem unitSystem)
        {
            if (unitSystem is null) throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);
            var firstUnitInfo = unitInfos.FirstOrDefault();

            _value = Guard.EnsureValidNumber(value, nameof(value));
            _unit = firstUnitInfo?.Value ?? throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));
        }

        #region Static Properties

        /// <summary>
        ///     The <see cref="UnitConverter" /> containing the default generated conversion functions for <see cref="FuelEfficiency" /> instances.
        /// </summary>
        public static UnitConverter DefaultConversionFunctions { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        public static QuantityInfo<FuelEfficiencyUnit> Info { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions { get; }

        /// <summary>
        ///     The base unit of FuelEfficiency, which is LiterPer100Kilometers. All conversions go via this value.
        /// </summary>
        public static FuelEfficiencyUnit BaseUnit { get; }

        /// <summary>
        ///     All units of measurement for the FuelEfficiency quantity.
        /// </summary>
        public static FuelEfficiencyUnit[] Units { get; }

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit LiterPer100Kilometers.
        /// </summary>
        public static FuelEfficiency Zero { get; }

        #endregion

        #region Properties

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        QuantityValue IQuantity.Value => _value;

        Enum IQuantity.Unit => Unit;

        /// <inheritdoc />
        public FuelEfficiencyUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<FuelEfficiencyUnit> QuantityInfo => Info;

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        QuantityInfo IQuantity.QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => FuelEfficiency.BaseDimensions;

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="FuelEfficiencyUnit.KilometerPerLiter"/>
        /// </summary>
        public double KilometersPerLiters => As(FuelEfficiencyUnit.KilometerPerLiter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="FuelEfficiencyUnit.LiterPer100Kilometers"/>
        /// </summary>
        public double LitersPer100Kilometers => As(FuelEfficiencyUnit.LiterPer100Kilometers);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="FuelEfficiencyUnit.MilePerUkGallon"/>
        /// </summary>
        public double MilesPerUkGallon => As(FuelEfficiencyUnit.MilePerUkGallon);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="FuelEfficiencyUnit.MilePerUsGallon"/>
        /// </summary>
        public double MilesPerUsGallon => As(FuelEfficiencyUnit.MilePerUsGallon);

        #endregion

        #region Static Methods

        /// <summary>
        /// Registers the default conversion functions in the given <see cref="UnitConverter"/> instance.
        /// </summary>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to register the default conversion functions in.</param>
        internal static void RegisterDefaultConversions(UnitConverter unitConverter)
        {
            // Register in unit converter: BaseUnit -> FuelEfficiencyUnit
            unitConverter.SetConversionFunction<FuelEfficiency>(FuelEfficiencyUnit.LiterPer100Kilometers, FuelEfficiencyUnit.KilometerPerLiter, quantity => new FuelEfficiency(100 / quantity.Value, FuelEfficiencyUnit.KilometerPerLiter));
            unitConverter.SetConversionFunction<FuelEfficiency>(FuelEfficiencyUnit.LiterPer100Kilometers, FuelEfficiencyUnit.MilePerUkGallon, quantity => new FuelEfficiency((100 * 4.54609188) / (1.609344 * quantity.Value), FuelEfficiencyUnit.MilePerUkGallon));
            unitConverter.SetConversionFunction<FuelEfficiency>(FuelEfficiencyUnit.LiterPer100Kilometers, FuelEfficiencyUnit.MilePerUsGallon, quantity => new FuelEfficiency((100 * 3.785411784) / (1.609344 * quantity.Value), FuelEfficiencyUnit.MilePerUsGallon));

            // Register in unit converter: BaseUnit <-> BaseUnit
            unitConverter.SetConversionFunction<FuelEfficiency>(FuelEfficiencyUnit.LiterPer100Kilometers, FuelEfficiencyUnit.LiterPer100Kilometers, quantity => quantity);

            // Register in unit converter: FuelEfficiencyUnit -> BaseUnit
            unitConverter.SetConversionFunction<FuelEfficiency>(FuelEfficiencyUnit.KilometerPerLiter, FuelEfficiencyUnit.LiterPer100Kilometers, quantity => new FuelEfficiency(100 / quantity.Value, FuelEfficiencyUnit.LiterPer100Kilometers));
            unitConverter.SetConversionFunction<FuelEfficiency>(FuelEfficiencyUnit.MilePerUkGallon, FuelEfficiencyUnit.LiterPer100Kilometers, quantity => new FuelEfficiency((100 * 4.54609188) / (1.609344 * quantity.Value), FuelEfficiencyUnit.LiterPer100Kilometers));
            unitConverter.SetConversionFunction<FuelEfficiency>(FuelEfficiencyUnit.MilePerUsGallon, FuelEfficiencyUnit.LiterPer100Kilometers, quantity => new FuelEfficiency((100 * 3.785411784) / (1.609344 * quantity.Value), FuelEfficiencyUnit.LiterPer100Kilometers));
        }

        internal static void MapGeneratedLocalizations(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            unitAbbreviationsCache.PerformAbbreviationMapping(FuelEfficiencyUnit.KilometerPerLiter, new CultureInfo("en-US"), false, true, new string[]{"km/L"});
            unitAbbreviationsCache.PerformAbbreviationMapping(FuelEfficiencyUnit.LiterPer100Kilometers, new CultureInfo("en-US"), false, true, new string[]{"L/100km"});
            unitAbbreviationsCache.PerformAbbreviationMapping(FuelEfficiencyUnit.MilePerUkGallon, new CultureInfo("en-US"), false, true, new string[]{"mpg (imp.)"});
            unitAbbreviationsCache.PerformAbbreviationMapping(FuelEfficiencyUnit.MilePerUsGallon, new CultureInfo("en-US"), false, true, new string[]{"mpg (U.S.)"});
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(FuelEfficiencyUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="provider">Format to use for localization. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static string GetAbbreviation(FuelEfficiencyUnit unit, IFormatProvider? provider)
        {
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="FuelEfficiency"/> from <see cref="FuelEfficiencyUnit.KilometerPerLiter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static FuelEfficiency FromKilometersPerLiters(QuantityValue kilometersperliters)
        {
            double value = (double) kilometersperliters;
            return new FuelEfficiency(value, FuelEfficiencyUnit.KilometerPerLiter);
        }

        /// <summary>
        ///     Creates a <see cref="FuelEfficiency"/> from <see cref="FuelEfficiencyUnit.LiterPer100Kilometers"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static FuelEfficiency FromLitersPer100Kilometers(QuantityValue litersper100kilometers)
        {
            double value = (double) litersper100kilometers;
            return new FuelEfficiency(value, FuelEfficiencyUnit.LiterPer100Kilometers);
        }

        /// <summary>
        ///     Creates a <see cref="FuelEfficiency"/> from <see cref="FuelEfficiencyUnit.MilePerUkGallon"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static FuelEfficiency FromMilesPerUkGallon(QuantityValue milesperukgallon)
        {
            double value = (double) milesperukgallon;
            return new FuelEfficiency(value, FuelEfficiencyUnit.MilePerUkGallon);
        }

        /// <summary>
        ///     Creates a <see cref="FuelEfficiency"/> from <see cref="FuelEfficiencyUnit.MilePerUsGallon"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static FuelEfficiency FromMilesPerUsGallon(QuantityValue milesperusgallon)
        {
            double value = (double) milesperusgallon;
            return new FuelEfficiency(value, FuelEfficiencyUnit.MilePerUsGallon);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="FuelEfficiencyUnit" /> to <see cref="FuelEfficiency" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>FuelEfficiency unit value.</returns>
        public static FuelEfficiency From(QuantityValue value, FuelEfficiencyUnit fromUnit)
        {
            return new FuelEfficiency((double)value, fromUnit);
        }

        #endregion

        #region Static Parse Methods

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static FuelEfficiency Parse(string str)
        {
            return Parse(str, null);
        }

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static FuelEfficiency Parse(string str, IFormatProvider? provider)
        {
            return QuantityParser.Default.Parse<FuelEfficiency, FuelEfficiencyUnit>(
                str,
                provider,
                From);
        }

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="result">Resulting unit quantity if successful.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        public static bool TryParse(string? str, out FuelEfficiency result)
        {
            return TryParse(str, null, out result);
        }

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="result">Resulting unit quantity if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static bool TryParse(string? str, IFormatProvider? provider, out FuelEfficiency result)
        {
            return QuantityParser.Default.TryParse<FuelEfficiency, FuelEfficiencyUnit>(
                str,
                provider,
                From,
                out result);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static FuelEfficiencyUnit ParseUnit(string str)
        {
            return ParseUnit(str, null);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static FuelEfficiencyUnit ParseUnit(string str, IFormatProvider? provider)
        {
            return UnitParser.Default.Parse<FuelEfficiencyUnit>(str, provider);
        }

        /// <inheritdoc cref="TryParseUnit(string,IFormatProvider,out UnitsNet.Units.FuelEfficiencyUnit)"/>
        public static bool TryParseUnit(string str, out FuelEfficiencyUnit unit)
        {
            return TryParseUnit(str, null, out unit);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="unit">The parsed unit if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        /// <example>
        ///     Length.TryParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static bool TryParseUnit(string str, IFormatProvider? provider, out FuelEfficiencyUnit unit)
        {
            return UnitParser.Default.TryParse<FuelEfficiencyUnit>(str, provider, out unit);
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static FuelEfficiency operator -(FuelEfficiency right)
        {
            return new FuelEfficiency(-right.Value, right.Unit);
        }

        /// <summary>Get <see cref="FuelEfficiency"/> from adding two <see cref="FuelEfficiency"/>.</summary>
        public static FuelEfficiency operator +(FuelEfficiency left, FuelEfficiency right)
        {
            return new FuelEfficiency(left.Value + right.GetValueAs(left.Unit), left.Unit);
        }

        /// <summary>Get <see cref="FuelEfficiency"/> from subtracting two <see cref="FuelEfficiency"/>.</summary>
        public static FuelEfficiency operator -(FuelEfficiency left, FuelEfficiency right)
        {
            return new FuelEfficiency(left.Value - right.GetValueAs(left.Unit), left.Unit);
        }

        /// <summary>Get <see cref="FuelEfficiency"/> from multiplying value and <see cref="FuelEfficiency"/>.</summary>
        public static FuelEfficiency operator *(double left, FuelEfficiency right)
        {
            return new FuelEfficiency(left * right.Value, right.Unit);
        }

        /// <summary>Get <see cref="FuelEfficiency"/> from multiplying value and <see cref="FuelEfficiency"/>.</summary>
        public static FuelEfficiency operator *(FuelEfficiency left, double right)
        {
            return new FuelEfficiency(left.Value * right, left.Unit);
        }

        /// <summary>Get <see cref="FuelEfficiency"/> from dividing <see cref="FuelEfficiency"/> by value.</summary>
        public static FuelEfficiency operator /(FuelEfficiency left, double right)
        {
            return new FuelEfficiency(left.Value / right, left.Unit);
        }

        /// <summary>Get ratio value from dividing <see cref="FuelEfficiency"/> by <see cref="FuelEfficiency"/>.</summary>
        public static double operator /(FuelEfficiency left, FuelEfficiency right)
        {
            return left.LitersPer100Kilometers / right.LitersPer100Kilometers;
        }

        #endregion

        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=(FuelEfficiency left, FuelEfficiency right)
        {
            return left.Value <= right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=(FuelEfficiency left, FuelEfficiency right)
        {
            return left.Value >= right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if less than.</summary>
        public static bool operator <(FuelEfficiency left, FuelEfficiency right)
        {
            return left.Value < right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >(FuelEfficiency left, FuelEfficiency right)
        {
            return left.Value > right.GetValueAs(left.Unit);
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            if (!(obj is FuelEfficiency objFuelEfficiency)) throw new ArgumentException("Expected type FuelEfficiency.", nameof(obj));

            return CompareTo(objFuelEfficiency);
        }

        /// <inheritdoc />
        public int CompareTo(FuelEfficiency other)
        {
            return _value.CompareTo(other.GetValueAs(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another FuelEfficiency within the given absolute or relative tolerance.
        ///     </para>
        ///     <para>
        ///     Relative tolerance is defined as the maximum allowable absolute difference between this quantity's value and
        ///     <paramref name="other"/> as a percentage of this quantity's value. <paramref name="other"/> will be converted into
        ///     this quantity's unit for comparison. A relative tolerance of 0.01 means the absolute difference must be within +/- 1% of
        ///     this quantity's value to be considered equal.
        ///     <example>
        ///     In this example, the two quantities will be equal if the value of b is within +/- 1% of a (0.02m or 2cm).
        ///     <code>
        ///     var a = Length.FromMeters(2.0);
        ///     var b = Length.FromInches(50.0);
        ///     a.Equals(b, 0.01, ComparisonType.Relative);
        ///     </code>
        ///     </example>
        ///     </para>
        ///     <para>
        ///     Absolute tolerance is defined as the maximum allowable absolute difference between this quantity's value and
        ///     <paramref name="other"/> as a fixed number in this quantity's unit. <paramref name="other"/> will be converted into
        ///     this quantity's unit for comparison.
        ///     <example>
        ///     In this example, the two quantities will be equal if the value of b is within 0.01 of a (0.01m or 1cm).
        ///     <code>
        ///     var a = Length.FromMeters(2.0);
        ///     var b = Length.FromInches(50.0);
        ///     a.Equals(b, 0.01, ComparisonType.Absolute);
        ///     </code>
        ///     </example>
        ///     </para>
        ///     <para>
        ///     Note that it is advised against specifying zero difference, due to the nature
        ///     of floating point operations and using System.Double internally.
        ///     </para>
        /// </summary>
        /// <param name="other">The other quantity to compare to.</param>
        /// <param name="tolerance">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
        /// <param name="comparisonType">The comparison type: either relative or absolute.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified relative or absolute tolerance.</returns>
        public bool Equals(FuelEfficiency other, double tolerance, ComparisonType comparisonType)
        {
            if (tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0.");

            double thisValue = this.Value;
            double otherValueInThisUnits = other.As(this.Unit);

            return UnitsNet.Comparison.Equals(thisValue, otherValueInThisUnits, tolerance, comparisonType);
        }

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current FuelEfficiency.</returns>
        public override int GetHashCode()
        {
            return new { Info.Name, Value, Unit }.GetHashCode();
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(FuelEfficiencyUnit unit)
        {
            if(Unit == unit)
                return Value;

            return GetValueAs(unit);
        }

        /// <inheritdoc cref="IQuantity.As(UnitSystem)"/>
        public double As(UnitSystem unitSystem)
        {
            if (unitSystem is null)
                throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);

            var firstUnitInfo = unitInfos.FirstOrDefault();
            if (firstUnitInfo == null)
                throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));

            return As(firstUnitInfo.Value);
        }

        /// <inheritdoc />
        double IQuantity.As(Enum unit)
        {
            if (!(unit is FuelEfficiencyUnit typedUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(FuelEfficiencyUnit)} is supported.", nameof(unit));

            return (double)As(typedUnit);
        }

        /// <summary>
        ///     Converts this FuelEfficiency to another FuelEfficiency with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>A FuelEfficiency with the specified unit.</returns>
        public FuelEfficiency ToUnit(FuelEfficiencyUnit unit)
        {
            return ToUnit(unit, DefaultConversionFunctions);
        }

        /// <summary>
        ///     Converts this FuelEfficiency to another FuelEfficiency with the unit representation <paramref name="unit" /> and returns its see <cref name="QuantityValue" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>A FuelEfficiency with the specified unit.</returns>
        public QuantityValue ToQuantity(FuelEfficiencyUnit unit)
        {
            return ((IQuantity)ToUnit(unit, DefaultConversionFunctions)).Value;
        }

        /// <summary>
        ///     Converts this FuelEfficiency to another FuelEfficiency using the given <paramref name="unitConverter"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to use for the conversion.</param>
        /// <returns>A FuelEfficiency with the specified unit.</returns>
        public FuelEfficiency ToUnit(FuelEfficiencyUnit unit, UnitConverter unitConverter)
        {
            if (Unit == unit)
            {
                // Already in requested units.
                return this;
            }
            else if (unitConverter.TryGetConversionFunction((typeof(FuelEfficiency), Unit, typeof(FuelEfficiency), unit), out var conversionFunction))
            {
                // Direct conversion to requested unit found. Return the converted quantity.
                var converted = conversionFunction(this);
                return (FuelEfficiency)converted;
            }
            else if (Unit != BaseUnit)
            {
                // Direct conversion to requested unit NOT found. Convert to BaseUnit, and then from BaseUnit to requested unit.
                var inBaseUnits = ToUnit(BaseUnit);
                return inBaseUnits.ToUnit(unit);
            }
            else
            {
                throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(Enum unit)
        {
            if (!(unit is FuelEfficiencyUnit typedUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(FuelEfficiencyUnit)} is supported.", nameof(unit));

            return ToUnit(typedUnit, DefaultConversionFunctions);
        }

        /// <inheritdoc cref="IQuantity.ToUnit(UnitSystem)"/>
        public FuelEfficiency ToUnit(UnitSystem unitSystem)
        {
            if (unitSystem is null)
                throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);

            var firstUnitInfo = unitInfos.FirstOrDefault();
            if (firstUnitInfo == null)
                throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));

            return ToUnit(firstUnitInfo.Value);
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <inheritdoc />
        IQuantity<FuelEfficiencyUnit> IQuantity<FuelEfficiencyUnit>.ToUnit(FuelEfficiencyUnit unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<FuelEfficiencyUnit> IQuantity<FuelEfficiencyUnit>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        private double GetValueAs(FuelEfficiencyUnit unit)
        {
            var converted = ToUnit(unit);
            return (double)converted.Value;
        }

        #endregion

        #region ToString Methods

        /// <summary>
        ///     Gets the default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString("g");
        }

        /// <summary>
        ///     Gets the default string representation of value and unit using the given format provider.
        /// </summary>
        /// <returns>String representation.</returns>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public string ToString(IFormatProvider? provider)
        {
            return ToString("g", provider);
        }

        /// <inheritdoc cref="QuantityFormatter.Format{TUnitType}(IQuantity{TUnitType}, string, IFormatProvider)"/>
        /// <summary>
        /// Gets the string representation of this instance in the specified format string using <see cref="CultureInfo.CurrentCulture" />.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <returns>The string representation.</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <inheritdoc cref="QuantityFormatter.Format{TUnitType}(IQuantity{TUnitType}, string, IFormatProvider)"/>
        /// <summary>
        /// Gets the string representation of this instance in the specified format string using the specified format provider, or <see cref="CultureInfo.CurrentCulture" /> if null.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>The string representation.</returns>
        public string ToString(string format, IFormatProvider? provider)
        {
            return QuantityFormatter.Format<FuelEfficiencyUnit>(this, format, provider);
        }

        #endregion

        #region IConvertible Methods

        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(FuelEfficiency)} to bool is not supported.");
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(FuelEfficiency)} to char is not supported.");
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(FuelEfficiency)} to DateTime is not supported.");
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(_value);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(_value);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(_value);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(_value);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(_value);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(_value);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(_value);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return ToString("g", provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof(FuelEfficiency))
                return this;
            else if (conversionType == typeof(FuelEfficiencyUnit))
                return Unit;
            else if (conversionType == typeof(QuantityInfo))
                return FuelEfficiency.Info;
            else if (conversionType == typeof(BaseDimensions))
                return FuelEfficiency.BaseDimensions;
            else
                throw new InvalidCastException($"Converting {typeof(FuelEfficiency)} to {conversionType} is not supported.");
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(_value);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(_value);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(_value);
        }

        #endregion
    }
}
