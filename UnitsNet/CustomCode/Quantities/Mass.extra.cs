// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Threading;
using System.Globalization;
using JetBrains.Annotations;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Mass
    {
        /// <summary>Get <see cref="Mass"/> from <see cref="Force"/> of gravity.</summary>
        public static Mass FromGravitationalForce(Force f)
        {
            return new Mass(f.KilogramsForce, MassUnit.Kilogram);
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
        public static Mass FromStonePounds(double stone, double pounds)
        {
            return FromPounds(StonesInOnePound*stone + pounds);
        }

        /// <summary>Get <see cref="MassFlow"/> from <see cref="Mass"/> divided by <see cref="TimeSpan"/>.</summary>
        public static MassFlow operator /(Mass mass, TimeSpan timeSpan)
        {
            return MassFlow.FromKilogramsPerSecond(mass.Kilograms/timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="MassFlow"/> from <see cref="Mass"/> divided by <see cref="Duration"/>.</summary>
        public static MassFlow operator /(Mass mass, Duration duration)
        {
            return MassFlow.FromKilogramsPerSecond(mass.Kilograms/duration.Seconds);
        }

        /// <summary>Get <see cref="Density"/> from <see cref="MassFlow"/> divided by <see cref="Volume"/>.</summary>
        public static Density operator /(Mass mass, Volume volume)
        {
            return Density.FromKilogramsPerCubicMeter(mass.Kilograms/volume.CubicMeters);
        }

        /// <summary>Get <see cref="Volume"/> from <see cref="Mass"/> divided by <see cref="Density"/>.</summary>
        public static Volume operator /(Mass mass, Density density)
        {
            return Volume.FromCubicMeters(mass.Kilograms / density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="AmountOfSubstance" /> from <see cref="MolarMass" /> divided by <see cref="Mass" />.</summary>
        public static AmountOfSubstance operator /(Mass mass, MolarMass molarMass)
        {
            return AmountOfSubstance.FromMoles(mass.Kilograms / molarMass.KilogramsPerMole);
        }

        /// <summary>Get <see cref="Force"/> from <see cref="Mass"/> times <see cref="Acceleration"/>.</summary>
        public static Force operator *(Mass mass, Acceleration acceleration)
        {
            return Force.FromNewtons(mass.Kilograms*acceleration.MetersPerSecondSquared);
        }

        /// <summary>Get <see cref="Force"/> from <see cref="Acceleration"/> times <see cref="Mass"/>.</summary>
        public static Force operator *(Acceleration acceleration, Mass mass)
        {
            return Force.FromNewtons(mass.Kilograms*acceleration.MetersPerSecondSquared);
        }
    }

    /// <summary>
    ///     Representation of stone and pounds, used to preserve the original values when constructing <see cref="Mass"/> by
    ///     <see cref="Mass.FromStonePounds"/> and later output them unaltered with <see cref="ToString()"/>.
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
