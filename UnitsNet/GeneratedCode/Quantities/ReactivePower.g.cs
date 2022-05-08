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
    ///     Volt-ampere reactive (var) is a unit by which reactive power is expressed in an AC electric power system. Reactive power exists in an AC circuit when the current and voltage are not in phase.
    /// </summary>
    [DataContract]
    public partial struct ReactivePower : IQuantity<ReactivePowerUnit>, IComparable, IComparable<ReactivePower>, IConvertible, IFormattable
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
        private readonly ReactivePowerUnit? _unit;

        static ReactivePower()
        {
            BaseDimensions = new BaseDimensions(2, 1, -3, 0, 0, 0, 0);
            BaseUnit = ReactivePowerUnit.VoltampereReactive;
            Units = Enum.GetValues(typeof(ReactivePowerUnit)).Cast<ReactivePowerUnit>().ToArray();
            Zero = new ReactivePower(0, BaseUnit);
            Info = new QuantityInfo<ReactivePowerUnit>("ReactivePower",
                new UnitInfo<ReactivePowerUnit>[]
                {
                    new UnitInfo<ReactivePowerUnit>(ReactivePowerUnit.GigavoltampereReactive, "GigavoltamperesReactive", BaseUnits.Undefined),
                    new UnitInfo<ReactivePowerUnit>(ReactivePowerUnit.KilovoltampereReactive, "KilovoltamperesReactive", BaseUnits.Undefined),
                    new UnitInfo<ReactivePowerUnit>(ReactivePowerUnit.MegavoltampereReactive, "MegavoltamperesReactive", BaseUnits.Undefined),
                    new UnitInfo<ReactivePowerUnit>(ReactivePowerUnit.VoltampereReactive, "VoltamperesReactive", BaseUnits.Undefined),
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
        public ReactivePower(double value, ReactivePowerUnit unit)
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
        public ReactivePower(double value, UnitSystem unitSystem)
        {
            if (unitSystem is null) throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);
            var firstUnitInfo = unitInfos.FirstOrDefault();

            _value = Guard.EnsureValidNumber(value, nameof(value));
            _unit = firstUnitInfo?.Value ?? throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));
        }

        #region Static Properties

        /// <summary>
        ///     The <see cref="UnitConverter" /> containing the default generated conversion functions for <see cref="ReactivePower" /> instances.
        /// </summary>
        public static UnitConverter DefaultConversionFunctions { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        public static QuantityInfo<ReactivePowerUnit> Info { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions { get; }

        /// <summary>
        ///     The base unit of ReactivePower, which is VoltampereReactive. All conversions go via this value.
        /// </summary>
        public static ReactivePowerUnit BaseUnit { get; }

        /// <summary>
        ///     All units of measurement for the ReactivePower quantity.
        /// </summary>
        public static ReactivePowerUnit[] Units { get; }

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit VoltampereReactive.
        /// </summary>
        public static ReactivePower Zero { get; }

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
        public ReactivePowerUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<ReactivePowerUnit> QuantityInfo => Info;

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        QuantityInfo IQuantity.QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => ReactivePower.BaseDimensions;

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ReactivePowerUnit.GigavoltampereReactive"/>
        /// </summary>
        public double GigavoltamperesReactive => As(ReactivePowerUnit.GigavoltampereReactive);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ReactivePowerUnit.KilovoltampereReactive"/>
        /// </summary>
        public double KilovoltamperesReactive => As(ReactivePowerUnit.KilovoltampereReactive);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ReactivePowerUnit.MegavoltampereReactive"/>
        /// </summary>
        public double MegavoltamperesReactive => As(ReactivePowerUnit.MegavoltampereReactive);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ReactivePowerUnit.VoltampereReactive"/>
        /// </summary>
        public double VoltamperesReactive => As(ReactivePowerUnit.VoltampereReactive);

        #endregion

        #region Static Methods

        /// <summary>
        /// Registers the default conversion functions in the given <see cref="UnitConverter"/> instance.
        /// </summary>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to register the default conversion functions in.</param>
        internal static void RegisterDefaultConversions(UnitConverter unitConverter)
        {
            // Register in unit converter: BaseUnit -> ReactivePowerUnit
            unitConverter.SetConversionFunction<ReactivePower>(ReactivePowerUnit.VoltampereReactive, ReactivePowerUnit.GigavoltampereReactive, quantity => new ReactivePower((quantity.Value) / 1e9d, ReactivePowerUnit.GigavoltampereReactive));
            unitConverter.SetConversionFunction<ReactivePower>(ReactivePowerUnit.VoltampereReactive, ReactivePowerUnit.KilovoltampereReactive, quantity => new ReactivePower((quantity.Value) / 1e3d, ReactivePowerUnit.KilovoltampereReactive));
            unitConverter.SetConversionFunction<ReactivePower>(ReactivePowerUnit.VoltampereReactive, ReactivePowerUnit.MegavoltampereReactive, quantity => new ReactivePower((quantity.Value) / 1e6d, ReactivePowerUnit.MegavoltampereReactive));

            // Register in unit converter: BaseUnit <-> BaseUnit
            unitConverter.SetConversionFunction<ReactivePower>(ReactivePowerUnit.VoltampereReactive, ReactivePowerUnit.VoltampereReactive, quantity => quantity);

            // Register in unit converter: ReactivePowerUnit -> BaseUnit
            unitConverter.SetConversionFunction<ReactivePower>(ReactivePowerUnit.GigavoltampereReactive, ReactivePowerUnit.VoltampereReactive, quantity => new ReactivePower((quantity.Value) * 1e9d, ReactivePowerUnit.VoltampereReactive));
            unitConverter.SetConversionFunction<ReactivePower>(ReactivePowerUnit.KilovoltampereReactive, ReactivePowerUnit.VoltampereReactive, quantity => new ReactivePower((quantity.Value) * 1e3d, ReactivePowerUnit.VoltampereReactive));
            unitConverter.SetConversionFunction<ReactivePower>(ReactivePowerUnit.MegavoltampereReactive, ReactivePowerUnit.VoltampereReactive, quantity => new ReactivePower((quantity.Value) * 1e6d, ReactivePowerUnit.VoltampereReactive));
        }

        internal static void MapGeneratedLocalizations(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            unitAbbreviationsCache.PerformAbbreviationMapping(ReactivePowerUnit.GigavoltampereReactive, new CultureInfo("en-US"), false, true, new string[]{"Gvar"});
            unitAbbreviationsCache.PerformAbbreviationMapping(ReactivePowerUnit.KilovoltampereReactive, new CultureInfo("en-US"), false, true, new string[]{"kvar"});
            unitAbbreviationsCache.PerformAbbreviationMapping(ReactivePowerUnit.MegavoltampereReactive, new CultureInfo("en-US"), false, true, new string[]{"Mvar"});
            unitAbbreviationsCache.PerformAbbreviationMapping(ReactivePowerUnit.VoltampereReactive, new CultureInfo("en-US"), false, true, new string[]{"var"});
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(ReactivePowerUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="provider">Format to use for localization. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static string GetAbbreviation(ReactivePowerUnit unit, IFormatProvider? provider)
        {
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="ReactivePower"/> from <see cref="ReactivePowerUnit.GigavoltampereReactive"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReactivePower FromGigavoltamperesReactive(QuantityValue gigavoltamperesreactive)
        {
            double value = (double) gigavoltamperesreactive;
            return new ReactivePower(value, ReactivePowerUnit.GigavoltampereReactive);
        }

        /// <summary>
        ///     Creates a <see cref="ReactivePower"/> from <see cref="ReactivePowerUnit.KilovoltampereReactive"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReactivePower FromKilovoltamperesReactive(QuantityValue kilovoltamperesreactive)
        {
            double value = (double) kilovoltamperesreactive;
            return new ReactivePower(value, ReactivePowerUnit.KilovoltampereReactive);
        }

        /// <summary>
        ///     Creates a <see cref="ReactivePower"/> from <see cref="ReactivePowerUnit.MegavoltampereReactive"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReactivePower FromMegavoltamperesReactive(QuantityValue megavoltamperesreactive)
        {
            double value = (double) megavoltamperesreactive;
            return new ReactivePower(value, ReactivePowerUnit.MegavoltampereReactive);
        }

        /// <summary>
        ///     Creates a <see cref="ReactivePower"/> from <see cref="ReactivePowerUnit.VoltampereReactive"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReactivePower FromVoltamperesReactive(QuantityValue voltamperesreactive)
        {
            double value = (double) voltamperesreactive;
            return new ReactivePower(value, ReactivePowerUnit.VoltampereReactive);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ReactivePowerUnit" /> to <see cref="ReactivePower" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ReactivePower unit value.</returns>
        public static ReactivePower From(QuantityValue value, ReactivePowerUnit fromUnit)
        {
            return new ReactivePower((double)value, fromUnit);
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
        public static ReactivePower Parse(string str)
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
        public static ReactivePower Parse(string str, IFormatProvider? provider)
        {
            return QuantityParser.Default.Parse<ReactivePower, ReactivePowerUnit>(
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
        public static bool TryParse(string? str, out ReactivePower result)
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
        public static bool TryParse(string? str, IFormatProvider? provider, out ReactivePower result)
        {
            return QuantityParser.Default.TryParse<ReactivePower, ReactivePowerUnit>(
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
        public static ReactivePowerUnit ParseUnit(string str)
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
        public static ReactivePowerUnit ParseUnit(string str, IFormatProvider? provider)
        {
            return UnitParser.Default.Parse<ReactivePowerUnit>(str, provider);
        }

        /// <inheritdoc cref="TryParseUnit(string,IFormatProvider,out UnitsNet.Units.ReactivePowerUnit)"/>
        public static bool TryParseUnit(string str, out ReactivePowerUnit unit)
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
        public static bool TryParseUnit(string str, IFormatProvider? provider, out ReactivePowerUnit unit)
        {
            return UnitParser.Default.TryParse<ReactivePowerUnit>(str, provider, out unit);
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static ReactivePower operator -(ReactivePower right)
        {
            return new ReactivePower(-right.Value, right.Unit);
        }

        /// <summary>Get <see cref="ReactivePower"/> from adding two <see cref="ReactivePower"/>.</summary>
        public static ReactivePower operator +(ReactivePower left, ReactivePower right)
        {
            return new ReactivePower(left.Value + right.GetValueAs(left.Unit), left.Unit);
        }

        /// <summary>Get <see cref="ReactivePower"/> from subtracting two <see cref="ReactivePower"/>.</summary>
        public static ReactivePower operator -(ReactivePower left, ReactivePower right)
        {
            return new ReactivePower(left.Value - right.GetValueAs(left.Unit), left.Unit);
        }

        /// <summary>Get <see cref="ReactivePower"/> from multiplying value and <see cref="ReactivePower"/>.</summary>
        public static ReactivePower operator *(double left, ReactivePower right)
        {
            return new ReactivePower(left * right.Value, right.Unit);
        }

        /// <summary>Get <see cref="ReactivePower"/> from multiplying value and <see cref="ReactivePower"/>.</summary>
        public static ReactivePower operator *(ReactivePower left, double right)
        {
            return new ReactivePower(left.Value * right, left.Unit);
        }

        /// <summary>Get <see cref="ReactivePower"/> from dividing <see cref="ReactivePower"/> by value.</summary>
        public static ReactivePower operator /(ReactivePower left, double right)
        {
            return new ReactivePower(left.Value / right, left.Unit);
        }

        /// <summary>Get ratio value from dividing <see cref="ReactivePower"/> by <see cref="ReactivePower"/>.</summary>
        public static double operator /(ReactivePower left, ReactivePower right)
        {
            return left.VoltamperesReactive / right.VoltamperesReactive;
        }

        #endregion

        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=(ReactivePower left, ReactivePower right)
        {
            return left.Value <= right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=(ReactivePower left, ReactivePower right)
        {
            return left.Value >= right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if less than.</summary>
        public static bool operator <(ReactivePower left, ReactivePower right)
        {
            return left.Value < right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >(ReactivePower left, ReactivePower right)
        {
            return left.Value > right.GetValueAs(left.Unit);
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            if (!(obj is ReactivePower objReactivePower)) throw new ArgumentException("Expected type ReactivePower.", nameof(obj));

            return CompareTo(objReactivePower);
        }

        /// <inheritdoc />
        public int CompareTo(ReactivePower other)
        {
            return _value.CompareTo(other.GetValueAs(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another ReactivePower within the given absolute or relative tolerance.
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
        public bool Equals(ReactivePower other, double tolerance, ComparisonType comparisonType)
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
        /// <returns>A hash code for the current ReactivePower.</returns>
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
        public double As(ReactivePowerUnit unit)
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
            if (!(unit is ReactivePowerUnit unitAsReactivePowerUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(ReactivePowerUnit)} is supported.", nameof(unit));

            return ((IQuantity<ReactivePowerUnit>)this).As(unitAsReactivePowerUnit);
        }

        /// <summary>
        ///     Converts this ReactivePower to another ReactivePower with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>A ReactivePower with the specified unit.</returns>
        public ReactivePower ToUnit(ReactivePowerUnit unit)
        {
            return ToUnit(unit, DefaultConversionFunctions);
        }

        /// <summary>
        ///     Converts this ReactivePower to another ReactivePower with the unit representation <paramref name="unit" /> and returns its see <cref name="QuantityValue" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>A ReactivePower with the specified unit.</returns>
        public QuantityValue ToQuantity(ReactivePowerUnit unit)
        {
            return ((IQuantity)ToUnit(unit, DefaultConversionFunctions)).Value;
        }

        /// <summary>
        ///     Converts this ReactivePower to another ReactivePower using the given <paramref name="unitConverter"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to use for the conversion.</param>
        /// <returns>A ReactivePower with the specified unit.</returns>
        public ReactivePower ToUnit(ReactivePowerUnit unit, UnitConverter unitConverter)
        {
            if (Unit == unit)
            {
                // Already in requested units.
                return this;
            }
            else if (unitConverter.TryGetConversionFunction((typeof(ReactivePower), Unit, typeof(ReactivePower), unit), out var conversionFunction))
            {
                // Direct conversion to requested unit found. Return the converted quantity.
                var converted = conversionFunction(this);
                return (ReactivePower)converted;
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
            if (!(unit is ReactivePowerUnit unitAsReactivePowerUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(ReactivePowerUnit)} is supported.", nameof(unit));

            return ToUnit(unitAsReactivePowerUnit, DefaultConversionFunctions);
        }

        /// <inheritdoc cref="IQuantity.ToUnit(UnitSystem)"/>
        public ReactivePower ToUnit(UnitSystem unitSystem)
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
        IQuantity<ReactivePowerUnit> IQuantity<ReactivePowerUnit>.ToUnit(ReactivePowerUnit unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<ReactivePowerUnit> IQuantity<ReactivePowerUnit>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        private double GetValueAs(ReactivePowerUnit unit)
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
            return QuantityFormatter.Format<ReactivePowerUnit>(this, format, provider);
        }

        #endregion

        #region IConvertible Methods

        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(ReactivePower)} to bool is not supported.");
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(ReactivePower)} to char is not supported.");
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(ReactivePower)} to DateTime is not supported.");
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
            if (conversionType == typeof(ReactivePower))
                return this;
            else if (conversionType == typeof(ReactivePowerUnit))
                return Unit;
            else if (conversionType == typeof(QuantityInfo))
                return ReactivePower.Info;
            else if (conversionType == typeof(BaseDimensions))
                return ReactivePower.BaseDimensions;
            else
                throw new InvalidCastException($"Converting {typeof(ReactivePower)} to {conversionType} is not supported.");
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
