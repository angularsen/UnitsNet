// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Pressure (symbol: P or p) is the ratio of force to the area over which that force is distributed. Pressure is force per unit area applied in a direction perpendicular to the surface of an object. Gauge pressure (also spelled gage pressure)[a] is the pressure relative to the local atmospheric or ambient pressure. Pressure is measured in any unit of force divided by any unit of area. The SI unit of pressure is the newton per square metre, which is called the pascal (Pa) after the seventeenth-century philosopher and scientist Blaise Pascal. A pressure of 1 Pa is small; it approximately equals the pressure exerted by a dollar bill resting flat on a table. Everyday pressures are often stated in kilopascals (1 kPa = 1000 Pa).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Pressure : IComparable, IComparable<Pressure>
    {
        /// <summary>
        ///     Base unit of Pressure.
        /// </summary>
        private readonly double _pascals;

        public Pressure(double pascals) : this()
        {
            _pascals = pascals;
        }

        #region Properties

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


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="PressureUnit" /> to <see cref="Pressure" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Pressure unit value.</returns>
        public static Pressure From(double value, PressureUnit fromUnit)
        {
            switch (fromUnit)
            {
                case PressureUnit.Atmosphere:
                    return FromAtmospheres(value);
                case PressureUnit.Bar:
                    return FromBars(value);
                case PressureUnit.Centibar:
                    return FromCentibars(value);
                case PressureUnit.Decapascal:
                    return FromDecapascals(value);
                case PressureUnit.Decibar:
                    return FromDecibars(value);
                case PressureUnit.Gigapascal:
                    return FromGigapascals(value);
                case PressureUnit.Hectopascal:
                    return FromHectopascals(value);
                case PressureUnit.Kilobar:
                    return FromKilobars(value);
                case PressureUnit.KilogramForcePerSquareCentimeter:
                    return FromKilogramsForcePerSquareCentimeter(value);
                case PressureUnit.KilogramForcePerSquareMeter:
                    return FromKilogramsForcePerSquareMeter(value);
                case PressureUnit.KilogramForcePerSquareMillimeter:
                    return FromKilogramsForcePerSquareMillimeter(value);
                case PressureUnit.KilonewtonPerSquareCentimeter:
                    return FromKilonewtonsPerSquareCentimeter(value);
                case PressureUnit.KilonewtonPerSquareMeter:
                    return FromKilonewtonsPerSquareMeter(value);
                case PressureUnit.KilonewtonPerSquareMillimeter:
                    return FromKilonewtonsPerSquareMillimeter(value);
                case PressureUnit.Kilopascal:
                    return FromKilopascals(value);
                case PressureUnit.KilopoundForcePerSquareFoot:
                    return FromKilopoundsForcePerSquareFoot(value);
                case PressureUnit.KilopoundForcePerSquareInch:
                    return FromKilopoundsForcePerSquareInch(value);
                case PressureUnit.Megabar:
                    return FromMegabars(value);
                case PressureUnit.Megapascal:
                    return FromMegapascals(value);
                case PressureUnit.Micropascal:
                    return FromMicropascals(value);
                case PressureUnit.Millibar:
                    return FromMillibars(value);
                case PressureUnit.NewtonPerSquareCentimeter:
                    return FromNewtonsPerSquareCentimeter(value);
                case PressureUnit.NewtonPerSquareMeter:
                    return FromNewtonsPerSquareMeter(value);
                case PressureUnit.NewtonPerSquareMillimeter:
                    return FromNewtonsPerSquareMillimeter(value);
                case PressureUnit.Pascal:
                    return FromPascals(value);
                case PressureUnit.PoundForcePerSquareFoot:
                    return FromPoundsForcePerSquareFoot(value);
                case PressureUnit.PoundForcePerSquareInch:
                    return FromPoundsForcePerSquareInch(value);
                case PressureUnit.Psi:
                    return FromPsi(value);
                case PressureUnit.TechnicalAtmosphere:
                    return FromTechnicalAtmospheres(value);
                case PressureUnit.TonneForcePerSquareCentimeter:
                    return FromTonnesForcePerSquareCentimeter(value);
                case PressureUnit.TonneForcePerSquareMeter:
                    return FromTonnesForcePerSquareMeter(value);
                case PressureUnit.TonneForcePerSquareMillimeter:
                    return FromTonnesForcePerSquareMillimeter(value);
                case PressureUnit.Torr:
                    return FromTorrs(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(PressureUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

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

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Pressure)) throw new ArgumentException("Expected type Pressure.", "obj");
            return CompareTo((Pressure) obj);
        }

        public int CompareTo(Pressure other)
        {
            return _pascals.CompareTo(other._pascals);
        }

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
        ///     Parse a string of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected 2 words. Input string needs to be in the format "&lt;quantity&gt; &lt;unit
        ///     &gt;".
        /// </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static Pressure Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var regexString = string.Format("(?<value>[-+]?{0}{1}{2}{3}",
                            numRegex,              // capture base (integral) Quantity value
                            @"(?:[eE][-+]?\d+)?)", // capture exponential (if any), end of Quantity capturing
                            @"\s?",                // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>\S+)");      // capture Unit (non-whitespace) input

            var regex = new Regex(regexString);
            GroupCollection groups = regex.Match(str.Trim()).Groups;

            var valueString = groups["value"].Value;
            var unitString = groups["unit"].Value;

            if (valueString == "" || unitString == "")
            {
                var ex = new ArgumentException(
                    "Expected valid quantity and unit. Input string needs to be in the format \"<quantity><unit> or <quantity> <unit>\".", "str");
                ex.Data["input"] = str;
                ex.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw ex;
            }

            try
            {
                PressureUnit unit = ParseUnit(unitString, formatProvider);
                double value = double.Parse(valueString, formatProvider);

                return From(value, unit);
            }
            catch (Exception e)
            {
                var newEx = new UnitsNetException("Error parsing string.", e);
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
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
        public static PressureUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<PressureUnit>(str.Trim());

            if (unit == PressureUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized PressureUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(PressureUnit.Pascal);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(PressureUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
        {
            return ToString(unit, culture, UnitFormatter.GetFormat(As(unit), significantDigitsAfterRadix));
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
        public string ToString(PressureUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
