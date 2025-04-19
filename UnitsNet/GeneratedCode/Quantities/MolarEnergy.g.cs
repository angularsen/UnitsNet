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
    ///     Molar energy is the amount of energy stored in 1 mole of a substance.
    /// </summary>
    [DataContract]
    [DebuggerTypeProxy(typeof(QuantityDisplay))]
    public readonly partial struct MolarEnergy :
        IArithmeticQuantity<MolarEnergy, MolarEnergyUnit>,
#if NET7_0_OR_GREATER
        IMultiplyOperators<MolarEnergy, AmountOfSubstance, Energy>,
#endif
#if NET7_0_OR_GREATER
        IComparisonOperators<MolarEnergy, MolarEnergy, bool>,
        IParsable<MolarEnergy>,
#endif
        IComparable,
        IComparable<MolarEnergy>,
        IEquatable<MolarEnergy>,
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
        private readonly MolarEnergyUnit? _unit;

        static MolarEnergy()
        {
            BaseDimensions = new BaseDimensions(2, 1, -2, 0, 0, -1, 0);
            BaseUnit = MolarEnergyUnit.JoulePerMole;
            Units = Enum.GetValues(typeof(MolarEnergyUnit)).Cast<MolarEnergyUnit>().ToArray();
            Zero = new MolarEnergy(0, BaseUnit);
            Info = new QuantityInfo<MolarEnergyUnit>("MolarEnergy",
                new UnitInfo<MolarEnergyUnit>[]
                {
                    new UnitInfo<MolarEnergyUnit>(MolarEnergyUnit.JoulePerMole, "JoulesPerMole", new BaseUnits(length: LengthUnit.Meter, mass: MassUnit.Kilogram, time: DurationUnit.Second, amount: AmountOfSubstanceUnit.Mole), "MolarEnergy"),
                    new UnitInfo<MolarEnergyUnit>(MolarEnergyUnit.KilojoulePerMole, "KilojoulesPerMole", new BaseUnits(length: LengthUnit.Meter, mass: MassUnit.Kilogram, time: DurationUnit.Second, amount: AmountOfSubstanceUnit.Millimole), "MolarEnergy"),
                    new UnitInfo<MolarEnergyUnit>(MolarEnergyUnit.MegajoulePerMole, "MegajoulesPerMole", new BaseUnits(length: LengthUnit.Meter, mass: MassUnit.Kilogram, time: DurationUnit.Second, amount: AmountOfSubstanceUnit.Micromole), "MolarEnergy"),
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
        public MolarEnergy(double value, MolarEnergyUnit unit)
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
        public MolarEnergy(double value, UnitSystem unitSystem)
        {
            _value = value;
            _unit = Info.GetDefaultUnit(unitSystem);
        }

        #region Static Properties

        /// <summary>
        ///     The <see cref="UnitConverter" /> containing the default generated conversion functions for <see cref="MolarEnergy" /> instances.
        /// </summary>
        public static UnitConverter DefaultConversionFunctions { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        public static QuantityInfo<MolarEnergyUnit> Info { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions { get; }

        /// <summary>
        ///     The base unit of MolarEnergy, which is JoulePerMole. All conversions go via this value.
        /// </summary>
        public static MolarEnergyUnit BaseUnit { get; }

        /// <summary>
        ///     All units of measurement for the MolarEnergy quantity.
        /// </summary>
        public static MolarEnergyUnit[] Units { get; }

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit JoulePerMole.
        /// </summary>
        public static MolarEnergy Zero { get; }

        /// <inheritdoc cref="Zero"/>
        public static MolarEnergy AdditiveIdentity => Zero;

        #endregion

        #region Properties

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public MolarEnergyUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        /// <inheritdoc />
        public QuantityInfo<MolarEnergyUnit> QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => MolarEnergy.BaseDimensions;

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
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MolarEnergyUnit.JoulePerMole"/>
        /// </summary>
        public double JoulesPerMole => As(MolarEnergyUnit.JoulePerMole);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MolarEnergyUnit.KilojoulePerMole"/>
        /// </summary>
        public double KilojoulesPerMole => As(MolarEnergyUnit.KilojoulePerMole);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MolarEnergyUnit.MegajoulePerMole"/>
        /// </summary>
        public double MegajoulesPerMole => As(MolarEnergyUnit.MegajoulePerMole);

        #endregion

        #region Static Methods

        /// <summary>
        /// Registers the default conversion functions in the given <see cref="UnitConverter"/> instance.
        /// </summary>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to register the default conversion functions in.</param>
        internal static void RegisterDefaultConversions(UnitConverter unitConverter)
        {
            // Register in unit converter: MolarEnergyUnit -> BaseUnit
            unitConverter.SetConversionFunction<MolarEnergy>(MolarEnergyUnit.KilojoulePerMole, MolarEnergyUnit.JoulePerMole, quantity => quantity.ToUnit(MolarEnergyUnit.JoulePerMole));
            unitConverter.SetConversionFunction<MolarEnergy>(MolarEnergyUnit.MegajoulePerMole, MolarEnergyUnit.JoulePerMole, quantity => quantity.ToUnit(MolarEnergyUnit.JoulePerMole));

            // Register in unit converter: BaseUnit <-> BaseUnit
            unitConverter.SetConversionFunction<MolarEnergy>(MolarEnergyUnit.JoulePerMole, MolarEnergyUnit.JoulePerMole, quantity => quantity);

            // Register in unit converter: BaseUnit -> MolarEnergyUnit
            unitConverter.SetConversionFunction<MolarEnergy>(MolarEnergyUnit.JoulePerMole, MolarEnergyUnit.KilojoulePerMole, quantity => quantity.ToUnit(MolarEnergyUnit.KilojoulePerMole));
            unitConverter.SetConversionFunction<MolarEnergy>(MolarEnergyUnit.JoulePerMole, MolarEnergyUnit.MegajoulePerMole, quantity => quantity.ToUnit(MolarEnergyUnit.MegajoulePerMole));
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(MolarEnergyUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="provider">Format to use for localization. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        public static string GetAbbreviation(MolarEnergyUnit unit, IFormatProvider? provider)
        {
            return UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="MolarEnergy"/> from <see cref="MolarEnergyUnit.JoulePerMole"/>.
        /// </summary>
        public static MolarEnergy FromJoulesPerMole(double value)
        {
            return new MolarEnergy(value, MolarEnergyUnit.JoulePerMole);
        }

        /// <summary>
        ///     Creates a <see cref="MolarEnergy"/> from <see cref="MolarEnergyUnit.KilojoulePerMole"/>.
        /// </summary>
        public static MolarEnergy FromKilojoulesPerMole(double value)
        {
            return new MolarEnergy(value, MolarEnergyUnit.KilojoulePerMole);
        }

        /// <summary>
        ///     Creates a <see cref="MolarEnergy"/> from <see cref="MolarEnergyUnit.MegajoulePerMole"/>.
        /// </summary>
        public static MolarEnergy FromMegajoulesPerMole(double value)
        {
            return new MolarEnergy(value, MolarEnergyUnit.MegajoulePerMole);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="MolarEnergyUnit" /> to <see cref="MolarEnergy" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>MolarEnergy unit value.</returns>
        public static MolarEnergy From(double value, MolarEnergyUnit fromUnit)
        {
            return new MolarEnergy(value, fromUnit);
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
        public static MolarEnergy Parse(string str)
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
        public static MolarEnergy Parse(string str, IFormatProvider? provider)
        {
            return UnitsNetSetup.Default.QuantityParser.Parse<MolarEnergy, MolarEnergyUnit>(
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
        public static bool TryParse([NotNullWhen(true)]string? str, out MolarEnergy result)
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
        public static bool TryParse([NotNullWhen(true)]string? str, IFormatProvider? provider, out MolarEnergy result)
        {
            return UnitsNetSetup.Default.QuantityParser.TryParse<MolarEnergy, MolarEnergyUnit>(
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
        public static MolarEnergyUnit ParseUnit(string str)
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
        public static MolarEnergyUnit ParseUnit(string str, IFormatProvider? provider)
        {
            return UnitParser.Default.Parse(str, Info.UnitInfos, provider).Value;
        }

        /// <inheritdoc cref="TryParseUnit(string,IFormatProvider,out UnitsNet.Units.MolarEnergyUnit)"/>
        public static bool TryParseUnit([NotNullWhen(true)]string? str, out MolarEnergyUnit unit)
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
        public static bool TryParseUnit([NotNullWhen(true)]string? str, IFormatProvider? provider, out MolarEnergyUnit unit)
        {
            return UnitParser.Default.TryParse(str, Info, provider, out unit);
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>Negate the value.</summary>
        public static MolarEnergy operator -(MolarEnergy right)
        {
            return new MolarEnergy(-right.Value, right.Unit);
        }

        /// <summary>Get <see cref="MolarEnergy"/> from adding two <see cref="MolarEnergy"/>.</summary>
        public static MolarEnergy operator +(MolarEnergy left, MolarEnergy right)
        {
            return new MolarEnergy(left.Value + right.ToUnit(left.Unit).Value, left.Unit);
        }

        /// <summary>Get <see cref="MolarEnergy"/> from subtracting two <see cref="MolarEnergy"/>.</summary>
        public static MolarEnergy operator -(MolarEnergy left, MolarEnergy right)
        {
            return new MolarEnergy(left.Value - right.ToUnit(left.Unit).Value, left.Unit);
        }

        /// <summary>Get <see cref="MolarEnergy"/> from multiplying value and <see cref="MolarEnergy"/>.</summary>
        public static MolarEnergy operator *(double left, MolarEnergy right)
        {
            return new MolarEnergy(left * right.Value, right.Unit);
        }

        /// <summary>Get <see cref="MolarEnergy"/> from multiplying value and <see cref="MolarEnergy"/>.</summary>
        public static MolarEnergy operator *(MolarEnergy left, double right)
        {
            return new MolarEnergy(left.Value * right, left.Unit);
        }

        /// <summary>Get <see cref="MolarEnergy"/> from dividing <see cref="MolarEnergy"/> by value.</summary>
        public static MolarEnergy operator /(MolarEnergy left, double right)
        {
            return new MolarEnergy(left.Value / right, left.Unit);
        }

        /// <summary>Get ratio value from dividing <see cref="MolarEnergy"/> by <see cref="MolarEnergy"/>.</summary>
        public static double operator /(MolarEnergy left, MolarEnergy right)
        {
            return left.JoulesPerMole / right.JoulesPerMole;
        }

        #endregion

        #region Relational Operators

        /// <summary>Get <see cref="Energy"/> from <see cref="MolarEnergy"/> * <see cref="AmountOfSubstance"/>.</summary>
        public static Energy operator *(MolarEnergy molarEnergy, AmountOfSubstance amountOfSubstance)
        {
            return Energy.FromJoules(molarEnergy.JoulesPerMole * amountOfSubstance.Moles);
        }

        #endregion

        #region Equality / IComparable

        /// <summary>Returns true if less or equal to.</summary>
        public static bool operator <=(MolarEnergy left, MolarEnergy right)
        {
            return left.Value <= right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if greater than or equal to.</summary>
        public static bool operator >=(MolarEnergy left, MolarEnergy right)
        {
            return left.Value >= right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if less than.</summary>
        public static bool operator <(MolarEnergy left, MolarEnergy right)
        {
            return left.Value < right.ToUnit(left.Unit).Value;
        }

        /// <summary>Returns true if greater than.</summary>
        public static bool operator >(MolarEnergy left, MolarEnergy right)
        {
            return left.Value > right.ToUnit(left.Unit).Value;
        }

        // We use obsolete attribute to communicate the preferred equality members to use.
        // CS0809: Obsolete member 'memberA' overrides non-obsolete member 'memberB'.
        #pragma warning disable CS0809

        /// <summary>Indicates strict equality of two <see cref="MolarEnergy"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("For null checks, use `x is null` syntax to not invoke overloads. For equality checks, use Equals(MolarEnergy other, MolarEnergy tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public static bool operator ==(MolarEnergy left, MolarEnergy right)
        {
            return left.Equals(right);
        }

        /// <summary>Indicates strict inequality of two <see cref="MolarEnergy"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("For null checks, use `x is null` syntax to not invoke overloads. For equality checks, use Equals(MolarEnergy other, MolarEnergy tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public static bool operator !=(MolarEnergy left, MolarEnergy right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        /// <summary>Indicates strict equality of two <see cref="MolarEnergy"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("Use Equals(MolarEnergy other, MolarEnergy tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is MolarEnergy otherQuantity))
                return false;

            return Equals(otherQuantity);
        }

        /// <inheritdoc />
        /// <summary>Indicates strict equality of two <see cref="MolarEnergy"/> quantities, where both <see cref="Value" /> and <see cref="Unit" /> are exactly equal.</summary>
        [Obsolete("Use Equals(MolarEnergy other, MolarEnergy tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public bool Equals(MolarEnergy other)
        {
            return new { Value, Unit }.Equals(new { other.Value, other.Unit });
        }

        #pragma warning restore CS0809

        /// <summary>Compares the current <see cref="MolarEnergy"/> with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other when converted to the same unit.</summary>
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
            if (!(obj is MolarEnergy otherQuantity)) throw new ArgumentException("Expected type MolarEnergy.", nameof(obj));

            return CompareTo(otherQuantity);
        }

        /// <summary>Compares the current <see cref="MolarEnergy"/> with another <see cref="MolarEnergy"/> and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other when converted to the same unit.</summary>
        /// <param name="other">A quantity to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the quantities being compared. The return value has these meanings:
        ///     <list type="table">
        ///         <listheader><term> Value</term><description> Meaning</description></listheader>
        ///         <item><term> Less than zero</term><description> This instance precedes <paramref name="other" /> in the sort order.</description></item>
        ///         <item><term> Zero</term><description> This instance occurs in the same position in the sort order as <paramref name="other" />.</description></item>
        ///         <item><term> Greater than zero</term><description> This instance follows <paramref name="other" /> in the sort order.</description></item>
        ///     </list>
        /// </returns>
        public int CompareTo(MolarEnergy other)
        {
            return _value.CompareTo(other.ToUnit(this.Unit).Value);
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another MolarEnergy within the given absolute or relative tolerance.
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
        [Obsolete("Use Equals(MolarEnergy other, MolarEnergy tolerance) instead, to check equality across units and to specify the max tolerance for rounding errors due to floating-point arithmetic when converting between units.")]
        public bool Equals(MolarEnergy other, double tolerance, ComparisonType comparisonType)
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
            return other is MolarEnergy otherTyped
                   && (tolerance is MolarEnergy toleranceTyped
                       ? true
                       : throw new ArgumentException($"Tolerance quantity ({tolerance.QuantityInfo.Name}) did not match the other quantities of type 'MolarEnergy'.", nameof(tolerance)))
                   && Equals(otherTyped, toleranceTyped);
        }

        /// <inheritdoc />
        public bool Equals(MolarEnergy other, MolarEnergy tolerance)
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
        /// <returns>A hash code for the current MolarEnergy.</returns>
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
        public double As(MolarEnergyUnit unit)
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
        ///     Converts this MolarEnergy to another MolarEnergy with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>A MolarEnergy with the specified unit.</returns>
        public MolarEnergy ToUnit(MolarEnergyUnit unit)
        {
            return ToUnit(unit, DefaultConversionFunctions);
        }

        /// <summary>
        ///     Converts this <see cref="MolarEnergy"/> to another <see cref="MolarEnergy"/> using the given <paramref name="unitConverter"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to use for the conversion.</param>
        /// <returns>A MolarEnergy with the specified unit.</returns>
        public MolarEnergy ToUnit(MolarEnergyUnit unit, UnitConverter unitConverter)
        {
            if (TryToUnit(unit, out var converted))
            {
                // Try to convert using the auto-generated conversion methods.
                return converted!.Value;
            }
            else if (unitConverter.TryGetConversionFunction((typeof(MolarEnergy), Unit, typeof(MolarEnergy), unit), out var conversionFunction))
            {
                // See if the unit converter has an extensibility conversion registered.
                return (MolarEnergy)conversionFunction(this);
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
        ///     Attempts to convert this <see cref="MolarEnergy"/> to another <see cref="MolarEnergy"/> with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <param name="unit">The unit to convert to.</param>
        /// <param name="converted">The converted <see cref="MolarEnergy"/> in <paramref name="unit"/>, if successful.</param>
        /// <returns>True if successful, otherwise false.</returns>
        private bool TryToUnit(MolarEnergyUnit unit, [NotNullWhen(true)] out MolarEnergy? converted)
        {
            if (Unit == unit)
            {
                converted = this;
                return true;
            }

            MolarEnergy? convertedOrNull = (Unit, unit) switch
            {
                // MolarEnergyUnit -> BaseUnit
                (MolarEnergyUnit.KilojoulePerMole, MolarEnergyUnit.JoulePerMole) => new MolarEnergy((_value) * 1e3d, MolarEnergyUnit.JoulePerMole),
                (MolarEnergyUnit.MegajoulePerMole, MolarEnergyUnit.JoulePerMole) => new MolarEnergy((_value) * 1e6d, MolarEnergyUnit.JoulePerMole),

                // BaseUnit -> MolarEnergyUnit
                (MolarEnergyUnit.JoulePerMole, MolarEnergyUnit.KilojoulePerMole) => new MolarEnergy((_value) / 1e3d, MolarEnergyUnit.KilojoulePerMole),
                (MolarEnergyUnit.JoulePerMole, MolarEnergyUnit.MegajoulePerMole) => new MolarEnergy((_value) / 1e6d, MolarEnergyUnit.MegajoulePerMole),

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
        public MolarEnergy ToUnit(UnitSystem unitSystem)
        {
            return ToUnit(Info.GetDefaultUnit(unitSystem));
        }

        #region Explicit implementations

        double IQuantity.As(Enum unit)
        {
            if (unit is not MolarEnergyUnit typedUnit)
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(MolarEnergyUnit)} is supported.", nameof(unit));

            return As(typedUnit);
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(Enum unit)
        {
            if (!(unit is MolarEnergyUnit typedUnit))
                throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(MolarEnergyUnit)} is supported.", nameof(unit));

            return ToUnit(typedUnit, DefaultConversionFunctions);
        }

        /// <inheritdoc />
        IQuantity IQuantity.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

        /// <inheritdoc />
        IQuantity<MolarEnergyUnit> IQuantity<MolarEnergyUnit>.ToUnit(MolarEnergyUnit unit) => ToUnit(unit);

        /// <inheritdoc />
        IQuantity<MolarEnergyUnit> IQuantity<MolarEnergyUnit>.ToUnit(UnitSystem unitSystem) => ToUnit(unitSystem);

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
        public string ToString(string? format = null, IFormatProvider? provider = null)
        {
            return QuantityFormatter.Default.Format(this, format, provider);
        }

        #endregion

    }
}
