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
using JetBrains.Annotations;
using UnitsNet.Units;
using UnitsNet.InternalHelpers;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Specific entropy is an amount of energy required to raise temperature of a substance by 1 Kelvin per unit mass.
    /// </summary>
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
    public sealed partial class SpecificEntropy : IQuantity
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly SpecificEntropyUnit? _unit;

        static SpecificEntropy()
        {
            BaseDimensions = new BaseDimensions(2, 0, -2, 0, -1, 0, 0);
            Info = new QuantityInfo(QuantityType.SpecificEntropy, Units.Cast<Enum>().ToArray(), BaseUnit, Zero, BaseDimensions);
        }

        /// <summary>
        ///     Creates the quantity with a value of 0 in the base unit JoulePerKilogramKelvin.
        /// </summary>
        /// <remarks>
        ///     Windows Runtime Component requires a default constructor.
        /// </remarks>
        public SpecificEntropy()
        {
            _value = 0;
            _unit = BaseUnit;
        }

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <remarks>Value parameter cannot be named 'value' due to constraint when targeting Windows Runtime Component.</remarks>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        private SpecificEntropy(double value, SpecificEntropyUnit unit)
        {
            if(unit == SpecificEntropyUnit.Undefined)
              throw new ArgumentException("The quantity can not be created with an undefined unit.", nameof(unit));

            _value = Guard.EnsureValidNumber(value, nameof(value));
            _unit = unit;
        }

        #region Static Properties

        /// <summary>
        ///     Information about the quantity type, such as unit values and names.
        /// </summary>
        internal static QuantityInfo Info { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions { get; }

        /// <summary>
        ///     The base unit of SpecificEntropy, which is JoulePerKilogramKelvin. All conversions go via this value.
        /// </summary>
        public static SpecificEntropyUnit BaseUnit { get; } = SpecificEntropyUnit.JoulePerKilogramKelvin;

        /// <summary>
        /// Represents the largest possible value of SpecificEntropy
        /// </summary>
        public static SpecificEntropy MaxValue { get; } = new SpecificEntropy(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of SpecificEntropy
        /// </summary>
        public static SpecificEntropy MinValue { get; } = new SpecificEntropy(double.MinValue, BaseUnit);

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        [Obsolete("QuantityType will be removed in the future. Use the Info property instead.")]
        public static QuantityType QuantityType { get; } = QuantityType.SpecificEntropy;

        /// <summary>
        ///     All units of measurement for the SpecificEntropy quantity.
        /// </summary>
        public static SpecificEntropyUnit[] Units { get; } = Enum.GetValues(typeof(SpecificEntropyUnit)).Cast<SpecificEntropyUnit>().Except(new SpecificEntropyUnit[]{ SpecificEntropyUnit.Undefined }).ToArray();

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit JoulePerKilogramKelvin.
        /// </summary>
        public static SpecificEntropy Zero { get; } = new SpecificEntropy(0, BaseUnit);

        #endregion

        #region Properties

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => Convert.ToDouble(_value);

        /// <inheritdoc cref="IQuantity.Unit"/>
        object IQuantity.Unit => Unit;

        /// <summary>
        ///     The unit this quantity was constructed with -or- <see cref="BaseUnit" /> if default ctor was used.
        /// </summary>
        public SpecificEntropyUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        internal QuantityInfo QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        [Obsolete("QuantityType will be removed in the future. Use the Info property instead.")]
        public QuantityType Type => SpecificEntropy.QuantityType;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => SpecificEntropy.BaseDimensions;

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Get SpecificEntropy in BtusPerPoundFahrenheit.
        /// </summary>
        public double BtusPerPoundFahrenheit => As(SpecificEntropyUnit.BtuPerPoundFahrenheit);

        /// <summary>
        ///     Get SpecificEntropy in CaloriesPerGramKelvin.
        /// </summary>
        public double CaloriesPerGramKelvin => As(SpecificEntropyUnit.CaloriePerGramKelvin);

        /// <summary>
        ///     Get SpecificEntropy in JoulesPerKilogramDegreeCelsius.
        /// </summary>
        public double JoulesPerKilogramDegreeCelsius => As(SpecificEntropyUnit.JoulePerKilogramDegreeCelsius);

        /// <summary>
        ///     Get SpecificEntropy in JoulesPerKilogramKelvin.
        /// </summary>
        public double JoulesPerKilogramKelvin => As(SpecificEntropyUnit.JoulePerKilogramKelvin);

        /// <summary>
        ///     Get SpecificEntropy in KilocaloriesPerGramKelvin.
        /// </summary>
        public double KilocaloriesPerGramKelvin => As(SpecificEntropyUnit.KilocaloriePerGramKelvin);

        /// <summary>
        ///     Get SpecificEntropy in KilojoulesPerKilogramDegreeCelsius.
        /// </summary>
        public double KilojoulesPerKilogramDegreeCelsius => As(SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius);

        /// <summary>
        ///     Get SpecificEntropy in KilojoulesPerKilogramKelvin.
        /// </summary>
        public double KilojoulesPerKilogramKelvin => As(SpecificEntropyUnit.KilojoulePerKilogramKelvin);

        /// <summary>
        ///     Get SpecificEntropy in MegajoulesPerKilogramDegreeCelsius.
        /// </summary>
        public double MegajoulesPerKilogramDegreeCelsius => As(SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius);

        /// <summary>
        ///     Get SpecificEntropy in MegajoulesPerKilogramKelvin.
        /// </summary>
        public double MegajoulesPerKilogramKelvin => As(SpecificEntropyUnit.MegajoulePerKilogramKelvin);

        #endregion

        #region Static Methods

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(SpecificEntropyUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static string GetAbbreviation(SpecificEntropyUnit unit, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Get SpecificEntropy from BtusPerPoundFahrenheit.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromBtusPerPoundFahrenheit(double btusperpoundfahrenheit)
        {
            double value = (double) btusperpoundfahrenheit;
            return new SpecificEntropy(value, SpecificEntropyUnit.BtuPerPoundFahrenheit);
        }
        /// <summary>
        ///     Get SpecificEntropy from CaloriesPerGramKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromCaloriesPerGramKelvin(double caloriespergramkelvin)
        {
            double value = (double) caloriespergramkelvin;
            return new SpecificEntropy(value, SpecificEntropyUnit.CaloriePerGramKelvin);
        }
        /// <summary>
        ///     Get SpecificEntropy from JoulesPerKilogramDegreeCelsius.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromJoulesPerKilogramDegreeCelsius(double joulesperkilogramdegreecelsius)
        {
            double value = (double) joulesperkilogramdegreecelsius;
            return new SpecificEntropy(value, SpecificEntropyUnit.JoulePerKilogramDegreeCelsius);
        }
        /// <summary>
        ///     Get SpecificEntropy from JoulesPerKilogramKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromJoulesPerKilogramKelvin(double joulesperkilogramkelvin)
        {
            double value = (double) joulesperkilogramkelvin;
            return new SpecificEntropy(value, SpecificEntropyUnit.JoulePerKilogramKelvin);
        }
        /// <summary>
        ///     Get SpecificEntropy from KilocaloriesPerGramKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromKilocaloriesPerGramKelvin(double kilocaloriespergramkelvin)
        {
            double value = (double) kilocaloriespergramkelvin;
            return new SpecificEntropy(value, SpecificEntropyUnit.KilocaloriePerGramKelvin);
        }
        /// <summary>
        ///     Get SpecificEntropy from KilojoulesPerKilogramDegreeCelsius.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromKilojoulesPerKilogramDegreeCelsius(double kilojoulesperkilogramdegreecelsius)
        {
            double value = (double) kilojoulesperkilogramdegreecelsius;
            return new SpecificEntropy(value, SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius);
        }
        /// <summary>
        ///     Get SpecificEntropy from KilojoulesPerKilogramKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromKilojoulesPerKilogramKelvin(double kilojoulesperkilogramkelvin)
        {
            double value = (double) kilojoulesperkilogramkelvin;
            return new SpecificEntropy(value, SpecificEntropyUnit.KilojoulePerKilogramKelvin);
        }
        /// <summary>
        ///     Get SpecificEntropy from MegajoulesPerKilogramDegreeCelsius.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromMegajoulesPerKilogramDegreeCelsius(double megajoulesperkilogramdegreecelsius)
        {
            double value = (double) megajoulesperkilogramdegreecelsius;
            return new SpecificEntropy(value, SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius);
        }
        /// <summary>
        ///     Get SpecificEntropy from MegajoulesPerKilogramKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static SpecificEntropy FromMegajoulesPerKilogramKelvin(double megajoulesperkilogramkelvin)
        {
            double value = (double) megajoulesperkilogramkelvin;
            return new SpecificEntropy(value, SpecificEntropyUnit.MegajoulePerKilogramKelvin);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpecificEntropyUnit" /> to <see cref="SpecificEntropy" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>SpecificEntropy unit value.</returns>
        // Fix name conflict with parameter "value"
        [return: System.Runtime.InteropServices.WindowsRuntime.ReturnValueName("returnValue")]
        public static SpecificEntropy From(double value, SpecificEntropyUnit fromUnit)
        {
            return new SpecificEntropy((double)value, fromUnit);
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
        public static SpecificEntropy Parse(string str)
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
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static SpecificEntropy Parse(string str, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return QuantityParser.Default.Parse<SpecificEntropy, SpecificEntropyUnit>(
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
        public static bool TryParse([CanBeNull] string str, out SpecificEntropy result)
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
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static bool TryParse([CanBeNull] string str, [CanBeNull] string cultureName, out SpecificEntropy result)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return QuantityParser.Default.TryParse<SpecificEntropy, SpecificEntropyUnit>(
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
        public static SpecificEntropyUnit ParseUnit(string str)
        {
            return ParseUnit(str, null);
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
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static SpecificEntropyUnit ParseUnit(string str, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitParser.Default.Parse<SpecificEntropyUnit>(str, provider);
        }

        public static bool TryParseUnit(string str, out SpecificEntropyUnit unit)
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
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static bool TryParseUnit(string str, [CanBeNull] string cultureName, out SpecificEntropyUnit unit)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitParser.Default.TryParse<SpecificEntropyUnit>(str, provider, out unit);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if(obj is null) throw new ArgumentNullException(nameof(obj));
            if(!(obj is SpecificEntropy objSpecificEntropy)) throw new ArgumentException("Expected type SpecificEntropy.", nameof(obj));

            return CompareTo(objSpecificEntropy);
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        internal int CompareTo(SpecificEntropy other)
        {
            return _value.CompareTo(other.AsBaseNumericType(this.Unit));
        }

        [Windows.Foundation.Metadata.DefaultOverload]
        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is SpecificEntropy objSpecificEntropy))
                return false;

            return Equals(objSpecificEntropy);
        }

        public bool Equals(SpecificEntropy other)
        {
            return _value.Equals(other.AsBaseNumericType(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another SpecificEntropy within the given absolute or relative tolerance.
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
        public bool Equals(SpecificEntropy other, double tolerance, ComparisonType comparisonType)
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
        /// <returns>A hash code for the current SpecificEntropy.</returns>
        public override int GetHashCode()
        {
            return new { Info.Name, Value, Unit }.GetHashCode();
        }

        #endregion

        #region Conversion Methods

        double IQuantity.As(object unit) => As((SpecificEntropyUnit)unit);

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(SpecificEntropyUnit unit)
        {
            if(Unit == unit)
                return Convert.ToDouble(Value);

            var converted = AsBaseNumericType(unit);
            return Convert.ToDouble(converted);
        }

        /// <summary>
        ///     Converts this SpecificEntropy to another SpecificEntropy with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A SpecificEntropy with the specified unit.</returns>
        public SpecificEntropy ToUnit(SpecificEntropyUnit unit)
        {
            var convertedValue = AsBaseNumericType(unit);
            return new SpecificEntropy(convertedValue, unit);
        }

        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private double AsBaseUnit()
        {
            switch(Unit)
            {
                case SpecificEntropyUnit.BtuPerPoundFahrenheit: return _value * 4.1868e3;
                case SpecificEntropyUnit.CaloriePerGramKelvin: return _value*4.184e3;
                case SpecificEntropyUnit.JoulePerKilogramDegreeCelsius: return _value;
                case SpecificEntropyUnit.JoulePerKilogramKelvin: return _value;
                case SpecificEntropyUnit.KilocaloriePerGramKelvin: return (_value*4.184e3) * 1e3d;
                case SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius: return (_value) * 1e3d;
                case SpecificEntropyUnit.KilojoulePerKilogramKelvin: return (_value) * 1e3d;
                case SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius: return (_value) * 1e6d;
                case SpecificEntropyUnit.MegajoulePerKilogramKelvin: return (_value) * 1e6d;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double AsBaseNumericType(SpecificEntropyUnit unit)
        {
            if(Unit == unit)
                return _value;

            var baseUnitValue = AsBaseUnit();

            switch(unit)
            {
                case SpecificEntropyUnit.BtuPerPoundFahrenheit: return baseUnitValue / 4.1868e3;
                case SpecificEntropyUnit.CaloriePerGramKelvin: return baseUnitValue/4.184e3;
                case SpecificEntropyUnit.JoulePerKilogramDegreeCelsius: return baseUnitValue;
                case SpecificEntropyUnit.JoulePerKilogramKelvin: return baseUnitValue;
                case SpecificEntropyUnit.KilocaloriePerGramKelvin: return (baseUnitValue/4.184e3) / 1e3d;
                case SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius: return (baseUnitValue) / 1e3d;
                case SpecificEntropyUnit.KilojoulePerKilogramKelvin: return (baseUnitValue) / 1e3d;
                case SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius: return (baseUnitValue) / 1e6d;
                case SpecificEntropyUnit.MegajoulePerKilogramKelvin: return (baseUnitValue) / 1e6d;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }

        #endregion

        #region ToString Methods

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(null);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <returns>String representation.</returns>
        /// <param name="cultureName">Name of culture (ex: "en-US") to use for localization and number formatting. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public string ToString([CanBeNull] string cultureName)
        {
            var provider = cultureName;
            return ToString(provider, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        /// <param name="cultureName">Name of culture (ex: "en-US") to use for localization and number formatting. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public string ToString(string cultureName, int significantDigitsAfterRadix)
        {
            var provider = cultureName;
            var value = Convert.ToDouble(Value);
            var format = UnitFormatter.GetFormat(value, significantDigitsAfterRadix);
            return ToString(provider, format);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implicitly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        /// <param name="cultureName">Name of culture (ex: "en-US") to use for localization and number formatting. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public string ToString([CanBeNull] string cultureName, [NotNull] string format, [NotNull] params object[] args)
        {
            var provider = GetFormatProviderFromCultureName(cultureName);
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

            provider = provider ?? GlobalConfiguration.DefaultCulture;

            var value = Convert.ToDouble(Value);
            var formatArgs = UnitFormatter.GetFormatArgs(Unit, value, provider, args);
            return string.Format(provider, format, formatArgs);
        }

        #endregion

        private static IFormatProvider GetFormatProviderFromCultureName([CanBeNull] string cultureName)
        {
            return cultureName != null ? new CultureInfo(cultureName) : (IFormatProvider)null;
        }
    }
}
