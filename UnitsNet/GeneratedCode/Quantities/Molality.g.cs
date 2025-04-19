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
    ///     Molality is a measure of the amount of solute in a solution relative to a given mass of solvent.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Molality
    /// </remarks>
    [DataContract]
    [DebuggerTypeProxy(typeof(QuantityDisplay))]
    public readonly partial struct Molality :
        IArithmeticQuantity<Molality, MolalityUnit>,
#if NET7_0_OR_GREATER
        IComparisonOperators<Molality, Molality, bool>,
        IParsable<Molality>,
#endif
        IComparable,
        IComparable<Molality>,
        IEquatable<Molality>,
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
        private readonly MolalityUnit? _unit;

        static Molality()
        {
            BaseDimensions = new BaseDimensions(0, -1, 0, 0, 0, 1, 0);
            BaseUnit = MolalityUnit.MolePerKilogram;
            Units = Enum.GetValues(typeof(MolalityUnit)).Cast<MolalityUnit>().ToArray();
            Zero = new Molality(0, BaseUnit);
            Info = new QuantityInfo<MolalityUnit>("Molality",
                new UnitInfo<MolalityUnit>[]
                {
                    new UnitInfo<MolalityUnit>(MolalityUnit.MillimolePerKilogram, "MillimolesPerKilogram", new BaseUnits(mass: MassUnit.Kilogram, amount: AmountOfSubstanceUnit.Millimole), "Molality"),
                    new UnitInfo<MolalityUnit>(MolalityUnit.MolePerGram, "MolesPerGram", new BaseUnits(mass: MassUnit.Gram, amount: AmountOfSubstanceUnit.Mole), "Molality"),
                    new UnitInfo<MolalityUnit>(MolalityUnit.MolePerKilogram, "MolesPerKilogram", new BaseUnits(mass: MassUnit.Kilogram, amount: AmountOfSubstanceUnit.Mole), "Molality"),
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
        public Molality(double value, MolalityUnit unit)
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
        public Molality(double value, UnitSystem unitSystem)
        {
            _value = value;
            _unit = Info.GetDefaultUnit(unitSystem);
        }

        #region Static Properties

        /// <summary>
        ///     The <see cref="UnitConverter" /> containing the default generated conversion functions for <see cref="Molality" /> instances.
        /// </summary>
        public static UnitConverter DefaultConversionFunctions { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        public static QuantityInfo<MolalityUnit> Info { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions { get; }

        /// <summary>
        ///     The base unit of Molality, which is MolePerKilogram. All conversions go via this value.
        /// </summary>
        public static MolalityUnit BaseUnit { get; }

        /// <summary>
        ///     All units of measurement for the Molality quantity.
        /// </summary>
        public static MolalityUnit[] Units { get; }

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit MolePerKilogram.
        /// </summary>
        public static Molality Zero { get; }

        /// <inheritdoc cref="Zero"/>
        public static Molality AdditiveIdentity => Zero;

        #endregion

        #region Properties

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public MolalityUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<MolalityUnit> QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => Molality.BaseDimensions;

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
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MolalityUnit.MillimolePerKilogram"/>
        /// </summary>
        public double MillimolesPerKilogram => As(MolalityUnit.MillimolePerKilogram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MolalityUnit.MolePerGram"/>
        /// </summary>
        public double MolesPerGram => As(MolalityUnit.MolePerGram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MolalityUnit.MolePerKilogram"/>
        /// </summary>
        public double MolesPerKilogram => As(MolalityUnit.MolePerKilogram);

        #endregion

        #region Static Methods

        /// <summary>
        /// Registers the default conversion functions in the given <see cref="UnitConverter"/> instance.
        /// </summary>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to register the default conversion functions in.</param>
        internal static void RegisterDefaultConversions(UnitConverter unitConverter)
        {
            // Register in unit converter: MolalityUnit -> BaseUnit
            unitConverter.SetConversionFunction<Molality>(MolalityUnit.MillimolePerKilogram, MolalityUnit.MolePerKilogram, quantity => quantity.ToUnit(MolalityUnit.MolePerKilogram));
            unitConverter.SetConversionFunction<Molality>(MolalityUnit.MolePerGram, MolalityUnit.MolePerKilogram, quantity => quantity.ToUnit(MolalityUnit.MolePerKilogram));

            // Register in unit converter: BaseUnit <-> BaseUnit
            unitConverter.SetConversionFunction<Molality>(MolalityUnit.MolePerKilogram, MolalityUnit.MolePerKilogram, quantity => quantity);

            // Register in unit converter: BaseUnit -> MolalityUnit
            unitConverter.SetConversionFunction<Molality>(MolalityUnit.MolePerKilogram, MolalityUnit.MillimolePerKilogram, quantity => quantity.ToUnit(MolalityUnit.MillimolePerKilogram));
            unitConverter.SetConversionFunction<Molality>(MolalityUnit.MolePerKilogram, MolalityUnit.MolePerGram, quantity => quantity.ToUnit(MolalityUnit.MolePerGram));
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(MolalityUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="provider">Format to use for localization. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static string GetAbbreviation(MolalityUnit unit, IFormatProvider? provider)
        {
            return UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="Molality"/> from <see cref="MolalityUnit.MillimolePerKilogram"/>.
        /// </summary>
        public static Molality FromMillimolesPerKilogram(double value)
        {
            return new Molality(value, MolalityUnit.MillimolePerKilogram);
        }

        /// <summary>
        ///     Creates a <see cref="Molality"/> from <see cref="MolalityUnit.MolePerGram"/>.
        /// </summary>
        public static Molality FromMolesPerGram(double value)
        {
            return new Molality(value, MolalityUnit.MolePerGram);
        }

        /// <summary>
        ///     Creates a <see cref="Molality"/> from <see cref="MolalityUnit.MolePerKilogram"/>.
        /// </summary>
        public static Molality FromMolesPerKilogram(double value)
        {
            return new Molality(value, MolalityUnit.MolePerKilogram);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="MolalityUnit" /> to <see cref="Molality" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Molality unit value.</returns>
        public static Molality From(double value, MolalityUnit fromUnit)
        {
            return new Molality(value, fromUnit);
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
        public static Molality Parse(string str)
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
        public static Molality Parse(string str, IFormatProvider? provider)
        {
            return UnitsNetSetup.Default.QuantityParser.Parse<Molality, MolalityUnit>(
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
        public static bool TryParse([NotNullWhen(true)]string? str, out Molality result)
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
        public static bool TryParse([NotNullWhen(true)]string? str, IFormatProvider? provider, out Molality result)
        {
            return UnitsNetSetup.Default.QuantityParser.TryParse<Molality, MolalityUnit>(
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
        public static MolalityUnit ParseUnit(string str)
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
        public static MolalityUnit ParseUnit(string str, IFormatProvider? provider)
        {
            return UnitParser.Default.Parse(str, Info.UnitInfos, provider).Value;
        }

        /// <inheritdoc cref="TryParseUnit(string,IFormatProvider,out UnitsNet.Units.MolalityUnit)"/>
        public static bool TryParseUnit([NotNullWhen(true)]string? str, out MolalityUnit unit)
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
        public static bool TryParseUnit([NotNullWhen(true)]string? str, IFormatProvider? provider, out MolalityUnit unit)
        {
            return UnitParser.Default.TryParse(str, Info, provider, out unit);
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static Molality operator -(Molality right)
        {
            return new Molality(-right.Value, right.Unit);
        }

        /// <summary>Get <see cref="Molality"/> from adding two <see cref="Molality"/>.</summary>
        public static Molality operator +(Molality left, Molality right)
        {
            return new Molality(left.Value + right.ToUnit(left.Unit).Value, left.Unit);
        }

        /// <summary>Get <see cref="Molality"/> from subtracting two <see cref="Molality"/>.</summary>
        public static Molality operator -(Molality left, Molality right)
        {
            return new Molality(left.Value - right.ToUnit(left.Unit).Value, left.Unit);
        }

        /// <summary>Get <see cref="Molality"/> from multiplying value and <see cref="Molality"/>.</summary>
        public static Molality operator *(double left, Molality right)
        {
            return new Molality(left * right.Value, right.Unit);
        }

        /// <summary>Get <see cref="Molality"/> from multiplying value and <see cref="Molality"/>.</summary>
        public static Molality operator *(Molality left, double right)
        {
            return new Molality(left.Value * right, left.Unit);
        }

        /// <summary>Get <see cref="Molality"/> from dividing <see cref="Molality"/> by value.</summary>
        public static Molality operator /(Molality left, double right)
        {
            return new Molality(left.Value / right, left.Unit);
        }

        /// <summary>Get ratio value from dividing <see cref="Molality"/> by <see cref="Molality"/>.</summary>
        public static double operator /(Molality left, Molality right)
        {
            return left.MolesPerKilogram / right.MolesPerKilogram;
        }

        #endregion

        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=(Molality left, Molality right)
        {
            return left.Value <= right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=(Molality left, Molality right)
        {
            return left.Value >= right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if less than.</summary>
        public static bool operator <(Molality left, Molality right)
        {
            return left.Value < right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >(Molality left, Molality right)
        {
            return left.Value > right.ToUnit(left.Unit).Value;
        }

        // We use obsolete attribute to communicate the preferred equality members to use.
        // CS0809: Obsolete member 'memberA' overrides non-obsolete member 'memberB'.
        #pragma warning disable CS0809

        /// <summary>Indicates strict equality of two <see cref="Molality"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("For null checks, use `x is null` syntax to not invoke overloads. For equality checks, use Equals(Molality other, Molality tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public static bool operator ==(Molality left, Molality right)
        {
            return left.Equals(right);
        }

        /// <summary>Indicates strict inequality of two <see cref="Molality"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("For null checks, use `x is null` syntax to not invoke overloads. For equality checks, use Equals(Molality other, Molality tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public static bool operator !=(Molality left, Molality right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        /// <summary>Indicates strict equality of two <see cref="Molality"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("Use Equals(Molality other, Molality tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Molality otherQuantity))
                return false;

            return Equals(otherQuantity);
        }

        /// <inheritdoc />
        /// <summary>Indicates strict equality of two <see cref="Molality"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("Use Equals(Molality other, Molality tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public bool Equals(Molality other)
        {
            return new { Value, Unit }.Equals(new { other.Value, other.Unit });
        }

        #pragma warning restore CS0809

        /// <summary>Compares the current <see cref="Molality"/> with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other when converted to the same unit.</summary>
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
            if (!(obj is Molality otherQuantity)) throw new ArgumentException("Expected type Molality.", nameof(obj));

            return CompareTo(otherQuantity);
        }

        /// <summary>Compares the current <see cref="Molality"/> with another <see cref="Molality"/> and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other when converted to the same unit.</summary>
        /// <param name="other">A quantity to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the quantities being compared. The return value has these meanings:
        ///     <list type="table">
        ///         <listheader><term> Value</term><description> Meaning</description></listheader>
        ///         <item><term> Less than zero</term><description> This instance precedes <paramref name="other" /> in the sort order.</description></item>
        ///         <item><term> Zero</term><description> This instance occurs in the same position in the sort order as <paramref name="other" />.</description></item>
        ///         <item><term> Greater than zero</term><description> This instance follows <paramref name="other" /> in the sort order.</description></item>
        ///     </list>
        /// </returns>
        public int CompareTo(Molality other)
        {
            return _value.CompareTo(other.ToUnit(this.Unit).Value);
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another Molality within the given absolute or relative tolerance.
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
        [Obsolete("Use Equals(Molality other, Molality tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public bool Equals(Molality other, double tolerance, ComparisonType comparisonType)
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
            return other is Molality otherTyped
                   && (tolerance is Molality toleranceTyped
                       ? true
                       : throw new ArgumentException($"Tolerance quantity ({tolerance.QuantityInfo.Name}) did not match the other quantities of type 'Molality'.", nameof(tolerance)))
                   && Equals(otherTyped, toleranceTyped);
        }

        /// <inheritdoc />
        public bool Equals(Molality other, Molality tolerance)
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
        /// <returns>A hash code for the current Molality.</returns>
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
        public double As(MolalityUnit unit)
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
        ///     Converts this Molality to another Molality with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>A Molality with the specified unit.</returns>
        public Molality ToUnit(MolalityUnit unit)
        {
            return ToUnit(unit, DefaultConversionFunctions);
        }

        /// <summary>
        ///     Converts this <see cref="Molality"/> to another <see cref="Molality"/> using the given <paramref name="unitConverter"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to use for the conversion.</param>
        /// <returns>A Molality with the specified unit.</returns>
        public Molality ToUnit(MolalityUnit unit, UnitConverter unitConverter)
        {
            if (TryToUnit(unit, out var converted))
            {
                // Try to convert using the auto-generated conversion methods.
                return converted!.Value;
            }
            else if (unitConverter.TryGetConversionFunction((typeof(Molality), Unit, typeof(Molality), unit), out var conversionFunction))
            {
                // See if the unit converter has an extensibility conversion registered.
                return (Molality)conversionFunction(this);
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
        ///     Attempts to convert this <see cref="Molality"/> to another <see cref="Molality"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="converted">The converted <see cref="Molality"/> in <paramref name="unit"/>, if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        private bool TryToUnit(MolalityUnit unit, [NotNullWhen(true)] out Molality? converted)
        {
            if (Unit == unit)
            {
                converted = this;
                return true;
            }

            Molality? convertedOrNull = (Unit, unit) switch
            {
                // MolalityUnit -> BaseUnit
                (MolalityUnit.MillimolePerKilogram, MolalityUnit.MolePerKilogram) => new Molality((_value) * 1e-3d, MolalityUnit.MolePerKilogram),
                (MolalityUnit.MolePerGram, MolalityUnit.MolePerKilogram) => new Molality(_value / 1e-3, MolalityUnit.MolePerKilogram),

                // BaseUnit -> MolalityUnit
                (MolalityUnit.MolePerKilogram, MolalityUnit.MillimolePerKilogram) => new Molality((_value) / 1e-3d, MolalityUnit.MillimolePerKilogram),
                (MolalityUnit.MolePerKilogram, MolalityUnit.MolePerGram) => new Molality(_value * 1e-3, MolalityUnit.MolePerGram),

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
        public Molality ToUnit(UnitSystem unitSystem)
        {
            return ToUnit(Info.GetDefaultUnit(unitSystem));
        }

        #region Explicit implementations

        double IQuantity.As(Enum unit)
        {
            if (unit is not MolalityUnit typedUnit)
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(MolalityUnit)} is supported.", nameof(unit));

            return As(typedUnit);
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(Enum unit)
        {
            if (!(unit is MolalityUnit typedUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(MolalityUnit)} is supported.", nameof(unit));

            return ToUnit(typedUnit, DefaultConversionFunctions);
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <inheritdoc />
        IQuantity<MolalityUnit> IQuantity<MolalityUnit>.ToUnit(MolalityUnit unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<MolalityUnit> IQuantity<MolalityUnit>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

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
