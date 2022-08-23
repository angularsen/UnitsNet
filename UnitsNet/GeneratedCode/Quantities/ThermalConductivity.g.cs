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
    ///     Thermal conductivity is the property of a material to conduct heat.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Thermal_Conductivity
    /// </remarks>
    [DataContract]
    public partial struct ThermalConductivity : IQuantity<ThermalConductivityUnit>, IEquatable<ThermalConductivity>, IComparable, IComparable<ThermalConductivity>, IConvertible, IFormattable
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        [DataMember(Name = "Value", Order = 0)]
        private readonly QuantityValue _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        [DataMember(Name = "Unit", Order = 1)]
        private readonly ThermalConductivityUnit? _unit;

        static ThermalConductivity()
        {
            BaseDimensions = new BaseDimensions(1, 1, -3, 0, -1, 0, 0);
            BaseUnit = ThermalConductivityUnit.WattPerMeterKelvin;
            Units = Enum.GetValues(typeof(ThermalConductivityUnit)).Cast<ThermalConductivityUnit>().ToArray();
            Zero = new ThermalConductivity(0, BaseUnit);
            Info = new QuantityInfo<ThermalConductivityUnit>("ThermalConductivity",
                new UnitInfo<ThermalConductivityUnit>[]
                {
                    new UnitInfo<ThermalConductivityUnit>(ThermalConductivityUnit.BtuPerHourFootFahrenheit, "BtusPerHourFootFahrenheit", BaseUnits.Undefined),
                    new UnitInfo<ThermalConductivityUnit>(ThermalConductivityUnit.WattPerMeterKelvin, "WattsPerMeterKelvin", BaseUnits.Undefined),
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
        public ThermalConductivity(QuantityValue value, ThermalConductivityUnit unit)
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
        public ThermalConductivity(QuantityValue value, UnitSystem unitSystem)
        {
            if (unitSystem is null) throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);
            var firstUnitInfo = unitInfos.FirstOrDefault();

            _value = value;
            _unit = firstUnitInfo?.Value ?? throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));
        }

        #region Static Properties

        /// <summary>
        ///     The <see cref="UnitConverter" /> containing the default generated conversion functions for <see cref="ThermalConductivity" /> instances.
        /// </summary>
        public static UnitConverter DefaultConversionFunctions { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        public static QuantityInfo<ThermalConductivityUnit> Info { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions { get; }

        /// <summary>
        ///     The base unit of ThermalConductivity, which is WattPerMeterKelvin. All conversions go via this value.
        /// </summary>
        public static ThermalConductivityUnit BaseUnit { get; }

        /// <summary>
        ///     All units of measurement for the ThermalConductivity quantity.
        /// </summary>
        public static ThermalConductivityUnit[] Units { get; }

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit WattPerMeterKelvin.
        /// </summary>
        public static ThermalConductivity Zero { get; }

        #endregion

        #region Properties

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public QuantityValue Value => _value;

        /// <inheritdoc />
        QuantityValue IQuantity.Value => _value;

        Enum IQuantity.Unit => Unit;

        /// <inheritdoc />
        public ThermalConductivityUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<ThermalConductivityUnit> QuantityInfo => Info;

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        QuantityInfo IQuantity.QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => ThermalConductivity.BaseDimensions;

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Gets the numeric value of this quantity converted into <see cref="ThermalConductivityUnit.BtuPerHourFootFahrenheit"/>
        /// </summary>
        public QuantityValue BtusPerHourFootFahrenheit => As(ThermalConductivityUnit.BtuPerHourFootFahrenheit);

        /// <summary>
        ///     Gets the numeric value of this quantity converted into <see cref="ThermalConductivityUnit.WattPerMeterKelvin"/>
        /// </summary>
        public QuantityValue WattsPerMeterKelvin => As(ThermalConductivityUnit.WattPerMeterKelvin);

        #endregion

        #region Static Methods

        /// <summary>
        /// Registers the default conversion functions in the given <see cref="UnitConverter"/> instance.
        /// </summary>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to register the default conversion functions in.</param>
        internal static void RegisterDefaultConversions(UnitConverter unitConverter)
        {
            // Register in unit converter: BaseUnit -> ThermalConductivityUnit
            unitConverter.SetConversionFunction<ThermalConductivity>(ThermalConductivityUnit.WattPerMeterKelvin, ThermalConductivityUnit.BtuPerHourFootFahrenheit, quantity => new ThermalConductivity(quantity.Value / 1.73073467, ThermalConductivityUnit.BtuPerHourFootFahrenheit));

            // Register in unit converter: BaseUnit <-> BaseUnit
            unitConverter.SetConversionFunction<ThermalConductivity>(ThermalConductivityUnit.WattPerMeterKelvin, ThermalConductivityUnit.WattPerMeterKelvin, quantity => quantity);

            // Register in unit converter: ThermalConductivityUnit -> BaseUnit
            unitConverter.SetConversionFunction<ThermalConductivity>(ThermalConductivityUnit.BtuPerHourFootFahrenheit, ThermalConductivityUnit.WattPerMeterKelvin, quantity => new ThermalConductivity(quantity.Value * 1.73073467, ThermalConductivityUnit.WattPerMeterKelvin));
        }

        internal static void MapGeneratedLocalizations(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            unitAbbreviationsCache.PerformAbbreviationMapping(ThermalConductivityUnit.BtuPerHourFootFahrenheit, new CultureInfo("en-US"), false, true, new string[]{"BTU/h·ft·°F"});
            unitAbbreviationsCache.PerformAbbreviationMapping(ThermalConductivityUnit.WattPerMeterKelvin, new CultureInfo("en-US"), false, true, new string[]{"W/m·K"});
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(ThermalConductivityUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="provider">Format to use for localization. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static string GetAbbreviation(ThermalConductivityUnit unit, IFormatProvider? provider)
        {
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="ThermalConductivity"/> from <see cref="ThermalConductivityUnit.BtuPerHourFootFahrenheit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ThermalConductivity FromBtusPerHourFootFahrenheit(QuantityValue btusperhourfootfahrenheit)
        {
            QuantityValue value = (QuantityValue) btusperhourfootfahrenheit;
            return new ThermalConductivity(value, ThermalConductivityUnit.BtuPerHourFootFahrenheit);
        }

        /// <summary>
        ///     Creates a <see cref="ThermalConductivity"/> from <see cref="ThermalConductivityUnit.WattPerMeterKelvin"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ThermalConductivity FromWattsPerMeterKelvin(QuantityValue wattspermeterkelvin)
        {
            QuantityValue value = (QuantityValue) wattspermeterkelvin;
            return new ThermalConductivity(value, ThermalConductivityUnit.WattPerMeterKelvin);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ThermalConductivityUnit" /> to <see cref="ThermalConductivity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ThermalConductivity unit value.</returns>
        public static ThermalConductivity From(QuantityValue value, ThermalConductivityUnit fromUnit)
        {
            return new ThermalConductivity((QuantityValue)value, fromUnit);
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
        public static ThermalConductivity Parse(string str)
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
        public static ThermalConductivity Parse(string str, IFormatProvider? provider)
        {
            return QuantityParser.Default.Parse<ThermalConductivity, ThermalConductivityUnit>(
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
        public static bool TryParse(string? str, out ThermalConductivity result)
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
        public static bool TryParse(string? str, IFormatProvider? provider, out ThermalConductivity result)
        {
            return QuantityParser.Default.TryParse<ThermalConductivity, ThermalConductivityUnit>(
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
        public static ThermalConductivityUnit ParseUnit(string str)
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
        public static ThermalConductivityUnit ParseUnit(string str, IFormatProvider? provider)
        {
            return UnitParser.Default.Parse<ThermalConductivityUnit>(str, provider);
        }

        /// <inheritdoc cref="TryParseUnit(string,IFormatProvider,out UnitsNet.Units.ThermalConductivityUnit)"/>
        public static bool TryParseUnit(string str, out ThermalConductivityUnit unit)
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
        public static bool TryParseUnit(string str, IFormatProvider? provider, out ThermalConductivityUnit unit)
        {
            return UnitParser.Default.TryParse<ThermalConductivityUnit>(str, provider, out unit);
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static ThermalConductivity operator -(ThermalConductivity right)
        {
            return new ThermalConductivity(-right.Value, right.Unit);
        }

        /// <summary>Get <see cref="ThermalConductivity"/> from adding two <see cref="ThermalConductivity"/>.</summary>
        public static ThermalConductivity operator +(ThermalConductivity left, ThermalConductivity right)
        {
            return new ThermalConductivity(left.Value + right.GetValueAs(left.Unit), left.Unit);
        }

        /// <summary>Get <see cref="ThermalConductivity"/> from subtracting two <see cref="ThermalConductivity"/>.</summary>
        public static ThermalConductivity operator -(ThermalConductivity left, ThermalConductivity right)
        {
            return new ThermalConductivity(left.Value - right.GetValueAs(left.Unit), left.Unit);
        }

        /// <summary>Get <see cref="ThermalConductivity"/> from multiplying value and <see cref="ThermalConductivity"/>.</summary>
        public static ThermalConductivity operator *(QuantityValue left, ThermalConductivity right)
        {
            return new ThermalConductivity(left * right.Value, right.Unit);
        }

        /// <summary>Get <see cref="ThermalConductivity"/> from multiplying value and <see cref="ThermalConductivity"/>.</summary>
        public static ThermalConductivity operator *(ThermalConductivity left, QuantityValue right)
        {
            return new ThermalConductivity(left.Value * right, left.Unit);
        }

        /// <summary>Get <see cref="ThermalConductivity"/> from dividing <see cref="ThermalConductivity"/> by value.</summary>
        public static ThermalConductivity operator /(ThermalConductivity left, QuantityValue right)
        {
            return new ThermalConductivity(left.Value / right, left.Unit);
        }

        /// <summary>Get ratio value from dividing <see cref="ThermalConductivity"/> by <see cref="ThermalConductivity"/>.</summary>
        public static QuantityValue operator /(ThermalConductivity left, ThermalConductivity right)
        {
            return left.WattsPerMeterKelvin / right.WattsPerMeterKelvin;
        }

        #endregion

        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=(ThermalConductivity left, ThermalConductivity right)
        {
            return left.Value <= right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=(ThermalConductivity left, ThermalConductivity right)
        {
            return left.Value >= right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if less than.</summary>
        public static bool operator <(ThermalConductivity left, ThermalConductivity right)
        {
            return left.Value < right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >(ThermalConductivity left, ThermalConductivity right)
        {
            return left.Value > right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if exactly equal.</summary>
        /// <remarks>Consider using <see cref="Equals(ThermalConductivity, QuantityValue, ComparisonType)"/> for safely comparing floating point values.</remarks>
        public static bool operator ==(ThermalConductivity left, ThermalConductivity right)
        {
            return left.Equals(right);
        }
        /// <summary>Returns true if not exactly equal.</summary>
        /// <remarks>Consider using <see cref="Equals(ThermalConductivity, QuantityValue, ComparisonType)"/> for safely comparing floating point values.</remarks>
        public static bool operator !=(ThermalConductivity left, ThermalConductivity right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            if (!(obj is ThermalConductivity objThermalConductivity)) throw new ArgumentException("Expected type ThermalConductivity.", nameof(obj));

            return CompareTo(objThermalConductivity);
        }

        /// <inheritdoc />
        public int CompareTo(ThermalConductivity other)
        {
            var asFirstUnit = other.GetValueAs(this.Unit);
            var asSecondUnit = GetValueAs(other.Unit);
            return (_value.CompareTo(asFirstUnit) - other.Value.CompareTo(asSecondUnit)) / 2;
        }

        /// <inheritdoc />
        /// <remarks>Consider using <see cref="Equals(ThermalConductivity, QuantityValue, ComparisonType)"/> for safely comparing floating point values.</remarks>
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is ThermalConductivity objThermalConductivity))
                return false;
            return Equals(objThermalConductivity);
        }

        /// <inheritdoc />
        /// <remarks>Consider using <see cref="Equals(ThermalConductivity, QuantityValue, ComparisonType)"/> for safely comparing floating point values.</remarks>
        public bool Equals(ThermalConductivity other)
        {
            if (Value.IsDecimal)
                return other.Value.Equals(this.GetValueAs(other.Unit));
            if (other.Value.IsDecimal)
                return Value.Equals(other.GetValueAs(this.Unit));
            return this.Unit == other.Unit && this.Value.Equals(other.Value);
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another ThermalConductivity within the given absolute or relative tolerance.
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
        public bool Equals(ThermalConductivity other, QuantityValue tolerance, ComparisonType comparisonType)
        {
            if (tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0.");

            QuantityValue thisValue = this.Value;
            QuantityValue otherValueInThisUnits = other.As(this.Unit);

            return UnitsNet.Comparison.Equals(thisValue, otherValueInThisUnits, tolerance, comparisonType);
        }

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current ThermalConductivity.</returns>
        public override int GetHashCode()
        {
            return Info.Name.GetHashCode();
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public QuantityValue As(ThermalConductivityUnit unit)
        {
            if(Unit == unit)
                return Value;

            return GetValueAs(unit);
        }

        /// <inheritdoc cref="IQuantity.As(UnitSystem)"/>
        public QuantityValue As(UnitSystem unitSystem)
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
        QuantityValue IQuantity.As(Enum unit)
        {
            if (!(unit is ThermalConductivityUnit typedUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(ThermalConductivityUnit)} is supported.", nameof(unit));

            return (QuantityValue)As(typedUnit);
        }

        /// <summary>
        ///     Converts this ThermalConductivity to another ThermalConductivity with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>A ThermalConductivity with the specified unit.</returns>
        public ThermalConductivity ToUnit(ThermalConductivityUnit unit)
        {
            return ToUnit(unit, DefaultConversionFunctions);
        }

        /// <summary>
        ///     Converts this ThermalConductivity to another ThermalConductivity using the given <paramref name="unitConverter"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to use for the conversion.</param>
        /// <returns>A ThermalConductivity with the specified unit.</returns>
        public ThermalConductivity ToUnit(ThermalConductivityUnit unit, UnitConverter unitConverter)
        {
            if (Unit == unit)
            {
                // Already in requested units.
                return this;
            }
            else if (unitConverter.TryGetConversionFunction((typeof(ThermalConductivity), Unit, typeof(ThermalConductivity), unit), out var conversionFunction))
            {
                // Direct conversion to requested unit found. Return the converted quantity.
                var converted = conversionFunction(this);
                return (ThermalConductivity)converted;
            }
            else if (Enum.IsDefined(typeof(ThermalConductivityUnit), unit))
            {
                // Direct conversion to requested unit NOT found. Convert to BaseUnit, and then from BaseUnit to requested unit.
                var inBaseUnits = ToUnit(BaseUnit);
                return inBaseUnits.ToUnit(unit);
            }
            else
            {
                throw new NotSupportedException($"Can not convert {Unit} to {unit}.");
            }
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(Enum unit)
        {
            if (!(unit is ThermalConductivityUnit typedUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(ThermalConductivityUnit)} is supported.", nameof(unit));

            return ToUnit(typedUnit, DefaultConversionFunctions);
        }

        /// <inheritdoc cref="IQuantity.ToUnit(UnitSystem)"/>
        public ThermalConductivity ToUnit(UnitSystem unitSystem)
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
        IQuantity<ThermalConductivityUnit> IQuantity<ThermalConductivityUnit>.ToUnit(ThermalConductivityUnit unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<ThermalConductivityUnit> IQuantity<ThermalConductivityUnit>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        private QuantityValue GetValueAs(ThermalConductivityUnit unit)
        {
            var converted = ToUnit(unit);
            return (QuantityValue)converted.Value;
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
            return QuantityFormatter.Format<ThermalConductivityUnit>(this, format, provider);
        }

        #endregion

        #region IConvertible Methods

        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(ThermalConductivity)} to bool is not supported.");
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(ThermalConductivity)} to char is not supported.");
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(ThermalConductivity)} to DateTime is not supported.");
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
            if (conversionType == typeof(ThermalConductivity))
                return this;
            else if (conversionType == typeof(ThermalConductivityUnit))
                return Unit;
            else if (conversionType == typeof(QuantityInfo))
                return ThermalConductivity.Info;
            else if (conversionType == typeof(BaseDimensions))
                return ThermalConductivity.BaseDimensions;
            else
                throw new InvalidCastException($"Converting {typeof(ThermalConductivity)} to {conversionType} is not supported.");
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
