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
//     Add Extensions\MyQuantityExtensions.cs to decorate quantities with new behavior.
//     Add UnitDefinitions\MyQuantity.json and run GeneratUnits.bat to generate new units or quantities.
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
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     A geometric property of an area that reflects how its points are distributed with regard to an axis.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart

    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
#if WINDOWS_UWP
    public sealed partial class AreaMomentOfInertia : IQuantity
#else
    public partial struct AreaMomentOfInertia : IQuantity, IComparable, IComparable<AreaMomentOfInertia>
#endif
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly AreaMomentOfInertiaUnit? _unit;

        /// <summary>
        ///     The unit this quantity was constructed with -or- <see cref="BaseUnit" /> if default ctor was used.
        /// </summary>
        public AreaMomentOfInertiaUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        static AreaMomentOfInertia()
        {
            BaseDimensions = new BaseDimensions(4, 0, 0, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Creates the quantity with the given value in the base unit MeterToTheFourth.
        /// </summary>
        [Obsolete("Use the constructor that takes a unit parameter. This constructor will be removed in a future version.")]
        public AreaMomentOfInertia(double meterstothefourth)
        {
            _value = Convert.ToDouble(meterstothefourth);
            _unit = BaseUnit;
        }

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="numericValue">Numeric value.</param>
        /// <param name="unit">Unit representation.</param>
        /// <remarks>Value parameter cannot be named 'value' due to constraint when targeting Windows Runtime Component.</remarks>
#if WINDOWS_UWP
        private
#else
        public
#endif
        AreaMomentOfInertia(double numericValue, AreaMomentOfInertiaUnit unit)
        {
            _value = numericValue;
            _unit = unit;
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        /// <summary>
        ///     Creates the quantity with the given value assuming the base unit MeterToTheFourth.
        /// </summary>
        /// <param name="meterstothefourth">Value assuming base unit MeterToTheFourth.</param>
#if WINDOWS_UWP
        private
#else
        [Obsolete("Use the constructor that takes a unit parameter. This constructor will be removed in a future version.")]
        public
#endif
        AreaMomentOfInertia(long meterstothefourth) : this(Convert.ToDouble(meterstothefourth), BaseUnit) { }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        // Windows Runtime Component does not support decimal type
        /// <summary>
        ///     Creates the quantity with the given value assuming the base unit MeterToTheFourth.
        /// </summary>
        /// <param name="meterstothefourth">Value assuming base unit MeterToTheFourth.</param>
#if WINDOWS_UWP
        private
#else
        [Obsolete("Use the constructor that takes a unit parameter. This constructor will be removed in a future version.")]
        public
#endif
        AreaMomentOfInertia(decimal meterstothefourth) : this(Convert.ToDouble(meterstothefourth), BaseUnit) { }

        #region Properties

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        public static QuantityType QuantityType => QuantityType.AreaMomentOfInertia;

        /// <summary>
        ///     The base unit representation of this quantity for the numeric value stored internally. All conversions go via this value.
        /// </summary>
        public static AreaMomentOfInertiaUnit BaseUnit => AreaMomentOfInertiaUnit.MeterToTheFourth;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions
        {
            get;
        }

        /// <summary>
        ///     All units of measurement for the AreaMomentOfInertia quantity.
        /// </summary>
        public static AreaMomentOfInertiaUnit[] Units { get; } = Enum.GetValues(typeof(AreaMomentOfInertiaUnit)).Cast<AreaMomentOfInertiaUnit>().Except(new AreaMomentOfInertiaUnit[]{ AreaMomentOfInertiaUnit.Undefined }).ToArray();

        /// <summary>
        ///     Get AreaMomentOfInertia in CentimetersToTheFourth.
        /// </summary>
        public double CentimetersToTheFourth => As(AreaMomentOfInertiaUnit.CentimeterToTheFourth);

        /// <summary>
        ///     Get AreaMomentOfInertia in DecimetersToTheFourth.
        /// </summary>
        public double DecimetersToTheFourth => As(AreaMomentOfInertiaUnit.DecimeterToTheFourth);

        /// <summary>
        ///     Get AreaMomentOfInertia in FeetToTheFourth.
        /// </summary>
        public double FeetToTheFourth => As(AreaMomentOfInertiaUnit.FootToTheFourth);

        /// <summary>
        ///     Get AreaMomentOfInertia in InchesToTheFourth.
        /// </summary>
        public double InchesToTheFourth => As(AreaMomentOfInertiaUnit.InchToTheFourth);

        /// <summary>
        ///     Get AreaMomentOfInertia in MetersToTheFourth.
        /// </summary>
        public double MetersToTheFourth => As(AreaMomentOfInertiaUnit.MeterToTheFourth);

        /// <summary>
        ///     Get AreaMomentOfInertia in MillimetersToTheFourth.
        /// </summary>
        public double MillimetersToTheFourth => As(AreaMomentOfInertiaUnit.MillimeterToTheFourth);

        #endregion

        #region Static

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit MeterToTheFourth.
        /// </summary>
        public static AreaMomentOfInertia Zero => new AreaMomentOfInertia(0, BaseUnit);

        /// <summary>
        ///     Get AreaMomentOfInertia from CentimetersToTheFourth.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static AreaMomentOfInertia FromCentimetersToTheFourth(double centimeterstothefourth)
#else
        public static AreaMomentOfInertia FromCentimetersToTheFourth(QuantityValue centimeterstothefourth)
#endif
        {
            double value = (double) centimeterstothefourth;
            return new AreaMomentOfInertia(value, AreaMomentOfInertiaUnit.CentimeterToTheFourth);
        }

        /// <summary>
        ///     Get AreaMomentOfInertia from DecimetersToTheFourth.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static AreaMomentOfInertia FromDecimetersToTheFourth(double decimeterstothefourth)
#else
        public static AreaMomentOfInertia FromDecimetersToTheFourth(QuantityValue decimeterstothefourth)
#endif
        {
            double value = (double) decimeterstothefourth;
            return new AreaMomentOfInertia(value, AreaMomentOfInertiaUnit.DecimeterToTheFourth);
        }

        /// <summary>
        ///     Get AreaMomentOfInertia from FeetToTheFourth.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static AreaMomentOfInertia FromFeetToTheFourth(double feettothefourth)
#else
        public static AreaMomentOfInertia FromFeetToTheFourth(QuantityValue feettothefourth)
#endif
        {
            double value = (double) feettothefourth;
            return new AreaMomentOfInertia(value, AreaMomentOfInertiaUnit.FootToTheFourth);
        }

        /// <summary>
        ///     Get AreaMomentOfInertia from InchesToTheFourth.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static AreaMomentOfInertia FromInchesToTheFourth(double inchestothefourth)
#else
        public static AreaMomentOfInertia FromInchesToTheFourth(QuantityValue inchestothefourth)
#endif
        {
            double value = (double) inchestothefourth;
            return new AreaMomentOfInertia(value, AreaMomentOfInertiaUnit.InchToTheFourth);
        }

        /// <summary>
        ///     Get AreaMomentOfInertia from MetersToTheFourth.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static AreaMomentOfInertia FromMetersToTheFourth(double meterstothefourth)
#else
        public static AreaMomentOfInertia FromMetersToTheFourth(QuantityValue meterstothefourth)
#endif
        {
            double value = (double) meterstothefourth;
            return new AreaMomentOfInertia(value, AreaMomentOfInertiaUnit.MeterToTheFourth);
        }

        /// <summary>
        ///     Get AreaMomentOfInertia from MillimetersToTheFourth.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static AreaMomentOfInertia FromMillimetersToTheFourth(double millimeterstothefourth)
#else
        public static AreaMomentOfInertia FromMillimetersToTheFourth(QuantityValue millimeterstothefourth)
#endif
        {
            double value = (double) millimeterstothefourth;
            return new AreaMomentOfInertia(value, AreaMomentOfInertiaUnit.MillimeterToTheFourth);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AreaMomentOfInertiaUnit" /> to <see cref="AreaMomentOfInertia" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>AreaMomentOfInertia unit value.</returns>
#if WINDOWS_UWP
        // Fix name conflict with parameter "value"
        [return: System.Runtime.InteropServices.WindowsRuntime.ReturnValueName("returnValue")]
        public static AreaMomentOfInertia From(double value, AreaMomentOfInertiaUnit fromUnit)
#else
        public static AreaMomentOfInertia From(QuantityValue value, AreaMomentOfInertiaUnit fromUnit)
#endif
        {
            return new AreaMomentOfInertia((double)value, fromUnit);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(AreaMomentOfInertiaUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if(obj is null) throw new ArgumentNullException(nameof(obj));
            if(!(obj is AreaMomentOfInertia)) throw new ArgumentException("Expected type AreaMomentOfInertia.", nameof(obj));

            return CompareTo((AreaMomentOfInertia)obj);
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(AreaMomentOfInertia other)
        {
            return _value.CompareTo(other.AsBaseNumericType(this.Unit));
        }

        [Obsolete("It is not safe to compare equality due to using System.Double as the internal representation. It is very easy to get slightly different values due to floating point operations. Instead use Equals(AreaMomentOfInertia, double, ComparisonType) to provide the max allowed absolute or relative error.")]
        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is AreaMomentOfInertia))
                return false;

            var objQuantity = (AreaMomentOfInertia)obj;
            return _value.Equals(objQuantity.AsBaseNumericType(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another AreaMomentOfInertia within the given absolute or relative tolerance.
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
        public bool Equals(AreaMomentOfInertia other, double tolerance, ComparisonType comparisonType)
        {
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0.");

            double thisValue = (double)this.Value;
            double otherValueInThisUnits = other.As(this.Unit);

            return UnitsNet.Comparison.Equals(thisValue, otherValueInThisUnits, tolerance, comparisonType);
        }

        /// <summary>
        ///     Compare equality to another AreaMomentOfInertia by specifying a max allowed difference.
        ///     Note that it is advised against specifying zero difference, due to the nature
        ///     of floating point operations and using System.Double internally.
        /// </summary>
        /// <param name="other">Other quantity to compare to.</param>
        /// <param name="maxError">Max error allowed.</param>
        /// <returns>True if the difference between the two values is not greater than the specified max.</returns>
        [Obsolete("Please use the Equals(AreaMomentOfInertia, double, ComparisonType) overload. This method will be removed in a future version.")]
        public bool Equals(AreaMomentOfInertia other, AreaMomentOfInertia maxError)
        {
            return Math.Abs(_value - other.AsBaseNumericType(this.Unit)) <= maxError.AsBaseNumericType(this.Unit);
        }

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current AreaMomentOfInertia.</returns>
        public override int GetHashCode()
        {
            return new { type = typeof(AreaMomentOfInertia), Value, Unit }.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(AreaMomentOfInertiaUnit unit)
        {
            if(Unit == unit)
                return Convert.ToDouble(Value);

            var converted = AsBaseNumericType(unit);
            return Convert.ToDouble(converted);
        }

        /// <summary>
        ///     Converts this AreaMomentOfInertia to another AreaMomentOfInertia with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A AreaMomentOfInertia with the specified unit.</returns>
        public AreaMomentOfInertia ToUnit(AreaMomentOfInertiaUnit unit)
        {
            var convertedValue = AsBaseNumericType(unit);
            return new AreaMomentOfInertia(convertedValue, unit);
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
                case AreaMomentOfInertiaUnit.CentimeterToTheFourth: return _value/1e8;
                case AreaMomentOfInertiaUnit.DecimeterToTheFourth: return _value/1e4;
                case AreaMomentOfInertiaUnit.FootToTheFourth: return _value*Math.Pow(0.3048, 4);
                case AreaMomentOfInertiaUnit.InchToTheFourth: return _value*Math.Pow(2.54e-2, 4);
                case AreaMomentOfInertiaUnit.MeterToTheFourth: return _value;
                case AreaMomentOfInertiaUnit.MillimeterToTheFourth: return _value/1e12;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double AsBaseNumericType(AreaMomentOfInertiaUnit unit)
        {
            if(Unit == unit)
                return _value;

            var baseUnitValue = AsBaseUnit();

            switch(unit)
            {
                case AreaMomentOfInertiaUnit.CentimeterToTheFourth: return baseUnitValue*1e8;
                case AreaMomentOfInertiaUnit.DecimeterToTheFourth: return baseUnitValue*1e4;
                case AreaMomentOfInertiaUnit.FootToTheFourth: return baseUnitValue/Math.Pow(0.3048, 4);
                case AreaMomentOfInertiaUnit.InchToTheFourth: return baseUnitValue/Math.Pow(2.54e-2, 4);
                case AreaMomentOfInertiaUnit.MeterToTheFourth: return baseUnitValue;
                case AreaMomentOfInertiaUnit.MillimeterToTheFourth: return baseUnitValue*1e12;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }

        #endregion

        #region Parsing

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
        public static AreaMomentOfInertia Parse(string str)
        {
            return Parse(str, null);
        }

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="result">Resulting unit quantity if successful.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        public static bool TryParse([CanBeNull] string str, out AreaMomentOfInertia result)
        {
            return TryParse(str, null, out result);
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
        public static AreaMomentOfInertiaUnit ParseUnit(string str)
        {
            return ParseUnit(str, (IFormatProvider)null);
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is MeterToTheFourth
        /// </summary>
        [Obsolete("This is no longer used since we will instead use the quantity's Unit value as default.")]
        public static AreaMomentOfInertiaUnit ToStringDefaultUnit { get; set; } = AreaMomentOfInertiaUnit.MeterToTheFourth;

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(Unit);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using current UI culture and two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(AreaMomentOfInertiaUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        /// Represents the largest possible value of AreaMomentOfInertia
        /// </summary>
        public static AreaMomentOfInertia MaxValue => new AreaMomentOfInertia(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of AreaMomentOfInertia
        /// </summary>
        public static AreaMomentOfInertia MinValue => new AreaMomentOfInertia(double.MinValue, BaseUnit);

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        public QuantityType Type => AreaMomentOfInertia.QuantityType;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => AreaMomentOfInertia.BaseDimensions;
    }
}
