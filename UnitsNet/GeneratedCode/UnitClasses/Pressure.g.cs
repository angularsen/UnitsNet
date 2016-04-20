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
    ///     Pressure (symbol: P or p) is the ratio of force to the area over which that force is distributed. Pressure is force per unit area applied in a direction perpendicular to the surface of an object. Gauge pressure (also spelled gage pressure)[a] is the pressure relative to the local atmospheric or ambient pressure. Pressure is measured in any unit of force divided by any unit of area. The SI unit of pressure is the newton per square metre, which is called the pascal (Pa) after the seventeenth-century philosopher and scientist Blaise Pascal. A pressure of 1 Pa is small; it approximately equals the pressure exerted by a dollar bill resting flat on a table. Everyday pressures are often stated in kilopascals (1 kPa = 1000 Pa).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Pressure
#else
    public partial struct Pressure : IComparable, IComparable<Pressure>
#endif
    {
        /// <summary>
        ///     Base unit of Pressure.
        /// </summary>
        private readonly double _pascals;

#if WINDOWS_UWP
        public Pressure() : this(0)
        {
        }
#endif

        public Pressure(double pascals)
        {
            _pascals = Convert.ToDouble(pascals);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Pressure(long pascals)
        {
            _pascals = Convert.ToDouble(pascals);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Pressure(decimal pascals)
        {
            _pascals = Convert.ToDouble(pascals);
        }

        #region Properties

        public static PressureUnit BaseUnit
        {
            get { return PressureUnit.Pascal; }
        }

        /// <summary>
        ///     Get Pressure in Atmospheres.
        /// </summary>
        public double Atmospheres
        {
            get { return _pascals/(1.01325*1e5); }
        }

        /// <summary>
        ///     Get Pressure in Bars.
        /// </summary>
        public double Bars
        {
            get { return _pascals/1e5; }
        }

        /// <summary>
        ///     Get Pressure in Centibars.
        /// </summary>
        public double Centibars
        {
            get { return (_pascals/1e5) / 1e-2d; }
        }

        /// <summary>
        ///     Get Pressure in Decapascals.
        /// </summary>
        public double Decapascals
        {
            get { return (_pascals) / 1e1d; }
        }

        /// <summary>
        ///     Get Pressure in Decibars.
        /// </summary>
        public double Decibars
        {
            get { return (_pascals/1e5) / 1e-1d; }
        }

        /// <summary>
        ///     Get Pressure in Gigapascals.
        /// </summary>
        public double Gigapascals
        {
            get { return (_pascals) / 1e9d; }
        }

        /// <summary>
        ///     Get Pressure in Hectopascals.
        /// </summary>
        public double Hectopascals
        {
            get { return (_pascals) / 1e2d; }
        }

        /// <summary>
        ///     Get Pressure in Kilobars.
        /// </summary>
        public double Kilobars
        {
            get { return (_pascals/1e5) / 1e3d; }
        }

        /// <summary>
        ///     Get Pressure in KilogramsForcePerSquareCentimeter.
        /// </summary>
        public double KilogramsForcePerSquareCentimeter
        {
            get { return _pascals/(9.80665*1e4); }
        }

        /// <summary>
        ///     Get Pressure in KilogramsForcePerSquareMeter.
        /// </summary>
        public double KilogramsForcePerSquareMeter
        {
            get { return _pascals*0.101971619222242; }
        }

        /// <summary>
        ///     Get Pressure in KilogramsForcePerSquareMillimeter.
        /// </summary>
        public double KilogramsForcePerSquareMillimeter
        {
            get { return _pascals*1.01971619222242E-07; }
        }

        /// <summary>
        ///     Get Pressure in KilonewtonsPerSquareCentimeter.
        /// </summary>
        public double KilonewtonsPerSquareCentimeter
        {
            get { return (_pascals/1e4) / 1e3d; }
        }

        /// <summary>
        ///     Get Pressure in KilonewtonsPerSquareMeter.
        /// </summary>
        public double KilonewtonsPerSquareMeter
        {
            get { return (_pascals) / 1e3d; }
        }

        /// <summary>
        ///     Get Pressure in KilonewtonsPerSquareMillimeter.
        /// </summary>
        public double KilonewtonsPerSquareMillimeter
        {
            get { return (_pascals/1e6) / 1e3d; }
        }

        /// <summary>
        ///     Get Pressure in Kilopascals.
        /// </summary>
        public double Kilopascals
        {
            get { return (_pascals) / 1e3d; }
        }

        /// <summary>
        ///     Get Pressure in KilopoundsForcePerSquareFoot.
        /// </summary>
        public double KilopoundsForcePerSquareFoot
        {
            get { return (_pascals*0.020885432426709) / 1e3d; }
        }

        /// <summary>
        ///     Get Pressure in KilopoundsForcePerSquareInch.
        /// </summary>
        public double KilopoundsForcePerSquareInch
        {
            get { return (_pascals*0.000145037725185479) / 1e3d; }
        }

        /// <summary>
        ///     Get Pressure in Megabars.
        /// </summary>
        public double Megabars
        {
            get { return (_pascals/1e5) / 1e6d; }
        }

        /// <summary>
        ///     Get Pressure in Megapascals.
        /// </summary>
        public double Megapascals
        {
            get { return (_pascals) / 1e6d; }
        }

        /// <summary>
        ///     Get Pressure in Micropascals.
        /// </summary>
        public double Micropascals
        {
            get { return (_pascals) / 1e-6d; }
        }

        /// <summary>
        ///     Get Pressure in Millibars.
        /// </summary>
        public double Millibars
        {
            get { return (_pascals/1e5) / 1e-3d; }
        }

        /// <summary>
        ///     Get Pressure in NewtonsPerSquareCentimeter.
        /// </summary>
        public double NewtonsPerSquareCentimeter
        {
            get { return _pascals/1e4; }
        }

        /// <summary>
        ///     Get Pressure in NewtonsPerSquareMeter.
        /// </summary>
        public double NewtonsPerSquareMeter
        {
            get { return _pascals; }
        }

        /// <summary>
        ///     Get Pressure in NewtonsPerSquareMillimeter.
        /// </summary>
        public double NewtonsPerSquareMillimeter
        {
            get { return _pascals/1e6; }
        }

        /// <summary>
        ///     Get Pressure in Pascals.
        /// </summary>
        public double Pascals
        {
            get { return _pascals; }
        }

        /// <summary>
        ///     Get Pressure in PoundsForcePerSquareFoot.
        /// </summary>
        public double PoundsForcePerSquareFoot
        {
            get { return _pascals*0.020885432426709; }
        }

        /// <summary>
        ///     Get Pressure in PoundsForcePerSquareInch.
        /// </summary>
        public double PoundsForcePerSquareInch
        {
            get { return _pascals*0.000145037725185479; }
        }

        /// <summary>
        ///     Get Pressure in Psi.
        /// </summary>
        public double Psi
        {
            get { return _pascals/(6.89464975179*1e3); }
        }

        /// <summary>
        ///     Get Pressure in TechnicalAtmospheres.
        /// </summary>
        public double TechnicalAtmospheres
        {
            get { return _pascals/(9.80680592331*1e4); }
        }

        /// <summary>
        ///     Get Pressure in TonnesForcePerSquareCentimeter.
        /// </summary>
        public double TonnesForcePerSquareCentimeter
        {
            get { return _pascals*1.01971619222242E-08; }
        }

        /// <summary>
        ///     Get Pressure in TonnesForcePerSquareMeter.
        /// </summary>
        public double TonnesForcePerSquareMeter
        {
            get { return _pascals*0.000101971619222242; }
        }

        /// <summary>
        ///     Get Pressure in TonnesForcePerSquareMillimeter.
        /// </summary>
        public double TonnesForcePerSquareMillimeter
        {
            get { return _pascals*1.01971619222242E-10; }
        }

        /// <summary>
        ///     Get Pressure in Torrs.
        /// </summary>
        public double Torrs
        {
            get { return _pascals/(1.3332266752*1e2); }
        }

        #endregion

        #region Static

        public static Pressure Zero
        {
            get { return new Pressure(); }
        }

        /// <summary>
        ///     Get Pressure from Atmospheres.
        /// </summary>
        public static Pressure FromAtmospheres(double atmospheres)
        {
            return new Pressure(atmospheres*1.01325*1e5);
        }

        /// <summary>
        ///     Get Pressure from Bars.
        /// </summary>
        public static Pressure FromBars(double bars)
        {
            return new Pressure(bars*1e5);
        }

        /// <summary>
        ///     Get Pressure from Centibars.
        /// </summary>
        public static Pressure FromCentibars(double centibars)
        {
            return new Pressure((centibars*1e5) * 1e-2d);
        }

        /// <summary>
        ///     Get Pressure from Decapascals.
        /// </summary>
        public static Pressure FromDecapascals(double decapascals)
        {
            return new Pressure((decapascals) * 1e1d);
        }

        /// <summary>
        ///     Get Pressure from Decibars.
        /// </summary>
        public static Pressure FromDecibars(double decibars)
        {
            return new Pressure((decibars*1e5) * 1e-1d);
        }

        /// <summary>
        ///     Get Pressure from Gigapascals.
        /// </summary>
        public static Pressure FromGigapascals(double gigapascals)
        {
            return new Pressure((gigapascals) * 1e9d);
        }

        /// <summary>
        ///     Get Pressure from Hectopascals.
        /// </summary>
        public static Pressure FromHectopascals(double hectopascals)
        {
            return new Pressure((hectopascals) * 1e2d);
        }

        /// <summary>
        ///     Get Pressure from Kilobars.
        /// </summary>
        public static Pressure FromKilobars(double kilobars)
        {
            return new Pressure((kilobars*1e5) * 1e3d);
        }

        /// <summary>
        ///     Get Pressure from KilogramsForcePerSquareCentimeter.
        /// </summary>
        public static Pressure FromKilogramsForcePerSquareCentimeter(double kilogramsforcepersquarecentimeter)
        {
            return new Pressure(kilogramsforcepersquarecentimeter*9.80665*1e4);
        }

        /// <summary>
        ///     Get Pressure from KilogramsForcePerSquareMeter.
        /// </summary>
        public static Pressure FromKilogramsForcePerSquareMeter(double kilogramsforcepersquaremeter)
        {
            return new Pressure(kilogramsforcepersquaremeter*9.80665019960652);
        }

        /// <summary>
        ///     Get Pressure from KilogramsForcePerSquareMillimeter.
        /// </summary>
        public static Pressure FromKilogramsForcePerSquareMillimeter(double kilogramsforcepersquaremillimeter)
        {
            return new Pressure(kilogramsforcepersquaremillimeter*9806650.19960652);
        }

        /// <summary>
        ///     Get Pressure from KilonewtonsPerSquareCentimeter.
        /// </summary>
        public static Pressure FromKilonewtonsPerSquareCentimeter(double kilonewtonspersquarecentimeter)
        {
            return new Pressure((kilonewtonspersquarecentimeter*1e4) * 1e3d);
        }

        /// <summary>
        ///     Get Pressure from KilonewtonsPerSquareMeter.
        /// </summary>
        public static Pressure FromKilonewtonsPerSquareMeter(double kilonewtonspersquaremeter)
        {
            return new Pressure((kilonewtonspersquaremeter) * 1e3d);
        }

        /// <summary>
        ///     Get Pressure from KilonewtonsPerSquareMillimeter.
        /// </summary>
        public static Pressure FromKilonewtonsPerSquareMillimeter(double kilonewtonspersquaremillimeter)
        {
            return new Pressure((kilonewtonspersquaremillimeter*1e6) * 1e3d);
        }

        /// <summary>
        ///     Get Pressure from Kilopascals.
        /// </summary>
        public static Pressure FromKilopascals(double kilopascals)
        {
            return new Pressure((kilopascals) * 1e3d);
        }

        /// <summary>
        ///     Get Pressure from KilopoundsForcePerSquareFoot.
        /// </summary>
        public static Pressure FromKilopoundsForcePerSquareFoot(double kilopoundsforcepersquarefoot)
        {
            return new Pressure((kilopoundsforcepersquarefoot*47.8802631216372) * 1e3d);
        }

        /// <summary>
        ///     Get Pressure from KilopoundsForcePerSquareInch.
        /// </summary>
        public static Pressure FromKilopoundsForcePerSquareInch(double kilopoundsforcepersquareinch)
        {
            return new Pressure((kilopoundsforcepersquareinch*6894.75788951576) * 1e3d);
        }

        /// <summary>
        ///     Get Pressure from Megabars.
        /// </summary>
        public static Pressure FromMegabars(double megabars)
        {
            return new Pressure((megabars*1e5) * 1e6d);
        }

        /// <summary>
        ///     Get Pressure from Megapascals.
        /// </summary>
        public static Pressure FromMegapascals(double megapascals)
        {
            return new Pressure((megapascals) * 1e6d);
        }

        /// <summary>
        ///     Get Pressure from Micropascals.
        /// </summary>
        public static Pressure FromMicropascals(double micropascals)
        {
            return new Pressure((micropascals) * 1e-6d);
        }

        /// <summary>
        ///     Get Pressure from Millibars.
        /// </summary>
        public static Pressure FromMillibars(double millibars)
        {
            return new Pressure((millibars*1e5) * 1e-3d);
        }

        /// <summary>
        ///     Get Pressure from NewtonsPerSquareCentimeter.
        /// </summary>
        public static Pressure FromNewtonsPerSquareCentimeter(double newtonspersquarecentimeter)
        {
            return new Pressure(newtonspersquarecentimeter*1e4);
        }

        /// <summary>
        ///     Get Pressure from NewtonsPerSquareMeter.
        /// </summary>
        public static Pressure FromNewtonsPerSquareMeter(double newtonspersquaremeter)
        {
            return new Pressure(newtonspersquaremeter);
        }

        /// <summary>
        ///     Get Pressure from NewtonsPerSquareMillimeter.
        /// </summary>
        public static Pressure FromNewtonsPerSquareMillimeter(double newtonspersquaremillimeter)
        {
            return new Pressure(newtonspersquaremillimeter*1e6);
        }

        /// <summary>
        ///     Get Pressure from Pascals.
        /// </summary>
        public static Pressure FromPascals(double pascals)
        {
            return new Pressure(pascals);
        }

        /// <summary>
        ///     Get Pressure from PoundsForcePerSquareFoot.
        /// </summary>
        public static Pressure FromPoundsForcePerSquareFoot(double poundsforcepersquarefoot)
        {
            return new Pressure(poundsforcepersquarefoot*47.8802631216372);
        }

        /// <summary>
        ///     Get Pressure from PoundsForcePerSquareInch.
        /// </summary>
        public static Pressure FromPoundsForcePerSquareInch(double poundsforcepersquareinch)
        {
            return new Pressure(poundsforcepersquareinch*6894.75788951576);
        }

        /// <summary>
        ///     Get Pressure from Psi.
        /// </summary>
        public static Pressure FromPsi(double psi)
        {
            return new Pressure(psi*6.89464975179*1e3);
        }

        /// <summary>
        ///     Get Pressure from TechnicalAtmospheres.
        /// </summary>
        public static Pressure FromTechnicalAtmospheres(double technicalatmospheres)
        {
            return new Pressure(technicalatmospheres*9.80680592331*1e4);
        }

        /// <summary>
        ///     Get Pressure from TonnesForcePerSquareCentimeter.
        /// </summary>
        public static Pressure FromTonnesForcePerSquareCentimeter(double tonnesforcepersquarecentimeter)
        {
            return new Pressure(tonnesforcepersquarecentimeter*98066501.9960652);
        }

        /// <summary>
        ///     Get Pressure from TonnesForcePerSquareMeter.
        /// </summary>
        public static Pressure FromTonnesForcePerSquareMeter(double tonnesforcepersquaremeter)
        {
            return new Pressure(tonnesforcepersquaremeter*9806.65019960653);
        }

        /// <summary>
        ///     Get Pressure from TonnesForcePerSquareMillimeter.
        /// </summary>
        public static Pressure FromTonnesForcePerSquareMillimeter(double tonnesforcepersquaremillimeter)
        {
            return new Pressure(tonnesforcepersquaremillimeter*9806650199.60653);
        }

        /// <summary>
        ///     Get Pressure from Torrs.
        /// </summary>
        public static Pressure FromTorrs(double torrs)
        {
            return new Pressure(torrs*1.3332266752*1e2);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Pressure from nullable Atmospheres.
        /// </summary>
        public static Pressure? FromAtmospheres(double? atmospheres)
        {
            if (atmospheres.HasValue)
            {
                return FromAtmospheres(atmospheres.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Bars.
        /// </summary>
        public static Pressure? FromBars(double? bars)
        {
            if (bars.HasValue)
            {
                return FromBars(bars.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Centibars.
        /// </summary>
        public static Pressure? FromCentibars(double? centibars)
        {
            if (centibars.HasValue)
            {
                return FromCentibars(centibars.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Decapascals.
        /// </summary>
        public static Pressure? FromDecapascals(double? decapascals)
        {
            if (decapascals.HasValue)
            {
                return FromDecapascals(decapascals.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Decibars.
        /// </summary>
        public static Pressure? FromDecibars(double? decibars)
        {
            if (decibars.HasValue)
            {
                return FromDecibars(decibars.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Gigapascals.
        /// </summary>
        public static Pressure? FromGigapascals(double? gigapascals)
        {
            if (gigapascals.HasValue)
            {
                return FromGigapascals(gigapascals.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Hectopascals.
        /// </summary>
        public static Pressure? FromHectopascals(double? hectopascals)
        {
            if (hectopascals.HasValue)
            {
                return FromHectopascals(hectopascals.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Kilobars.
        /// </summary>
        public static Pressure? FromKilobars(double? kilobars)
        {
            if (kilobars.HasValue)
            {
                return FromKilobars(kilobars.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable KilogramsForcePerSquareCentimeter.
        /// </summary>
        public static Pressure? FromKilogramsForcePerSquareCentimeter(double? kilogramsforcepersquarecentimeter)
        {
            if (kilogramsforcepersquarecentimeter.HasValue)
            {
                return FromKilogramsForcePerSquareCentimeter(kilogramsforcepersquarecentimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable KilogramsForcePerSquareMeter.
        /// </summary>
        public static Pressure? FromKilogramsForcePerSquareMeter(double? kilogramsforcepersquaremeter)
        {
            if (kilogramsforcepersquaremeter.HasValue)
            {
                return FromKilogramsForcePerSquareMeter(kilogramsforcepersquaremeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable KilogramsForcePerSquareMillimeter.
        /// </summary>
        public static Pressure? FromKilogramsForcePerSquareMillimeter(double? kilogramsforcepersquaremillimeter)
        {
            if (kilogramsforcepersquaremillimeter.HasValue)
            {
                return FromKilogramsForcePerSquareMillimeter(kilogramsforcepersquaremillimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable KilonewtonsPerSquareCentimeter.
        /// </summary>
        public static Pressure? FromKilonewtonsPerSquareCentimeter(double? kilonewtonspersquarecentimeter)
        {
            if (kilonewtonspersquarecentimeter.HasValue)
            {
                return FromKilonewtonsPerSquareCentimeter(kilonewtonspersquarecentimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable KilonewtonsPerSquareMeter.
        /// </summary>
        public static Pressure? FromKilonewtonsPerSquareMeter(double? kilonewtonspersquaremeter)
        {
            if (kilonewtonspersquaremeter.HasValue)
            {
                return FromKilonewtonsPerSquareMeter(kilonewtonspersquaremeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable KilonewtonsPerSquareMillimeter.
        /// </summary>
        public static Pressure? FromKilonewtonsPerSquareMillimeter(double? kilonewtonspersquaremillimeter)
        {
            if (kilonewtonspersquaremillimeter.HasValue)
            {
                return FromKilonewtonsPerSquareMillimeter(kilonewtonspersquaremillimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Kilopascals.
        /// </summary>
        public static Pressure? FromKilopascals(double? kilopascals)
        {
            if (kilopascals.HasValue)
            {
                return FromKilopascals(kilopascals.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable KilopoundsForcePerSquareFoot.
        /// </summary>
        public static Pressure? FromKilopoundsForcePerSquareFoot(double? kilopoundsforcepersquarefoot)
        {
            if (kilopoundsforcepersquarefoot.HasValue)
            {
                return FromKilopoundsForcePerSquareFoot(kilopoundsforcepersquarefoot.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable KilopoundsForcePerSquareInch.
        /// </summary>
        public static Pressure? FromKilopoundsForcePerSquareInch(double? kilopoundsforcepersquareinch)
        {
            if (kilopoundsforcepersquareinch.HasValue)
            {
                return FromKilopoundsForcePerSquareInch(kilopoundsforcepersquareinch.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Megabars.
        /// </summary>
        public static Pressure? FromMegabars(double? megabars)
        {
            if (megabars.HasValue)
            {
                return FromMegabars(megabars.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Megapascals.
        /// </summary>
        public static Pressure? FromMegapascals(double? megapascals)
        {
            if (megapascals.HasValue)
            {
                return FromMegapascals(megapascals.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Micropascals.
        /// </summary>
        public static Pressure? FromMicropascals(double? micropascals)
        {
            if (micropascals.HasValue)
            {
                return FromMicropascals(micropascals.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Millibars.
        /// </summary>
        public static Pressure? FromMillibars(double? millibars)
        {
            if (millibars.HasValue)
            {
                return FromMillibars(millibars.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable NewtonsPerSquareCentimeter.
        /// </summary>
        public static Pressure? FromNewtonsPerSquareCentimeter(double? newtonspersquarecentimeter)
        {
            if (newtonspersquarecentimeter.HasValue)
            {
                return FromNewtonsPerSquareCentimeter(newtonspersquarecentimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable NewtonsPerSquareMeter.
        /// </summary>
        public static Pressure? FromNewtonsPerSquareMeter(double? newtonspersquaremeter)
        {
            if (newtonspersquaremeter.HasValue)
            {
                return FromNewtonsPerSquareMeter(newtonspersquaremeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable NewtonsPerSquareMillimeter.
        /// </summary>
        public static Pressure? FromNewtonsPerSquareMillimeter(double? newtonspersquaremillimeter)
        {
            if (newtonspersquaremillimeter.HasValue)
            {
                return FromNewtonsPerSquareMillimeter(newtonspersquaremillimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Pascals.
        /// </summary>
        public static Pressure? FromPascals(double? pascals)
        {
            if (pascals.HasValue)
            {
                return FromPascals(pascals.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable PoundsForcePerSquareFoot.
        /// </summary>
        public static Pressure? FromPoundsForcePerSquareFoot(double? poundsforcepersquarefoot)
        {
            if (poundsforcepersquarefoot.HasValue)
            {
                return FromPoundsForcePerSquareFoot(poundsforcepersquarefoot.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable PoundsForcePerSquareInch.
        /// </summary>
        public static Pressure? FromPoundsForcePerSquareInch(double? poundsforcepersquareinch)
        {
            if (poundsforcepersquareinch.HasValue)
            {
                return FromPoundsForcePerSquareInch(poundsforcepersquareinch.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Psi.
        /// </summary>
        public static Pressure? FromPsi(double? psi)
        {
            if (psi.HasValue)
            {
                return FromPsi(psi.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable TechnicalAtmospheres.
        /// </summary>
        public static Pressure? FromTechnicalAtmospheres(double? technicalatmospheres)
        {
            if (technicalatmospheres.HasValue)
            {
                return FromTechnicalAtmospheres(technicalatmospheres.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable TonnesForcePerSquareCentimeter.
        /// </summary>
        public static Pressure? FromTonnesForcePerSquareCentimeter(double? tonnesforcepersquarecentimeter)
        {
            if (tonnesforcepersquarecentimeter.HasValue)
            {
                return FromTonnesForcePerSquareCentimeter(tonnesforcepersquarecentimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable TonnesForcePerSquareMeter.
        /// </summary>
        public static Pressure? FromTonnesForcePerSquareMeter(double? tonnesforcepersquaremeter)
        {
            if (tonnesforcepersquaremeter.HasValue)
            {
                return FromTonnesForcePerSquareMeter(tonnesforcepersquaremeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable TonnesForcePerSquareMillimeter.
        /// </summary>
        public static Pressure? FromTonnesForcePerSquareMillimeter(double? tonnesforcepersquaremillimeter)
        {
            if (tonnesforcepersquaremillimeter.HasValue)
            {
                return FromTonnesForcePerSquareMillimeter(tonnesforcepersquaremillimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Pressure from nullable Torrs.
        /// </summary>
        public static Pressure? FromTorrs(double? torrs)
        {
            if (torrs.HasValue)
            {
                return FromTorrs(torrs.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="PressureUnit" /> to <see cref="Pressure" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Pressure unit value.</returns>
        public static Pressure From(double val, PressureUnit fromUnit)
        {
            switch (fromUnit)
            {
                case PressureUnit.Atmosphere:
                    return FromAtmospheres(val);
                case PressureUnit.Bar:
                    return FromBars(val);
                case PressureUnit.Centibar:
                    return FromCentibars(val);
                case PressureUnit.Decapascal:
                    return FromDecapascals(val);
                case PressureUnit.Decibar:
                    return FromDecibars(val);
                case PressureUnit.Gigapascal:
                    return FromGigapascals(val);
                case PressureUnit.Hectopascal:
                    return FromHectopascals(val);
                case PressureUnit.Kilobar:
                    return FromKilobars(val);
                case PressureUnit.KilogramForcePerSquareCentimeter:
                    return FromKilogramsForcePerSquareCentimeter(val);
                case PressureUnit.KilogramForcePerSquareMeter:
                    return FromKilogramsForcePerSquareMeter(val);
                case PressureUnit.KilogramForcePerSquareMillimeter:
                    return FromKilogramsForcePerSquareMillimeter(val);
                case PressureUnit.KilonewtonPerSquareCentimeter:
                    return FromKilonewtonsPerSquareCentimeter(val);
                case PressureUnit.KilonewtonPerSquareMeter:
                    return FromKilonewtonsPerSquareMeter(val);
                case PressureUnit.KilonewtonPerSquareMillimeter:
                    return FromKilonewtonsPerSquareMillimeter(val);
                case PressureUnit.Kilopascal:
                    return FromKilopascals(val);
                case PressureUnit.KilopoundForcePerSquareFoot:
                    return FromKilopoundsForcePerSquareFoot(val);
                case PressureUnit.KilopoundForcePerSquareInch:
                    return FromKilopoundsForcePerSquareInch(val);
                case PressureUnit.Megabar:
                    return FromMegabars(val);
                case PressureUnit.Megapascal:
                    return FromMegapascals(val);
                case PressureUnit.Micropascal:
                    return FromMicropascals(val);
                case PressureUnit.Millibar:
                    return FromMillibars(val);
                case PressureUnit.NewtonPerSquareCentimeter:
                    return FromNewtonsPerSquareCentimeter(val);
                case PressureUnit.NewtonPerSquareMeter:
                    return FromNewtonsPerSquareMeter(val);
                case PressureUnit.NewtonPerSquareMillimeter:
                    return FromNewtonsPerSquareMillimeter(val);
                case PressureUnit.Pascal:
                    return FromPascals(val);
                case PressureUnit.PoundForcePerSquareFoot:
                    return FromPoundsForcePerSquareFoot(val);
                case PressureUnit.PoundForcePerSquareInch:
                    return FromPoundsForcePerSquareInch(val);
                case PressureUnit.Psi:
                    return FromPsi(val);
                case PressureUnit.TechnicalAtmosphere:
                    return FromTechnicalAtmospheres(val);
                case PressureUnit.TonneForcePerSquareCentimeter:
                    return FromTonnesForcePerSquareCentimeter(val);
                case PressureUnit.TonneForcePerSquareMeter:
                    return FromTonnesForcePerSquareMeter(val);
                case PressureUnit.TonneForcePerSquareMillimeter:
                    return FromTonnesForcePerSquareMillimeter(val);
                case PressureUnit.Torr:
                    return FromTorrs(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="PressureUnit" /> to <see cref="Pressure" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Pressure unit value.</returns>
        public static Pressure? From(double? value, PressureUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case PressureUnit.Atmosphere:
                    return FromAtmospheres(value.Value);
                case PressureUnit.Bar:
                    return FromBars(value.Value);
                case PressureUnit.Centibar:
                    return FromCentibars(value.Value);
                case PressureUnit.Decapascal:
                    return FromDecapascals(value.Value);
                case PressureUnit.Decibar:
                    return FromDecibars(value.Value);
                case PressureUnit.Gigapascal:
                    return FromGigapascals(value.Value);
                case PressureUnit.Hectopascal:
                    return FromHectopascals(value.Value);
                case PressureUnit.Kilobar:
                    return FromKilobars(value.Value);
                case PressureUnit.KilogramForcePerSquareCentimeter:
                    return FromKilogramsForcePerSquareCentimeter(value.Value);
                case PressureUnit.KilogramForcePerSquareMeter:
                    return FromKilogramsForcePerSquareMeter(value.Value);
                case PressureUnit.KilogramForcePerSquareMillimeter:
                    return FromKilogramsForcePerSquareMillimeter(value.Value);
                case PressureUnit.KilonewtonPerSquareCentimeter:
                    return FromKilonewtonsPerSquareCentimeter(value.Value);
                case PressureUnit.KilonewtonPerSquareMeter:
                    return FromKilonewtonsPerSquareMeter(value.Value);
                case PressureUnit.KilonewtonPerSquareMillimeter:
                    return FromKilonewtonsPerSquareMillimeter(value.Value);
                case PressureUnit.Kilopascal:
                    return FromKilopascals(value.Value);
                case PressureUnit.KilopoundForcePerSquareFoot:
                    return FromKilopoundsForcePerSquareFoot(value.Value);
                case PressureUnit.KilopoundForcePerSquareInch:
                    return FromKilopoundsForcePerSquareInch(value.Value);
                case PressureUnit.Megabar:
                    return FromMegabars(value.Value);
                case PressureUnit.Megapascal:
                    return FromMegapascals(value.Value);
                case PressureUnit.Micropascal:
                    return FromMicropascals(value.Value);
                case PressureUnit.Millibar:
                    return FromMillibars(value.Value);
                case PressureUnit.NewtonPerSquareCentimeter:
                    return FromNewtonsPerSquareCentimeter(value.Value);
                case PressureUnit.NewtonPerSquareMeter:
                    return FromNewtonsPerSquareMeter(value.Value);
                case PressureUnit.NewtonPerSquareMillimeter:
                    return FromNewtonsPerSquareMillimeter(value.Value);
                case PressureUnit.Pascal:
                    return FromPascals(value.Value);
                case PressureUnit.PoundForcePerSquareFoot:
                    return FromPoundsForcePerSquareFoot(value.Value);
                case PressureUnit.PoundForcePerSquareInch:
                    return FromPoundsForcePerSquareInch(value.Value);
                case PressureUnit.Psi:
                    return FromPsi(value.Value);
                case PressureUnit.TechnicalAtmosphere:
                    return FromTechnicalAtmospheres(value.Value);
                case PressureUnit.TonneForcePerSquareCentimeter:
                    return FromTonnesForcePerSquareCentimeter(value.Value);
                case PressureUnit.TonneForcePerSquareMeter:
                    return FromTonnesForcePerSquareMeter(value.Value);
                case PressureUnit.TonneForcePerSquareMillimeter:
                    return FromTonnesForcePerSquareMillimeter(value.Value);
                case PressureUnit.Torr:
                    return FromTorrs(value.Value);

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
        public static string GetAbbreviation(PressureUnit unit)
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
        public static string GetAbbreviation(PressureUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static Pressure operator -(Pressure right)
        {
            return new Pressure(-right._pascals);
        }

        public static Pressure operator +(Pressure left, Pressure right)
        {
            return new Pressure(left._pascals + right._pascals);
        }

        public static Pressure operator -(Pressure left, Pressure right)
        {
            return new Pressure(left._pascals - right._pascals);
        }

        public static Pressure operator *(double left, Pressure right)
        {
            return new Pressure(left*right._pascals);
        }

        public static Pressure operator *(Pressure left, double right)
        {
            return new Pressure(left._pascals*(double)right);
        }

        public static Pressure operator /(Pressure left, double right)
        {
            return new Pressure(left._pascals/(double)right);
        }

        public static double operator /(Pressure left, Pressure right)
        {
            return Convert.ToDouble(left._pascals/right._pascals);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Pressure)) throw new ArgumentException("Expected type Pressure.", "obj");
            return CompareTo((Pressure) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Pressure other)
        {
            return _pascals.CompareTo(other._pascals);
        }

#if !WINDOWS_UWP
        public static bool operator <=(Pressure left, Pressure right)
        {
            return left._pascals <= right._pascals;
        }

        public static bool operator >=(Pressure left, Pressure right)
        {
            return left._pascals >= right._pascals;
        }

        public static bool operator <(Pressure left, Pressure right)
        {
            return left._pascals < right._pascals;
        }

        public static bool operator >(Pressure left, Pressure right)
        {
            return left._pascals > right._pascals;
        }

        public static bool operator ==(Pressure left, Pressure right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._pascals == right._pascals;
        }

        public static bool operator !=(Pressure left, Pressure right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._pascals != right._pascals;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _pascals.Equals(((Pressure) obj)._pascals);
        }

        public override int GetHashCode()
        {
            return _pascals.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(PressureUnit unit)
        {
            switch (unit)
            {
                case PressureUnit.Atmosphere:
                    return Atmospheres;
                case PressureUnit.Bar:
                    return Bars;
                case PressureUnit.Centibar:
                    return Centibars;
                case PressureUnit.Decapascal:
                    return Decapascals;
                case PressureUnit.Decibar:
                    return Decibars;
                case PressureUnit.Gigapascal:
                    return Gigapascals;
                case PressureUnit.Hectopascal:
                    return Hectopascals;
                case PressureUnit.Kilobar:
                    return Kilobars;
                case PressureUnit.KilogramForcePerSquareCentimeter:
                    return KilogramsForcePerSquareCentimeter;
                case PressureUnit.KilogramForcePerSquareMeter:
                    return KilogramsForcePerSquareMeter;
                case PressureUnit.KilogramForcePerSquareMillimeter:
                    return KilogramsForcePerSquareMillimeter;
                case PressureUnit.KilonewtonPerSquareCentimeter:
                    return KilonewtonsPerSquareCentimeter;
                case PressureUnit.KilonewtonPerSquareMeter:
                    return KilonewtonsPerSquareMeter;
                case PressureUnit.KilonewtonPerSquareMillimeter:
                    return KilonewtonsPerSquareMillimeter;
                case PressureUnit.Kilopascal:
                    return Kilopascals;
                case PressureUnit.KilopoundForcePerSquareFoot:
                    return KilopoundsForcePerSquareFoot;
                case PressureUnit.KilopoundForcePerSquareInch:
                    return KilopoundsForcePerSquareInch;
                case PressureUnit.Megabar:
                    return Megabars;
                case PressureUnit.Megapascal:
                    return Megapascals;
                case PressureUnit.Micropascal:
                    return Micropascals;
                case PressureUnit.Millibar:
                    return Millibars;
                case PressureUnit.NewtonPerSquareCentimeter:
                    return NewtonsPerSquareCentimeter;
                case PressureUnit.NewtonPerSquareMeter:
                    return NewtonsPerSquareMeter;
                case PressureUnit.NewtonPerSquareMillimeter:
                    return NewtonsPerSquareMillimeter;
                case PressureUnit.Pascal:
                    return Pascals;
                case PressureUnit.PoundForcePerSquareFoot:
                    return PoundsForcePerSquareFoot;
                case PressureUnit.PoundForcePerSquareInch:
                    return PoundsForcePerSquareInch;
                case PressureUnit.Psi:
                    return Psi;
                case PressureUnit.TechnicalAtmosphere:
                    return TechnicalAtmospheres;
                case PressureUnit.TonneForcePerSquareCentimeter:
                    return TonnesForcePerSquareCentimeter;
                case PressureUnit.TonneForcePerSquareMeter:
                    return TonnesForcePerSquareMeter;
                case PressureUnit.TonneForcePerSquareMillimeter:
                    return TonnesForcePerSquareMillimeter;
                case PressureUnit.Torr:
                    return Torrs;

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
        public static Pressure Parse(string str)
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
        public static Pressure Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => Pressure.FromPascals(x.Pascals + y.Pascals));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Pressure> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Pressure>();

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
                    PressureUnit unit = ParseUnit(unitString, formatProvider);
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
        public static PressureUnit ParseUnit(string str)
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
        public static PressureUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static PressureUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<PressureUnit>(str.Trim());

            if (unit == PressureUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized PressureUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Pascal
        /// </summary>
        public static PressureUnit ToStringDefaultUnit { get; set; } = PressureUnit.Pascal;

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
        public string ToString(PressureUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(PressureUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(PressureUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(PressureUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
