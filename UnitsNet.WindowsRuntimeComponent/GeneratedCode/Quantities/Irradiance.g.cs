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
    ///     Irradiance is the intensity of ultraviolet (UV) or visible light incident on a surface.
    /// </summary>
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
    public sealed partial class Irradiance : IQuantity
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly IrradianceUnit? _unit;

        static Irradiance()
        {
            BaseDimensions = new BaseDimensions(0, 1, -3, 0, 0, 0, 0);
            Info = new QuantityInfo(QuantityType.Irradiance, Units.Cast<Enum>().ToArray(), BaseUnit, Zero, BaseDimensions);
        }

        /// <summary>
        ///     Creates the quantity with a value of 0 in the base unit WattPerSquareMeter.
        /// </summary>
        /// <remarks>
        ///     Windows Runtime Component requires a default constructor.
        /// </remarks>
        public Irradiance()
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
        private Irradiance(double value, IrradianceUnit unit)
        {
            if(unit == IrradianceUnit.Undefined)
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
        ///     The base unit of Irradiance, which is WattPerSquareMeter. All conversions go via this value.
        /// </summary>
        public static IrradianceUnit BaseUnit { get; } = IrradianceUnit.WattPerSquareMeter;

        /// <summary>
        /// Represents the largest possible value of Irradiance
        /// </summary>
        public static Irradiance MaxValue { get; } = new Irradiance(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Irradiance
        /// </summary>
        public static Irradiance MinValue { get; } = new Irradiance(double.MinValue, BaseUnit);

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        [Obsolete("QuantityType will be removed in the future. Use the Info property instead.")]
        public static QuantityType QuantityType { get; } = QuantityType.Irradiance;

        /// <summary>
        ///     All units of measurement for the Irradiance quantity.
        /// </summary>
        public static IrradianceUnit[] Units { get; } = Enum.GetValues(typeof(IrradianceUnit)).Cast<IrradianceUnit>().Except(new IrradianceUnit[]{ IrradianceUnit.Undefined }).ToArray();

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit WattPerSquareMeter.
        /// </summary>
        public static Irradiance Zero { get; } = new Irradiance(0, BaseUnit);

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
        public IrradianceUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        internal QuantityInfo QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        [Obsolete("QuantityType will be removed in the future. Use the Info property instead.")]
        public QuantityType Type => Irradiance.QuantityType;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => Irradiance.BaseDimensions;

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Get Irradiance in KilowattsPerSquareCentimeter.
        /// </summary>
        public double KilowattsPerSquareCentimeter => As(IrradianceUnit.KilowattPerSquareCentimeter);

        /// <summary>
        ///     Get Irradiance in KilowattsPerSquareMeter.
        /// </summary>
        public double KilowattsPerSquareMeter => As(IrradianceUnit.KilowattPerSquareMeter);

        /// <summary>
        ///     Get Irradiance in MegawattsPerSquareCentimeter.
        /// </summary>
        public double MegawattsPerSquareCentimeter => As(IrradianceUnit.MegawattPerSquareCentimeter);

        /// <summary>
        ///     Get Irradiance in MegawattsPerSquareMeter.
        /// </summary>
        public double MegawattsPerSquareMeter => As(IrradianceUnit.MegawattPerSquareMeter);

        /// <summary>
        ///     Get Irradiance in MicrowattsPerSquareCentimeter.
        /// </summary>
        public double MicrowattsPerSquareCentimeter => As(IrradianceUnit.MicrowattPerSquareCentimeter);

        /// <summary>
        ///     Get Irradiance in MicrowattsPerSquareMeter.
        /// </summary>
        public double MicrowattsPerSquareMeter => As(IrradianceUnit.MicrowattPerSquareMeter);

        /// <summary>
        ///     Get Irradiance in MilliwattsPerSquareCentimeter.
        /// </summary>
        public double MilliwattsPerSquareCentimeter => As(IrradianceUnit.MilliwattPerSquareCentimeter);

        /// <summary>
        ///     Get Irradiance in MilliwattsPerSquareMeter.
        /// </summary>
        public double MilliwattsPerSquareMeter => As(IrradianceUnit.MilliwattPerSquareMeter);

        /// <summary>
        ///     Get Irradiance in NanowattsPerSquareCentimeter.
        /// </summary>
        public double NanowattsPerSquareCentimeter => As(IrradianceUnit.NanowattPerSquareCentimeter);

        /// <summary>
        ///     Get Irradiance in NanowattsPerSquareMeter.
        /// </summary>
        public double NanowattsPerSquareMeter => As(IrradianceUnit.NanowattPerSquareMeter);

        /// <summary>
        ///     Get Irradiance in PicowattsPerSquareCentimeter.
        /// </summary>
        public double PicowattsPerSquareCentimeter => As(IrradianceUnit.PicowattPerSquareCentimeter);

        /// <summary>
        ///     Get Irradiance in PicowattsPerSquareMeter.
        /// </summary>
        public double PicowattsPerSquareMeter => As(IrradianceUnit.PicowattPerSquareMeter);

        /// <summary>
        ///     Get Irradiance in WattsPerSquareCentimeter.
        /// </summary>
        public double WattsPerSquareCentimeter => As(IrradianceUnit.WattPerSquareCentimeter);

        /// <summary>
        ///     Get Irradiance in WattsPerSquareMeter.
        /// </summary>
        public double WattsPerSquareMeter => As(IrradianceUnit.WattPerSquareMeter);

        #endregion

        #region Static Methods

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(IrradianceUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static string GetAbbreviation(IrradianceUnit unit, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Get Irradiance from KilowattsPerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromKilowattsPerSquareCentimeter(double kilowattspersquarecentimeter)
        {
            double value = (double) kilowattspersquarecentimeter;
            return new Irradiance(value, IrradianceUnit.KilowattPerSquareCentimeter);
        }
        /// <summary>
        ///     Get Irradiance from KilowattsPerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromKilowattsPerSquareMeter(double kilowattspersquaremeter)
        {
            double value = (double) kilowattspersquaremeter;
            return new Irradiance(value, IrradianceUnit.KilowattPerSquareMeter);
        }
        /// <summary>
        ///     Get Irradiance from MegawattsPerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromMegawattsPerSquareCentimeter(double megawattspersquarecentimeter)
        {
            double value = (double) megawattspersquarecentimeter;
            return new Irradiance(value, IrradianceUnit.MegawattPerSquareCentimeter);
        }
        /// <summary>
        ///     Get Irradiance from MegawattsPerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromMegawattsPerSquareMeter(double megawattspersquaremeter)
        {
            double value = (double) megawattspersquaremeter;
            return new Irradiance(value, IrradianceUnit.MegawattPerSquareMeter);
        }
        /// <summary>
        ///     Get Irradiance from MicrowattsPerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromMicrowattsPerSquareCentimeter(double microwattspersquarecentimeter)
        {
            double value = (double) microwattspersquarecentimeter;
            return new Irradiance(value, IrradianceUnit.MicrowattPerSquareCentimeter);
        }
        /// <summary>
        ///     Get Irradiance from MicrowattsPerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromMicrowattsPerSquareMeter(double microwattspersquaremeter)
        {
            double value = (double) microwattspersquaremeter;
            return new Irradiance(value, IrradianceUnit.MicrowattPerSquareMeter);
        }
        /// <summary>
        ///     Get Irradiance from MilliwattsPerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromMilliwattsPerSquareCentimeter(double milliwattspersquarecentimeter)
        {
            double value = (double) milliwattspersquarecentimeter;
            return new Irradiance(value, IrradianceUnit.MilliwattPerSquareCentimeter);
        }
        /// <summary>
        ///     Get Irradiance from MilliwattsPerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromMilliwattsPerSquareMeter(double milliwattspersquaremeter)
        {
            double value = (double) milliwattspersquaremeter;
            return new Irradiance(value, IrradianceUnit.MilliwattPerSquareMeter);
        }
        /// <summary>
        ///     Get Irradiance from NanowattsPerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromNanowattsPerSquareCentimeter(double nanowattspersquarecentimeter)
        {
            double value = (double) nanowattspersquarecentimeter;
            return new Irradiance(value, IrradianceUnit.NanowattPerSquareCentimeter);
        }
        /// <summary>
        ///     Get Irradiance from NanowattsPerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromNanowattsPerSquareMeter(double nanowattspersquaremeter)
        {
            double value = (double) nanowattspersquaremeter;
            return new Irradiance(value, IrradianceUnit.NanowattPerSquareMeter);
        }
        /// <summary>
        ///     Get Irradiance from PicowattsPerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromPicowattsPerSquareCentimeter(double picowattspersquarecentimeter)
        {
            double value = (double) picowattspersquarecentimeter;
            return new Irradiance(value, IrradianceUnit.PicowattPerSquareCentimeter);
        }
        /// <summary>
        ///     Get Irradiance from PicowattsPerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromPicowattsPerSquareMeter(double picowattspersquaremeter)
        {
            double value = (double) picowattspersquaremeter;
            return new Irradiance(value, IrradianceUnit.PicowattPerSquareMeter);
        }
        /// <summary>
        ///     Get Irradiance from WattsPerSquareCentimeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromWattsPerSquareCentimeter(double wattspersquarecentimeter)
        {
            double value = (double) wattspersquarecentimeter;
            return new Irradiance(value, IrradianceUnit.WattPerSquareCentimeter);
        }
        /// <summary>
        ///     Get Irradiance from WattsPerSquareMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        [Windows.Foundation.Metadata.DefaultOverload]
        public static Irradiance FromWattsPerSquareMeter(double wattspersquaremeter)
        {
            double value = (double) wattspersquaremeter;
            return new Irradiance(value, IrradianceUnit.WattPerSquareMeter);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="IrradianceUnit" /> to <see cref="Irradiance" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Irradiance unit value.</returns>
        // Fix name conflict with parameter "value"
        [return: System.Runtime.InteropServices.WindowsRuntime.ReturnValueName("returnValue")]
        public static Irradiance From(double value, IrradianceUnit fromUnit)
        {
            return new Irradiance((double)value, fromUnit);
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
        public static Irradiance Parse(string str)
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
        public static Irradiance Parse(string str, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return QuantityParser.Default.Parse<Irradiance, IrradianceUnit>(
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
        public static bool TryParse([CanBeNull] string str, out Irradiance result)
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
        public static bool TryParse([CanBeNull] string str, [CanBeNull] string cultureName, out Irradiance result)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return QuantityParser.Default.TryParse<Irradiance, IrradianceUnit>(
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
        public static IrradianceUnit ParseUnit(string str)
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
        public static IrradianceUnit ParseUnit(string str, [CanBeNull] string cultureName)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitParser.Default.Parse<IrradianceUnit>(str, provider);
        }

        public static bool TryParseUnit(string str, out IrradianceUnit unit)
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
        public static bool TryParseUnit(string str, [CanBeNull] string cultureName, out IrradianceUnit unit)
        {
            IFormatProvider provider = GetFormatProviderFromCultureName(cultureName);
            return UnitParser.Default.TryParse<IrradianceUnit>(str, provider, out unit);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if(obj is null) throw new ArgumentNullException(nameof(obj));
            if(!(obj is Irradiance objIrradiance)) throw new ArgumentException("Expected type Irradiance.", nameof(obj));

            return CompareTo(objIrradiance);
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        internal int CompareTo(Irradiance other)
        {
            return _value.CompareTo(other.AsBaseNumericType(this.Unit));
        }

        [Windows.Foundation.Metadata.DefaultOverload]
        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is Irradiance objIrradiance))
                return false;

            return Equals(objIrradiance);
        }

        public bool Equals(Irradiance other)
        {
            return _value.Equals(other.AsBaseNumericType(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another Irradiance within the given absolute or relative tolerance.
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
        public bool Equals(Irradiance other, double tolerance, ComparisonType comparisonType)
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
        /// <returns>A hash code for the current Irradiance.</returns>
        public override int GetHashCode()
        {
            return new { Info.Name, Value, Unit }.GetHashCode();
        }

        #endregion

        #region Conversion Methods

        double IQuantity.As(object unit) => As((IrradianceUnit)unit);

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(IrradianceUnit unit)
        {
            if(Unit == unit)
                return Convert.ToDouble(Value);

            var converted = AsBaseNumericType(unit);
            return Convert.ToDouble(converted);
        }

        /// <summary>
        ///     Converts this Irradiance to another Irradiance with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Irradiance with the specified unit.</returns>
        public Irradiance ToUnit(IrradianceUnit unit)
        {
            var convertedValue = AsBaseNumericType(unit);
            return new Irradiance(convertedValue, unit);
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
                case IrradianceUnit.KilowattPerSquareCentimeter: return (_value*10000) * 1e3d;
                case IrradianceUnit.KilowattPerSquareMeter: return (_value) * 1e3d;
                case IrradianceUnit.MegawattPerSquareCentimeter: return (_value*10000) * 1e6d;
                case IrradianceUnit.MegawattPerSquareMeter: return (_value) * 1e6d;
                case IrradianceUnit.MicrowattPerSquareCentimeter: return (_value*10000) * 1e-6d;
                case IrradianceUnit.MicrowattPerSquareMeter: return (_value) * 1e-6d;
                case IrradianceUnit.MilliwattPerSquareCentimeter: return (_value*10000) * 1e-3d;
                case IrradianceUnit.MilliwattPerSquareMeter: return (_value) * 1e-3d;
                case IrradianceUnit.NanowattPerSquareCentimeter: return (_value*10000) * 1e-9d;
                case IrradianceUnit.NanowattPerSquareMeter: return (_value) * 1e-9d;
                case IrradianceUnit.PicowattPerSquareCentimeter: return (_value*10000) * 1e-12d;
                case IrradianceUnit.PicowattPerSquareMeter: return (_value) * 1e-12d;
                case IrradianceUnit.WattPerSquareCentimeter: return _value*10000;
                case IrradianceUnit.WattPerSquareMeter: return _value;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double AsBaseNumericType(IrradianceUnit unit)
        {
            if(Unit == unit)
                return _value;

            var baseUnitValue = AsBaseUnit();

            switch(unit)
            {
                case IrradianceUnit.KilowattPerSquareCentimeter: return (baseUnitValue*0.0001) / 1e3d;
                case IrradianceUnit.KilowattPerSquareMeter: return (baseUnitValue) / 1e3d;
                case IrradianceUnit.MegawattPerSquareCentimeter: return (baseUnitValue*0.0001) / 1e6d;
                case IrradianceUnit.MegawattPerSquareMeter: return (baseUnitValue) / 1e6d;
                case IrradianceUnit.MicrowattPerSquareCentimeter: return (baseUnitValue*0.0001) / 1e-6d;
                case IrradianceUnit.MicrowattPerSquareMeter: return (baseUnitValue) / 1e-6d;
                case IrradianceUnit.MilliwattPerSquareCentimeter: return (baseUnitValue*0.0001) / 1e-3d;
                case IrradianceUnit.MilliwattPerSquareMeter: return (baseUnitValue) / 1e-3d;
                case IrradianceUnit.NanowattPerSquareCentimeter: return (baseUnitValue*0.0001) / 1e-9d;
                case IrradianceUnit.NanowattPerSquareMeter: return (baseUnitValue) / 1e-9d;
                case IrradianceUnit.PicowattPerSquareCentimeter: return (baseUnitValue*0.0001) / 1e-12d;
                case IrradianceUnit.PicowattPerSquareMeter: return (baseUnitValue) / 1e-12d;
                case IrradianceUnit.WattPerSquareCentimeter: return baseUnitValue*0.0001;
                case IrradianceUnit.WattPerSquareMeter: return baseUnitValue;
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
