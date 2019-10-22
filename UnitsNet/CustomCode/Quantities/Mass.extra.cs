// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Threading;
using System.Globalization;
using JetBrains.Annotations;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Mass<T>
    {
        /// <summary>Get <see cref="Mass{T}"/> from <see cref="Force{T}"/> of gravity.</summary>
        public static Mass<T> FromGravitationalForce(Force<T> f )
        {
            return new Mass<T>( f.KilogramsForce, MassUnit.Kilogram);
        }

        /// <summary>
        ///     StonePounds related code makes it easier to work with Stone/Pound combination, which are customarily used in the UK
        ///     to express body weight. For example, someone weighs 11 stone 4 pounds (about 72 kilograms).
        /// </summary>
        private const double StonesInOnePound = 14.0;

        /// <summary>
        ///     Converts the mass to a customary stone/pounds combination.
        /// </summary>
        public StonePounds StonePounds
        {
            get
            {
                var inPounds = Pounds;

                var stones = Math.Truncate(inPounds / StonesInOnePound);
                var pounds = inPounds % StonesInOnePound;

                return new StonePounds(stones, pounds);
            }
        }

        /// <summary>
        ///     Get Mass from combination of stone and pounds.
        /// </summary>
        public static Mass<T> FromStonePounds(double stone, double pounds)
        {
            return FromPounds(StonesInOnePound*stone + pounds);
        }

        /// <summary>Get <see cref="MassFlow{T}"/> from <see cref="Mass{T}"/> divided by <see cref="TimeSpan"/>.</summary>
        public static MassFlow<T> operator /(Mass<T> mass, TimeSpan timeSpan)
        {
            return MassFlow<T>.FromKilogramsPerSecond(mass.Kilograms/timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="MassFlow{T}"/> from <see cref="Mass{T}"/> divided by <see cref="Duration{T}"/>.</summary>
        public static MassFlow<T> operator /(Mass<T> mass, Duration<T> duration )
        {
            return MassFlow<T>.FromKilogramsPerSecond(mass.Kilograms/duration.Seconds);
        }

        /// <summary>Get <see cref="Density{T}"/> from <see cref="MassFlow{T}"/> divided by <see cref="Volume{T}"/>.</summary>
        public static Density<T> operator /(Mass<T> mass, Volume<T> volume )
        {
            return Density<T>.FromKilogramsPerCubicMeter(mass.Kilograms/volume.CubicMeters);
        }

        /// <summary>Get <see cref="Volume{T}"/> from <see cref="Mass{T}"/> divided by <see cref="Density{T}"/>.</summary>
        public static Volume<T> operator /(Mass<T> mass, Density<T> density )
        {
            return Volume<T>.FromCubicMeters(mass.Kilograms / density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="AmountOfSubstance{T}" /> from <see cref="MolarMass{T}" /> divided by <see cref="Mass{T}" />.</summary>
        public static AmountOfSubstance<T> operator /(Mass<T> mass, MolarMass<T> molarMass )
        {
            return AmountOfSubstance<T>.FromMoles(mass.Kilograms / molarMass.KilogramsPerMole);
        }

        /// <summary>Get <see cref="Force{T}"/> from <see cref="Mass{T}"/> times <see cref="Acceleration{T}"/>.</summary>
        public static Force<T> operator *(Mass<T> mass, Acceleration<T> acceleration )
        {
            return Force<T>.FromNewtons(mass.Kilograms*acceleration.MetersPerSecondSquared);
        }

        /// <summary>Get <see cref="Force{T}"/> from <see cref="Acceleration{T}"/> times <see cref="Mass{T}"/>.</summary>
        public static Force<T> operator *(Acceleration<T> acceleration, Mass<T> mass )
        {
            return Force<T>.FromNewtons(mass.Kilograms*acceleration.MetersPerSecondSquared);
        }
    }

    /// <summary>
    ///     Representation of stone and pounds, used to preserve the original values when constructing <see cref="Mass{T}"/> by
    ///     <see cref="Mass{T}.FromStonePounds"/> and later output them unaltered with <see cref="ToString()"/>.
    /// </summary>
    public sealed class StonePounds
    {
        /// <summary>
        ///     Construct from stone and pounds.
        /// </summary>
        public StonePounds(double stone, double pounds)
        {
            Stone = stone;
            Pounds = pounds;
        }

        /// <summary>
        ///     The stone value it was created with.
        /// </summary>
        public double Stone { get; }

        /// <summary>
        ///     The pounds value it was created with.
        /// </summary>
        public double Pounds { get; }

        /// <inheritdoc cref="ToString(IFormatProvider)"/>
        public override string ToString()
        {
            return ToString(null);
        }

        /// <summary>
        ///     Outputs stone and pounds on the format: {stoneValue} {stoneUnit} {poundsValue} {poundsUnit}
        /// </summary>
        /// <example>Mass.FromStonePounds(3,2).StonePounds.ToString() outputs: "3 st 2 lb"</example>
        /// <param name="cultureInfo">
        ///     Optional culture to format number and localize unit abbreviations.
        ///     If null, defaults to <see cref="Thread.CurrentUICulture"/>.
        /// </param>
        public string ToString([CanBeNull] IFormatProvider cultureInfo)
        {
            cultureInfo = cultureInfo ?? CultureInfo.CurrentUICulture;

            var stoneUnit = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(MassUnit.Stone, cultureInfo);
            var poundUnit = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(MassUnit.Pound, cultureInfo);

            // Note that it isn't customary to use fractions - one wouldn't say "I am 11 stone and 4.5 pounds".
            // So pounds are rounded here.
            return string.Format(cultureInfo, "{0:n0} {1} {2:n0} {3}", Stone, stoneUnit, Math.Round(Pounds), poundUnit);
        }
    }
}
