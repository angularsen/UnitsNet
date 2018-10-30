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
    ///     The magnitude of force per unit length.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart

    public partial struct ForcePerLength : IComparable, IComparable<ForcePerLength>
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        #region Nullable From Methods

        /// <summary>
        ///     Get nullable ForcePerLength from nullable CentinewtonsPerMeter.
        /// </summary>
        [Obsolete("Nullable type support is obsolete and will be removed in a future release.")]
        public static ForcePerLength? FromCentinewtonsPerMeter(QuantityValue? centinewtonspermeter)
        {
            return centinewtonspermeter.HasValue ? FromCentinewtonsPerMeter(centinewtonspermeter.Value) : default(ForcePerLength?);
        }

        /// <summary>
        ///     Get nullable ForcePerLength from nullable DecinewtonsPerMeter.
        /// </summary>
        [Obsolete("Nullable type support is obsolete and will be removed in a future release.")]
        public static ForcePerLength? FromDecinewtonsPerMeter(QuantityValue? decinewtonspermeter)
        {
            return decinewtonspermeter.HasValue ? FromDecinewtonsPerMeter(decinewtonspermeter.Value) : default(ForcePerLength?);
        }

        /// <summary>
        ///     Get nullable ForcePerLength from nullable KilogramsForcePerMeter.
        /// </summary>
        [Obsolete("Nullable type support is obsolete and will be removed in a future release.")]
        public static ForcePerLength? FromKilogramsForcePerMeter(QuantityValue? kilogramsforcepermeter)
        {
            return kilogramsforcepermeter.HasValue ? FromKilogramsForcePerMeter(kilogramsforcepermeter.Value) : default(ForcePerLength?);
        }

        /// <summary>
        ///     Get nullable ForcePerLength from nullable KilonewtonsPerMeter.
        /// </summary>
        [Obsolete("Nullable type support is obsolete and will be removed in a future release.")]
        public static ForcePerLength? FromKilonewtonsPerMeter(QuantityValue? kilonewtonspermeter)
        {
            return kilonewtonspermeter.HasValue ? FromKilonewtonsPerMeter(kilonewtonspermeter.Value) : default(ForcePerLength?);
        }

        /// <summary>
        ///     Get nullable ForcePerLength from nullable MeganewtonsPerMeter.
        /// </summary>
        [Obsolete("Nullable type support is obsolete and will be removed in a future release.")]
        public static ForcePerLength? FromMeganewtonsPerMeter(QuantityValue? meganewtonspermeter)
        {
            return meganewtonspermeter.HasValue ? FromMeganewtonsPerMeter(meganewtonspermeter.Value) : default(ForcePerLength?);
        }

        /// <summary>
        ///     Get nullable ForcePerLength from nullable MicronewtonsPerMeter.
        /// </summary>
        [Obsolete("Nullable type support is obsolete and will be removed in a future release.")]
        public static ForcePerLength? FromMicronewtonsPerMeter(QuantityValue? micronewtonspermeter)
        {
            return micronewtonspermeter.HasValue ? FromMicronewtonsPerMeter(micronewtonspermeter.Value) : default(ForcePerLength?);
        }

        /// <summary>
        ///     Get nullable ForcePerLength from nullable MillinewtonsPerMeter.
        /// </summary>
        [Obsolete("Nullable type support is obsolete and will be removed in a future release.")]
        public static ForcePerLength? FromMillinewtonsPerMeter(QuantityValue? millinewtonspermeter)
        {
            return millinewtonspermeter.HasValue ? FromMillinewtonsPerMeter(millinewtonspermeter.Value) : default(ForcePerLength?);
        }

        /// <summary>
        ///     Get nullable ForcePerLength from nullable NanonewtonsPerMeter.
        /// </summary>
        [Obsolete("Nullable type support is obsolete and will be removed in a future release.")]
        public static ForcePerLength? FromNanonewtonsPerMeter(QuantityValue? nanonewtonspermeter)
        {
            return nanonewtonspermeter.HasValue ? FromNanonewtonsPerMeter(nanonewtonspermeter.Value) : default(ForcePerLength?);
        }

        /// <summary>
        ///     Get nullable ForcePerLength from nullable NewtonsPerMeter.
        /// </summary>
        [Obsolete("Nullable type support is obsolete and will be removed in a future release.")]
        public static ForcePerLength? FromNewtonsPerMeter(QuantityValue? newtonspermeter)
        {
            return newtonspermeter.HasValue ? FromNewtonsPerMeter(newtonspermeter.Value) : default(ForcePerLength?);
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ForcePerLengthUnit" /> to <see cref="ForcePerLength" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ForcePerLength unit value.</returns>
        [Obsolete("Nullable type support has been deprecated and will be removed in a future release.")]
        public static ForcePerLength? From(QuantityValue? value, ForcePerLengthUnit fromUnit)
        {
            return value.HasValue ? new ForcePerLength((double)value.Value, fromUnit) : default(ForcePerLength?);
        }

        #endregion

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="provider">Format to use for localization. Defaults to <see cref="UnitSystem.DefaultCulture" />.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(ForcePerLengthUnit unit, [CanBeNull] IFormatProvider provider)
        {
            provider = provider ?? UnitSystem.DefaultCulture;

            return UnitSystem.GetCached(provider).GetDefaultAbbreviation(unit);
        }

        #region Arithmetic Operators

        public static ForcePerLength operator -(ForcePerLength right)
        {
            return new ForcePerLength(-right.Value, right.Unit);
        }

        public static ForcePerLength operator +(ForcePerLength left, ForcePerLength right)
        {
            return new ForcePerLength(left.Value + right.AsBaseNumericType(left.Unit), left.Unit);
        }

        public static ForcePerLength operator -(ForcePerLength left, ForcePerLength right)
        {
            return new ForcePerLength(left.Value - right.AsBaseNumericType(left.Unit), left.Unit);
        }

        public static ForcePerLength operator *(double left, ForcePerLength right)
        {
            return new ForcePerLength(left * right.Value, right.Unit);
        }

        public static ForcePerLength operator *(ForcePerLength left, double right)
        {
            return new ForcePerLength(left.Value * right, left.Unit);
        }

        public static ForcePerLength operator /(ForcePerLength left, double right)
        {
            return new ForcePerLength(left.Value / right, left.Unit);
        }

        public static double operator /(ForcePerLength left, ForcePerLength right)
        {
            return left.NewtonsPerMeter / right.NewtonsPerMeter;
        }

        #endregion

        public static bool operator <=(ForcePerLength left, ForcePerLength right)
        {
            return left.Value <= right.AsBaseNumericType(left.Unit);
        }

        public static bool operator >=(ForcePerLength left, ForcePerLength right)
        {
            return left.Value >= right.AsBaseNumericType(left.Unit);
        }

        public static bool operator <(ForcePerLength left, ForcePerLength right)
        {
            return left.Value < right.AsBaseNumericType(left.Unit);
        }

        public static bool operator >(ForcePerLength left, ForcePerLength right)
        {
            return left.Value > right.AsBaseNumericType(left.Unit);
        }

        [Obsolete("It is not safe to compare equality due to using System.Double as the internal representation. It is very easy to get slightly different values due to floating point operations. Instead use Equals(ForcePerLength, double, ComparisonType) to provide the max allowed absolute or relative error.")]
        public static bool operator ==(ForcePerLength left, ForcePerLength right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left.Value == right.AsBaseNumericType(left.Unit);
        }

        [Obsolete("It is not safe to compare equality due to using System.Double as the internal representation. It is very easy to get slightly different values due to floating point operations. Instead use Equals(ForcePerLength, double, ComparisonType) to provide the max allowed absolute or relative error.")]
        public static bool operator !=(ForcePerLength left, ForcePerLength right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left.Value != right.AsBaseNumericType(left.Unit);
        }

        #region Parsing

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="UnitSystem.DefaultCulture" />.</param>
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
        public static ForcePerLength Parse(string str, [CanBeNull] IFormatProvider provider)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));

            provider = provider ?? UnitSystem.DefaultCulture;

            return QuantityParser.Parse<ForcePerLength, ForcePerLengthUnit>(str, provider,
                delegate(string value, string unit, IFormatProvider formatProvider2)
                {
                    double parsedValue = double.Parse(value, formatProvider2);
                    ForcePerLengthUnit parsedUnit = ParseUnit(unit, formatProvider2);
                    return From(parsedValue, parsedUnit);
                }, (x, y) => FromNewtonsPerMeter(x.NewtonsPerMeter + y.NewtonsPerMeter));
        }

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="UnitSystem.DefaultCulture" />.</param>
        /// <param name="result">Resulting unit quantity if successful.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        public static bool TryParse([CanBeNull] string str, [CanBeNull] IFormatProvider provider, out ForcePerLength result)
        {
            provider = provider ?? UnitSystem.DefaultCulture;

            try
            {
                result = Parse(str, provider);
                return true;
            }
            catch
            {
                result = default(ForcePerLength);
                return false;
            }
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
        [Obsolete("Use overload that takes IFormatProvider instead of culture name. This method was only added to support WindowsRuntimeComponent and will be removed from .NET Framework targets.")]
        public static ForcePerLengthUnit ParseUnit(string str, [CanBeNull] string cultureName)
        {
            return ParseUnit(str, cultureName == null ? null : new CultureInfo(cultureName));
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="provider">Format to use when parsing number and unit. Defaults to <see cref="UnitSystem.DefaultCulture" />.</param>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static ForcePerLengthUnit ParseUnit(string str, IFormatProvider provider = null)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));

            var unitSystem = UnitSystem.GetCached(provider);
            var unit = unitSystem.Parse<ForcePerLengthUnit>(str.Trim());

            if (unit == ForcePerLengthUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized ForcePerLengthUnit.");
                newEx.Data["input"] = str;
                newEx.Data["provider"] = provider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        #region ToString Methods

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="UnitSystem.DefaultCulture" />.</param>
        /// <returns>String representation.</returns>
        public string ToString(ForcePerLengthUnit unit, [CanBeNull] IFormatProvider provider)
        {
            return ToString(unit, provider, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="UnitSystem.DefaultCulture" />.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(ForcePerLengthUnit unit, [CanBeNull] IFormatProvider provider, int significantDigitsAfterRadix)
        {
            double value = As(unit);
            string format = UnitFormatter.GetFormat(value, significantDigitsAfterRadix);
            return ToString(unit, provider, format);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="UnitSystem.DefaultCulture" />.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(ForcePerLengthUnit unit, [CanBeNull] IFormatProvider provider, [NotNull] string format, [NotNull] params object[] args)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

            provider = provider ?? UnitSystem.DefaultCulture;

            double value = As(unit);
            object[] formatArgs = UnitFormatter.GetFormatArgs(unit, value, provider, args);
            return string.Format(provider, format, formatArgs);
        }

        #endregion
    }
}
