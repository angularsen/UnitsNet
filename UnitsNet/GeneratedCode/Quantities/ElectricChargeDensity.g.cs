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
    ///     In electromagnetism, charge density is a measure of the amount of electric charge per volume.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Charge_density
    /// </remarks>
    [DataContract]
    public partial struct ElectricChargeDensity : IQuantity<ElectricChargeDensityUnit>, IComparable, IComparable<ElectricChargeDensity>, IConvertible, IFormattable
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
                    new UnitInfo<ElectricChargeDensityUnit>(ElectricChargeDensityUnit.CoulombPerCubicMeter, "CoulombsPerCubicMeter", new BaseUnits(length: LengthUnit.Meter, time: DurationUnit.Second, current: ElectricCurrentUnit.Ampere)),
                },
                BaseUnit, Zero, BaseDimensions);

            RegisterDefaultConversions(DefaultConversionFunctions);
        }

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public ElectricChargeDensity(double value, ElectricChargeDensityUnit unit)
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
        public ElectricChargeDensity(double value, UnitSystem unitSystem)
        {
            if(unitSystem is null) throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);
            var firstUnitInfo = unitInfos.FirstOrDefault();

            _value = Guard.EnsureValidNumber(value, nameof(value));
            _unit = firstUnitInfo?.Value ?? throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));
        }

        #region Static Properties

        /// <summary>
        ///     The <see cref="UnitConverter" /> containing the default generated conversion functions for <see cref="ElectricChargeDensity" /> instances.
        /// </summary>
        public static UnitConverter DefaultConversionFunctions { get; } = new UnitConverter();

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

        #endregion

        #region Properties

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        Enum IQuantity.Unit => Unit;

        /// <inheritdoc />
        public ElectricChargeDensityUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<ElectricChargeDensityUnit> QuantityInfo => Info;

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        QuantityInfo IQuantity.QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => ElectricChargeDensity.BaseDimensions;

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Get ElectricChargeDensity in CoulombsPerCubicMeter.
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
            // Register in unit converter: BaseUnit -> ElectricChargeDensityUnit
            // Register in unit converter: BaseUnit <-> BaseUnit
            unitConverter.SetConversionFunction<ElectricChargeDensity>(ElectricChargeDensityUnit.CoulombPerCubicMeter, ElectricChargeDensityUnit.CoulombPerCubicMeter, quantity => quantity);

            // Register in unit converter: ElectricChargeDensityUnit -> BaseUnit
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
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Get ElectricChargeDensity from CoulombsPerCubicMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricChargeDensity FromCoulombsPerCubicMeter(QuantityValue coulombspercubicmeter)
        {
            double value = (double) coulombspercubicmeter;
            return new ElectricChargeDensity(value, ElectricChargeDensityUnit.CoulombPerCubicMeter);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricChargeDensityUnit" /> to <see cref="ElectricChargeDensity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricChargeDensity unit value.</returns>
        public static ElectricChargeDensity From(QuantityValue value, ElectricChargeDensityUnit fromUnit)
        {
            return new ElectricChargeDensity((double)value, fromUnit);
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
        public static ElectricChargeDensity Parse(string str)
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
        public static ElectricChargeDensity Parse(string str, IFormatProvider? provider)
        {
            return QuantityParser.Default.Parse<ElectricChargeDensity, ElectricChargeDensityUnit>(
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
        public static bool TryParse(string? str, out ElectricChargeDensity result)
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
        public static bool TryParse(string? str, IFormatProvider? provider, out ElectricChargeDensity result)
        {
            return QuantityParser.Default.TryParse<ElectricChargeDensity, ElectricChargeDensityUnit>(
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
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static ElectricChargeDensityUnit ParseUnit(string str, IFormatProvider? provider)
        {
            return UnitParser.Default.Parse<ElectricChargeDensityUnit>(str, provider);
        }

        /// <inheritdoc cref="TryParseUnit(string,IFormatProvider,out UnitsNet.Units.ElectricChargeDensityUnit)"/>
        public static bool TryParseUnit(string str, out ElectricChargeDensityUnit unit)
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
        public static bool TryParseUnit(string str, IFormatProvider? provider, out ElectricChargeDensityUnit unit)
        {
            return UnitParser.Default.TryParse<ElectricChargeDensityUnit>(str, provider, out unit);
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
            return new ElectricChargeDensity(left.Value + right.GetValueAs(left.Unit), left.Unit);
        }

        /// <summary>Get <see cref="ElectricChargeDensity"/> from subtracting two <see cref="ElectricChargeDensity"/>.</summary>
        public static ElectricChargeDensity operator -(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return new ElectricChargeDensity(left.Value - right.GetValueAs(left.Unit), left.Unit);
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
            return left.Value <= right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return left.Value >= right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if less than.</summary>
        public static bool operator <(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return left.Value < right.GetValueAs(left.Unit);
        }

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >(ElectricChargeDensity left, ElectricChargeDensity right)
        {
            return left.Value > right.GetValueAs(left.Unit);
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if(obj is null) throw new ArgumentNullException(nameof(obj));
            if(!(obj is ElectricChargeDensity objElectricChargeDensity)) throw new ArgumentException("Expected type ElectricChargeDensity.", nameof(obj));

            return CompareTo(objElectricChargeDensity);
        }

        /// <inheritdoc />
        public int CompareTo(ElectricChargeDensity other)
        {
            return _value.CompareTo(other.GetValueAs(this.Unit));
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
        ///     of floating point operations and using System.Double internally.
        ///     </para>
        /// </summary>
        /// <param name="other">The other quantity to compare to.</param>
        /// <param name="tolerance">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
        /// <param name="comparisonType">The comparison type: either relative or absolute.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified relative or absolute tolerance.</returns>
        public bool Equals(ElectricChargeDensity other, double tolerance, ComparisonType comparisonType)
        {
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0.");

            double thisValue = (double)this.Value;
            double otherValueInThisUnits = other.As(this.Unit);

            return UnitsNet.Comparison.Equals(thisValue, otherValueInThisUnits, tolerance, comparisonType);
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
            if(Unit == unit)
                return Convert.ToDouble(Value);

            var converted = GetValueAs(unit);
            return Convert.ToDouble(converted);
        }

        /// <inheritdoc cref="IQuantity.As(UnitSystem)"/>
        public double As(UnitSystem unitSystem)
        {
            if(unitSystem is null)
                throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);

            var firstUnitInfo = unitInfos.FirstOrDefault();
            if(firstUnitInfo == null)
                throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));

            return As(firstUnitInfo.Value);
        }

        /// <inheritdoc />
        double IQuantity.As(Enum unit)
        {
            if(!(unit is ElectricChargeDensityUnit unitAsElectricChargeDensityUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(ElectricChargeDensityUnit)} is supported.", nameof(unit));

            return As(unitAsElectricChargeDensityUnit);
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
        ///     Converts this ElectricChargeDensity to another ElectricChargeDensity using the given <paramref name="unitConverter"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to use for the conversion.</param>
        /// <returns>A ElectricChargeDensity with the specified unit.</returns>
        public ElectricChargeDensity ToUnit(ElectricChargeDensityUnit unit, UnitConverter unitConverter)
        {
            if(Unit == unit)
            {
                // Already in requested units.
                return this;
            }
            else if(unitConverter.TryGetConversionFunction((typeof(ElectricChargeDensity), Unit, typeof(ElectricChargeDensity), unit), out var conversionFunction))
            {
                // Direct conversion to requested unit found. Return the converted quantity.
                var converted = conversionFunction(this);
                return (ElectricChargeDensity)converted;
            }
            else if(Unit != BaseUnit)
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
            if(!(unit is ElectricChargeDensityUnit unitAsElectricChargeDensityUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(ElectricChargeDensityUnit)} is supported.", nameof(unit));

            return ToUnit(unitAsElectricChargeDensityUnit, DefaultConversionFunctions);
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(Enum unit, UnitConverter unitConverter)
        {
            if(!(unit is ElectricChargeDensityUnit unitAsElectricChargeDensityUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(ElectricChargeDensityUnit)} is supported.", nameof(unit));

            return ToUnit(unitAsElectricChargeDensityUnit, unitConverter);
        }

        /// <inheritdoc cref="IQuantity.ToUnit(UnitSystem)"/>
        public ElectricChargeDensity ToUnit(UnitSystem unitSystem)
        {
            if(unitSystem is null)
                throw new ArgumentNullException(nameof(unitSystem));

            var unitInfos = Info.GetUnitInfosFor(unitSystem.BaseUnits);

            var firstUnitInfo = unitInfos.FirstOrDefault();
            if(firstUnitInfo == null)
                throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));

            return ToUnit(firstUnitInfo.Value);
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <inheritdoc />
        IQuantity<ElectricChargeDensityUnit> IQuantity<ElectricChargeDensityUnit>.ToUnit(ElectricChargeDensityUnit unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<ElectricChargeDensityUnit> IQuantity<ElectricChargeDensityUnit>.ToUnit(ElectricChargeDensityUnit unit, UnitConverter unitConverter) => ToUnit(unit, unitConverter);

        /// <inheritdoc />
        IQuantity<ElectricChargeDensityUnit> IQuantity<ElectricChargeDensityUnit>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        private double GetValueAs(ElectricChargeDensityUnit unit)
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
            return QuantityFormatter.Format<ElectricChargeDensityUnit>(this, format, provider);
        }

        #endregion

        #region IConvertible Methods

        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(ElectricChargeDensity)} to bool is not supported.");
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(ElectricChargeDensity)} to char is not supported.");
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(ElectricChargeDensity)} to DateTime is not supported.");
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
            if(conversionType == typeof(ElectricChargeDensity))
                return this;
            else if(conversionType == typeof(ElectricChargeDensityUnit))
                return Unit;
            else if(conversionType == typeof(QuantityInfo))
                return ElectricChargeDensity.Info;
            else if(conversionType == typeof(BaseDimensions))
                return ElectricChargeDensity.BaseDimensions;
            else
                throw new InvalidCastException($"Converting {typeof(ElectricChargeDensity)} to {conversionType} is not supported.");
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
