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
using NUnit.Framework;
using UnitsNet.Units;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Pressure.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class PressureTestsBase
    {
        protected abstract double AtmospheresInOnePascal { get; }
        protected abstract double BarsInOnePascal { get; }
        protected abstract double CentibarsInOnePascal { get; }
        protected abstract double DecapascalsInOnePascal { get; }
        protected abstract double DecibarsInOnePascal { get; }
        protected abstract double GigapascalsInOnePascal { get; }
        protected abstract double HectopascalsInOnePascal { get; }
        protected abstract double KilobarsInOnePascal { get; }
        protected abstract double KilogramsForcePerSquareCentimeterInOnePascal { get; }
        protected abstract double KilogramsForcePerSquareMeterInOnePascal { get; }
        protected abstract double KilogramsForcePerSquareMillimeterInOnePascal { get; }
        protected abstract double KilonewtonsPerSquareCentimeterInOnePascal { get; }
        protected abstract double KilonewtonsPerSquareMeterInOnePascal { get; }
        protected abstract double KilonewtonsPerSquareMillimeterInOnePascal { get; }
        protected abstract double KilopascalsInOnePascal { get; }
        protected abstract double KilopoundsForcePerSquareFootInOnePascal { get; }
        protected abstract double KilopoundsForcePerSquareInchInOnePascal { get; }
        protected abstract double MegabarsInOnePascal { get; }
        protected abstract double MegapascalsInOnePascal { get; }
        protected abstract double MicropascalsInOnePascal { get; }
        protected abstract double MillibarsInOnePascal { get; }
        protected abstract double NewtonsPerSquareCentimeterInOnePascal { get; }
        protected abstract double NewtonsPerSquareMeterInOnePascal { get; }
        protected abstract double NewtonsPerSquareMillimeterInOnePascal { get; }
        protected abstract double PascalsInOnePascal { get; }
        protected abstract double PoundsForcePerSquareFootInOnePascal { get; }
        protected abstract double PoundsForcePerSquareInchInOnePascal { get; }
        protected abstract double PsiInOnePascal { get; }
        protected abstract double TechnicalAtmospheresInOnePascal { get; }
        protected abstract double TonnesForcePerSquareCentimeterInOnePascal { get; }
        protected abstract double TonnesForcePerSquareMeterInOnePascal { get; }
        protected abstract double TonnesForcePerSquareMillimeterInOnePascal { get; }
        protected abstract double TorrsInOnePascal { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double AtmospheresTolerance { get { return 1e-5; } }
        protected virtual double BarsTolerance { get { return 1e-5; } }
        protected virtual double CentibarsTolerance { get { return 1e-5; } }
        protected virtual double DecapascalsTolerance { get { return 1e-5; } }
        protected virtual double DecibarsTolerance { get { return 1e-5; } }
        protected virtual double GigapascalsTolerance { get { return 1e-5; } }
        protected virtual double HectopascalsTolerance { get { return 1e-5; } }
        protected virtual double KilobarsTolerance { get { return 1e-5; } }
        protected virtual double KilogramsForcePerSquareCentimeterTolerance { get { return 1e-5; } }
        protected virtual double KilogramsForcePerSquareMeterTolerance { get { return 1e-5; } }
        protected virtual double KilogramsForcePerSquareMillimeterTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonsPerSquareCentimeterTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonsPerSquareMeterTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonsPerSquareMillimeterTolerance { get { return 1e-5; } }
        protected virtual double KilopascalsTolerance { get { return 1e-5; } }
        protected virtual double KilopoundsForcePerSquareFootTolerance { get { return 1e-5; } }
        protected virtual double KilopoundsForcePerSquareInchTolerance { get { return 1e-5; } }
        protected virtual double MegabarsTolerance { get { return 1e-5; } }
        protected virtual double MegapascalsTolerance { get { return 1e-5; } }
        protected virtual double MicropascalsTolerance { get { return 1e-5; } }
        protected virtual double MillibarsTolerance { get { return 1e-5; } }
        protected virtual double NewtonsPerSquareCentimeterTolerance { get { return 1e-5; } }
        protected virtual double NewtonsPerSquareMeterTolerance { get { return 1e-5; } }
        protected virtual double NewtonsPerSquareMillimeterTolerance { get { return 1e-5; } }
        protected virtual double PascalsTolerance { get { return 1e-5; } }
        protected virtual double PoundsForcePerSquareFootTolerance { get { return 1e-5; } }
        protected virtual double PoundsForcePerSquareInchTolerance { get { return 1e-5; } }
        protected virtual double PsiTolerance { get { return 1e-5; } }
        protected virtual double TechnicalAtmospheresTolerance { get { return 1e-5; } }
        protected virtual double TonnesForcePerSquareCentimeterTolerance { get { return 1e-5; } }
        protected virtual double TonnesForcePerSquareMeterTolerance { get { return 1e-5; } }
        protected virtual double TonnesForcePerSquareMillimeterTolerance { get { return 1e-5; } }
        protected virtual double TorrsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void PascalToPressureUnits()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.AreEqual(AtmospheresInOnePascal, pascal.Atmospheres, AtmospheresTolerance);
            Assert.AreEqual(BarsInOnePascal, pascal.Bars, BarsTolerance);
            Assert.AreEqual(CentibarsInOnePascal, pascal.Centibars, CentibarsTolerance);
            Assert.AreEqual(DecapascalsInOnePascal, pascal.Decapascals, DecapascalsTolerance);
            Assert.AreEqual(DecibarsInOnePascal, pascal.Decibars, DecibarsTolerance);
            Assert.AreEqual(GigapascalsInOnePascal, pascal.Gigapascals, GigapascalsTolerance);
            Assert.AreEqual(HectopascalsInOnePascal, pascal.Hectopascals, HectopascalsTolerance);
            Assert.AreEqual(KilobarsInOnePascal, pascal.Kilobars, KilobarsTolerance);
            Assert.AreEqual(KilogramsForcePerSquareCentimeterInOnePascal, pascal.KilogramsForcePerSquareCentimeter, KilogramsForcePerSquareCentimeterTolerance);
            Assert.AreEqual(KilogramsForcePerSquareMeterInOnePascal, pascal.KilogramsForcePerSquareMeter, KilogramsForcePerSquareMeterTolerance);
            Assert.AreEqual(KilogramsForcePerSquareMillimeterInOnePascal, pascal.KilogramsForcePerSquareMillimeter, KilogramsForcePerSquareMillimeterTolerance);
            Assert.AreEqual(KilonewtonsPerSquareCentimeterInOnePascal, pascal.KilonewtonsPerSquareCentimeter, KilonewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(KilonewtonsPerSquareMeterInOnePascal, pascal.KilonewtonsPerSquareMeter, KilonewtonsPerSquareMeterTolerance);
            Assert.AreEqual(KilonewtonsPerSquareMillimeterInOnePascal, pascal.KilonewtonsPerSquareMillimeter, KilonewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(KilopascalsInOnePascal, pascal.Kilopascals, KilopascalsTolerance);
            Assert.AreEqual(KilopoundsForcePerSquareFootInOnePascal, pascal.KilopoundsForcePerSquareFoot, KilopoundsForcePerSquareFootTolerance);
            Assert.AreEqual(KilopoundsForcePerSquareInchInOnePascal, pascal.KilopoundsForcePerSquareInch, KilopoundsForcePerSquareInchTolerance);
            Assert.AreEqual(MegabarsInOnePascal, pascal.Megabars, MegabarsTolerance);
            Assert.AreEqual(MegapascalsInOnePascal, pascal.Megapascals, MegapascalsTolerance);
            Assert.AreEqual(MicropascalsInOnePascal, pascal.Micropascals, MicropascalsTolerance);
            Assert.AreEqual(MillibarsInOnePascal, pascal.Millibars, MillibarsTolerance);
            Assert.AreEqual(NewtonsPerSquareCentimeterInOnePascal, pascal.NewtonsPerSquareCentimeter, NewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(NewtonsPerSquareMeterInOnePascal, pascal.NewtonsPerSquareMeter, NewtonsPerSquareMeterTolerance);
            Assert.AreEqual(NewtonsPerSquareMillimeterInOnePascal, pascal.NewtonsPerSquareMillimeter, NewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(PascalsInOnePascal, pascal.Pascals, PascalsTolerance);
            Assert.AreEqual(PoundsForcePerSquareFootInOnePascal, pascal.PoundsForcePerSquareFoot, PoundsForcePerSquareFootTolerance);
            Assert.AreEqual(PoundsForcePerSquareInchInOnePascal, pascal.PoundsForcePerSquareInch, PoundsForcePerSquareInchTolerance);
            Assert.AreEqual(PsiInOnePascal, pascal.Psi, PsiTolerance);
            Assert.AreEqual(TechnicalAtmospheresInOnePascal, pascal.TechnicalAtmospheres, TechnicalAtmospheresTolerance);
            Assert.AreEqual(TonnesForcePerSquareCentimeterInOnePascal, pascal.TonnesForcePerSquareCentimeter, TonnesForcePerSquareCentimeterTolerance);
            Assert.AreEqual(TonnesForcePerSquareMeterInOnePascal, pascal.TonnesForcePerSquareMeter, TonnesForcePerSquareMeterTolerance);
            Assert.AreEqual(TonnesForcePerSquareMillimeterInOnePascal, pascal.TonnesForcePerSquareMillimeter, TonnesForcePerSquareMillimeterTolerance);
            Assert.AreEqual(TorrsInOnePascal, pascal.Torrs, TorrsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Atmosphere).Atmospheres, AtmospheresTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Bar).Bars, BarsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Centibar).Centibars, CentibarsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Decapascal).Decapascals, DecapascalsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Decibar).Decibars, DecibarsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Gigapascal).Gigapascals, GigapascalsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Hectopascal).Hectopascals, HectopascalsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Kilobar).Kilobars, KilobarsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.KilogramForcePerSquareCentimeter).KilogramsForcePerSquareCentimeter, KilogramsForcePerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.KilogramForcePerSquareMeter).KilogramsForcePerSquareMeter, KilogramsForcePerSquareMeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.KilogramForcePerSquareMillimeter).KilogramsForcePerSquareMillimeter, KilogramsForcePerSquareMillimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.KilonewtonPerSquareCentimeter).KilonewtonsPerSquareCentimeter, KilonewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.KilonewtonPerSquareMeter).KilonewtonsPerSquareMeter, KilonewtonsPerSquareMeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.KilonewtonPerSquareMillimeter).KilonewtonsPerSquareMillimeter, KilonewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Kilopascal).Kilopascals, KilopascalsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.KilopoundForcePerSquareFoot).KilopoundsForcePerSquareFoot, KilopoundsForcePerSquareFootTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.KilopoundForcePerSquareInch).KilopoundsForcePerSquareInch, KilopoundsForcePerSquareInchTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Megabar).Megabars, MegabarsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Megapascal).Megapascals, MegapascalsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Micropascal).Micropascals, MicropascalsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Millibar).Millibars, MillibarsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.NewtonPerSquareCentimeter).NewtonsPerSquareCentimeter, NewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.NewtonPerSquareMeter).NewtonsPerSquareMeter, NewtonsPerSquareMeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.NewtonPerSquareMillimeter).NewtonsPerSquareMillimeter, NewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Pascal).Pascals, PascalsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.PoundForcePerSquareFoot).PoundsForcePerSquareFoot, PoundsForcePerSquareFootTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.PoundForcePerSquareInch).PoundsForcePerSquareInch, PoundsForcePerSquareInchTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Psi).Psi, PsiTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.TechnicalAtmosphere).TechnicalAtmospheres, TechnicalAtmospheresTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.TonneForcePerSquareCentimeter).TonnesForcePerSquareCentimeter, TonnesForcePerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.TonneForcePerSquareMeter).TonnesForcePerSquareMeter, TonnesForcePerSquareMeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.TonneForcePerSquareMillimeter).TonnesForcePerSquareMillimeter, TonnesForcePerSquareMillimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Torr).Torrs, TorrsTolerance);
        }

        [Test]
        public void As()
        {
            var pascal = Pressure.FromPascals(1);
            Assert.AreEqual(AtmospheresInOnePascal, pascal.As(PressureUnit.Atmosphere), AtmospheresTolerance);
            Assert.AreEqual(BarsInOnePascal, pascal.As(PressureUnit.Bar), BarsTolerance);
            Assert.AreEqual(CentibarsInOnePascal, pascal.As(PressureUnit.Centibar), CentibarsTolerance);
            Assert.AreEqual(DecapascalsInOnePascal, pascal.As(PressureUnit.Decapascal), DecapascalsTolerance);
            Assert.AreEqual(DecibarsInOnePascal, pascal.As(PressureUnit.Decibar), DecibarsTolerance);
            Assert.AreEqual(GigapascalsInOnePascal, pascal.As(PressureUnit.Gigapascal), GigapascalsTolerance);
            Assert.AreEqual(HectopascalsInOnePascal, pascal.As(PressureUnit.Hectopascal), HectopascalsTolerance);
            Assert.AreEqual(KilobarsInOnePascal, pascal.As(PressureUnit.Kilobar), KilobarsTolerance);
            Assert.AreEqual(KilogramsForcePerSquareCentimeterInOnePascal, pascal.As(PressureUnit.KilogramForcePerSquareCentimeter), KilogramsForcePerSquareCentimeterTolerance);
            Assert.AreEqual(KilogramsForcePerSquareMeterInOnePascal, pascal.As(PressureUnit.KilogramForcePerSquareMeter), KilogramsForcePerSquareMeterTolerance);
            Assert.AreEqual(KilogramsForcePerSquareMillimeterInOnePascal, pascal.As(PressureUnit.KilogramForcePerSquareMillimeter), KilogramsForcePerSquareMillimeterTolerance);
            Assert.AreEqual(KilonewtonsPerSquareCentimeterInOnePascal, pascal.As(PressureUnit.KilonewtonPerSquareCentimeter), KilonewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(KilonewtonsPerSquareMeterInOnePascal, pascal.As(PressureUnit.KilonewtonPerSquareMeter), KilonewtonsPerSquareMeterTolerance);
            Assert.AreEqual(KilonewtonsPerSquareMillimeterInOnePascal, pascal.As(PressureUnit.KilonewtonPerSquareMillimeter), KilonewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(KilopascalsInOnePascal, pascal.As(PressureUnit.Kilopascal), KilopascalsTolerance);
            Assert.AreEqual(KilopoundsForcePerSquareFootInOnePascal, pascal.As(PressureUnit.KilopoundForcePerSquareFoot), KilopoundsForcePerSquareFootTolerance);
            Assert.AreEqual(KilopoundsForcePerSquareInchInOnePascal, pascal.As(PressureUnit.KilopoundForcePerSquareInch), KilopoundsForcePerSquareInchTolerance);
            Assert.AreEqual(MegabarsInOnePascal, pascal.As(PressureUnit.Megabar), MegabarsTolerance);
            Assert.AreEqual(MegapascalsInOnePascal, pascal.As(PressureUnit.Megapascal), MegapascalsTolerance);
            Assert.AreEqual(MicropascalsInOnePascal, pascal.As(PressureUnit.Micropascal), MicropascalsTolerance);
            Assert.AreEqual(MillibarsInOnePascal, pascal.As(PressureUnit.Millibar), MillibarsTolerance);
            Assert.AreEqual(NewtonsPerSquareCentimeterInOnePascal, pascal.As(PressureUnit.NewtonPerSquareCentimeter), NewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(NewtonsPerSquareMeterInOnePascal, pascal.As(PressureUnit.NewtonPerSquareMeter), NewtonsPerSquareMeterTolerance);
            Assert.AreEqual(NewtonsPerSquareMillimeterInOnePascal, pascal.As(PressureUnit.NewtonPerSquareMillimeter), NewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(PascalsInOnePascal, pascal.As(PressureUnit.Pascal), PascalsTolerance);
            Assert.AreEqual(PoundsForcePerSquareFootInOnePascal, pascal.As(PressureUnit.PoundForcePerSquareFoot), PoundsForcePerSquareFootTolerance);
            Assert.AreEqual(PoundsForcePerSquareInchInOnePascal, pascal.As(PressureUnit.PoundForcePerSquareInch), PoundsForcePerSquareInchTolerance);
            Assert.AreEqual(PsiInOnePascal, pascal.As(PressureUnit.Psi), PsiTolerance);
            Assert.AreEqual(TechnicalAtmospheresInOnePascal, pascal.As(PressureUnit.TechnicalAtmosphere), TechnicalAtmospheresTolerance);
            Assert.AreEqual(TonnesForcePerSquareCentimeterInOnePascal, pascal.As(PressureUnit.TonneForcePerSquareCentimeter), TonnesForcePerSquareCentimeterTolerance);
            Assert.AreEqual(TonnesForcePerSquareMeterInOnePascal, pascal.As(PressureUnit.TonneForcePerSquareMeter), TonnesForcePerSquareMeterTolerance);
            Assert.AreEqual(TonnesForcePerSquareMillimeterInOnePascal, pascal.As(PressureUnit.TonneForcePerSquareMillimeter), TonnesForcePerSquareMillimeterTolerance);
            Assert.AreEqual(TorrsInOnePascal, pascal.As(PressureUnit.Torr), TorrsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.AreEqual(1, Pressure.FromAtmospheres(pascal.Atmospheres).Pascals, AtmospheresTolerance);
            Assert.AreEqual(1, Pressure.FromBars(pascal.Bars).Pascals, BarsTolerance);
            Assert.AreEqual(1, Pressure.FromCentibars(pascal.Centibars).Pascals, CentibarsTolerance);
            Assert.AreEqual(1, Pressure.FromDecapascals(pascal.Decapascals).Pascals, DecapascalsTolerance);
            Assert.AreEqual(1, Pressure.FromDecibars(pascal.Decibars).Pascals, DecibarsTolerance);
            Assert.AreEqual(1, Pressure.FromGigapascals(pascal.Gigapascals).Pascals, GigapascalsTolerance);
            Assert.AreEqual(1, Pressure.FromHectopascals(pascal.Hectopascals).Pascals, HectopascalsTolerance);
            Assert.AreEqual(1, Pressure.FromKilobars(pascal.Kilobars).Pascals, KilobarsTolerance);
            Assert.AreEqual(1, Pressure.FromKilogramsForcePerSquareCentimeter(pascal.KilogramsForcePerSquareCentimeter).Pascals, KilogramsForcePerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.FromKilogramsForcePerSquareMeter(pascal.KilogramsForcePerSquareMeter).Pascals, KilogramsForcePerSquareMeterTolerance);
            Assert.AreEqual(1, Pressure.FromKilogramsForcePerSquareMillimeter(pascal.KilogramsForcePerSquareMillimeter).Pascals, KilogramsForcePerSquareMillimeterTolerance);
            Assert.AreEqual(1, Pressure.FromKilonewtonsPerSquareCentimeter(pascal.KilonewtonsPerSquareCentimeter).Pascals, KilonewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.FromKilonewtonsPerSquareMeter(pascal.KilonewtonsPerSquareMeter).Pascals, KilonewtonsPerSquareMeterTolerance);
            Assert.AreEqual(1, Pressure.FromKilonewtonsPerSquareMillimeter(pascal.KilonewtonsPerSquareMillimeter).Pascals, KilonewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(1, Pressure.FromKilopascals(pascal.Kilopascals).Pascals, KilopascalsTolerance);
            Assert.AreEqual(1, Pressure.FromKilopoundsForcePerSquareFoot(pascal.KilopoundsForcePerSquareFoot).Pascals, KilopoundsForcePerSquareFootTolerance);
            Assert.AreEqual(1, Pressure.FromKilopoundsForcePerSquareInch(pascal.KilopoundsForcePerSquareInch).Pascals, KilopoundsForcePerSquareInchTolerance);
            Assert.AreEqual(1, Pressure.FromMegabars(pascal.Megabars).Pascals, MegabarsTolerance);
            Assert.AreEqual(1, Pressure.FromMegapascals(pascal.Megapascals).Pascals, MegapascalsTolerance);
            Assert.AreEqual(1, Pressure.FromMicropascals(pascal.Micropascals).Pascals, MicropascalsTolerance);
            Assert.AreEqual(1, Pressure.FromMillibars(pascal.Millibars).Pascals, MillibarsTolerance);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareCentimeter(pascal.NewtonsPerSquareCentimeter).Pascals, NewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareMeter(pascal.NewtonsPerSquareMeter).Pascals, NewtonsPerSquareMeterTolerance);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareMillimeter(pascal.NewtonsPerSquareMillimeter).Pascals, NewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(1, Pressure.FromPascals(pascal.Pascals).Pascals, PascalsTolerance);
            Assert.AreEqual(1, Pressure.FromPoundsForcePerSquareFoot(pascal.PoundsForcePerSquareFoot).Pascals, PoundsForcePerSquareFootTolerance);
            Assert.AreEqual(1, Pressure.FromPoundsForcePerSquareInch(pascal.PoundsForcePerSquareInch).Pascals, PoundsForcePerSquareInchTolerance);
            Assert.AreEqual(1, Pressure.FromPsi(pascal.Psi).Pascals, PsiTolerance);
            Assert.AreEqual(1, Pressure.FromTechnicalAtmospheres(pascal.TechnicalAtmospheres).Pascals, TechnicalAtmospheresTolerance);
            Assert.AreEqual(1, Pressure.FromTonnesForcePerSquareCentimeter(pascal.TonnesForcePerSquareCentimeter).Pascals, TonnesForcePerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.FromTonnesForcePerSquareMeter(pascal.TonnesForcePerSquareMeter).Pascals, TonnesForcePerSquareMeterTolerance);
            Assert.AreEqual(1, Pressure.FromTonnesForcePerSquareMillimeter(pascal.TonnesForcePerSquareMillimeter).Pascals, TonnesForcePerSquareMillimeterTolerance);
            Assert.AreEqual(1, Pressure.FromTorrs(pascal.Torrs).Pascals, TorrsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Pressure v = Pressure.FromPascals(1);
            Assert.AreEqual(-1, -v.Pascals, PascalsTolerance);
            Assert.AreEqual(2, (Pressure.FromPascals(3)-v).Pascals, PascalsTolerance);
            Assert.AreEqual(2, (v + v).Pascals, PascalsTolerance);
            Assert.AreEqual(10, (v*10).Pascals, PascalsTolerance);
            Assert.AreEqual(10, (10*v).Pascals, PascalsTolerance);
            Assert.AreEqual(2, (Pressure.FromPascals(10)/5).Pascals, PascalsTolerance);
            Assert.AreEqual(2, Pressure.FromPascals(10)/Pressure.FromPascals(5), PascalsTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Pressure onePascal = Pressure.FromPascals(1);
            Pressure twoPascals = Pressure.FromPascals(2);

            Assert.True(onePascal < twoPascals);
            Assert.True(onePascal <= twoPascals);
            Assert.True(twoPascals > onePascal);
            Assert.True(twoPascals >= onePascal);

            Assert.False(onePascal > twoPascals);
            Assert.False(onePascal >= twoPascals);
            Assert.False(twoPascals < onePascal);
            Assert.False(twoPascals <= onePascal);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.AreEqual(0, pascal.CompareTo(pascal));
            Assert.Greater(pascal.CompareTo(Pressure.Zero), 0);
            Assert.Less(Pressure.Zero.CompareTo(pascal), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Pressure pascal = Pressure.FromPascals(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            pascal.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Pressure pascal = Pressure.FromPascals(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            pascal.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Pressure a = Pressure.FromPascals(1);
            Pressure b = Pressure.FromPascals(2);

// ReSharper disable EqualExpressionComparison
            Assert.True(a == a);
            Assert.True(a != b);

            Assert.False(a == b);
            Assert.False(a != a);
// ReSharper restore EqualExpressionComparison
        }

        [Test]
        public void EqualsIsImplemented()
        {
            Pressure v = Pressure.FromPascals(1);
            Assert.IsTrue(v.Equals(Pressure.FromPascals(1)));
            Assert.IsFalse(v.Equals(Pressure.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.IsFalse(pascal.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.IsFalse(pascal.Equals(null));
        }
    }
}
