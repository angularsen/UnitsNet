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
    ///     Difference between two temperatures. The conversions are different than for Temperature.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart

    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
#if WINDOWS_UWP
    public sealed partial class TemperatureDelta : IQuantity
#else
    public partial struct TemperatureDelta : IQuantity, IComparable, IComparable<TemperatureDelta>
#endif
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly TemperatureDeltaUnit? _unit;

        /// <summary>
        ///     The unit this quantity was constructed with -or- <see cref="BaseUnit" /> if default ctor was used.
        /// </summary>
        public TemperatureDeltaUnit Unit => _unit.GetValueOrDefault(BaseUnit);

        static TemperatureDelta()
        {
        }

        /// <summary>
        ///     Creates the quantity with the given value in the base unit Kelvin.
        /// </summary>
        [Obsolete("Use the constructor that takes a unit parameter. This constructor will be removed in a future version.")]
        public TemperatureDelta(double kelvins)
        {
            _value = Convert.ToDouble(kelvins);
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
        TemperatureDelta(double numericValue, TemperatureDeltaUnit unit)
        {
            _value = numericValue;
            _unit = unit;
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        /// <summary>
        ///     Creates the quantity with the given value assuming the base unit Kelvin.
        /// </summary>
        /// <param name="kelvins">Value assuming base unit Kelvin.</param>
#if WINDOWS_UWP
        private
#else
        [Obsolete("Use the constructor that takes a unit parameter. This constructor will be removed in a future version.")]
        public
#endif
        TemperatureDelta(long kelvins) : this(Convert.ToDouble(kelvins), BaseUnit) { }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        // Windows Runtime Component does not support decimal type
        /// <summary>
        ///     Creates the quantity with the given value assuming the base unit Kelvin.
        /// </summary>
        /// <param name="kelvins">Value assuming base unit Kelvin.</param>
#if WINDOWS_UWP
        private
#else
        [Obsolete("Use the constructor that takes a unit parameter. This constructor will be removed in a future version.")]
        public
#endif
        TemperatureDelta(decimal kelvins) : this(Convert.ToDouble(kelvins), BaseUnit) { }

        #region Properties

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        public static QuantityType QuantityType => QuantityType.TemperatureDelta;

        /// <summary>
        ///     The base unit representation of this quantity for the numeric value stored internally. All conversions go via this value.
        /// </summary>
        public static TemperatureDeltaUnit BaseUnit => TemperatureDeltaUnit.Kelvin;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public static BaseDimensions BaseDimensions
        {
            get;
        }

        /// <summary>
        ///     All units of measurement for the TemperatureDelta quantity.
        /// </summary>
        public static TemperatureDeltaUnit[] Units { get; } = Enum.GetValues(typeof(TemperatureDeltaUnit)).Cast<TemperatureDeltaUnit>().Except(new TemperatureDeltaUnit[]{ TemperatureDeltaUnit.Undefined }).ToArray();

        /// <summary>
        ///     Get TemperatureDelta in DegreesCelsius.
        /// </summary>
        public double DegreesCelsius => As(TemperatureDeltaUnit.DegreeCelsius);

        /// <summary>
        ///     Get TemperatureDelta in DegreesCelsiusDelta.
        /// </summary>
        [System.Obsolete("Deprecated due to github issue #180, please use DegreeCelsius instead")]
        public double DegreesCelsiusDelta => As(TemperatureDeltaUnit.DegreeCelsiusDelta);

        /// <summary>
        ///     Get TemperatureDelta in DegreesDelisle.
        /// </summary>
        public double DegreesDelisle => As(TemperatureDeltaUnit.DegreeDelisle);

        /// <summary>
        ///     Get TemperatureDelta in DegreesDelisleDelta.
        /// </summary>
        [System.Obsolete("Deprecated due to github issue #180, please use DegreeDelisle instead")]
        public double DegreesDelisleDelta => As(TemperatureDeltaUnit.DegreeDelisleDelta);

        /// <summary>
        ///     Get TemperatureDelta in DegreesFahrenheit.
        /// </summary>
        public double DegreesFahrenheit => As(TemperatureDeltaUnit.DegreeFahrenheit);

        /// <summary>
        ///     Get TemperatureDelta in DegreesFahrenheitDelta.
        /// </summary>
        [System.Obsolete("Deprecated due to github issue #180, please use DegreeFahrenheit instead")]
        public double DegreesFahrenheitDelta => As(TemperatureDeltaUnit.DegreeFahrenheitDelta);

        /// <summary>
        ///     Get TemperatureDelta in DegreesNewton.
        /// </summary>
        public double DegreesNewton => As(TemperatureDeltaUnit.DegreeNewton);

        /// <summary>
        ///     Get TemperatureDelta in DegreesNewtonDelta.
        /// </summary>
        [System.Obsolete("Deprecated due to github issue #180, please use DegreeNewton instead")]
        public double DegreesNewtonDelta => As(TemperatureDeltaUnit.DegreeNewtonDelta);

        /// <summary>
        ///     Get TemperatureDelta in DegreesRankine.
        /// </summary>
        public double DegreesRankine => As(TemperatureDeltaUnit.DegreeRankine);

        /// <summary>
        ///     Get TemperatureDelta in DegreesRankineDelta.
        /// </summary>
        [System.Obsolete("Deprecated due to github issue #180, please use DegreeRankine instead")]
        public double DegreesRankineDelta => As(TemperatureDeltaUnit.DegreeRankineDelta);

        /// <summary>
        ///     Get TemperatureDelta in DegreesReaumur.
        /// </summary>
        public double DegreesReaumur => As(TemperatureDeltaUnit.DegreeReaumur);

        /// <summary>
        ///     Get TemperatureDelta in DegreesReaumurDelta.
        /// </summary>
        [System.Obsolete("Deprecated due to github issue #180, please use DegreeReaumur instead")]
        public double DegreesReaumurDelta => As(TemperatureDeltaUnit.DegreeReaumurDelta);

        /// <summary>
        ///     Get TemperatureDelta in DegreesRoemer.
        /// </summary>
        public double DegreesRoemer => As(TemperatureDeltaUnit.DegreeRoemer);

        /// <summary>
        ///     Get TemperatureDelta in DegreesRoemerDelta.
        /// </summary>
        [System.Obsolete("Deprecated due to github issue #180, please use DegreeRoemer instead")]
        public double DegreesRoemerDelta => As(TemperatureDeltaUnit.DegreeRoemerDelta);

        /// <summary>
        ///     Get TemperatureDelta in Kelvins.
        /// </summary>
        public double Kelvins => As(TemperatureDeltaUnit.Kelvin);

        /// <summary>
        ///     Get TemperatureDelta in KelvinsDelta.
        /// </summary>
        [System.Obsolete("Deprecated due to github issue #180, please use Kelvin instead")]
        public double KelvinsDelta => As(TemperatureDeltaUnit.KelvinDelta);

        #endregion

        #region Static

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Kelvin.
        /// </summary>
        public static TemperatureDelta Zero => new TemperatureDelta(0, BaseUnit);

        /// <summary>
        ///     Get TemperatureDelta from DegreesCelsius.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesCelsius(double degreescelsius)
#else
        public static TemperatureDelta FromDegreesCelsius(QuantityValue degreescelsius)
#endif
        {
            double value = (double) degreescelsius;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeCelsius);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesCelsiusDelta.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesCelsiusDelta(double degreescelsiusdelta)
#else
        public static TemperatureDelta FromDegreesCelsiusDelta(QuantityValue degreescelsiusdelta)
#endif
        {
            double value = (double) degreescelsiusdelta;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeCelsiusDelta);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesDelisle.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesDelisle(double degreesdelisle)
#else
        public static TemperatureDelta FromDegreesDelisle(QuantityValue degreesdelisle)
#endif
        {
            double value = (double) degreesdelisle;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeDelisle);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesDelisleDelta.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesDelisleDelta(double degreesdelisledelta)
#else
        public static TemperatureDelta FromDegreesDelisleDelta(QuantityValue degreesdelisledelta)
#endif
        {
            double value = (double) degreesdelisledelta;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeDelisleDelta);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesFahrenheit.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesFahrenheit(double degreesfahrenheit)
#else
        public static TemperatureDelta FromDegreesFahrenheit(QuantityValue degreesfahrenheit)
#endif
        {
            double value = (double) degreesfahrenheit;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeFahrenheit);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesFahrenheitDelta.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesFahrenheitDelta(double degreesfahrenheitdelta)
#else
        public static TemperatureDelta FromDegreesFahrenheitDelta(QuantityValue degreesfahrenheitdelta)
#endif
        {
            double value = (double) degreesfahrenheitdelta;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeFahrenheitDelta);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesNewton.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesNewton(double degreesnewton)
#else
        public static TemperatureDelta FromDegreesNewton(QuantityValue degreesnewton)
#endif
        {
            double value = (double) degreesnewton;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeNewton);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesNewtonDelta.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesNewtonDelta(double degreesnewtondelta)
#else
        public static TemperatureDelta FromDegreesNewtonDelta(QuantityValue degreesnewtondelta)
#endif
        {
            double value = (double) degreesnewtondelta;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeNewtonDelta);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesRankine.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesRankine(double degreesrankine)
#else
        public static TemperatureDelta FromDegreesRankine(QuantityValue degreesrankine)
#endif
        {
            double value = (double) degreesrankine;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeRankine);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesRankineDelta.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesRankineDelta(double degreesrankinedelta)
#else
        public static TemperatureDelta FromDegreesRankineDelta(QuantityValue degreesrankinedelta)
#endif
        {
            double value = (double) degreesrankinedelta;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeRankineDelta);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesReaumur.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesReaumur(double degreesreaumur)
#else
        public static TemperatureDelta FromDegreesReaumur(QuantityValue degreesreaumur)
#endif
        {
            double value = (double) degreesreaumur;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeReaumur);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesReaumurDelta.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesReaumurDelta(double degreesreaumurdelta)
#else
        public static TemperatureDelta FromDegreesReaumurDelta(QuantityValue degreesreaumurdelta)
#endif
        {
            double value = (double) degreesreaumurdelta;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeReaumurDelta);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesRoemer.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesRoemer(double degreesroemer)
#else
        public static TemperatureDelta FromDegreesRoemer(QuantityValue degreesroemer)
#endif
        {
            double value = (double) degreesroemer;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeRoemer);
        }

        /// <summary>
        ///     Get TemperatureDelta from DegreesRoemerDelta.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromDegreesRoemerDelta(double degreesroemerdelta)
#else
        public static TemperatureDelta FromDegreesRoemerDelta(QuantityValue degreesroemerdelta)
#endif
        {
            double value = (double) degreesroemerdelta;
            return new TemperatureDelta(value, TemperatureDeltaUnit.DegreeRoemerDelta);
        }

        /// <summary>
        ///     Get TemperatureDelta from Kelvins.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromKelvins(double kelvins)
#else
        public static TemperatureDelta FromKelvins(QuantityValue kelvins)
#endif
        {
            double value = (double) kelvins;
            return new TemperatureDelta(value, TemperatureDeltaUnit.Kelvin);
        }

        /// <summary>
        ///     Get TemperatureDelta from KelvinsDelta.
        /// </summary>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
        public static TemperatureDelta FromKelvinsDelta(double kelvinsdelta)
#else
        public static TemperatureDelta FromKelvinsDelta(QuantityValue kelvinsdelta)
#endif
        {
            double value = (double) kelvinsdelta;
            return new TemperatureDelta(value, TemperatureDeltaUnit.KelvinDelta);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TemperatureDeltaUnit" /> to <see cref="TemperatureDelta" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>TemperatureDelta unit value.</returns>
#if WINDOWS_UWP
        // Fix name conflict with parameter "value"
        [return: System.Runtime.InteropServices.WindowsRuntime.ReturnValueName("returnValue")]
        public static TemperatureDelta From(double value, TemperatureDeltaUnit fromUnit)
#else
        public static TemperatureDelta From(QuantityValue value, TemperatureDeltaUnit fromUnit)
#endif
        {
            return new TemperatureDelta((double)value, fromUnit);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(TemperatureDeltaUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if(obj is null) throw new ArgumentNullException(nameof(obj));
            if(!(obj is TemperatureDelta)) throw new ArgumentException("Expected type TemperatureDelta.", nameof(obj));

            return CompareTo((TemperatureDelta)obj);
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(TemperatureDelta other)
        {
            return _value.CompareTo(other.AsBaseNumericType(this.Unit));
        }

        [Obsolete("It is not safe to compare equality due to using System.Double as the internal representation. It is very easy to get slightly different values due to floating point operations. Instead use Equals($quantityName, double, ComparisonType) to provide the max allowed absolute or relative error.")]
        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is TemperatureDelta))
                return false;

            var objQuantity = (TemperatureDelta)obj;
            return _value.Equals(objQuantity.AsBaseNumericType(this.Unit));
        }

        /// <summary>
        ///     <para>
        ///     Compare equality to another TemperatureDelta within the given absolute or relative tolerance.
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
        public bool Equals(TemperatureDelta other, double tolerance, ComparisonType comparisonType)
        {
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0.");

            double thisValue = (double)this.Value;
            double otherValueInThisUnits = other.As(this.Unit);

            return UnitsNet.Comparison.Equals(thisValue, otherValueInThisUnits, tolerance, comparisonType);
        }

        /// <summary>
        ///     Compare equality to another TemperatureDelta by specifying a max allowed difference.
        ///     Note that it is advised against specifying zero difference, due to the nature
        ///     of floating point operations and using System.Double internally.
        /// </summary>
        /// <param name="other">Other quantity to compare to.</param>
        /// <param name="maxError">Max error allowed.</param>
        /// <returns>True if the difference between the two values is not greater than the specified max.</returns>
        [Obsolete("Please use the Equals(TemperatureDelta, double, ComparisonType) overload. This method will be removed in a future version.")]
        public bool Equals(TemperatureDelta other, TemperatureDelta maxError)
        {
            return Math.Abs(_value - other.AsBaseNumericType(this.Unit)) <= maxError.AsBaseNumericType(this.Unit);
        }

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current TemperatureDelta.</returns>
        public override int GetHashCode()
        {
            return new { Value, Unit }.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(TemperatureDeltaUnit unit)
        {
            if(Unit == unit)
                return Convert.ToDouble(Value);

            var converted = AsBaseNumericType(unit);
            return Convert.ToDouble(converted);
        }

        /// <summary>
        ///     Converts this TemperatureDelta to another TemperatureDelta with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A TemperatureDelta with the specified unit.</returns>
        public TemperatureDelta ToUnit(TemperatureDeltaUnit unit)
        {
            var convertedValue = AsBaseNumericType(unit);
            return new TemperatureDelta(convertedValue, unit);
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
                case TemperatureDeltaUnit.DegreeCelsius: return _value;
                case TemperatureDeltaUnit.DegreeCelsiusDelta: return _value;
                case TemperatureDeltaUnit.DegreeDelisle: return _value*-2/3;
                case TemperatureDeltaUnit.DegreeDelisleDelta: return _value*-2/3;
                case TemperatureDeltaUnit.DegreeFahrenheit: return _value*5/9;
                case TemperatureDeltaUnit.DegreeFahrenheitDelta: return _value*5/9;
                case TemperatureDeltaUnit.DegreeNewton: return _value*100/33;
                case TemperatureDeltaUnit.DegreeNewtonDelta: return _value*100/33;
                case TemperatureDeltaUnit.DegreeRankine: return _value*5/9;
                case TemperatureDeltaUnit.DegreeRankineDelta: return _value*5/9;
                case TemperatureDeltaUnit.DegreeReaumur: return _value*5/4;
                case TemperatureDeltaUnit.DegreeReaumurDelta: return _value*5/4;
                case TemperatureDeltaUnit.DegreeRoemer: return _value*40/21;
                case TemperatureDeltaUnit.DegreeRoemerDelta: return _value*40/21;
                case TemperatureDeltaUnit.Kelvin: return _value;
                case TemperatureDeltaUnit.KelvinDelta: return _value;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double AsBaseNumericType(TemperatureDeltaUnit unit)
        {
            if(Unit == unit)
                return _value;

            var baseUnitValue = AsBaseUnit();

            switch(unit)
            {
                case TemperatureDeltaUnit.DegreeCelsius: return baseUnitValue;
                case TemperatureDeltaUnit.DegreeCelsiusDelta: return baseUnitValue;
                case TemperatureDeltaUnit.DegreeDelisle: return baseUnitValue*-3/2;
                case TemperatureDeltaUnit.DegreeDelisleDelta: return baseUnitValue*-3/2;
                case TemperatureDeltaUnit.DegreeFahrenheit: return baseUnitValue*9/5;
                case TemperatureDeltaUnit.DegreeFahrenheitDelta: return baseUnitValue*9/5;
                case TemperatureDeltaUnit.DegreeNewton: return baseUnitValue*33/100;
                case TemperatureDeltaUnit.DegreeNewtonDelta: return baseUnitValue*33/100;
                case TemperatureDeltaUnit.DegreeRankine: return baseUnitValue*9/5;
                case TemperatureDeltaUnit.DegreeRankineDelta: return baseUnitValue*9/5;
                case TemperatureDeltaUnit.DegreeReaumur: return baseUnitValue*4/5;
                case TemperatureDeltaUnit.DegreeReaumurDelta: return baseUnitValue*4/5;
                case TemperatureDeltaUnit.DegreeRoemer: return baseUnitValue*21/40;
                case TemperatureDeltaUnit.DegreeRoemerDelta: return baseUnitValue*21/40;
                case TemperatureDeltaUnit.Kelvin: return baseUnitValue;
                case TemperatureDeltaUnit.KelvinDelta: return baseUnitValue;
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
        public static TemperatureDelta Parse(string str)
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
        public static bool TryParse([CanBeNull] string str, out TemperatureDelta result)
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
        public static TemperatureDeltaUnit ParseUnit(string str)
        {
            return ParseUnit(str, (IFormatProvider)null);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="cultureName">Name of culture (ex: "en-US") to use when parsing number and unit. Defaults to <see cref="UnitSystem" />'s default culture.</param>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        [Obsolete("Use overload that takes IFormatProvider instead of culture name. This method was only added to support WindowsRuntimeComponent and will be removed from other .NET targets.")]
        public static TemperatureDeltaUnit ParseUnit(string str, [CanBeNull] string cultureName)
        {
            return ParseUnit(str, cultureName == null ? null : new CultureInfo(cultureName));
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Kelvin
        /// </summary>
        [Obsolete("This is no longer used since we will instead use the quantity's Unit value as default.")]
        public static TemperatureDeltaUnit ToStringDefaultUnit { get; set; } = TemperatureDeltaUnit.Kelvin;

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
        public string ToString(TemperatureDeltaUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        /// Represents the largest possible value of TemperatureDelta
        /// </summary>
        public static TemperatureDelta MaxValue => new TemperatureDelta(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of TemperatureDelta
        /// </summary>
        public static TemperatureDelta MinValue => new TemperatureDelta(double.MinValue, BaseUnit);

        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        public QuantityType Type => TemperatureDelta.QuantityType;

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        public BaseDimensions Dimensions => TemperatureDelta.BaseDimensions;
    }
}
