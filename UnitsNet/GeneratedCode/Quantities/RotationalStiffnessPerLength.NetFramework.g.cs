﻿//------------------------------------------------------------------------------
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

// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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
    ///     https://en.wikipedia.org/wiki/Stiffness#Rotational_stiffness
    /// </summary>
    public partial struct RotationalStiffnessPerLength : IQuantity<RotationalStiffnessPerLengthUnit>, IEquatable<RotationalStiffnessPerLength>, IComparable, IComparable<RotationalStiffnessPerLength>, IConvertible
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly RotationalStiffnessPerLengthUnit? _unit;

        static RotationalStiffnessPerLength()
        {
            BaseDimensions = new BaseDimensions(1, 1, -2, 0, 0, 0, 0);
            Info = new QuantityInfo<RotationalStiffnessPerLengthUnit>(QuantityType.RotationalStiffnessPerLength, Units, BaseUnit, Zero, BaseDimensions);
        }

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="numericValue">The numeric value  to contruct this quantity with.</param>
        /// <param name="unit">The unit representation to contruct this quantity with.</param>
        /// <remarks>Value parameter cannot be named 'value' due to constraint when targeting Windows Runtime Component.</remarks>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public RotationalStiffnessPerLength(double numericValue, RotationalStiffnessPerLengthUnit unit)
        {
            if(unit == RotationalStiffnessPerLengthUnit.Undefined)
              throw new ArgumentException("The quantity can not be created with an undefined unit.", nameof(unit));

            _value = Guard.EnsureValidNumber(numericValue, nameof(numericValue));
            _unit = unit;
        }

        #region Static Properties

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        public static QuantityInfo<RotationalStiffnessPerLengthUnit> Info { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions { get; }

        /// <summary>
        ///     The base unit of RotationalStiffnessPerLength, which is NewtonMeterPerRadianPerMeter. All conversions go via this value.
        /// </summary>
        public static RotationalStiffnessPerLengthUnit BaseUnit { get; } = RotationalStiffnessPerLengthUnit.NewtonMeterPerRadianPerMeter;

        /// <summary>
        /// Represents the largest possible value of RotationalStiffnessPerLength
        /// </summary>
        public static RotationalStiffnessPerLength MaxValue { get; } = new RotationalStiffnessPerLength(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of RotationalStiffnessPerLength
        /// </summary>
        public static RotationalStiffnessPerLength MinValue { get; } = new RotationalStiffnessPerLength(double.MinValue, BaseUnit);

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        public static QuantityType QuantityType { get; } = QuantityType.RotationalStiffnessPerLength;

        /// <summary>
        ///     All units of measurement for the RotationalStiffnessPerLength quantity.
        /// </summary>
        public static RotationalStiffnessPerLengthUnit[] Units { get; } = Enum.GetValues(typeof(RotationalStiffnessPerLengthUnit)).Cast<RotationalStiffnessPerLengthUnit>().Except(new RotationalStiffnessPerLengthUnit[]{ RotationalStiffnessPerLengthUnit.Undefined }).ToArray();

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit NewtonMeterPerRadianPerMeter.
        /// </summary>
        public static RotationalStiffnessPerLength Zero { get; } = new RotationalStiffnessPerLength(0, BaseUnit);

        #endregion

        #region Properties

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc cref="IQuantity.Unit"/>
        Enum IQuantity.Unit => Unit;

        /// <summary>
        ///     The unit this quantity was constructed with -or- <see cref="BaseUnit" /> if default ctor was used.
        /// </summary>
        public RotationalStiffnessPerLengthUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        public QuantityInfo<RotationalStiffnessPerLengthUnit> QuantityInfo => Info;

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        QuantityInfo IQuantity.QuantityInfo => Info;

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        public QuantityType Type => RotationalStiffnessPerLength.QuantityType;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => RotationalStiffnessPerLength.BaseDimensions;

        #endregion

        #region Conversion Properties

        /// <summary>
        ///     Get RotationalStiffnessPerLength in KilonewtonMetersPerRadianPerMeter.
        /// </summary>
        public double KilonewtonMetersPerRadianPerMeter => As(RotationalStiffnessPerLengthUnit.KilonewtonMeterPerRadianPerMeter);

        /// <summary>
        ///     Get RotationalStiffnessPerLength in MeganewtonMetersPerRadianPerMeter.
        /// </summary>
        public double MeganewtonMetersPerRadianPerMeter => As(RotationalStiffnessPerLengthUnit.MeganewtonMeterPerRadianPerMeter);

        /// <summary>
        ///     Get RotationalStiffnessPerLength in NewtonMetersPerRadianPerMeter.
        /// </summary>
        public double NewtonMetersPerRadianPerMeter => As(RotationalStiffnessPerLengthUnit.NewtonMeterPerRadianPerMeter);

        #endregion

        #region Static Methods

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(RotationalStiffnessPerLengthUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        /// <param name="provider">Format to use for localization. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static string GetAbbreviation(RotationalStiffnessPerLengthUnit unit, [CanBeNull] IFormatProvider provider)
        {
            return UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit, provider);
        }

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Get RotationalStiffnessPerLength from KilonewtonMetersPerRadianPerMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffnessPerLength FromKilonewtonMetersPerRadianPerMeter(QuantityValue kilonewtonmetersperradianpermeter)
        {
            double value = (double) kilonewtonmetersperradianpermeter;
            return new RotationalStiffnessPerLength(value, RotationalStiffnessPerLengthUnit.KilonewtonMeterPerRadianPerMeter);
        }
        /// <summary>
        ///     Get RotationalStiffnessPerLength from MeganewtonMetersPerRadianPerMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffnessPerLength FromMeganewtonMetersPerRadianPerMeter(QuantityValue meganewtonmetersperradianpermeter)
        {
            double value = (double) meganewtonmetersperradianpermeter;
            return new RotationalStiffnessPerLength(value, RotationalStiffnessPerLengthUnit.MeganewtonMeterPerRadianPerMeter);
        }
        /// <summary>
        ///     Get RotationalStiffnessPerLength from NewtonMetersPerRadianPerMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffnessPerLength FromNewtonMetersPerRadianPerMeter(QuantityValue newtonmetersperradianpermeter)
        {
            double value = (double) newtonmetersperradianpermeter;
            return new RotationalStiffnessPerLength(value, RotationalStiffnessPerLengthUnit.NewtonMeterPerRadianPerMeter);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RotationalStiffnessPerLengthUnit" /> to <see cref="RotationalStiffnessPerLength" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>RotationalStiffnessPerLength unit value.</returns>
        public static RotationalStiffnessPerLength From(QuantityValue value, RotationalStiffnessPerLengthUnit fromUnit)
        {
            return new RotationalStiffnessPerLength((double)value, fromUnit);
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
        public static RotationalStiffnessPerLength Parse(string str)
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
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static RotationalStiffnessPerLength Parse(string str, [CanBeNull] IFormatProvider provider)
        {
            return QuantityParser.Default.Parse<RotationalStiffnessPerLength, RotationalStiffnessPerLengthUnit>(
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
        public static bool TryParse([CanBeNull] string str, out RotationalStiffnessPerLength result)
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
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static bool TryParse([CanBeNull] string str, [CanBeNull] IFormatProvider provider, out RotationalStiffnessPerLength result)
        {
            return QuantityParser.Default.TryParse<RotationalStiffnessPerLength, RotationalStiffnessPerLengthUnit>(
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
        public static RotationalStiffnessPerLengthUnit ParseUnit(string str)
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
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static RotationalStiffnessPerLengthUnit ParseUnit(string str, IFormatProvider provider = null)
        {
            return UnitParser.Default.Parse<RotationalStiffnessPerLengthUnit>(str, provider);
        }

        public static bool TryParseUnit(string str, out RotationalStiffnessPerLengthUnit unit)
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
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public static bool TryParseUnit(string str, IFormatProvider provider, out RotationalStiffnessPerLengthUnit unit)
        {
            return UnitParser.Default.TryParse<RotationalStiffnessPerLengthUnit>(str, provider, out unit);
        }

        #endregion

        #region Arithmetic Operators

        public static RotationalStiffnessPerLength operator -(RotationalStiffnessPerLength right)
        {
            return new RotationalStiffnessPerLength(-right.Value, right.Unit);
        }

        public static RotationalStiffnessPerLength operator +(RotationalStiffnessPerLength left, RotationalStiffnessPerLength right)
        {
            return new RotationalStiffnessPerLength(left.Value + right.AsBaseNumericType(left.Unit), left.Unit);
        }

        public static RotationalStiffnessPerLength operator -(RotationalStiffnessPerLength left, RotationalStiffnessPerLength right)
        {
            return new RotationalStiffnessPerLength(left.Value - right.AsBaseNumericType(left.Unit), left.Unit);
        }

        public static RotationalStiffnessPerLength operator *(double left, RotationalStiffnessPerLength right)
        {
            return new RotationalStiffnessPerLength(left * right.Value, right.Unit);
        }

        public static RotationalStiffnessPerLength operator *(RotationalStiffnessPerLength left, double right)
        {
            return new RotationalStiffnessPerLength(left.Value * right, left.Unit);
        }

        public static RotationalStiffnessPerLength operator /(RotationalStiffnessPerLength left, double right)
        {
            return new RotationalStiffnessPerLength(left.Value / right, left.Unit);
        }

        public static double operator /(RotationalStiffnessPerLength left, RotationalStiffnessPerLength right)
        {
            return left.NewtonMetersPerRadianPerMeter / right.NewtonMetersPerRadianPerMeter;
        }

        #endregion

        #region Equality / IComparable

        public static bool operator <=(RotationalStiffnessPerLength left, RotationalStiffnessPerLength right)
        {
            return left.Value <= right.AsBaseNumericType(left.Unit);
        }

        public static bool operator >=(RotationalStiffnessPerLength left, RotationalStiffnessPerLength right)
        {
            return left.Value >= right.AsBaseNumericType(left.Unit);
        }

        public static bool operator <(RotationalStiffnessPerLength left, RotationalStiffnessPerLength right)
        {
            return left.Value < right.AsBaseNumericType(left.Unit);
        }

        public static bool operator >(RotationalStiffnessPerLength left, RotationalStiffnessPerLength right)
        {
            return left.Value > right.AsBaseNumericType(left.Unit);
        }

        public static bool operator ==(RotationalStiffnessPerLength left, RotationalStiffnessPerLength right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RotationalStiffnessPerLength left, RotationalStiffnessPerLength right)
        {
            return !(left == right);
        }

        public int CompareTo(object obj)
        {
            if(obj is null) throw new ArgumentNullException(nameof(obj));
            if(!(obj is RotationalStiffnessPerLength objRotationalStiffnessPerLength)) throw new ArgumentException("Expected type RotationalStiffnessPerLength.", nameof(obj));

            return CompareTo(objRotationalStiffnessPerLength);
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        public int CompareTo(RotationalStiffnessPerLength other)
        {
            return _value.CompareTo(other.AsBaseNumericType(this.Unit));
        }

        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is RotationalStiffnessPerLength objRotationalStiffnessPerLength))
                return false;

            return Equals(objRotationalStiffnessPerLength);
        }

        public bool Equals(RotationalStiffnessPerLength other)
        {
            return _value.Equals(other.AsBaseNumericType(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another RotationalStiffnessPerLength within the given absolute or relative tolerance.
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
        public bool Equals(RotationalStiffnessPerLength other, double tolerance, ComparisonType comparisonType)
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
        /// <returns>A hash code for the current RotationalStiffnessPerLength.</returns>
        public override int GetHashCode()
        {
            return new { QuantityType, Value, Unit }.GetHashCode();
        }

        #endregion

        #region Conversion Methods

        double IQuantity.As(Enum unit) => As((RotationalStiffnessPerLengthUnit)unit);

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(RotationalStiffnessPerLengthUnit unit)
        {
            if(Unit == unit)
                return Convert.ToDouble(Value);

            var converted = AsBaseNumericType(unit);
            return Convert.ToDouble(converted);
        }

        public double As(Enum unit) => As((RotationalStiffnessPerLengthUnit) unit);

        /// <summary>
        ///     Converts this RotationalStiffnessPerLength to another RotationalStiffnessPerLength with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A RotationalStiffnessPerLength with the specified unit.</returns>
        public RotationalStiffnessPerLength ToUnit(RotationalStiffnessPerLengthUnit unit)
        {
            var convertedValue = AsBaseNumericType(unit);
            return new RotationalStiffnessPerLength(convertedValue, unit);
        }

        IQuantity<RotationalStiffnessPerLengthUnit> IQuantity<RotationalStiffnessPerLengthUnit>.ToUnit(RotationalStiffnessPerLengthUnit unit) => ToUnit(unit);

        public IQuantity ToUnit(Enum unit) => ToUnit((RotationalStiffnessPerLengthUnit) unit);

        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private double AsBaseUnit()
        {
            switch(Unit)
            {
                case RotationalStiffnessPerLengthUnit.KilonewtonMeterPerRadianPerMeter: return (_value) * 1e3d;
                case RotationalStiffnessPerLengthUnit.MeganewtonMeterPerRadianPerMeter: return (_value) * 1e6d;
                case RotationalStiffnessPerLengthUnit.NewtonMeterPerRadianPerMeter: return _value;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double AsBaseNumericType(RotationalStiffnessPerLengthUnit unit)
        {
            if(Unit == unit)
                return _value;

            var baseUnitValue = AsBaseUnit();

            switch(unit)
            {
                case RotationalStiffnessPerLengthUnit.KilonewtonMeterPerRadianPerMeter: return (baseUnitValue) / 1e3d;
                case RotationalStiffnessPerLengthUnit.MeganewtonMeterPerRadianPerMeter: return (baseUnitValue) / 1e6d;
                case RotationalStiffnessPerLengthUnit.NewtonMeterPerRadianPerMeter: return baseUnitValue;
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
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public string ToString([CanBeNull] IFormatProvider provider)
        {
            return ToString(provider, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public string ToString([CanBeNull] IFormatProvider provider, int significantDigitsAfterRadix)
        {
            var value = Convert.ToDouble(Value);
            var format = UnitFormatter.GetFormat(value, significantDigitsAfterRadix);
            return ToString(provider, format);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        public string ToString([CanBeNull] IFormatProvider provider, [NotNull] string format, [NotNull] params object[] args)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

            provider = provider ?? GlobalConfiguration.DefaultCulture;

            var value = Convert.ToDouble(Value);
            var formatArgs = UnitFormatter.GetFormatArgs(Unit, value, provider, args);
            return string.Format(provider, format, formatArgs);
        }

        #endregion

        #region IConvertible Methods

        TypeCode IConvertible.GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(RotationalStiffnessPerLength)} to bool is not supported.");
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(RotationalStiffnessPerLength)} to char is not supported.");
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException($"Converting {typeof(RotationalStiffnessPerLength)} to DateTime is not supported.");
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
            return ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            if(conversionType == typeof(RotationalStiffnessPerLength))
                return this;
            else if(conversionType == typeof(RotationalStiffnessPerLengthUnit))
                return Unit;
            else if(conversionType == typeof(QuantityType))
                return RotationalStiffnessPerLength.QuantityType;
            else if(conversionType == typeof(BaseDimensions))
                return RotationalStiffnessPerLength.BaseDimensions;
            else
                throw new InvalidCastException($"Converting {typeof(RotationalStiffnessPerLength)} to {conversionType} is not supported.");
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
