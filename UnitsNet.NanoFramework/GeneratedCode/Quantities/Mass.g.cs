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
using UnitsNet.Units;

namespace UnitsNet
{
    /// <inheritdoc />
    /// <summary>
    ///     In physics, mass (from Greek μᾶζα "barley cake, lump [of dough]") is a property of a physical system or body, giving rise to the phenomena of the body's resistance to being accelerated by a force and the strength of its mutual gravitational attraction with other bodies. Instruments such as mass balances or scales use those phenomena to measure mass. The SI unit of mass is the kilogram (kg).
    /// </summary>
    public struct  Mass
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly MassUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public MassUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        public Mass(double value, MassUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Mass, which is Second. All conversions go via this value.
        /// </summary>
        public static MassUnit BaseUnit { get; } = MassUnit.Kilogram;

        /// <summary>
        /// Represents the largest possible value of Mass.
        /// </summary>
        public static Mass MaxValue { get; } = new Mass(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Mass.
        /// </summary>
        public static Mass MinValue { get; } = new Mass(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static Mass Zero { get; } = new Mass(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Centigram"/>
        /// </summary>
        public double Centigrams => As(MassUnit.Centigram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Decagram"/>
        /// </summary>
        public double Decagrams => As(MassUnit.Decagram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Decigram"/>
        /// </summary>
        public double Decigrams => As(MassUnit.Decigram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.EarthMass"/>
        /// </summary>
        public double EarthMasses => As(MassUnit.EarthMass);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Femtogram"/>
        /// </summary>
        public double Femtograms => As(MassUnit.Femtogram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Grain"/>
        /// </summary>
        public double Grains => As(MassUnit.Grain);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Gram"/>
        /// </summary>
        public double Grams => As(MassUnit.Gram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Hectogram"/>
        /// </summary>
        public double Hectograms => As(MassUnit.Hectogram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Kilogram"/>
        /// </summary>
        public double Kilograms => As(MassUnit.Kilogram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Kilopound"/>
        /// </summary>
        public double Kilopounds => As(MassUnit.Kilopound);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Kilotonne"/>
        /// </summary>
        public double Kilotonnes => As(MassUnit.Kilotonne);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.LongHundredweight"/>
        /// </summary>
        public double LongHundredweight => As(MassUnit.LongHundredweight);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.LongTon"/>
        /// </summary>
        public double LongTons => As(MassUnit.LongTon);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Megapound"/>
        /// </summary>
        public double Megapounds => As(MassUnit.Megapound);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Megatonne"/>
        /// </summary>
        public double Megatonnes => As(MassUnit.Megatonne);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Microgram"/>
        /// </summary>
        public double Micrograms => As(MassUnit.Microgram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Milligram"/>
        /// </summary>
        public double Milligrams => As(MassUnit.Milligram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Nanogram"/>
        /// </summary>
        public double Nanograms => As(MassUnit.Nanogram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Ounce"/>
        /// </summary>
        public double Ounces => As(MassUnit.Ounce);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Picogram"/>
        /// </summary>
        public double Picograms => As(MassUnit.Picogram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Pound"/>
        /// </summary>
        public double Pounds => As(MassUnit.Pound);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.ShortHundredweight"/>
        /// </summary>
        public double ShortHundredweight => As(MassUnit.ShortHundredweight);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.ShortTon"/>
        /// </summary>
        public double ShortTons => As(MassUnit.ShortTon);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Slug"/>
        /// </summary>
        public double Slugs => As(MassUnit.Slug);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.SolarMass"/>
        /// </summary>
        public double SolarMasses => As(MassUnit.SolarMass);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Stone"/>
        /// </summary>
        public double Stone => As(MassUnit.Stone);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="MassUnit.Tonne"/>
        /// </summary>
        public double Tonnes => As(MassUnit.Tonne);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Centigram"/>.
        /// </summary>
        public static Mass FromCentigrams(double centigrams) => new Mass(centigrams, MassUnit.Centigram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Decagram"/>.
        /// </summary>
        public static Mass FromDecagrams(double decagrams) => new Mass(decagrams, MassUnit.Decagram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Decigram"/>.
        /// </summary>
        public static Mass FromDecigrams(double decigrams) => new Mass(decigrams, MassUnit.Decigram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.EarthMass"/>.
        /// </summary>
        public static Mass FromEarthMasses(double earthmasses) => new Mass(earthmasses, MassUnit.EarthMass);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Femtogram"/>.
        /// </summary>
        public static Mass FromFemtograms(double femtograms) => new Mass(femtograms, MassUnit.Femtogram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Grain"/>.
        /// </summary>
        public static Mass FromGrains(double grains) => new Mass(grains, MassUnit.Grain);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Gram"/>.
        /// </summary>
        public static Mass FromGrams(double grams) => new Mass(grams, MassUnit.Gram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Hectogram"/>.
        /// </summary>
        public static Mass FromHectograms(double hectograms) => new Mass(hectograms, MassUnit.Hectogram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Kilogram"/>.
        /// </summary>
        public static Mass FromKilograms(double kilograms) => new Mass(kilograms, MassUnit.Kilogram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Kilopound"/>.
        /// </summary>
        public static Mass FromKilopounds(double kilopounds) => new Mass(kilopounds, MassUnit.Kilopound);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Kilotonne"/>.
        /// </summary>
        public static Mass FromKilotonnes(double kilotonnes) => new Mass(kilotonnes, MassUnit.Kilotonne);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.LongHundredweight"/>.
        /// </summary>
        public static Mass FromLongHundredweight(double longhundredweight) => new Mass(longhundredweight, MassUnit.LongHundredweight);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.LongTon"/>.
        /// </summary>
        public static Mass FromLongTons(double longtons) => new Mass(longtons, MassUnit.LongTon);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Megapound"/>.
        /// </summary>
        public static Mass FromMegapounds(double megapounds) => new Mass(megapounds, MassUnit.Megapound);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Megatonne"/>.
        /// </summary>
        public static Mass FromMegatonnes(double megatonnes) => new Mass(megatonnes, MassUnit.Megatonne);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Microgram"/>.
        /// </summary>
        public static Mass FromMicrograms(double micrograms) => new Mass(micrograms, MassUnit.Microgram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Milligram"/>.
        /// </summary>
        public static Mass FromMilligrams(double milligrams) => new Mass(milligrams, MassUnit.Milligram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Nanogram"/>.
        /// </summary>
        public static Mass FromNanograms(double nanograms) => new Mass(nanograms, MassUnit.Nanogram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Ounce"/>.
        /// </summary>
        public static Mass FromOunces(double ounces) => new Mass(ounces, MassUnit.Ounce);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Picogram"/>.
        /// </summary>
        public static Mass FromPicograms(double picograms) => new Mass(picograms, MassUnit.Picogram);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Pound"/>.
        /// </summary>
        public static Mass FromPounds(double pounds) => new Mass(pounds, MassUnit.Pound);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.ShortHundredweight"/>.
        /// </summary>
        public static Mass FromShortHundredweight(double shorthundredweight) => new Mass(shorthundredweight, MassUnit.ShortHundredweight);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.ShortTon"/>.
        /// </summary>
        public static Mass FromShortTons(double shorttons) => new Mass(shorttons, MassUnit.ShortTon);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Slug"/>.
        /// </summary>
        public static Mass FromSlugs(double slugs) => new Mass(slugs, MassUnit.Slug);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.SolarMass"/>.
        /// </summary>
        public static Mass FromSolarMasses(double solarmasses) => new Mass(solarmasses, MassUnit.SolarMass);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Stone"/>.
        /// </summary>
        public static Mass FromStone(double stone) => new Mass(stone, MassUnit.Stone);

        /// <summary>
        ///     Creates a <see cref="Mass"/> from <see cref="MassUnit.Tonne"/>.
        /// </summary>
        public static Mass FromTonnes(double tonnes) => new Mass(tonnes, MassUnit.Tonne);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="MassUnit" /> to <see cref="Mass" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Mass unit value.</returns>
        public static Mass From(double value, MassUnit fromUnit)
        {
            return new Mass(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(MassUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this Mass to another Mass with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A Mass with the specified unit.</returns>
                public Mass ToUnit(MassUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new Mass(convertedValue, unit);
                }

                /// <summary>
                ///     Converts the current value + unit to the base unit.
                ///     This is typically the first step in converting from one unit to another.
                /// </summary>
                /// <returns>The value in the base unit representation.</returns>
                private double GetValueInBaseUnit()
                {
                    return Unit switch
                    {
                        MassUnit.Centigram => (_value / 1e3) * 1e-2d,
                        MassUnit.Decagram => (_value / 1e3) * 1e1d,
                        MassUnit.Decigram => (_value / 1e3) * 1e-1d,
                        MassUnit.EarthMass => _value * 5.9722E+24,
                        MassUnit.Femtogram => (_value / 1e3) * 1e-15d,
                        MassUnit.Grain => _value * 64.79891e-6,
                        MassUnit.Gram => _value / 1e3,
                        MassUnit.Hectogram => (_value / 1e3) * 1e2d,
                        MassUnit.Kilogram => (_value / 1e3) * 1e3d,
                        MassUnit.Kilopound => (_value * 0.45359237) * 1e3d,
                        MassUnit.Kilotonne => (_value * 1e3) * 1e3d,
                        MassUnit.LongHundredweight => _value * 50.80234544,
                        MassUnit.LongTon => _value * 1016.0469088,
                        MassUnit.Megapound => (_value * 0.45359237) * 1e6d,
                        MassUnit.Megatonne => (_value * 1e3) * 1e6d,
                        MassUnit.Microgram => (_value / 1e3) * 1e-6d,
                        MassUnit.Milligram => (_value / 1e3) * 1e-3d,
                        MassUnit.Nanogram => (_value / 1e3) * 1e-9d,
                        MassUnit.Ounce => _value * 0.028349523125,
                        MassUnit.Picogram => (_value / 1e3) * 1e-12d,
                        MassUnit.Pound => _value * 0.45359237,
                        MassUnit.ShortHundredweight => _value * 45.359237,
                        MassUnit.ShortTon => _value * 907.18474,
                        MassUnit.Slug => _value * 0.45359237 * 9.80665 / 0.3048,
                        MassUnit.SolarMass => _value * 1.98947e30,
                        MassUnit.Stone => _value * 6.35029318,
                        MassUnit.Tonne => _value * 1e3,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(MassUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        MassUnit.Centigram => (baseUnitValue * 1e3) / 1e-2d,
                        MassUnit.Decagram => (baseUnitValue * 1e3) / 1e1d,
                        MassUnit.Decigram => (baseUnitValue * 1e3) / 1e-1d,
                        MassUnit.EarthMass => baseUnitValue / 5.9722E+24,
                        MassUnit.Femtogram => (baseUnitValue * 1e3) / 1e-15d,
                        MassUnit.Grain => baseUnitValue / 64.79891e-6,
                        MassUnit.Gram => baseUnitValue * 1e3,
                        MassUnit.Hectogram => (baseUnitValue * 1e3) / 1e2d,
                        MassUnit.Kilogram => (baseUnitValue * 1e3) / 1e3d,
                        MassUnit.Kilopound => (baseUnitValue / 0.45359237) / 1e3d,
                        MassUnit.Kilotonne => (baseUnitValue / 1e3) / 1e3d,
                        MassUnit.LongHundredweight => baseUnitValue / 50.80234544,
                        MassUnit.LongTon => baseUnitValue / 1016.0469088,
                        MassUnit.Megapound => (baseUnitValue / 0.45359237) / 1e6d,
                        MassUnit.Megatonne => (baseUnitValue / 1e3) / 1e6d,
                        MassUnit.Microgram => (baseUnitValue * 1e3) / 1e-6d,
                        MassUnit.Milligram => (baseUnitValue * 1e3) / 1e-3d,
                        MassUnit.Nanogram => (baseUnitValue * 1e3) / 1e-9d,
                        MassUnit.Ounce => baseUnitValue / 0.028349523125,
                        MassUnit.Picogram => (baseUnitValue * 1e3) / 1e-12d,
                        MassUnit.Pound => baseUnitValue / 0.45359237,
                        MassUnit.ShortHundredweight => baseUnitValue / 45.359237,
                        MassUnit.ShortTon => baseUnitValue / 907.18474,
                        MassUnit.Slug => baseUnitValue * 0.3048 / (0.45359237 * 9.80665),
                        MassUnit.SolarMass => baseUnitValue / 1.98947e30,
                        MassUnit.Stone => baseUnitValue / 6.35029318,
                        MassUnit.Tonne => baseUnitValue / 1e3,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

