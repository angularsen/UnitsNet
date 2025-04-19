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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using UnitsNet.Units;
#if NET
using System.Numerics;
#endif

#nullable enable

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <inheritdoc />
    /// <summary>
    ///     In electromagnetism, charge density is a measure of the amount of electric charge per volume.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Charge_density
    /// </remarks>
    [DataContract]
    [DebuggerTypeProxy(typeof(QuantityDisplay))]
    public readonly partial struct ElectricChargeDensity :
        IArithmeticQuantity<ElectricChargeDensity, ElectricChargeDensityUnit>,
#if NET7_0_OR_GREATER
        IComparisonOperators<ElectricChargeDensity, ElectricChargeDensity, bool>,
        IParsable<ElectricChargeDensity>,
#endif
        IComparable,
        IComparable<ElectricChargeDensity>,
        IEquatable<ElectricChargeDensity>,
        IFormattable
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        [DataMember(Name = "Value", Order = 1)]
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        [DataMember(Name = "Unit", Order = 2)]
        private readonly ElectricChargeDensityUnit? _unit;

        static ElectricChargeDensity()
        {
            BaseDimensions = new BaseDimensions(-3, 0, 1, 1, 0, 0, 0);
            BaseUnit = ElectricChargeDensityUnit.CoulombPerCubicMeter;
            Units = Enum.GetValues(typeof(ElectricChargeDensityUnit)).Cast<ElectricChargeDensityUnit>().ToArray();
            Zero = new ElectricChargeDensity(0, BaseUnit);
            Info = new QuantityInfo<ElectricChargeDensityUnit>("ElectricChargeDensity",
                new UnitInfo<ElectricChargeDensityUnit>[]
                {
                    new UnitInfo<ElectricChargeDensityUnit>(ElectricChargeDensityUnit.CoulombPerCubicMeter, "CoulombsPerCubicMeter", new BaseUnits(length: LengthUnit.Meter, time: DurationUnit.Second, current: ElectricCurrentUnit.Ampere), "ElectricChargeDensity"),
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
        public ElectricChargeDensity(double value, ElectricChargeDensityUnit unit)
        {
            _value = value;
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
        public ElectricChargeDensity(double value, UnitSystem unitSystem)
        {
            _value = value;
            _unit = Info.GetDefaultUnit(unitSystem);
        }

        #region Static Properties

        /// <summary>
        ///     The <see cref="UnitConverter" /> containing the default generated conversion functions for <see cref="ElectricChargeDensity" /> instances.
        /// </summary>
        public static UnitConverter DefaultConversionFunctions { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        public static QuantityInfo<ElectricChargeDensityUnit> Info { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions { get; }

        /// <summary>
        ///     The base unit of ElectricChargeDensity, which is CoulombPerCubicMeter. All conversions go via this value.
        /// </summary>
        public static ElectricChargeDensityUnit BaseUnit { get; }

        /// <summary>
        ///     All units of measurement for the ElectricChargeDensity quantity.
        /// </summary>
        public static ElectricChargeDensityUnit[] Units { get; }

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit CoulombPerCubicMeter.
        /// </summary>
        public static ElectricChargeDensity Zero { get; }

        /// <inheritdoc cref="Zero"/>
        public static ElectricChargeDensity AdditiveIdentity => Zero;

        #endregion

        #region Properties

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public ElectricChargeDensityUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<ElectricChargeDensityUnit> QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => ElectricChargeDensity.BaseDimensions;

        #region Explicit implementations

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Enum IQuantity.Unit => Unit;
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        UnitKey IQuantity.UnitKey => UnitKey.ForUnit(Unit);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        QuantityInfo IQuantity.QuantityInfo => Info;

        #endregion

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricChargeDensityUnit.CoulombPerCubicMeter"/>
        /// </summary>
        public double CoulombsPerCubicMeter => As(ElectricChargeDensityUnit.CoulombPerCubicMeter);

        #endregion

        #region Static Methods

        /// <summary>
        /// Registers the default conversion functions in the given <see cref="UnitConverter"/> instance.
        /// </summary>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to register the default conversion functions in.</param>
        internal static void RegisterDefaultConversions(UnitConverter unitConverter)
        {
            // Register in unit converter: ElectricChargeDensityUnit -> BaseUnit

            // Register in unit converter: BaseUnit <-> BaseUnit
            unitConverter.SetConversionFunction<ElectricChargeDensity>(ElectricChargeDensityUnit.CoulombPerCubicMeter, ElectricChargeDensityUnit.CoulombPerCubicMeter, quantity => quantity);

            // Register in unit converter: BaseUnit -> ElectricChargeDensityUnit
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(ElectricChargeDensityUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="provider">Format to use for localization. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static string GetAbbreviation(ElectricChargeDensityUnit unit, IFormatProvider? provider)
        {
            return UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="ElectricChargeDensity"/> from <see cref="ElectricChargeDensityUnit.CoulombPerCubicMeter"/>.
        /// </summary>
        public static ElectricChargeDensity FromCoulombsPerCubicMeter(double value)
        {
            return new ElectricChargeDensity(value, ElectricChargeDensityUnit.CoulombPerCubicMeter);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricChargeDensityUnit" /> to <see cref="ElectricChargeDensity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricChargeDensity unit value.</returns>
        public static ElectricChargeDensity From(double value, ElectricChargeDensityUnit fromUnit)
        {
            return new ElectricChargeDensity(value, fromUnit);
        }

        #endregion

        #region Static Parse Methods

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <example>
        ///     Length.Parse("5.5 m", CultureInfo.GetCultureInfo("en-US"));
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
        public static ElectricChargeDensity Parse(string str)
        {
            return Parse(str, null);
        }

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <example>
        ///     Length.Parse("5.5 m", CultureInfo.GetCultureInfo("en-US"));
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
        public static ElectricChargeDensity Parse(string str, IFormatProvider? provider)
        {
            return UnitsNetSetup.Default.QuantityParser.Parse<ElectricChargeDensity, ElectricChargeDensityUnit>(
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
        ///     Length.Parse("5.5 m", CultureInfo.GetCultureInfo("en-US"));
        /// </example>
        public static bool TryParse([NotNullWhen(true)]string? str, out ElectricChargeDensity result)
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
        ///     Length.Parse("5.5 m", CultureInfo.GetCultureInfo("en-US"));
        /// </example>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static bool TryParse([NotNullWhen(true)]string? str, IFormatProvider? provider, out ElectricChargeDensity result)
        {
            return UnitsNetSetup.Default.QuantityParser.TryParse<ElectricChargeDensity, ElectricChargeDensityUnit>(
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
        ///     Length.ParseUnit("m", CultureInfo.GetCultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static ElectricChargeDensityUnit ParseUnit(string str)
        {
            return ParseUnit(str, null);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <example>
        ///     Length.ParseUnit("m", CultureInfo.GetCultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static ElectricChargeDensityUnit ParseUnit(string str, IFormatProvider? provider)
        {
            return UnitParser.Default.Parse(str, Info.UnitInfos, provider).Value;
        }

        /// <inheritdoc cref="TryParseUnit(string,IFormatProvider,out UnitsNet.Units.ElectricChargeDensityUnit)"/>
        public static bool TryParseUnit([NotNullWhen(true)]string? str, out ElectricChargeDensityUnit unit)
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
        ///     Length.TryParseUnit("m", CultureInfo.GetCultureInfo("en-US"));
        /// </example>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static bool TryParseUnit([NotNullWhen(true)]string? str, IFormatProvider? provider, out ElectricChargeDensityUnit unit)
        {
            return UnitParser.Default.TryParse(str, Info, provider, out unit);
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static ElectricChargeDensity operator -(ElectricChargeDensity right)
        {
            return new ElectricChargeDensity(-right.Value, right.Unit);
        }

        /// <summary>Get <see cref="ElectricChargeDensity"/> from adding two <see cref="ElectricChargeDensity"/>.</summary>
        public static ElectricChargeDensity operator +(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return new ElectricChargeDensity(left.Value + right.ToUnit(left.Unit).Value, left.Unit);
        }

        /// <summary>Get <see cref="ElectricChargeDensity"/> from subtracting two <see cref="ElectricChargeDensity"/>.</summary>
        public static ElectricChargeDensity operator -(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return new ElectricChargeDensity(left.Value - right.ToUnit(left.Unit).Value, left.Unit);
        }

        /// <summary>Get <see cref="ElectricChargeDensity"/> from multiplying value and <see cref="ElectricChargeDensity"/>.</summary>
        public static ElectricChargeDensity operator *(double left, ElectricChargeDensity right)
        {
            return new ElectricChargeDensity(left * right.Value, right.Unit);
        }

        /// <summary>Get <see cref="ElectricChargeDensity"/> from multiplying value and <see cref="ElectricChargeDensity"/>.</summary>
        public static ElectricChargeDensity operator *(ElectricChargeDensity left, double right)
        {
            return new ElectricChargeDensity(left.Value * right, left.Unit);
        }

        /// <summary>Get <see cref="ElectricChargeDensity"/> from dividing <see cref="ElectricChargeDensity"/> by value.</summary>
        public static ElectricChargeDensity operator /(ElectricChargeDensity left, double right)
        {
            return new ElectricChargeDensity(left.Value / right, left.Unit);
        }

        /// <summary>Get ratio value from dividing <see cref="ElectricChargeDensity"/> by <see cref="ElectricChargeDensity"/>.</summary>
        public static double operator /(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return left.CoulombsPerCubicMeter / right.CoulombsPerCubicMeter;
        }

        #endregion

        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return left.Value <= right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return left.Value >= right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if less than.</summary>
        public static bool operator <(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return left.Value < right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return left.Value > right.ToUnit(left.Unit).Value;
        }

        // We use obsolete attribute to communicate the preferred equality members to use.
        // CS0809: Obsolete member 'memberA' overrides non-obsolete member 'memberB'.
        #pragma warning disable CS0809

        /// <summary>Indicates strict equality of two <see cref="ElectricChargeDensity"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("For null checks, use `x is null` syntax to not invoke overloads. For equality checks, use Equals(ElectricChargeDensity other, ElectricChargeDensity tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public static bool operator ==(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return left.Equals(right);
        }

        /// <summary>Indicates strict inequality of two <see cref="ElectricChargeDensity"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("For null checks, use `x is null` syntax to not invoke overloads. For equality checks, use Equals(ElectricChargeDensity other, ElectricChargeDensity tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public static bool operator !=(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        /// <summary>Indicates strict equality of two <see cref="ElectricChargeDensity"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("Use Equals(ElectricChargeDensity other, ElectricChargeDensity tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is ElectricChargeDensity otherQuantity))
                return false;

            return Equals(otherQuantity);
        }

        /// <inheritdoc />
        /// <summary>Indicates strict equality of two <see cref="ElectricChargeDensity"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("Use Equals(ElectricChargeDensity other, ElectricChargeDensity tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public bool Equals(ElectricChargeDensity other)
        {
            return new { Value, Unit }.Equals(new { other.Value, other.Unit });
        }

        #pragma warning restore CS0809

        /// <summary>Compares the current <see cref="ElectricChargeDensity"/> with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other when converted to the same unit.</summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <exception cref="T:System.ArgumentException">
        ///    <paramref name="obj" /> is not the same type as this instance.
        /// </exception>
        /// <returns>A value that indicates the relative order of the quantities being compared. The return value has these meanings:
        ///     <list type="table">
        ///         <listheader><term> Value</term><description> Meaning</description></listheader>
        ///         <item><term> Less than zero</term><description> This instance precedes <paramref name="obj" /> in the sort order.</description></item>
        ///         <item><term> Zero</term><description> This instance occurs in the same position in the sort order as <paramref name="obj" />.</description></item>
        ///         <item><term> Greater than zero</term><description> This instance follows <paramref name="obj" /> in the sort order.</description></item>
        ///     </list>
        /// </returns>
        public int CompareTo(object? obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            if (!(obj is ElectricChargeDensity otherQuantity)) throw new ArgumentException("Expected type ElectricChargeDensity.", nameof(obj));

            return CompareTo(otherQuantity);
        }

        /// <summary>Compares the current <see cref="ElectricChargeDensity"/> with another <see cref="ElectricChargeDensity"/> and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other when converted to the same unit.</summary>
        /// <param name="other">A quantity to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the quantities being compared. The return value has these meanings:
        ///     <list type="table">
        ///         <listheader><term> Value</term><description> Meaning</description></listheader>
        ///         <item><term> Less than zero</term><description> This instance precedes <paramref name="other" /> in the sort order.</description></item>
        ///         <item><term> Zero</term><description> This instance occurs in the same position in the sort order as <paramref name="other" />.</description></item>
        ///         <item><term> Greater than zero</term><description> This instance follows <paramref name="other" /> in the sort order.</description></item>
        ///     </list>
        /// </returns>
        public int CompareTo(ElectricChargeDensity other)
        {
            return _value.CompareTo(other.ToUnit(this.Unit).Value);
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another ElectricChargeDensity within the given absolute or relative tolerance.
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
        ///     of floating-point operations and using double internally.
        ///     </para>
        /// </summary>
        /// <param name="other">The other quantity to compare to.</param>
        /// <param name="tolerance">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
        /// <param name="comparisonType">The comparison type: either relative or absolute.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified relative or absolute tolerance.</returns>
        [Obsolete("Use Equals(ElectricChargeDensity other, ElectricChargeDensity tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public bool Equals(ElectricChargeDensity other, double tolerance, ComparisonType comparisonType)
        {
            if (tolerance < 0)
                throw new ArgumentOutOfRangeException(nameof(tolerance), "Tolerance must be greater than or equal to 0.");

            return UnitsNet.Comparison.Equals(
                referenceValue: this.Value,
                otherValue: other.As(this.Unit),
                tolerance: tolerance,
                comparisonType: comparisonType);
        }

        /// <inheritdoc />
        public bool Equals(IQuantity? other, IQuantity tolerance)
        {
            return other is ElectricChargeDensity otherTyped
                   && (tolerance is ElectricChargeDensity toleranceTyped
                       ? true
                       : throw new ArgumentException($"Tolerance quantity ({tolerance.QuantityInfo.Name}) did not match the other quantities of type 'ElectricChargeDensity'.", nameof(tolerance)))
                   && Equals(otherTyped, toleranceTyped);
        }

        /// <inheritdoc />
        public bool Equals(ElectricChargeDensity other, ElectricChargeDensity tolerance)
        {
            return UnitsNet.Comparison.Equals(
                referenceValue: this.Value,
                otherValue: other.As(this.Unit),
                tolerance: tolerance.As(this.Unit),
                comparisonType: ComparisonType.Absolute);
        }

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current ElectricChargeDensity.</returns>
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
        public double As(ElectricChargeDensityUnit unit)
        {
            if (Unit == unit)
                return Value;

            return ToUnit(unit).Value;
        }

        /// <inheritdoc cref="IQuantity.As(UnitSystem)"/>
        public double As(UnitSystem unitSystem)
        {
            return As(Info.GetDefaultUnit(unitSystem));
        }

        /// <summary>
        ///     Converts this ElectricChargeDensity to another ElectricChargeDensity with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>A ElectricChargeDensity with the specified unit.</returns>
        public ElectricChargeDensity ToUnit(ElectricChargeDensityUnit unit)
        {
            return ToUnit(unit, DefaultConversionFunctions);
        }

        /// <summary>
        ///     Converts this <see cref="ElectricChargeDensity"/> to another <see cref="ElectricChargeDensity"/> using the given <paramref name="unitConverter"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to use for the conversion.</param>
        /// <returns>A ElectricChargeDensity with the specified unit.</returns>
        public ElectricChargeDensity ToUnit(ElectricChargeDensityUnit unit, UnitConverter unitConverter)
        {
            if (TryToUnit(unit, out var converted))
            {
                // Try to convert using the auto-generated conversion methods.
                return converted!.Value;
            }
            else if (unitConverter.TryGetConversionFunction((typeof(ElectricChargeDensity), Unit, typeof(ElectricChargeDensity), unit), out var conversionFunction))
            {
                // See if the unit converter has an extensibility conversion registered.
                return (ElectricChargeDensity)conversionFunction(this);
            }
            else if (Unit != BaseUnit)
            {
                // Conversion to requested unit NOT found. Try to convert to BaseUnit, and then from BaseUnit to requested unit.
                var inBaseUnits = ToUnit(BaseUnit);
                return inBaseUnits.ToUnit(unit);
            }
            else
            {
                // No possible conversion
                throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }

        /// <summary>
        ///     Attempts to convert this <see cref="ElectricChargeDensity"/> to another <see cref="ElectricChargeDensity"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="converted">The converted <see cref="ElectricChargeDensity"/> in <paramref name="unit"/>, if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        private bool TryToUnit(ElectricChargeDensityUnit unit, [NotNullWhen(true)] out ElectricChargeDensity? converted)
        {
            if (Unit == unit)
            {
                converted = this;
                return true;
            }

            ElectricChargeDensity? convertedOrNull = (Unit, unit) switch
            {
                // ElectricChargeDensityUnit -> BaseUnit

                // BaseUnit -> ElectricChargeDensityUnit

                _ => null
            };

            if (convertedOrNull is null)
            {
                converted = default;
                return false;
            }

            converted = convertedOrNull.Value;
            return true;
        }

        /// <inheritdoc cref="IQuantity.ToUnit(UnitSystem)"/>
        public ElectricChargeDensity ToUnit(UnitSystem unitSystem)
        {
            return ToUnit(Info.GetDefaultUnit(unitSystem));
        }

        #region Explicit implementations

        double IQuantity.As(Enum unit)
        {
            if (unit is not ElectricChargeDensityUnit typedUnit)
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(ElectricChargeDensityUnit)} is supported.", nameof(unit));

            return As(typedUnit);
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(Enum unit)
        {
            if (!(unit is ElectricChargeDensityUnit typedUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(ElectricChargeDensityUnit)} is supported.", nameof(unit));

            return ToUnit(typedUnit, DefaultConversionFunctions);
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <inheritdoc />
        IQuantity<ElectricChargeDensityUnit> IQuantity<ElectricChargeDensityUnit>.ToUnit(ElectricChargeDensityUnit unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<ElectricChargeDensityUnit> IQuantity<ElectricChargeDensityUnit>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        #endregion

        #endregion

        #region ToString Methods

        /// <summary>
        ///     Gets the default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(null, null);
        }

        /// <inheritdoc cref="QuantityFormatter.Format{TQuantity}(TQuantity, string?, IFormatProvider?)"/>
        /// <summary>
        /// Gets the string representation of this instance in the specified format string using the specified format provider, or <see cref="CultureInfo.CurrentCulture" /> if null.
        /// </summary>
        public string ToString(string? format, IFormatProvider? provider)
        {
            return QuantityFormatter.Default.Format(this, format, provider);
        }

        #endregion

    }
}
