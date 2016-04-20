// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/anjdreas/UnitsNet
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

#if WINDOWS_UWP
using Culture = System.String;
#else
using Culture = System.IFormatProvider;
#endif

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     In physics, mass (from Greek μᾶζα "barley cake, lump [of dough]") is a property of a physical system or body, giving rise to the phenomena of the body's resistance to being accelerated by a force and the strength of its mutual gravitational attraction with other bodies. Instruments such as mass balances or scales use those phenomena to measure mass. The SI unit of mass is the kilogram (kg).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Mass
#else
    public partial struct Mass : IComparable, IComparable<Mass>
#endif
    {
        /// <summary>
        ///     Base unit of Mass.
        /// </summary>
        private readonly double _kilograms;

#if WINDOWS_UWP
        public Mass() : this(0)
        {
        }
#endif

        public Mass(double kilograms)
        {
            _kilograms = Convert.ToDouble(kilograms);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Mass(long kilograms)
        {
            _kilograms = Convert.ToDouble(kilograms);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Mass(decimal kilograms)
        {
            _kilograms = Convert.ToDouble(kilograms);
        }

        #region Properties

        public static MassUnit BaseUnit
        {
            get { return MassUnit.Kilogram; }
        }

        /// <summary>
        ///     Get Mass in Centigrams.
        /// </summary>
        public double Centigrams
        {
            get { return (_kilograms*1e3) / 1e-2d; }
        }

        /// <summary>
        ///     Get Mass in Decagrams.
        /// </summary>
        public double Decagrams
        {
            get { return (_kilograms*1e3) / 1e1d; }
        }

        /// <summary>
        ///     Get Mass in Decigrams.
        /// </summary>
        public double Decigrams
        {
            get { return (_kilograms*1e3) / 1e-1d; }
        }

        /// <summary>
        ///     Get Mass in Grams.
        /// </summary>
        public double Grams
        {
            get { return _kilograms*1e3; }
        }

        /// <summary>
        ///     Get Mass in Hectograms.
        /// </summary>
        public double Hectograms
        {
            get { return (_kilograms*1e3) / 1e2d; }
        }

        /// <summary>
        ///     Get Mass in Kilograms.
        /// </summary>
        public double Kilograms
        {
            get { return (_kilograms*1e3) / 1e3d; }
        }

        /// <summary>
        ///     Get Mass in Kilotonnes.
        /// </summary>
        public double Kilotonnes
        {
            get { return (_kilograms/1e3) / 1e3d; }
        }

        /// <summary>
        ///     Get Mass in LongTons.
        /// </summary>
        public double LongTons
        {
            get { return _kilograms/1016.0469088; }
        }

        /// <summary>
        ///     Get Mass in Megatonnes.
        /// </summary>
        public double Megatonnes
        {
            get { return (_kilograms/1e3) / 1e6d; }
        }

        /// <summary>
        ///     Get Mass in Micrograms.
        /// </summary>
        public double Micrograms
        {
            get { return (_kilograms*1e3) / 1e-6d; }
        }

        /// <summary>
        ///     Get Mass in Milligrams.
        /// </summary>
        public double Milligrams
        {
            get { return (_kilograms*1e3) / 1e-3d; }
        }

        /// <summary>
        ///     Get Mass in Nanograms.
        /// </summary>
        public double Nanograms
        {
            get { return (_kilograms*1e3) / 1e-9d; }
        }

        /// <summary>
        ///     Get Mass in Ounces.
        /// </summary>
        public double Ounces
        {
            get { return _kilograms*35.2739619; }
        }

        /// <summary>
        ///     Get Mass in Pounds.
        /// </summary>
        public double Pounds
        {
            get { return _kilograms/0.45359237; }
        }

        /// <summary>
        ///     Get Mass in ShortTons.
        /// </summary>
        public double ShortTons
        {
            get { return _kilograms/907.18474; }
        }

        /// <summary>
        ///     Get Mass in Stone.
        /// </summary>
        public double Stone
        {
            get { return _kilograms*0.1574731728702698; }
        }

        /// <summary>
        ///     Get Mass in Tonnes.
        /// </summary>
        public double Tonnes
        {
            get { return _kilograms/1e3; }
        }

        #endregion

        #region Static

        public static Mass Zero
        {
            get { return new Mass(); }
        }

        /// <summary>
        ///     Get Mass from Centigrams.
        /// </summary>
        public static Mass FromCentigrams(double centigrams)
        {
            return new Mass((centigrams/1e3) * 1e-2d);
        }

        /// <summary>
        ///     Get Mass from Decagrams.
        /// </summary>
        public static Mass FromDecagrams(double decagrams)
        {
            return new Mass((decagrams/1e3) * 1e1d);
        }

        /// <summary>
        ///     Get Mass from Decigrams.
        /// </summary>
        public static Mass FromDecigrams(double decigrams)
        {
            return new Mass((decigrams/1e3) * 1e-1d);
        }

        /// <summary>
        ///     Get Mass from Grams.
        /// </summary>
        public static Mass FromGrams(double grams)
        {
            return new Mass(grams/1e3);
        }

        /// <summary>
        ///     Get Mass from Hectograms.
        /// </summary>
        public static Mass FromHectograms(double hectograms)
        {
            return new Mass((hectograms/1e3) * 1e2d);
        }

        /// <summary>
        ///     Get Mass from Kilograms.
        /// </summary>
        public static Mass FromKilograms(double kilograms)
        {
            return new Mass((kilograms/1e3) * 1e3d);
        }

        /// <summary>
        ///     Get Mass from Kilotonnes.
        /// </summary>
        public static Mass FromKilotonnes(double kilotonnes)
        {
            return new Mass((kilotonnes*1e3) * 1e3d);
        }

        /// <summary>
        ///     Get Mass from LongTons.
        /// </summary>
        public static Mass FromLongTons(double longtons)
        {
            return new Mass(longtons*1016.0469088);
        }

        /// <summary>
        ///     Get Mass from Megatonnes.
        /// </summary>
        public static Mass FromMegatonnes(double megatonnes)
        {
            return new Mass((megatonnes*1e3) * 1e6d);
        }

        /// <summary>
        ///     Get Mass from Micrograms.
        /// </summary>
        public static Mass FromMicrograms(double micrograms)
        {
            return new Mass((micrograms/1e3) * 1e-6d);
        }

        /// <summary>
        ///     Get Mass from Milligrams.
        /// </summary>
        public static Mass FromMilligrams(double milligrams)
        {
            return new Mass((milligrams/1e3) * 1e-3d);
        }

        /// <summary>
        ///     Get Mass from Nanograms.
        /// </summary>
        public static Mass FromNanograms(double nanograms)
        {
            return new Mass((nanograms/1e3) * 1e-9d);
        }

        /// <summary>
        ///     Get Mass from Ounces.
        /// </summary>
        public static Mass FromOunces(double ounces)
        {
            return new Mass(ounces/35.2739619);
        }

        /// <summary>
        ///     Get Mass from Pounds.
        /// </summary>
        public static Mass FromPounds(double pounds)
        {
            return new Mass(pounds*0.45359237);
        }

        /// <summary>
        ///     Get Mass from ShortTons.
        /// </summary>
        public static Mass FromShortTons(double shorttons)
        {
            return new Mass(shorttons*907.18474);
        }

        /// <summary>
        ///     Get Mass from Stone.
        /// </summary>
        public static Mass FromStone(double stone)
        {
            return new Mass(stone/0.1574731728702698);
        }

        /// <summary>
        ///     Get Mass from Tonnes.
        /// </summary>
        public static Mass FromTonnes(double tonnes)
        {
            return new Mass(tonnes*1e3);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Mass from nullable Centigrams.
        /// </summary>
        public static Mass? FromCentigrams(double? centigrams)
        {
            if (centigrams.HasValue)
            {
                return FromCentigrams(centigrams.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Decagrams.
        /// </summary>
        public static Mass? FromDecagrams(double? decagrams)
        {
            if (decagrams.HasValue)
            {
                return FromDecagrams(decagrams.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Decigrams.
        /// </summary>
        public static Mass? FromDecigrams(double? decigrams)
        {
            if (decigrams.HasValue)
            {
                return FromDecigrams(decigrams.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Grams.
        /// </summary>
        public static Mass? FromGrams(double? grams)
        {
            if (grams.HasValue)
            {
                return FromGrams(grams.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Hectograms.
        /// </summary>
        public static Mass? FromHectograms(double? hectograms)
        {
            if (hectograms.HasValue)
            {
                return FromHectograms(hectograms.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Kilograms.
        /// </summary>
        public static Mass? FromKilograms(double? kilograms)
        {
            if (kilograms.HasValue)
            {
                return FromKilograms(kilograms.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Kilotonnes.
        /// </summary>
        public static Mass? FromKilotonnes(double? kilotonnes)
        {
            if (kilotonnes.HasValue)
            {
                return FromKilotonnes(kilotonnes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable LongTons.
        /// </summary>
        public static Mass? FromLongTons(double? longtons)
        {
            if (longtons.HasValue)
            {
                return FromLongTons(longtons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Megatonnes.
        /// </summary>
        public static Mass? FromMegatonnes(double? megatonnes)
        {
            if (megatonnes.HasValue)
            {
                return FromMegatonnes(megatonnes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Micrograms.
        /// </summary>
        public static Mass? FromMicrograms(double? micrograms)
        {
            if (micrograms.HasValue)
            {
                return FromMicrograms(micrograms.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Milligrams.
        /// </summary>
        public static Mass? FromMilligrams(double? milligrams)
        {
            if (milligrams.HasValue)
            {
                return FromMilligrams(milligrams.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Nanograms.
        /// </summary>
        public static Mass? FromNanograms(double? nanograms)
        {
            if (nanograms.HasValue)
            {
                return FromNanograms(nanograms.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Ounces.
        /// </summary>
        public static Mass? FromOunces(double? ounces)
        {
            if (ounces.HasValue)
            {
                return FromOunces(ounces.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Pounds.
        /// </summary>
        public static Mass? FromPounds(double? pounds)
        {
            if (pounds.HasValue)
            {
                return FromPounds(pounds.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable ShortTons.
        /// </summary>
        public static Mass? FromShortTons(double? shorttons)
        {
            if (shorttons.HasValue)
            {
                return FromShortTons(shorttons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Stone.
        /// </summary>
        public static Mass? FromStone(double? stone)
        {
            if (stone.HasValue)
            {
                return FromStone(stone.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Mass from nullable Tonnes.
        /// </summary>
        public static Mass? FromTonnes(double? tonnes)
        {
            if (tonnes.HasValue)
            {
                return FromTonnes(tonnes.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="MassUnit" /> to <see cref="Mass" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Mass unit value.</returns>
        public static Mass From(double val, MassUnit fromUnit)
        {
            switch (fromUnit)
            {
                case MassUnit.Centigram:
                    return FromCentigrams(val);
                case MassUnit.Decagram:
                    return FromDecagrams(val);
                case MassUnit.Decigram:
                    return FromDecigrams(val);
                case MassUnit.Gram:
                    return FromGrams(val);
                case MassUnit.Hectogram:
                    return FromHectograms(val);
                case MassUnit.Kilogram:
                    return FromKilograms(val);
                case MassUnit.Kilotonne:
                    return FromKilotonnes(val);
                case MassUnit.LongTon:
                    return FromLongTons(val);
                case MassUnit.Megatonne:
                    return FromMegatonnes(val);
                case MassUnit.Microgram:
                    return FromMicrograms(val);
                case MassUnit.Milligram:
                    return FromMilligrams(val);
                case MassUnit.Nanogram:
                    return FromNanograms(val);
                case MassUnit.Ounce:
                    return FromOunces(val);
                case MassUnit.Pound:
                    return FromPounds(val);
                case MassUnit.ShortTon:
                    return FromShortTons(val);
                case MassUnit.Stone:
                    return FromStone(val);
                case MassUnit.Tonne:
                    return FromTonnes(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="MassUnit" /> to <see cref="Mass" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Mass unit value.</returns>
        public static Mass? From(double? value, MassUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case MassUnit.Centigram:
                    return FromCentigrams(value.Value);
                case MassUnit.Decagram:
                    return FromDecagrams(value.Value);
                case MassUnit.Decigram:
                    return FromDecigrams(value.Value);
                case MassUnit.Gram:
                    return FromGrams(value.Value);
                case MassUnit.Hectogram:
                    return FromHectograms(value.Value);
                case MassUnit.Kilogram:
                    return FromKilograms(value.Value);
                case MassUnit.Kilotonne:
                    return FromKilotonnes(value.Value);
                case MassUnit.LongTon:
                    return FromLongTons(value.Value);
                case MassUnit.Megatonne:
                    return FromMegatonnes(value.Value);
                case MassUnit.Microgram:
                    return FromMicrograms(value.Value);
                case MassUnit.Milligram:
                    return FromMilligrams(value.Value);
                case MassUnit.Nanogram:
                    return FromNanograms(value.Value);
                case MassUnit.Ounce:
                    return FromOunces(value.Value);
                case MassUnit.Pound:
                    return FromPounds(value.Value);
                case MassUnit.ShortTon:
                    return FromShortTons(value.Value);
                case MassUnit.Stone:
                    return FromStone(value.Value);
                case MassUnit.Tonne:
                    return FromTonnes(value.Value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }
#endif

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(MassUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(MassUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static Mass operator -(Mass right)
        {
            return new Mass(-right._kilograms);
        }

        public static Mass operator +(Mass left, Mass right)
        {
            return new Mass(left._kilograms + right._kilograms);
        }

        public static Mass operator -(Mass left, Mass right)
        {
            return new Mass(left._kilograms - right._kilograms);
        }

        public static Mass operator *(double left, Mass right)
        {
            return new Mass(left*right._kilograms);
        }

        public static Mass operator *(Mass left, double right)
        {
            return new Mass(left._kilograms*(double)right);
        }

        public static Mass operator /(Mass left, double right)
        {
            return new Mass(left._kilograms/(double)right);
        }

        public static double operator /(Mass left, Mass right)
        {
            return Convert.ToDouble(left._kilograms/right._kilograms);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Mass)) throw new ArgumentException("Expected type Mass.", "obj");
            return CompareTo((Mass) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Mass other)
        {
            return _kilograms.CompareTo(other._kilograms);
        }

#if !WINDOWS_UWP
        public static bool operator <=(Mass left, Mass right)
        {
            return left._kilograms <= right._kilograms;
        }

        public static bool operator >=(Mass left, Mass right)
        {
            return left._kilograms >= right._kilograms;
        }

        public static bool operator <(Mass left, Mass right)
        {
            return left._kilograms < right._kilograms;
        }

        public static bool operator >(Mass left, Mass right)
        {
            return left._kilograms > right._kilograms;
        }

        public static bool operator ==(Mass left, Mass right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kilograms == right._kilograms;
        }

        public static bool operator !=(Mass left, Mass right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kilograms != right._kilograms;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _kilograms.Equals(((Mass) obj)._kilograms);
        }

        public override int GetHashCode()
        {
            return _kilograms.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(MassUnit unit)
        {
            switch (unit)
            {
                case MassUnit.Centigram:
                    return Centigrams;
                case MassUnit.Decagram:
                    return Decagrams;
                case MassUnit.Decigram:
                    return Decigrams;
                case MassUnit.Gram:
                    return Grams;
                case MassUnit.Hectogram:
                    return Hectograms;
                case MassUnit.Kilogram:
                    return Kilograms;
                case MassUnit.Kilotonne:
                    return Kilotonnes;
                case MassUnit.LongTon:
                    return LongTons;
                case MassUnit.Megatonne:
                    return Megatonnes;
                case MassUnit.Microgram:
                    return Micrograms;
                case MassUnit.Milligram:
                    return Milligrams;
                case MassUnit.Nanogram:
                    return Nanograms;
                case MassUnit.Ounce:
                    return Ounces;
                case MassUnit.Pound:
                    return Pounds;
                case MassUnit.ShortTon:
                    return ShortTons;
                case MassUnit.Stone:
                    return Stone;
                case MassUnit.Tonne:
                    return Tonnes;

                default:
                    throw new NotImplementedException("unit: " + unit);
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
        public static Mass Parse(string str)
        {
            return Parse(str, null);
        }

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="culture">Format to use when parsing number and unit. If it is null, it defaults to <see cref="NumberFormatInfo.CurrentInfo"/> for parsing the number and <see cref="CultureInfo.CurrentUICulture"/> for parsing the unit abbreviation by culture/language.</param>
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
        public static Mass Parse(string str, [CanBeNull] Culture culture)
        {
            if (str == null) throw new ArgumentNullException("str");

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var exponentialRegex = @"(?:[eE][-+]?\d+)?)";
            var regexString = string.Format(@"(?:\s*(?<value>[-+]?{0}{1}{2}{3})?{4}{5}",
                            numRegex,                // capture base (integral) Quantity value
                            exponentialRegex,        // capture exponential (if any), end of Quantity capturing
                            @"\s?",                  // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>[^\s\d,]+)",   // capture Unit (non-whitespace) input
                            @"(and)?,?",             // allow "and" & "," separators between quantities
                            @"(?<invalid>[a-z]*)?"); // capture invalid input

            var quantities = ParseWithRegex(regexString, str, formatProvider);
            if (quantities.Count == 0)
            {
                throw new ArgumentException(
                    "Expected string to have at least one pair of quantity and unit in the format"
                    + " \"&lt;quantity&gt; &lt;unit&gt;\". Eg. \"5.5 m\" or \"1ft 2in\"");
            }
            return quantities.Aggregate((x, y) => Mass.FromKilograms(x.Kilograms + y.Kilograms));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Mass> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Mass>();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                var valueString = groups["value"].Value;
                var unitString = groups["unit"].Value;
                if (groups["invalid"].Value != "")
                {
                    var newEx = new UnitsNetException("Invalid string detected: " + groups["invalid"].Value);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
                if (valueString == "" && unitString == "") continue;

                try
                {
                    MassUnit unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch(AmbiguousUnitParseException)
                {
                    throw;
                }
                catch(Exception ex)
                {
                    var newEx = new UnitsNetException("Error parsing string.", ex);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
            }
            return converted;
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static MassUnit ParseUnit(string str)
        {
            return ParseUnit(str, (IFormatProvider)null);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static MassUnit ParseUnit(string str, [CanBeNull] string cultureName)
        {
            return ParseUnit(str, cultureName == null ? null : new CultureInfo(cultureName));
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
#if WINDOWS_UWP
        internal
#else
        public
#endif
        static MassUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<MassUnit>(str.Trim());

            if (unit == MassUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized MassUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Kilogram
        /// </summary>
        public static MassUnit ToStringDefaultUnit { get; set; } = MassUnit.Kilogram;

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(ToStringDefaultUnit);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using current UI culture and two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(MassUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(MassUnit unit, [CanBeNull] Culture culture)
        {
            return ToString(unit, culture, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(MassUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
        {
            double value = As(unit);
            string format = UnitFormatter.GetFormat(value, significantDigitsAfterRadix);
            return ToString(unit, culture, format);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(MassUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
            [NotNull] params object[] args)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
            double value = As(unit);
            object[] formatArgs = UnitFormatter.GetFormatArgs(unit, value, formatProvider, args);
            return string.Format(formatProvider, format, formatArgs);
        }
    }
}
