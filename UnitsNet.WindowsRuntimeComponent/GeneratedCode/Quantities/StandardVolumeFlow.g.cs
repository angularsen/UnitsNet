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
    ///     The molar flow rate of a gas corrected to standardized conditions of temperature and pressure thus representing a fixed number of moles of gas regardless of composition and actual flow conditions.
    /// </summary>
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
    public sealed partial class StandardVolumeFlow : IQuantity
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly StandardVolumeFlowUnit? _unit;

        static StandardVolumeFlow()
        {
            BaseDimensions = new BaseDimensions(0, 1, -1, 0, 0, 0, 0);
            BaseUnit = StandardVolumeFlowUnit.StandardCubicMeterPerSecond;
            MaxValue = new StandardVolumeFlow(double.MaxValue, BaseUnit);
            MinValue = new StandardVolumeFlow(double.MinValue, BaseUnit);
            QuantityType = QuantityType.StandardVolumeFlow;
            Units = Enum.GetValues(typeof(StandardVolumeFlowUnit)).Cast<StandardVolumeFlowUnit>().Except(new StandardVolumeFlowUnit[]{ StandardVolumeFlowUnit.Undefined }).ToArray();
            Zero = new StandardVolumeFlow(0, BaseUnit);
            Info = new QuantityInfo(QuantityType.StandardVolumeFlow, Units.Cast<Enum>().ToArray(), BaseUnit, Zero, BaseDimensions);
        }

        /// <summary>
        ///     Creates the quantity with a value of 0 in the base unit StandardCubicMeterPerSecond.
        /// </summary>
        /// <remarks>
        ///     Windows Runtime Component requires a default constructor.
        /// </remarks>
        public StandardVolumeFlow()
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
        private StandardVolumeFlow(double value, StandardVolumeFlowUnit unit)
        {
            if (unit == StandardVolumeFlowUnit.Undefined)
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
        ///     The base unit of StandardVolumeFlow, which is StandardCubicMeterPerSecond. All conversions go via this value.
        /// </summary>
        public static StandardVolumeFlowUnit BaseUnit { get; }

        /// <summary>
        /// Represents the largest possible value of StandardVolumeFlow
        /// </summary>
        public static StandardVolumeFlow MaxValue { get; }

        /// <summary>
        /// Represents the smallest possible value of StandardVolumeFlow
        /// </summary>
        public static StandardVolumeFlow MinValue { get; }

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        [Obsolete("QuantityType will be removed in the future. Use the Info property instead.")]
        public static QuantityType QuantityType { get; }

        /// <summary>
        ///     All units of measurement for the StandardVolumeFlow quantity.
        /// </summary>
        public static StandardVolumeFlowUnit[] Units { get; }

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit StandardCubicMeterPerSecond.
        /// </summary>
        public static StandardVolumeFlow Zero { get; }

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
        public StandardVolumeFlowUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        internal QuantityInfo QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        [Obsolete("QuantityType will be removed in the future. Use the Info property instead.")]
        public QuantityType Type => StandardVolumeFlow.QuantityType;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => StandardVolumeFlow.BaseDimensions;

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="StandardVolumeFlowUnit.StandardCubicCentimeterPerMinute"/>
        /// </summary>
        public double StandardCubicCentimetersPerMinute => As(StandardVolumeFlowUnit.StandardCubicCentimeterPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="StandardVolumeFlowUnit.StandardCubicFootPerHour"/>
        /// </summary>
        public double StandardCubicFeetPerHour => As(StandardVolumeFlowUnit.StandardCubicFootPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="StandardVolumeFlowUnit.StandardCubicFootPerMinute"/>
        /// </summary>
        public double StandardCubicFeetPerMinute => As(StandardVolumeFlowUnit.StandardCubicFootPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="StandardVolumeFlowUnit.StandardCubicFootPerSecond"/>
        /// </summary>
        public double StandardCubicFeetPerSecond => As(StandardVolumeFlowUnit.StandardCubicFootPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="StandardVolumeFlowUnit.StandardCubicMeterPerDay"/>
        /// </summary>
        public double StandardCubicMetersPerDay => As(StandardVolumeFlowUnit.StandardCubicMeterPerDay);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="StandardVolumeFlowUnit.StandardCubicMeterPerHour"/>
        /// </summary>
        public double StandardCubicMetersPerHour => As(StandardVolumeFlowUnit.StandardCubicMeterPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="StandardVolumeFlowUnit.StandardCubicMeterPerMinute"/>
        /// </summary>
        public double StandardCubicMetersPerMinute => As(StandardVolumeFlowUnit.StandardCubicMeterPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="StandardVolumeFlowUnit.StandardCubicMeterPerSecond"/>
        /// </summary>
        public double StandardCubicMetersPerSecond => As(StandardVolumeFlowUnit.StandardCubicMeterPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="StandardVolumeFlowUnit.StandardLiterPerMinute"/>
        /// </summary>
        public double StandardLitersPerMinute => As(StandardVolumeFlowUnit.StandardLiterPerMinute);

        #endregion

        #region Static Methods

        internal static void MapGeneratedLocalizations(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            unitAbbreviationsCache.PerformAbbreviationMapping(StandardVolumeFlowUnit.StandardCubicCentimeterPerMinute, new CultureInfo("en-US"), false, true, new string[]{"sccm"});
            unitAbbreviationsCache.PerformAbbreviationMapping(StandardVolumeFlowUnit.StandardCubicFootPerHour, new CultureInfo("en-US"), false, true, new string[]{"scfh"});
            unitAbbreviationsCache.PerformAbbreviationMapping(StandardVolumeFlowUnit.StandardCubicFootPerMinute, new CultureInfo("en-US"), false, true, new string[]{"scfm"});
            unitAbbreviationsCache.PerformAbbreviationMapping(StandardVolumeFlowUnit.StandardCubicFootPerSecond, new CultureInfo("en-US"), false, true, new string[]{"Sft³/s"});
            unitAbbreviationsCache.PerformAbbreviationMapping(StandardVolumeFlowUnit.StandardCubicMeterPerDay, new CultureInfo("en-US"), false, true, new string[]{"Sm³/d"});
            unitAbbreviationsCache.PerformAbbreviationMapping(StandardVolumeFlowUnit.StandardCubicMeterPerHour, new CultureInfo("en-US"), false, true, new string[]{"Sm³/h"});
            unitAbbreviationsCache.PerformAbbreviationMapping(StandardVolumeFlowUnit.StandardCubicMeterPerMinute, new CultureInfo("en-US"), false, true, new string[]{"Sm³/min"});
            unitAbbreviationsCache.PerformAbbreviationMapping(StandardVolumeFlowUnit.StandardCubicMeterPerSecond, new CultureInfo("en-US"), false, true, new string[]{"Sm³/s"});
            unitAbbreviationsCache.PerformAbbreviationMapping(StandardVolumeFlowUnit.StandardLiterPerMinute, new CultureInfo("en-US"), false, true, new string[]{"slm"});
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(StandardVolumeFlowUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static string GetAbbreviation(StandardVolumeFlowUnit unit, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="StandardVolumeFlow"/> from <see cref="StandardVolumeFlowUnit.StandardCubicCentimeterPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static StandardVolumeFlow FromStandardCubicCentimetersPerMinute(double standardcubiccentimetersperminute)
        {
            double value = (double) standardcubiccentimetersperminute;
            return new StandardVolumeFlow(value, StandardVolumeFlowUnit.StandardCubicCentimeterPerMinute);
        }

        /// <summary>
        ///     Creates a <see cref="StandardVolumeFlow"/> from <see cref="StandardVolumeFlowUnit.StandardCubicFootPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static StandardVolumeFlow FromStandardCubicFeetPerHour(double standardcubicfeetperhour)
        {
            double value = (double) standardcubicfeetperhour;
            return new StandardVolumeFlow(value, StandardVolumeFlowUnit.StandardCubicFootPerHour);
        }

        /// <summary>
        ///     Creates a <see cref="StandardVolumeFlow"/> from <see cref="StandardVolumeFlowUnit.StandardCubicFootPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static StandardVolumeFlow FromStandardCubicFeetPerMinute(double standardcubicfeetperminute)
        {
            double value = (double) standardcubicfeetperminute;
            return new StandardVolumeFlow(value, StandardVolumeFlowUnit.StandardCubicFootPerMinute);
        }

        /// <summary>
        ///     Creates a <see cref="StandardVolumeFlow"/> from <see cref="StandardVolumeFlowUnit.StandardCubicFootPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static StandardVolumeFlow FromStandardCubicFeetPerSecond(double standardcubicfeetpersecond)
        {
            double value = (double) standardcubicfeetpersecond;
            return new StandardVolumeFlow(value, StandardVolumeFlowUnit.StandardCubicFootPerSecond);
        }

        /// <summary>
        ///     Creates a <see cref="StandardVolumeFlow"/> from <see cref="StandardVolumeFlowUnit.StandardCubicMeterPerDay"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static StandardVolumeFlow FromStandardCubicMetersPerDay(double standardcubicmetersperday)
        {
            double value = (double) standardcubicmetersperday;
            return new StandardVolumeFlow(value, StandardVolumeFlowUnit.StandardCubicMeterPerDay);
        }

        /// <summary>
        ///     Creates a <see cref="StandardVolumeFlow"/> from <see cref="StandardVolumeFlowUnit.StandardCubicMeterPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static StandardVolumeFlow FromStandardCubicMetersPerHour(double standardcubicmetersperhour)
        {
            double value = (double) standardcubicmetersperhour;
            return new StandardVolumeFlow(value, StandardVolumeFlowUnit.StandardCubicMeterPerHour);
        }

        /// <summary>
        ///     Creates a <see cref="StandardVolumeFlow"/> from <see cref="StandardVolumeFlowUnit.StandardCubicMeterPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static StandardVolumeFlow FromStandardCubicMetersPerMinute(double standardcubicmetersperminute)
        {
            double value = (double) standardcubicmetersperminute;
            return new StandardVolumeFlow(value, StandardVolumeFlowUnit.StandardCubicMeterPerMinute);
        }

        /// <summary>
        ///     Creates a <see cref="StandardVolumeFlow"/> from <see cref="StandardVolumeFlowUnit.StandardCubicMeterPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static StandardVolumeFlow FromStandardCubicMetersPerSecond(double standardcubicmeterspersecond)
        {
            double value = (double) standardcubicmeterspersecond;
            return new StandardVolumeFlow(value, StandardVolumeFlowUnit.StandardCubicMeterPerSecond);
        }

        /// <summary>
        ///     Creates a <see cref="StandardVolumeFlow"/> from <see cref="StandardVolumeFlowUnit.StandardLiterPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static StandardVolumeFlow FromStandardLitersPerMinute(double standardlitersperminute)
        {
            double value = (double) standardlitersperminute;
            return new StandardVolumeFlow(value, StandardVolumeFlowUnit.StandardLiterPerMinute);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="StandardVolumeFlowUnit" /> to <see cref="StandardVolumeFlow" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>StandardVolumeFlow unit value.</returns>
        // Fix name conflict with parameter "value"
        [return: System.Runtime.InteropServices.WindowsRuntime.ReturnValueName("returnValue")]
        public static StandardVolumeFlow From(double value, StandardVolumeFlowUnit fromUnit)
        {
            return new StandardVolumeFlow((double)value, fromUnit);
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
        public static StandardVolumeFlow Parse(string str)
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
        public static StandardVolumeFlow Parse(string str, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return QuantityParser.Default.Parse<StandardVolumeFlow, StandardVolumeFlowUnit>(
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
        public static bool TryParse([CanBeNull] string str, out StandardVolumeFlow result)
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
        public static bool TryParse([CanBeNull] string str, [CanBeNull] string cultureName, out StandardVolumeFlow result)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return QuantityParser.Default.TryParse<StandardVolumeFlow, StandardVolumeFlowUnit>(
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
        public static StandardVolumeFlowUnit ParseUnit(string str)
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
        public static StandardVolumeFlowUnit ParseUnit(string str, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitParser.Default.Parse<StandardVolumeFlowUnit>(str, provider);
        }

        public static bool TryParseUnit(string str, out StandardVolumeFlowUnit unit)
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
        public static bool TryParseUnit(string str, [CanBeNull] string cultureName, out StandardVolumeFlowUnit unit)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitParser.Default.TryParse<StandardVolumeFlowUnit>(str, provider, out unit);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            if (!(obj is StandardVolumeFlow objStandardVolumeFlow)) throw new ArgumentException("Expected type StandardVolumeFlow.", nameof(obj));

            return CompareTo(objStandardVolumeFlow);
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        internal int CompareTo(StandardVolumeFlow other)
        {
            return _value.CompareTo(other.AsBaseNumericType(this.Unit));
        }

        [Windows.Foundation.Metadata.DefaultOverload]
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is StandardVolumeFlow objStandardVolumeFlow))
                return false;

            return Equals(objStandardVolumeFlow);
        }

        public bool Equals(StandardVolumeFlow other)
        {
            return _value.Equals(other.AsBaseNumericType(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another StandardVolumeFlow within the given absolute or relative tolerance.
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
        public bool Equals(StandardVolumeFlow other, double tolerance, ComparisonType comparisonType)
        {
            if (tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0.");

            double thisValue = (double)this.Value;
            double otherValueInThisUnits = other.As(this.Unit);

            return UnitsNet.Comparison.Equals(thisValue, otherValueInThisUnits, tolerance, comparisonType);
        }

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current StandardVolumeFlow.</returns>
        public override int GetHashCode()
        {
            return new { Info.Name, Value, Unit }.GetHashCode();
        }

        #endregion

        #region Conversion Methods

        double IQuantity.As(object unit) => As((StandardVolumeFlowUnit)unit);

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(StandardVolumeFlowUnit unit)
        {
            if (Unit == unit)
                return Convert.ToDouble(Value);

            var converted = AsBaseNumericType(unit);
            return Convert.ToDouble(converted);
        }

        /// <summary>
        ///     Converts this StandardVolumeFlow to another StandardVolumeFlow with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A StandardVolumeFlow with the specified unit.</returns>
        public StandardVolumeFlow ToUnit(StandardVolumeFlowUnit unit)
        {
            var convertedValue = AsBaseNumericType(unit);
            return new StandardVolumeFlow(convertedValue, unit);
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
                case StandardVolumeFlowUnit.StandardCubicCentimeterPerMinute: return _value / 6e7;
                case StandardVolumeFlowUnit.StandardCubicFootPerHour: return _value * 7.8657907199999087346816086183876e-6;
                case StandardVolumeFlowUnit.StandardCubicFootPerMinute: return _value / 2118.88000326;
                case StandardVolumeFlowUnit.StandardCubicFootPerSecond: return _value / 35.314666721;
                case StandardVolumeFlowUnit.StandardCubicMeterPerDay: return _value / 86400;
                case StandardVolumeFlowUnit.StandardCubicMeterPerHour: return _value / 3600;
                case StandardVolumeFlowUnit.StandardCubicMeterPerMinute: return _value / 60;
                case StandardVolumeFlowUnit.StandardCubicMeterPerSecond: return _value;
                case StandardVolumeFlowUnit.StandardLiterPerMinute: return _value / 60000;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double AsBaseNumericType(StandardVolumeFlowUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = AsBaseUnit();

            switch(unit)
            {
                case StandardVolumeFlowUnit.StandardCubicCentimeterPerMinute: return baseUnitValue * 6e7;
                case StandardVolumeFlowUnit.StandardCubicFootPerHour: return baseUnitValue / 7.8657907199999087346816086183876e-6;
                case StandardVolumeFlowUnit.StandardCubicFootPerMinute: return baseUnitValue * 2118.88000326;
                case StandardVolumeFlowUnit.StandardCubicFootPerSecond: return baseUnitValue * 35.314666721;
                case StandardVolumeFlowUnit.StandardCubicMeterPerDay: return baseUnitValue * 86400;
                case StandardVolumeFlowUnit.StandardCubicMeterPerHour: return baseUnitValue * 3600;
                case StandardVolumeFlowUnit.StandardCubicMeterPerMinute: return baseUnitValue * 60;
                case StandardVolumeFlowUnit.StandardCubicMeterPerSecond: return baseUnitValue;
                case StandardVolumeFlowUnit.StandardLiterPerMinute: return baseUnitValue * 60000;
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
