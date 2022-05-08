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
    ///     In thermodynamics, the specific volume of a substance is the ratio of the substance's volume to its mass. It is the reciprocal of density and an intrinsic property of matter as well.
    /// </summary>
    [DataContract]
    public partial struct SpecificVolume : IQuantity<SpecificVolumeUnit>, IComparable, IComparable<SpecificVolume>, IConvertible, IFormattable
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
        private readonly SpecificVolumeUnit? _unit;

        static SpecificVolume()
        {
            BaseDimensions = new BaseDimensions(3, -1, 0, 0, 0, 0, 0);
            BaseUnit = SpecificVolumeUnit.CubicMeterPerKilogram;
            Units = Enum.GetValues(typeof(SpecificVolumeUnit)).Cast<SpecificVolumeUnit>().ToArray();
            Zero = new SpecificVolume(0, BaseUnit);
            Info = new QuantityInfo<SpecificVolumeUnit>("SpecificVolume",
                new UnitInfo<SpecificVolumeUnit>[]
                {
                    new UnitInfo<SpecificVolumeUnit>(SpecificVolumeUnit.CubicFootPerPound, "CubicFeetPerPound", BaseUnits.Undefined),
                    new UnitInfo<SpecificVolumeUnit>(SpecificVolumeUnit.CubicMeterPerKilogram, "CubicMetersPerKilogram", BaseUnits.Undefined),
                    new UnitInfo<SpecificVolumeUnit>(SpecificVolumeUnit.MillicubicMeterPerKilogram, "MillicubicMetersPerKilogram", BaseUnits.Undefined),
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
        public SpecificVolume(double value, SpecificVolumeUnit unit)
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
        public SpecificVolume(double value, UnitSystem unitSystem)
        {
            if (unitSystem is null) throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);
            var firstUnitInfo = unitInfos.FirstOrDefault();

            _value = Guard.EnsureValidNumber(value, nameof(value));
            _unit = firstUnitInfo?.Value ?? throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));
        }

        #region Static Properties

        /// <summary>
        ///     The <see cref="UnitConverter" /> containing the default generated conversion functions for <see cref="SpecificVolume" /> instances.
        /// </summary>
        public static UnitConverter DefaultConversionFunctions { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        public static QuantityInfo<SpecificVolumeUnit> Info { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions { get; }

        /// <summary>
        ///     The base unit of SpecificVolume, which is CubicMeterPerKilogram. All conversions go via this value.
        /// </summary>
        public static SpecificVolumeUnit BaseUnit { get; }

        /// <summary>
        ///     All units of measurement for the SpecificVolume quantity.
        /// </summary>
        public static SpecificVolumeUnit[] Units { get; }

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit CubicMeterPerKilogram.
        /// </summary>
        public static SpecificVolume Zero { get; }

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
        public SpecificVolumeUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<SpecificVolumeUnit> QuantityInfo => Info;

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        QuantityInfo IQuantity.QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => SpecificVolume.BaseDimensions;

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpecificVolumeUnit.CubicFootPerPound"/>
        /// </summary>
        public double CubicFeetPerPound => As(SpecificVolumeUnit.CubicFootPerPound);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpecificVolumeUnit.CubicMeterPerKilogram"/>
        /// </summary>
        public double CubicMetersPerKilogram => As(SpecificVolumeUnit.CubicMeterPerKilogram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpecificVolumeUnit.MillicubicMeterPerKilogram"/>
        /// </summary>
        public double MillicubicMetersPerKilogram => As(SpecificVolumeUnit.MillicubicMeterPerKilogram);

        #endregion

        #region Static Methods

        /// <summary>
        /// Registers the default conversion functions in the given <see cref="UnitConverter"/> instance.
        /// </summary>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to register the default conversion functions in.</param>
        internal static void RegisterDefaultConversions(UnitConverter unitConverter)
        {
            // Register in unit converter: BaseUnit -> SpecificVolumeUnit
            unitConverter.SetConversionFunction<SpecificVolume>(SpecificVolumeUnit.CubicMeterPerKilogram, SpecificVolumeUnit.CubicFootPerPound, quantity => new SpecificVolume(quantity.Value * 16.01846353, SpecificVolumeUnit.CubicFootPerPound));
            unitConverter.SetConversionFunction<SpecificVolume>(SpecificVolumeUnit.CubicMeterPerKilogram, SpecificVolumeUnit.MillicubicMeterPerKilogram, quantity => new SpecificVolume((quantity.Value) / 1e-3d, SpecificVolumeUnit.MillicubicMeterPerKilogram));

            // Register in unit converter: BaseUnit <-> BaseUnit
            unitConverter.SetConversionFunction<SpecificVolume>(SpecificVolumeUnit.CubicMeterPerKilogram, SpecificVolumeUnit.CubicMeterPerKilogram, quantity => quantity);

            // Register in unit converter: SpecificVolumeUnit -> BaseUnit
            unitConverter.SetConversionFunction<SpecificVolume>(SpecificVolumeUnit.CubicFootPerPound, SpecificVolumeUnit.CubicMeterPerKilogram, quantity => new SpecificVolume(quantity.Value / 16.01846353, SpecificVolumeUnit.CubicMeterPerKilogram));
            unitConverter.SetConversionFunction<SpecificVolume>(SpecificVolumeUnit.MillicubicMeterPerKilogram, SpecificVolumeUnit.CubicMeterPerKilogram, quantity => new SpecificVolume((quantity.Value) * 1e-3d, SpecificVolumeUnit.CubicMeterPerKilogram));
        }

        internal static void MapGeneratedLocalizations(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            unitAbbreviationsCache.PerformAbbreviationMapping(SpecificVolumeUnit.CubicFootPerPound, new CultureInfo("en-US"), false, true, new string[]{"ft³/lb"});
            unitAbbreviationsCache.PerformAbbreviationMapping(SpecificVolumeUnit.CubicMeterPerKilogram, new CultureInfo("en-US"), false, true, new string[]{"m³/kg"});
            unitAbbreviationsCache.PerformAbbreviationMapping(SpecificVolumeUnit.MillicubicMeterPerKilogram, new CultureInfo("en-US"), false, true, new string[]{"mm³/kg"});
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(SpecificVolumeUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="provider">Format to use for localization. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static string GetAbbreviation(SpecificVolumeUnit unit, IFormatProvider? provider)
        {
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="SpecificVolume"/> from <see cref="SpecificVolumeUnit.CubicFootPerPound"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static SpecificVolume FromCubicFeetPerPound(QuantityValue cubicfeetperpound)
        {
            double value = (double) cubicfeetperpound;
            return new SpecificVolume(value, SpecificVolumeUnit.CubicFootPerPound);
        }

        /// <summary>
        ///     Creates a <see cref="SpecificVolume"/> from <see cref="SpecificVolumeUnit.CubicMeterPerKilogram"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static SpecificVolume FromCubicMetersPerKilogram(QuantityValue cubicmetersperkilogram)
        {
            double value = (double) cubicmetersperkilogram;
            return new SpecificVolume(value, SpecificVolumeUnit.CubicMeterPerKilogram);
        }

        /// <summary>
        ///     Creates a <see cref="SpecificVolume"/> from <see cref="SpecificVolumeUnit.MillicubicMeterPerKilogram"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static SpecificVolume FromMillicubicMetersPerKilogram(QuantityValue millicubicmetersperkilogram)
        {
            double value = (double) millicubicmetersperkilogram;
            return new SpecificVolume(value, SpecificVolumeUnit.MillicubicMeterPerKilogram);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpecificVolumeUnit" /> to <see cref="SpecificVolume" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>SpecificVolume unit value.</returns>
        public static SpecificVolume From(QuantityValue value, SpecificVolumeUnit fromUnit)
        {
            return new SpecificVolume((double)value, fromUnit);
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
        public static SpecificVolume Parse(string str)
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
        public static SpecificVolume Parse(string str, IFormatProvider? provider)
        {
            return QuantityParser.Default.Parse<SpecificVolume, SpecificVolumeUnit>(
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
        public static bool TryParse(string? str, out SpecificVolume result)
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
        public static bool TryParse(string? str, IFormatProvider? provider, out SpecificVolume result)
        {
            return QuantityParser.Default.TryParse<SpecificVolume, SpecificVolumeUnit>(
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
        public static SpecificVolumeUnit ParseUnit(string str)
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
        public static SpecificVolumeUnit ParseUnit(string str, IFormatProvider? provider)
        {
            return UnitParser.Default.Parse<SpecificVolumeUnit>(str, provider);
        }

        /// <inheritdoc cref="TryParseUnit(string,IFormatProvider,out UnitsNet.Units.SpecificVolumeUnit)"/>
        public static bool TryParseUnit(string str, out SpecificVolumeUnit unit)
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
        public static bool TryParseUnit(string str, IFormatProvider? provider, out SpecificVolumeUnit unit)
        {
            return UnitParser.Default.TryParse<SpecificVolumeUnit>(str, provider, out unit);
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static SpecificVolume operator -(SpecificVolume right)
        {
            return new SpecificVolume(-right.Value, right.Unit);
        }

        /// <summary>Get <see cref="SpecificVolume"/> from adding two <see cref="SpecificVolume"/>.</summary>
        public static SpecificVolume operator +(SpecificVolume left, SpecificVolume right)
        {
            return new SpecificVolume(left.Value + right.GetValueAs(left.Unit), left.Unit);
        }

        /// <summary>Get <see cref="SpecificVolume"/> from subtracting two <see cref="SpecificVolume"/>.</summary>
        public static SpecificVolume operator -(SpecificVolume left, SpecificVolume right)
        {
            return new SpecificVolume(left.Value - right.GetValueAs(left.Unit), left.Unit);
        }

        /// <summary>Get <see cref="SpecificVolume"/> from multiplying value and <see cref="SpecificVolume"/>.</summary>
        public static SpecificVolume operator *(double left, SpecificVolume right)
        {
            return new SpecificVolume(left * right.Value, right.Unit);
        }

        /// <summary>Get <see cref="SpecificVolume"/> from multiplying value and <see cref="SpecificVolume"/>.</summary>
        public static SpecificVolume operator *(SpecificVolume left, double right)
        {
            return new SpecificVolume(left.Value * right, left.Unit);
        }

        /// <summary>Get <see cref="SpecificVolume"/> from dividing <see cref="SpecificVolume"/> by value.</summary>
        public static SpecificVolume operator /(SpecificVolume left, double right)
        {
            return new SpecificVolume(left.Value / right, left.Unit);
        }

        /// <summary>Get ratio value from dividing <see cref="SpecificVolume"/> by <see cref="SpecificVolume"/>.</summary>
        public static double operator /(SpecificVolume left, SpecificVolume right)
        {
            return left.CubicMetersPerKilogram / right.CubicMetersPerKilogram;
        }

        #endregion

        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=(SpecificVolume left, SpecificVolume right)
        {
            return left.Value <= right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=(SpecificVolume left, SpecificVolume right)
        {
            return left.Value >= right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if less than.</summary>
        public static bool operator <(SpecificVolume left, SpecificVolume right)
        {
            return left.Value < right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >(SpecificVolume left, SpecificVolume right)
        {
            return left.Value > right.GetValueAs(left.Unit);
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            if (!(obj is SpecificVolume objSpecificVolume)) throw new ArgumentException("Expected type SpecificVolume.", nameof(obj));

            return CompareTo(objSpecificVolume);
        }

        /// <inheritdoc />
        public int CompareTo(SpecificVolume other)
        {
            return _value.CompareTo(other.GetValueAs(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another SpecificVolume within the given absolute or relative tolerance.
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
        public bool Equals(SpecificVolume other, double tolerance, ComparisonType comparisonType)
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
        /// <returns>A hash code for the current SpecificVolume.</returns>
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
        public double As(SpecificVolumeUnit unit)
        {
            if(Unit == unit)
                return Value;

            var converted = GetValueAs(unit);
            return converted;
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
            if (!(unit is SpecificVolumeUnit unitAsSpecificVolumeUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(SpecificVolumeUnit)} is supported.", nameof(unit));

            return ((IQuantity<SpecificVolumeUnit>)this).As(unitAsSpecificVolumeUnit);
        }

        /// <summary>
        ///     Converts this SpecificVolume to another SpecificVolume with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>A SpecificVolume with the specified unit.</returns>
        public SpecificVolume ToUnit(SpecificVolumeUnit unit)
        {
            return ToUnit(unit, DefaultConversionFunctions);
        }

        /// <summary>
        ///     Converts this SpecificVolume to another SpecificVolume with the unit representation <paramref name="unit" /> and returns its see <cref name="QuantityValue" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>A SpecificVolume with the specified unit.</returns>
        public QuantityValue ToQuantity(SpecificVolumeUnit unit)
        {
            return ((IQuantity)ToUnit(unit, DefaultConversionFunctions)).Value;
        }

        /// <summary>
        ///     Converts this SpecificVolume to another SpecificVolume using the given <paramref name="unitConverter"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to use for the conversion.</param>
        /// <returns>A SpecificVolume with the specified unit.</returns>
        public SpecificVolume ToUnit(SpecificVolumeUnit unit, UnitConverter unitConverter)
        {
            if (Unit == unit)
            {
                // Already in requested units.
                return this;
            }
            else if (unitConverter.TryGetConversionFunction((typeof(SpecificVolume), Unit, typeof(SpecificVolume), unit), out var conversionFunction))
            {
                // Direct conversion to requested unit found. Return the converted quantity.
                var converted = conversionFunction(this);
                return (SpecificVolume)converted;
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
            if (!(unit is SpecificVolumeUnit unitAsSpecificVolumeUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(SpecificVolumeUnit)} is supported.", nameof(unit));

            return ToUnit(unitAsSpecificVolumeUnit, DefaultConversionFunctions);
        }

        /// <inheritdoc cref="IQuantity.ToUnit(UnitSystem)"/>
        public SpecificVolume ToUnit(UnitSystem unitSystem)
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
        IQuantity<SpecificVolumeUnit> IQuantity<SpecificVolumeUnit>.ToUnit(SpecificVolumeUnit unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<SpecificVolumeUnit> IQuantity<SpecificVolumeUnit>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        private double GetValueAs(SpecificVolumeUnit unit)
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
            return QuantityFormatter.Format<SpecificVolumeUnit>(this, format, provider);
        }

        #endregion

        #region IConvertible Methods

        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(SpecificVolume)} to bool is not supported.");
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(SpecificVolume)} to char is not supported.");
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(SpecificVolume)} to DateTime is not supported.");
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
            if (conversionType == typeof(SpecificVolume))
                return this;
            else if (conversionType == typeof(SpecificVolumeUnit))
                return Unit;
            else if (conversionType == typeof(QuantityInfo))
                return SpecificVolume.Info;
            else if (conversionType == typeof(BaseDimensions))
                return SpecificVolume.BaseDimensions;
            else
                throw new InvalidCastException($"Converting {typeof(SpecificVolume)} to {conversionType} is not supported.");
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
