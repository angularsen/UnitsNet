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
using OasysUnitsNet.Units;
using OasysUnitsNet.InternalHelpers;

// ReSharper disable once CheckNamespace

namespace OasysUnitsNet
{
    /// <summary>
    ///     Jerk or Jolt, in physics, is the rate at which the acceleration of an object changes over time. The SI unit for jerk is the Meter per second cubed (m/s³). Jerks are vector quantities (they have magnitude and direction) and add according to the parallelogram law.
    /// </summary>
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
    public sealed partial class Jerk : IQuantity
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly JerkUnit? _unit;

        static Jerk()
        {
            BaseDimensions = new BaseDimensions(1, 0, -3, 0, 0, 0, 0);
            BaseUnit = JerkUnit.MeterPerSecondCubed;
            MaxValue = new Jerk(double.MaxValue, BaseUnit);
            MinValue = new Jerk(double.MinValue, BaseUnit);
            QuantityType = QuantityType.Jerk;
            Units = Enum.GetValues(typeof(JerkUnit)).Cast<JerkUnit>().Except(new JerkUnit[]{ JerkUnit.Undefined }).ToArray();
            Zero = new Jerk(0, BaseUnit);
            Info = new QuantityInfo(QuantityType.Jerk, Units.Cast<Enum>().ToArray(), BaseUnit, Zero, BaseDimensions);
        }

        /// <summary>
        ///     Creates the quantity with a value of 0 in the base unit MeterPerSecondCubed.
        /// </summary>
        /// <remarks>
        ///     Windows Runtime Component requires a default constructor.
        /// </remarks>
        public Jerk()
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
        private Jerk(double value, JerkUnit unit)
        {
            if (unit == JerkUnit.Undefined)
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
        ///     The base unit of Jerk, which is MeterPerSecondCubed. All conversions go via this value.
        /// </summary>
        public static JerkUnit BaseUnit { get; }

        /// <summary>
        /// Represents the largest possible value of Jerk
        /// </summary>
        public static Jerk MaxValue { get; }

        /// <summary>
        /// Represents the smallest possible value of Jerk
        /// </summary>
        public static Jerk MinValue { get; }

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        [Obsolete("QuantityType will be removed in the future. Use the Info property instead.")]
        public static QuantityType QuantityType { get; }

        /// <summary>
        ///     All units of measurement for the Jerk quantity.
        /// </summary>
        public static JerkUnit[] Units { get; }

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit MeterPerSecondCubed.
        /// </summary>
        public static Jerk Zero { get; }

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
        public JerkUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        internal QuantityInfo QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        [Obsolete("QuantityType will be removed in the future. Use the Info property instead.")]
        public QuantityType Type => Jerk.QuantityType;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => Jerk.BaseDimensions;

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.CentimeterPerSecondCubed"/>
        /// </summary>
        public double CentimetersPerSecondCubed => As(JerkUnit.CentimeterPerSecondCubed);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.DecimeterPerSecondCubed"/>
        /// </summary>
        public double DecimetersPerSecondCubed => As(JerkUnit.DecimeterPerSecondCubed);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.FootPerSecondCubed"/>
        /// </summary>
        public double FeetPerSecondCubed => As(JerkUnit.FootPerSecondCubed);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.InchPerSecondCubed"/>
        /// </summary>
        public double InchesPerSecondCubed => As(JerkUnit.InchPerSecondCubed);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.KilometerPerSecondCubed"/>
        /// </summary>
        public double KilometersPerSecondCubed => As(JerkUnit.KilometerPerSecondCubed);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.MeterPerSecondCubed"/>
        /// </summary>
        public double MetersPerSecondCubed => As(JerkUnit.MeterPerSecondCubed);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.MicrometerPerSecondCubed"/>
        /// </summary>
        public double MicrometersPerSecondCubed => As(JerkUnit.MicrometerPerSecondCubed);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.MillimeterPerSecondCubed"/>
        /// </summary>
        public double MillimetersPerSecondCubed => As(JerkUnit.MillimeterPerSecondCubed);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.MillistandardGravitiesPerSecond"/>
        /// </summary>
        public double MillistandardGravitiesPerSecond => As(JerkUnit.MillistandardGravitiesPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.NanometerPerSecondCubed"/>
        /// </summary>
        public double NanometersPerSecondCubed => As(JerkUnit.NanometerPerSecondCubed);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="JerkUnit.StandardGravitiesPerSecond"/>
        /// </summary>
        public double StandardGravitiesPerSecond => As(JerkUnit.StandardGravitiesPerSecond);

        #endregion

        #region Static Methods

        internal static void MapGeneratedLocalizations(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.CentimeterPerSecondCubed, new CultureInfo("en-US"), false, true, new string[]{"cm/s³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.CentimeterPerSecondCubed, new CultureInfo("ru-RU"), false, true, new string[]{"см/с³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.DecimeterPerSecondCubed, new CultureInfo("en-US"), false, true, new string[]{"dm/s³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.DecimeterPerSecondCubed, new CultureInfo("ru-RU"), false, true, new string[]{"дм/с³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.FootPerSecondCubed, new CultureInfo("en-US"), false, true, new string[]{"ft/s³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.FootPerSecondCubed, new CultureInfo("ru-RU"), false, true, new string[]{"фут/с³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.InchPerSecondCubed, new CultureInfo("en-US"), false, true, new string[]{"in/s³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.InchPerSecondCubed, new CultureInfo("ru-RU"), false, true, new string[]{"дюйм/с³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.KilometerPerSecondCubed, new CultureInfo("en-US"), false, true, new string[]{"km/s³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.KilometerPerSecondCubed, new CultureInfo("ru-RU"), false, true, new string[]{"км/с³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.MeterPerSecondCubed, new CultureInfo("en-US"), false, true, new string[]{"m/s³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.MeterPerSecondCubed, new CultureInfo("ru-RU"), false, true, new string[]{"м/с³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.MicrometerPerSecondCubed, new CultureInfo("en-US"), false, true, new string[]{"µm/s³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.MicrometerPerSecondCubed, new CultureInfo("ru-RU"), false, true, new string[]{"мкм/с³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.MillimeterPerSecondCubed, new CultureInfo("en-US"), false, true, new string[]{"mm/s³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.MillimeterPerSecondCubed, new CultureInfo("ru-RU"), false, true, new string[]{"мм/с³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.MillistandardGravitiesPerSecond, new CultureInfo("en-US"), false, true, new string[]{"mg/s"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.MillistandardGravitiesPerSecond, new CultureInfo("ru-RU"), false, true, new string[]{"мg/s"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.NanometerPerSecondCubed, new CultureInfo("en-US"), false, true, new string[]{"nm/s³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.NanometerPerSecondCubed, new CultureInfo("ru-RU"), false, true, new string[]{"нм/с³"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.StandardGravitiesPerSecond, new CultureInfo("en-US"), false, true, new string[]{"g/s"});
            unitAbbreviationsCache.PerformAbbreviationMapping(JerkUnit.StandardGravitiesPerSecond, new CultureInfo("ru-RU"), false, true, new string[]{"g/s"});
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(JerkUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static string GetAbbreviation(JerkUnit unit, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.CentimeterPerSecondCubed"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromCentimetersPerSecondCubed(double centimeterspersecondcubed)
        {
            double value = (double) centimeterspersecondcubed;
            return new Jerk(value, JerkUnit.CentimeterPerSecondCubed);
        }

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.DecimeterPerSecondCubed"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromDecimetersPerSecondCubed(double decimeterspersecondcubed)
        {
            double value = (double) decimeterspersecondcubed;
            return new Jerk(value, JerkUnit.DecimeterPerSecondCubed);
        }

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.FootPerSecondCubed"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromFeetPerSecondCubed(double feetpersecondcubed)
        {
            double value = (double) feetpersecondcubed;
            return new Jerk(value, JerkUnit.FootPerSecondCubed);
        }

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.InchPerSecondCubed"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromInchesPerSecondCubed(double inchespersecondcubed)
        {
            double value = (double) inchespersecondcubed;
            return new Jerk(value, JerkUnit.InchPerSecondCubed);
        }

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.KilometerPerSecondCubed"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromKilometersPerSecondCubed(double kilometerspersecondcubed)
        {
            double value = (double) kilometerspersecondcubed;
            return new Jerk(value, JerkUnit.KilometerPerSecondCubed);
        }

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.MeterPerSecondCubed"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromMetersPerSecondCubed(double meterspersecondcubed)
        {
            double value = (double) meterspersecondcubed;
            return new Jerk(value, JerkUnit.MeterPerSecondCubed);
        }

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.MicrometerPerSecondCubed"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromMicrometersPerSecondCubed(double micrometerspersecondcubed)
        {
            double value = (double) micrometerspersecondcubed;
            return new Jerk(value, JerkUnit.MicrometerPerSecondCubed);
        }

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.MillimeterPerSecondCubed"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromMillimetersPerSecondCubed(double millimeterspersecondcubed)
        {
            double value = (double) millimeterspersecondcubed;
            return new Jerk(value, JerkUnit.MillimeterPerSecondCubed);
        }

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.MillistandardGravitiesPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromMillistandardGravitiesPerSecond(double millistandardgravitiespersecond)
        {
            double value = (double) millistandardgravitiespersecond;
            return new Jerk(value, JerkUnit.MillistandardGravitiesPerSecond);
        }

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.NanometerPerSecondCubed"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromNanometersPerSecondCubed(double nanometerspersecondcubed)
        {
            double value = (double) nanometerspersecondcubed;
            return new Jerk(value, JerkUnit.NanometerPerSecondCubed);
        }

        /// <summary>
        ///     Creates a <see cref="Jerk"/> from <see cref="JerkUnit.StandardGravitiesPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Jerk FromStandardGravitiesPerSecond(double standardgravitiespersecond)
        {
            double value = (double) standardgravitiespersecond;
            return new Jerk(value, JerkUnit.StandardGravitiesPerSecond);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="JerkUnit" /> to <see cref="Jerk" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Jerk unit value.</returns>
        // Fix name conflict with parameter "value"
        [return: System.Runtime.InteropServices.WindowsRuntime.ReturnValueName("returnValue")]
        public static Jerk From(double value, JerkUnit fromUnit)
        {
            return new Jerk((double)value, fromUnit);
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
        /// <exception cref="OasysUnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="OasysUnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static Jerk Parse(string str)
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
        /// <exception cref="OasysUnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="OasysUnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static Jerk Parse(string str, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return QuantityParser.Default.Parse<Jerk, JerkUnit>(
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
        public static bool TryParse([CanBeNull] string str, out Jerk result)
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
        public static bool TryParse([CanBeNull] string str, [CanBeNull] string cultureName, out Jerk result)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return QuantityParser.Default.TryParse<Jerk, JerkUnit>(
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
        /// <exception cref="OasysUnitsNetException">Error parsing string.</exception>
        public static JerkUnit ParseUnit(string str)
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
        /// <exception cref="OasysUnitsNetException">Error parsing string.</exception>
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static JerkUnit ParseUnit(string str, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitParser.Default.Parse<JerkUnit>(str, provider);
        }

        public static bool TryParseUnit(string str, out JerkUnit unit)
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
        public static bool TryParseUnit(string str, [CanBeNull] string cultureName, out JerkUnit unit)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitParser.Default.TryParse<JerkUnit>(str, provider, out unit);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            if (!(obj is Jerk objJerk)) throw new ArgumentException("Expected type Jerk.", nameof(obj));

            return CompareTo(objJerk);
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        internal int CompareTo(Jerk other)
        {
            return _value.CompareTo(other.AsBaseNumericType(this.Unit));
        }

        [Windows.Foundation.Metadata.DefaultOverload]
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Jerk objJerk))
                return false;

            return Equals(objJerk);
        }

        public bool Equals(Jerk other)
        {
            return _value.Equals(other.AsBaseNumericType(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another Jerk within the given absolute or relative tolerance.
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
        public bool Equals(Jerk other, double tolerance, ComparisonType comparisonType)
        {
            if (tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0.");

            double thisValue = (double)this.Value;
            double otherValueInThisUnits = other.As(this.Unit);

            return OasysUnitsNet.Comparison.Equals(thisValue, otherValueInThisUnits, tolerance, comparisonType);
        }

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current Jerk.</returns>
        public override int GetHashCode()
        {
            return new { Info.Name, Value, Unit }.GetHashCode();
        }

        #endregion

        #region Conversion Methods

        double IQuantity.As(object unit) => As((JerkUnit)unit);

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(JerkUnit unit)
        {
            if (Unit == unit)
                return Convert.ToDouble(Value);

            var converted = AsBaseNumericType(unit);
            return Convert.ToDouble(converted);
        }

        /// <summary>
        ///     Converts this Jerk to another Jerk with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Jerk with the specified unit.</returns>
        public Jerk ToUnit(JerkUnit unit)
        {
            var convertedValue = AsBaseNumericType(unit);
            return new Jerk(convertedValue, unit);
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
                case JerkUnit.CentimeterPerSecondCubed: return (_value) * 1e-2d;
                case JerkUnit.DecimeterPerSecondCubed: return (_value) * 1e-1d;
                case JerkUnit.FootPerSecondCubed: return _value * 0.304800;
                case JerkUnit.InchPerSecondCubed: return _value * 0.0254;
                case JerkUnit.KilometerPerSecondCubed: return (_value) * 1e3d;
                case JerkUnit.MeterPerSecondCubed: return _value;
                case JerkUnit.MicrometerPerSecondCubed: return (_value) * 1e-6d;
                case JerkUnit.MillimeterPerSecondCubed: return (_value) * 1e-3d;
                case JerkUnit.MillistandardGravitiesPerSecond: return (_value * 9.80665) * 1e-3d;
                case JerkUnit.NanometerPerSecondCubed: return (_value) * 1e-9d;
                case JerkUnit.StandardGravitiesPerSecond: return _value * 9.80665;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double AsBaseNumericType(JerkUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = AsBaseUnit();

            switch(unit)
            {
                case JerkUnit.CentimeterPerSecondCubed: return (baseUnitValue) / 1e-2d;
                case JerkUnit.DecimeterPerSecondCubed: return (baseUnitValue) / 1e-1d;
                case JerkUnit.FootPerSecondCubed: return baseUnitValue / 0.304800;
                case JerkUnit.InchPerSecondCubed: return baseUnitValue / 0.0254;
                case JerkUnit.KilometerPerSecondCubed: return (baseUnitValue) / 1e3d;
                case JerkUnit.MeterPerSecondCubed: return baseUnitValue;
                case JerkUnit.MicrometerPerSecondCubed: return (baseUnitValue) / 1e-6d;
                case JerkUnit.MillimeterPerSecondCubed: return (baseUnitValue) / 1e-3d;
                case JerkUnit.MillistandardGravitiesPerSecond: return (baseUnitValue / 9.80665) / 1e-3d;
                case JerkUnit.NanometerPerSecondCubed: return (baseUnitValue) / 1e-9d;
                case JerkUnit.StandardGravitiesPerSecond: return baseUnitValue / 9.80665;
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
