// Copyright Â© 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
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
    ///     Volume is the quantity of three-dimensional space enclosed by some closed boundary, for example, the space that a substance (solid, liquid, gas, or plasma) or shape occupies or contains.[1] Volume is often quantified numerically using the SI derived unit, the cubic metre. The volume of a container is generally understood to be the capacity of the container, i. e. the amount of fluid (gas or liquid) that the container could hold, rather than the amount of space the container itself displaces.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Volume
#else
    public partial struct Volume : IComparable, IComparable<Volume>
#endif
    {
        /// <summary>
        ///     Base unit of Volume.
        /// </summary>
        private readonly double _cubicMeters;

#if WINDOWS_UWP
        public Volume() : this(0)
        {
        }
#endif

        public Volume(double cubicmeters)
        {
            _cubicMeters = Convert.ToDouble(cubicmeters);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Volume(long cubicmeters)
        {
            _cubicMeters = Convert.ToDouble(cubicmeters);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Volume(decimal cubicmeters)
        {
            _cubicMeters = Convert.ToDouble(cubicmeters);
        }

        #region Properties

        public static VolumeUnit BaseUnit
        {
            get { return VolumeUnit.CubicMeter; }
        }

        /// <summary>
        ///     Get Volume in AuTablespoons.
        /// </summary>
        public double AuTablespoons
        {
            get { return _cubicMeters/2e-5; }
        }

        /// <summary>
        ///     Get Volume in Centiliters.
        /// </summary>
        public double Centiliters
        {
            get { return (_cubicMeters*1e3) / 1e-2d; }
        }

        /// <summary>
        ///     Get Volume in CubicCentimeters.
        /// </summary>
        public double CubicCentimeters
        {
            get { return _cubicMeters*1e6; }
        }

        /// <summary>
        ///     Get Volume in CubicDecimeters.
        /// </summary>
        public double CubicDecimeters
        {
            get { return _cubicMeters*1e3; }
        }

        /// <summary>
        ///     Get Volume in CubicFeet.
        /// </summary>
        public double CubicFeet
        {
            get { return _cubicMeters/0.0283168; }
        }

        /// <summary>
        ///     Get Volume in CubicInches.
        /// </summary>
        public double CubicInches
        {
            get { return _cubicMeters/(1.6387*1e-5); }
        }

        /// <summary>
        ///     Get Volume in CubicKilometers.
        /// </summary>
        public double CubicKilometers
        {
            get { return _cubicMeters/1e9; }
        }

        /// <summary>
        ///     Get Volume in CubicMeters.
        /// </summary>
        public double CubicMeters
        {
            get { return _cubicMeters; }
        }

        /// <summary>
        ///     Get Volume in CubicMicrometers.
        /// </summary>
        public double CubicMicrometers
        {
            get { return _cubicMeters*1e18; }
        }

        /// <summary>
        ///     Get Volume in CubicMiles.
        /// </summary>
        public double CubicMiles
        {
            get { return _cubicMeters/(4.16818183*1e9); }
        }

        /// <summary>
        ///     Get Volume in CubicMillimeters.
        /// </summary>
        public double CubicMillimeters
        {
            get { return _cubicMeters*1e9; }
        }

        /// <summary>
        ///     Get Volume in CubicYards.
        /// </summary>
        public double CubicYards
        {
            get { return _cubicMeters/0.764554858; }
        }

        /// <summary>
        ///     Get Volume in Deciliters.
        /// </summary>
        public double Deciliters
        {
            get { return (_cubicMeters*1e3) / 1e-1d; }
        }

        /// <summary>
        ///     Get Volume in Drums.
        /// </summary>
        public double Drums
        {
            get { return _cubicMeters/0.20819765; }
        }

        /// <summary>
        ///     Get Volume in Hectoliters.
        /// </summary>
        public double Hectoliters
        {
            get { return (_cubicMeters*1e3) / 1e2d; }
        }

        /// <summary>
        ///     Get Volume in ImperialGallons.
        /// </summary>
        public double ImperialGallons
        {
            get { return _cubicMeters/0.00454609000000181429905810072407; }
        }

        /// <summary>
        ///     Get Volume in ImperialOunces.
        /// </summary>
        public double ImperialOunces
        {
            get { return _cubicMeters/2.8413062499962901241875439064617e-5; }
        }

        /// <summary>
        ///     Get Volume in Liters.
        /// </summary>
        public double Liters
        {
            get { return _cubicMeters*1e3; }
        }

        /// <summary>
        ///     Get Volume in MetricCups.
        /// </summary>
        public double MetricCups
        {
            get { return _cubicMeters/0.00025; }
        }

        /// <summary>
        ///     Get Volume in MetricTeaspoons.
        /// </summary>
        public double MetricTeaspoons
        {
            get { return _cubicMeters/0.5e-5; }
        }

        /// <summary>
        ///     Get Volume in Microliters.
        /// </summary>
        public double Microliters
        {
            get { return (_cubicMeters*1e3) / 1e-6d; }
        }

        /// <summary>
        ///     Get Volume in Milliliters.
        /// </summary>
        public double Milliliters
        {
            get { return (_cubicMeters*1e3) / 1e-3d; }
        }

        /// <summary>
        ///     Get Volume in Tablespoons.
        /// </summary>
        [System.Obsolete("Deprecated due to github issue #134, please use UsTablespoon instead")]
        public double Tablespoons
        {
            get { return _cubicMeters/1.478676478125e-5; }
        }

        /// <summary>
        ///     Get Volume in Teaspoons.
        /// </summary>
        [System.Obsolete("Deprecated due to github issue #134, please use UsTeaspoon instead")]
        public double Teaspoons
        {
            get { return _cubicMeters/4.92892159375e-6; }
        }

        /// <summary>
        ///     Get Volume in Totes.
        /// </summary>
        public double Totes
        {
            get { return _cubicMeters/1.0409882; }
        }

        /// <summary>
        ///     Get Volume in UkTablespoons.
        /// </summary>
        public double UkTablespoons
        {
            get { return _cubicMeters/1.5e-5; }
        }

        /// <summary>
        ///     Get Volume in UsCustomaryCups.
        /// </summary>
        public double UsCustomaryCups
        {
            get { return _cubicMeters/0.0002365882365; }
        }

        /// <summary>
        ///     Get Volume in UsGallons.
        /// </summary>
        public double UsGallons
        {
            get { return _cubicMeters/0.00378541; }
        }

        /// <summary>
        ///     Get Volume in UsLegalCups.
        /// </summary>
        public double UsLegalCups
        {
            get { return _cubicMeters/0.00024; }
        }

        /// <summary>
        ///     Get Volume in UsOunces.
        /// </summary>
        public double UsOunces
        {
            get { return _cubicMeters/2.957352956253760505068307980135e-5; }
        }

        /// <summary>
        ///     Get Volume in UsTablespoons.
        /// </summary>
        public double UsTablespoons
        {
            get { return _cubicMeters/1.478676478125e-5; }
        }

        /// <summary>
        ///     Get Volume in UsTeaspoons.
        /// </summary>
        public double UsTeaspoons
        {
            get { return _cubicMeters/4.92892159375e-6; }
        }

        #endregion

        #region Static

        public static Volume Zero
        {
            get { return new Volume(); }
        }

        /// <summary>
        ///     Get Volume from AuTablespoons.
        /// </summary>
        public static Volume FromAuTablespoons(double autablespoons)
        {
            return new Volume(autablespoons*2e-5);
        }

        /// <summary>
        ///     Get Volume from Centiliters.
        /// </summary>
        public static Volume FromCentiliters(double centiliters)
        {
            return new Volume((centiliters/1e3) * 1e-2d);
        }

        /// <summary>
        ///     Get Volume from CubicCentimeters.
        /// </summary>
        public static Volume FromCubicCentimeters(double cubiccentimeters)
        {
            return new Volume(cubiccentimeters/1e6);
        }

        /// <summary>
        ///     Get Volume from CubicDecimeters.
        /// </summary>
        public static Volume FromCubicDecimeters(double cubicdecimeters)
        {
            return new Volume(cubicdecimeters/1e3);
        }

        /// <summary>
        ///     Get Volume from CubicFeet.
        /// </summary>
        public static Volume FromCubicFeet(double cubicfeet)
        {
            return new Volume(cubicfeet*0.0283168);
        }

        /// <summary>
        ///     Get Volume from CubicInches.
        /// </summary>
        public static Volume FromCubicInches(double cubicinches)
        {
            return new Volume(cubicinches*1.6387*1e-5);
        }

        /// <summary>
        ///     Get Volume from CubicKilometers.
        /// </summary>
        public static Volume FromCubicKilometers(double cubickilometers)
        {
            return new Volume(cubickilometers*1e9);
        }

        /// <summary>
        ///     Get Volume from CubicMeters.
        /// </summary>
        public static Volume FromCubicMeters(double cubicmeters)
        {
            return new Volume(cubicmeters);
        }

        /// <summary>
        ///     Get Volume from CubicMicrometers.
        /// </summary>
        public static Volume FromCubicMicrometers(double cubicmicrometers)
        {
            return new Volume(cubicmicrometers/1e18);
        }

        /// <summary>
        ///     Get Volume from CubicMiles.
        /// </summary>
        public static Volume FromCubicMiles(double cubicmiles)
        {
            return new Volume(cubicmiles*4.16818183*1e9);
        }

        /// <summary>
        ///     Get Volume from CubicMillimeters.
        /// </summary>
        public static Volume FromCubicMillimeters(double cubicmillimeters)
        {
            return new Volume(cubicmillimeters/1e9);
        }

        /// <summary>
        ///     Get Volume from CubicYards.
        /// </summary>
        public static Volume FromCubicYards(double cubicyards)
        {
            return new Volume(cubicyards*0.764554858);
        }

        /// <summary>
        ///     Get Volume from Deciliters.
        /// </summary>
        public static Volume FromDeciliters(double deciliters)
        {
            return new Volume((deciliters/1e3) * 1e-1d);
        }

        /// <summary>
        ///     Get Volume from Drums.
        /// </summary>
        public static Volume FromDrums(double drums)
        {
            return new Volume(drums*0.20819765);
        }

        /// <summary>
        ///     Get Volume from Hectoliters.
        /// </summary>
        public static Volume FromHectoliters(double hectoliters)
        {
            return new Volume((hectoliters/1e3) * 1e2d);
        }

        /// <summary>
        ///     Get Volume from ImperialGallons.
        /// </summary>
        public static Volume FromImperialGallons(double imperialgallons)
        {
            return new Volume(imperialgallons*0.00454609000000181429905810072407);
        }

        /// <summary>
        ///     Get Volume from ImperialOunces.
        /// </summary>
        public static Volume FromImperialOunces(double imperialounces)
        {
            return new Volume(imperialounces*2.8413062499962901241875439064617e-5);
        }

        /// <summary>
        ///     Get Volume from Liters.
        /// </summary>
        public static Volume FromLiters(double liters)
        {
            return new Volume(liters/1e3);
        }

        /// <summary>
        ///     Get Volume from MetricCups.
        /// </summary>
        public static Volume FromMetricCups(double metriccups)
        {
            return new Volume(metriccups*0.00025);
        }

        /// <summary>
        ///     Get Volume from MetricTeaspoons.
        /// </summary>
        public static Volume FromMetricTeaspoons(double metricteaspoons)
        {
            return new Volume(metricteaspoons*0.5e-5);
        }

        /// <summary>
        ///     Get Volume from Microliters.
        /// </summary>
        public static Volume FromMicroliters(double microliters)
        {
            return new Volume((microliters/1e3) * 1e-6d);
        }

        /// <summary>
        ///     Get Volume from Milliliters.
        /// </summary>
        public static Volume FromMilliliters(double milliliters)
        {
            return new Volume((milliliters/1e3) * 1e-3d);
        }

        /// <summary>
        ///     Get Volume from Tablespoons.
        /// </summary>
        public static Volume FromTablespoons(double tablespoons)
        {
            return new Volume(tablespoons*1.478676478125e-5);
        }

        /// <summary>
        ///     Get Volume from Teaspoons.
        /// </summary>
        public static Volume FromTeaspoons(double teaspoons)
        {
            return new Volume(teaspoons*4.92892159375e-6);
        }

        /// <summary>
        ///     Get Volume from Totes.
        /// </summary>
        public static Volume FromTotes(double totes)
        {
            return new Volume(totes*1.0409882);
        }

        /// <summary>
        ///     Get Volume from UkTablespoons.
        /// </summary>
        public static Volume FromUkTablespoons(double uktablespoons)
        {
            return new Volume(uktablespoons*1.5e-5);
        }

        /// <summary>
        ///     Get Volume from UsCustomaryCups.
        /// </summary>
        public static Volume FromUsCustomaryCups(double uscustomarycups)
        {
            return new Volume(uscustomarycups*0.0002365882365);
        }

        /// <summary>
        ///     Get Volume from UsGallons.
        /// </summary>
        public static Volume FromUsGallons(double usgallons)
        {
            return new Volume(usgallons*0.00378541);
        }

        /// <summary>
        ///     Get Volume from UsLegalCups.
        /// </summary>
        public static Volume FromUsLegalCups(double uslegalcups)
        {
            return new Volume(uslegalcups*0.00024);
        }

        /// <summary>
        ///     Get Volume from UsOunces.
        /// </summary>
        public static Volume FromUsOunces(double usounces)
        {
            return new Volume(usounces*2.957352956253760505068307980135e-5);
        }

        /// <summary>
        ///     Get Volume from UsTablespoons.
        /// </summary>
        public static Volume FromUsTablespoons(double ustablespoons)
        {
            return new Volume(ustablespoons*1.478676478125e-5);
        }

        /// <summary>
        ///     Get Volume from UsTeaspoons.
        /// </summary>
        public static Volume FromUsTeaspoons(double usteaspoons)
        {
            return new Volume(usteaspoons*4.92892159375e-6);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Volume from nullable AuTablespoons.
        /// </summary>
        public static Volume? FromAuTablespoons(double? autablespoons)
        {
            if (autablespoons.HasValue)
            {
                return FromAuTablespoons(autablespoons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable Centiliters.
        /// </summary>
        public static Volume? FromCentiliters(double? centiliters)
        {
            if (centiliters.HasValue)
            {
                return FromCentiliters(centiliters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable CubicCentimeters.
        /// </summary>
        public static Volume? FromCubicCentimeters(double? cubiccentimeters)
        {
            if (cubiccentimeters.HasValue)
            {
                return FromCubicCentimeters(cubiccentimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable CubicDecimeters.
        /// </summary>
        public static Volume? FromCubicDecimeters(double? cubicdecimeters)
        {
            if (cubicdecimeters.HasValue)
            {
                return FromCubicDecimeters(cubicdecimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable CubicFeet.
        /// </summary>
        public static Volume? FromCubicFeet(double? cubicfeet)
        {
            if (cubicfeet.HasValue)
            {
                return FromCubicFeet(cubicfeet.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable CubicInches.
        /// </summary>
        public static Volume? FromCubicInches(double? cubicinches)
        {
            if (cubicinches.HasValue)
            {
                return FromCubicInches(cubicinches.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable CubicKilometers.
        /// </summary>
        public static Volume? FromCubicKilometers(double? cubickilometers)
        {
            if (cubickilometers.HasValue)
            {
                return FromCubicKilometers(cubickilometers.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable CubicMeters.
        /// </summary>
        public static Volume? FromCubicMeters(double? cubicmeters)
        {
            if (cubicmeters.HasValue)
            {
                return FromCubicMeters(cubicmeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable CubicMicrometers.
        /// </summary>
        public static Volume? FromCubicMicrometers(double? cubicmicrometers)
        {
            if (cubicmicrometers.HasValue)
            {
                return FromCubicMicrometers(cubicmicrometers.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable CubicMiles.
        /// </summary>
        public static Volume? FromCubicMiles(double? cubicmiles)
        {
            if (cubicmiles.HasValue)
            {
                return FromCubicMiles(cubicmiles.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable CubicMillimeters.
        /// </summary>
        public static Volume? FromCubicMillimeters(double? cubicmillimeters)
        {
            if (cubicmillimeters.HasValue)
            {
                return FromCubicMillimeters(cubicmillimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable CubicYards.
        /// </summary>
        public static Volume? FromCubicYards(double? cubicyards)
        {
            if (cubicyards.HasValue)
            {
                return FromCubicYards(cubicyards.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable Deciliters.
        /// </summary>
        public static Volume? FromDeciliters(double? deciliters)
        {
            if (deciliters.HasValue)
            {
                return FromDeciliters(deciliters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable Drums.
        /// </summary>
        public static Volume? FromDrums(double? drums)
        {
            if (drums.HasValue)
            {
                return FromDrums(drums.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable Hectoliters.
        /// </summary>
        public static Volume? FromHectoliters(double? hectoliters)
        {
            if (hectoliters.HasValue)
            {
                return FromHectoliters(hectoliters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable ImperialGallons.
        /// </summary>
        public static Volume? FromImperialGallons(double? imperialgallons)
        {
            if (imperialgallons.HasValue)
            {
                return FromImperialGallons(imperialgallons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable ImperialOunces.
        /// </summary>
        public static Volume? FromImperialOunces(double? imperialounces)
        {
            if (imperialounces.HasValue)
            {
                return FromImperialOunces(imperialounces.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable Liters.
        /// </summary>
        public static Volume? FromLiters(double? liters)
        {
            if (liters.HasValue)
            {
                return FromLiters(liters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable MetricCups.
        /// </summary>
        public static Volume? FromMetricCups(double? metriccups)
        {
            if (metriccups.HasValue)
            {
                return FromMetricCups(metriccups.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable MetricTeaspoons.
        /// </summary>
        public static Volume? FromMetricTeaspoons(double? metricteaspoons)
        {
            if (metricteaspoons.HasValue)
            {
                return FromMetricTeaspoons(metricteaspoons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable Microliters.
        /// </summary>
        public static Volume? FromMicroliters(double? microliters)
        {
            if (microliters.HasValue)
            {
                return FromMicroliters(microliters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable Milliliters.
        /// </summary>
        public static Volume? FromMilliliters(double? milliliters)
        {
            if (milliliters.HasValue)
            {
                return FromMilliliters(milliliters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable Tablespoons.
        /// </summary>
        public static Volume? FromTablespoons(double? tablespoons)
        {
            if (tablespoons.HasValue)
            {
                return FromTablespoons(tablespoons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable Teaspoons.
        /// </summary>
        public static Volume? FromTeaspoons(double? teaspoons)
        {
            if (teaspoons.HasValue)
            {
                return FromTeaspoons(teaspoons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable Totes.
        /// </summary>
        public static Volume? FromTotes(double? totes)
        {
            if (totes.HasValue)
            {
                return FromTotes(totes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable UkTablespoons.
        /// </summary>
        public static Volume? FromUkTablespoons(double? uktablespoons)
        {
            if (uktablespoons.HasValue)
            {
                return FromUkTablespoons(uktablespoons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable UsCustomaryCups.
        /// </summary>
        public static Volume? FromUsCustomaryCups(double? uscustomarycups)
        {
            if (uscustomarycups.HasValue)
            {
                return FromUsCustomaryCups(uscustomarycups.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable UsGallons.
        /// </summary>
        public static Volume? FromUsGallons(double? usgallons)
        {
            if (usgallons.HasValue)
            {
                return FromUsGallons(usgallons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable UsLegalCups.
        /// </summary>
        public static Volume? FromUsLegalCups(double? uslegalcups)
        {
            if (uslegalcups.HasValue)
            {
                return FromUsLegalCups(uslegalcups.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable UsOunces.
        /// </summary>
        public static Volume? FromUsOunces(double? usounces)
        {
            if (usounces.HasValue)
            {
                return FromUsOunces(usounces.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable UsTablespoons.
        /// </summary>
        public static Volume? FromUsTablespoons(double? ustablespoons)
        {
            if (ustablespoons.HasValue)
            {
                return FromUsTablespoons(ustablespoons.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Volume from nullable UsTeaspoons.
        /// </summary>
        public static Volume? FromUsTeaspoons(double? usteaspoons)
        {
            if (usteaspoons.HasValue)
            {
                return FromUsTeaspoons(usteaspoons.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="VolumeUnit" /> to <see cref="Volume" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Volume unit value.</returns>
        public static Volume From(double val, VolumeUnit fromUnit)
        {
            switch (fromUnit)
            {
                case VolumeUnit.AuTablespoon:
                    return FromAuTablespoons(val);
                case VolumeUnit.Centiliter:
                    return FromCentiliters(val);
                case VolumeUnit.CubicCentimeter:
                    return FromCubicCentimeters(val);
                case VolumeUnit.CubicDecimeter:
                    return FromCubicDecimeters(val);
                case VolumeUnit.CubicFoot:
                    return FromCubicFeet(val);
                case VolumeUnit.CubicInch:
                    return FromCubicInches(val);
                case VolumeUnit.CubicKilometer:
                    return FromCubicKilometers(val);
                case VolumeUnit.CubicMeter:
                    return FromCubicMeters(val);
                case VolumeUnit.CubicMicrometer:
                    return FromCubicMicrometers(val);
                case VolumeUnit.CubicMile:
                    return FromCubicMiles(val);
                case VolumeUnit.CubicMillimeter:
                    return FromCubicMillimeters(val);
                case VolumeUnit.CubicYard:
                    return FromCubicYards(val);
                case VolumeUnit.Deciliter:
                    return FromDeciliters(val);
                case VolumeUnit.Drum:
                    return FromDrums(val);
                case VolumeUnit.Hectoliter:
                    return FromHectoliters(val);
                case VolumeUnit.ImperialGallon:
                    return FromImperialGallons(val);
                case VolumeUnit.ImperialOunce:
                    return FromImperialOunces(val);
                case VolumeUnit.Liter:
                    return FromLiters(val);
                case VolumeUnit.MetricCup:
                    return FromMetricCups(val);
                case VolumeUnit.MetricTeaspoon:
                    return FromMetricTeaspoons(val);
                case VolumeUnit.Microliter:
                    return FromMicroliters(val);
                case VolumeUnit.Milliliter:
                    return FromMilliliters(val);
                case VolumeUnit.Tablespoon:
                    return FromTablespoons(val);
                case VolumeUnit.Teaspoon:
                    return FromTeaspoons(val);
                case VolumeUnit.Tote:
                    return FromTotes(val);
                case VolumeUnit.UkTablespoon:
                    return FromUkTablespoons(val);
                case VolumeUnit.UsCustomaryCup:
                    return FromUsCustomaryCups(val);
                case VolumeUnit.UsGallon:
                    return FromUsGallons(val);
                case VolumeUnit.UsLegalCup:
                    return FromUsLegalCups(val);
                case VolumeUnit.UsOunce:
                    return FromUsOunces(val);
                case VolumeUnit.UsTablespoon:
                    return FromUsTablespoons(val);
                case VolumeUnit.UsTeaspoon:
                    return FromUsTeaspoons(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="VolumeUnit" /> to <see cref="Volume" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Volume unit value.</returns>
        public static Volume? From(double? value, VolumeUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case VolumeUnit.AuTablespoon:
                    return FromAuTablespoons(value.Value);
                case VolumeUnit.Centiliter:
                    return FromCentiliters(value.Value);
                case VolumeUnit.CubicCentimeter:
                    return FromCubicCentimeters(value.Value);
                case VolumeUnit.CubicDecimeter:
                    return FromCubicDecimeters(value.Value);
                case VolumeUnit.CubicFoot:
                    return FromCubicFeet(value.Value);
                case VolumeUnit.CubicInch:
                    return FromCubicInches(value.Value);
                case VolumeUnit.CubicKilometer:
                    return FromCubicKilometers(value.Value);
                case VolumeUnit.CubicMeter:
                    return FromCubicMeters(value.Value);
                case VolumeUnit.CubicMicrometer:
                    return FromCubicMicrometers(value.Value);
                case VolumeUnit.CubicMile:
                    return FromCubicMiles(value.Value);
                case VolumeUnit.CubicMillimeter:
                    return FromCubicMillimeters(value.Value);
                case VolumeUnit.CubicYard:
                    return FromCubicYards(value.Value);
                case VolumeUnit.Deciliter:
                    return FromDeciliters(value.Value);
                case VolumeUnit.Drum:
                    return FromDrums(value.Value);
                case VolumeUnit.Hectoliter:
                    return FromHectoliters(value.Value);
                case VolumeUnit.ImperialGallon:
                    return FromImperialGallons(value.Value);
                case VolumeUnit.ImperialOunce:
                    return FromImperialOunces(value.Value);
                case VolumeUnit.Liter:
                    return FromLiters(value.Value);
                case VolumeUnit.MetricCup:
                    return FromMetricCups(value.Value);
                case VolumeUnit.MetricTeaspoon:
                    return FromMetricTeaspoons(value.Value);
                case VolumeUnit.Microliter:
                    return FromMicroliters(value.Value);
                case VolumeUnit.Milliliter:
                    return FromMilliliters(value.Value);
                case VolumeUnit.Tablespoon:
                    return FromTablespoons(value.Value);
                case VolumeUnit.Teaspoon:
                    return FromTeaspoons(value.Value);
                case VolumeUnit.Tote:
                    return FromTotes(value.Value);
                case VolumeUnit.UkTablespoon:
                    return FromUkTablespoons(value.Value);
                case VolumeUnit.UsCustomaryCup:
                    return FromUsCustomaryCups(value.Value);
                case VolumeUnit.UsGallon:
                    return FromUsGallons(value.Value);
                case VolumeUnit.UsLegalCup:
                    return FromUsLegalCups(value.Value);
                case VolumeUnit.UsOunce:
                    return FromUsOunces(value.Value);
                case VolumeUnit.UsTablespoon:
                    return FromUsTablespoons(value.Value);
                case VolumeUnit.UsTeaspoon:
                    return FromUsTeaspoons(value.Value);

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
        public static string GetAbbreviation(VolumeUnit unit)
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
        public static string GetAbbreviation(VolumeUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static Volume operator -(Volume right)
        {
            return new Volume(-right._cubicMeters);
        }

        public static Volume operator +(Volume left, Volume right)
        {
            return new Volume(left._cubicMeters + right._cubicMeters);
        }

        public static Volume operator -(Volume left, Volume right)
        {
            return new Volume(left._cubicMeters - right._cubicMeters);
        }

        public static Volume operator *(double left, Volume right)
        {
            return new Volume(left*right._cubicMeters);
        }

        public static Volume operator *(Volume left, double right)
        {
            return new Volume(left._cubicMeters*(double)right);
        }

        public static Volume operator /(Volume left, double right)
        {
            return new Volume(left._cubicMeters/(double)right);
        }

        public static double operator /(Volume left, Volume right)
        {
            return Convert.ToDouble(left._cubicMeters/right._cubicMeters);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Volume)) throw new ArgumentException("Expected type Volume.", "obj");
            return CompareTo((Volume) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Volume other)
        {
            return _cubicMeters.CompareTo(other._cubicMeters);
        }

#if !WINDOWS_UWP
        public static bool operator <=(Volume left, Volume right)
        {
            return left._cubicMeters <= right._cubicMeters;
        }

        public static bool operator >=(Volume left, Volume right)
        {
            return left._cubicMeters >= right._cubicMeters;
        }

        public static bool operator <(Volume left, Volume right)
        {
            return left._cubicMeters < right._cubicMeters;
        }

        public static bool operator >(Volume left, Volume right)
        {
            return left._cubicMeters > right._cubicMeters;
        }

        public static bool operator ==(Volume left, Volume right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._cubicMeters == right._cubicMeters;
        }

        public static bool operator !=(Volume left, Volume right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._cubicMeters != right._cubicMeters;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _cubicMeters.Equals(((Volume) obj)._cubicMeters);
        }

        public override int GetHashCode()
        {
            return _cubicMeters.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(VolumeUnit unit)
        {
            switch (unit)
            {
                case VolumeUnit.AuTablespoon:
                    return AuTablespoons;
                case VolumeUnit.Centiliter:
                    return Centiliters;
                case VolumeUnit.CubicCentimeter:
                    return CubicCentimeters;
                case VolumeUnit.CubicDecimeter:
                    return CubicDecimeters;
                case VolumeUnit.CubicFoot:
                    return CubicFeet;
                case VolumeUnit.CubicInch:
                    return CubicInches;
                case VolumeUnit.CubicKilometer:
                    return CubicKilometers;
                case VolumeUnit.CubicMeter:
                    return CubicMeters;
                case VolumeUnit.CubicMicrometer:
                    return CubicMicrometers;
                case VolumeUnit.CubicMile:
                    return CubicMiles;
                case VolumeUnit.CubicMillimeter:
                    return CubicMillimeters;
                case VolumeUnit.CubicYard:
                    return CubicYards;
                case VolumeUnit.Deciliter:
                    return Deciliters;
                case VolumeUnit.Drum:
                    return Drums;
                case VolumeUnit.Hectoliter:
                    return Hectoliters;
                case VolumeUnit.ImperialGallon:
                    return ImperialGallons;
                case VolumeUnit.ImperialOunce:
                    return ImperialOunces;
                case VolumeUnit.Liter:
                    return Liters;
                case VolumeUnit.MetricCup:
                    return MetricCups;
                case VolumeUnit.MetricTeaspoon:
                    return MetricTeaspoons;
                case VolumeUnit.Microliter:
                    return Microliters;
                case VolumeUnit.Milliliter:
                    return Milliliters;
                case VolumeUnit.Tablespoon:
                    return Tablespoons;
                case VolumeUnit.Teaspoon:
                    return Teaspoons;
                case VolumeUnit.Tote:
                    return Totes;
                case VolumeUnit.UkTablespoon:
                    return UkTablespoons;
                case VolumeUnit.UsCustomaryCup:
                    return UsCustomaryCups;
                case VolumeUnit.UsGallon:
                    return UsGallons;
                case VolumeUnit.UsLegalCup:
                    return UsLegalCups;
                case VolumeUnit.UsOunce:
                    return UsOunces;
                case VolumeUnit.UsTablespoon:
                    return UsTablespoons;
                case VolumeUnit.UsTeaspoon:
                    return UsTeaspoons;

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
        public static Volume Parse(string str)
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
        public static Volume Parse(string str, [CanBeNull] Culture culture)
        {
            if (str == null) throw new ArgumentNullException("str");

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
            return UnitParser.ParseUnit<Volume>(str, formatProvider,
                delegate(string value, string unit, IFormatProvider formatProvider2)
                {
                    double parsedValue = double.Parse(value, formatProvider2);
                    VolumeUnit parsedUnit = ParseUnit(unit, formatProvider2);
                    return From(parsedValue, parsedUnit);
                }, (x, y) => FromCubicMeters(x.CubicMeters + y.CubicMeters));
        }

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="result">Resulting unit quantity if successful.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        public static bool TryParse([CanBeNull] string str, out Volume result)
        {
            return TryParse(str, null, out result);
        }

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="culture">Format to use when parsing number and unit. If it is null, it defaults to <see cref="NumberFormatInfo.CurrentInfo"/> for parsing the number and <see cref="CultureInfo.CurrentUICulture"/> for parsing the unit abbreviation by culture/language.</param>
        /// <param name="result">Resulting unit quantity if successful.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        public static bool TryParse([CanBeNull] string str, [CanBeNull] Culture culture, out Volume result)
        {
            try
            {
                result = Parse(str, culture);
                return true;
            }
            catch
            {
                result = default(Volume);
                return false;
            }
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static VolumeUnit ParseUnit(string str)
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
        public static VolumeUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static VolumeUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<VolumeUnit>(str.Trim());

            if (unit == VolumeUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized VolumeUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is CubicMeter
        /// </summary>
        public static VolumeUnit ToStringDefaultUnit { get; set; } = VolumeUnit.CubicMeter;

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
        public string ToString(VolumeUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(VolumeUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(VolumeUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(VolumeUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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

        /// <summary>
        /// Represents the largest possible value of Volume
        /// </summary>
        public static Volume MaxValue
        {
            get
            {
                return new Volume(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of Volume
        /// </summary>
        public static Volume MinValue
        {
            get
            {
                return new Volume(double.MinValue);
            }
        }
    }
}
