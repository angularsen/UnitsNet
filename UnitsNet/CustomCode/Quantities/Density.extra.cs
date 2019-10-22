// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Density<T>
    {
        /// <summary>
        ///     Gets <see cref="Molarity{T}" /> from this <see cref="Density{T}" />.
        /// </summary>
        /// <param name="molecularWeight"></param>
        /// <seealso cref="MassConcentration{T}.ToMolarity(MolarMass{T})"/>
        [Obsolete("This method is deprecated in favor of MassConcentration.ToMolarity(MolarMass).")]
        public Molarity<T> ToMolarity(Mass<T> molecularWeight )
        {
            return Molarity<T>.FromMolesPerCubicMeter(KilogramsPerCubicMeter / molecularWeight.Kilograms);
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="Density{T}" /> from <see cref="Molarity{T}" />.
        /// </summary>
        /// <seealso cref="MassConcentration{T}.FromMolarity(Molarity{T}, MolarMass{T})"/>
        [Obsolete("This method is deprecated in favor of MassConcentration.FromMolarity(Molarity, MolarMass).")]
        public static Density<T> FromMolarity(Molarity<T> molarity, Mass<T> molecularWeight )
        {
            return new Density<T>( molarity.MolesPerCubicMeter * molecularWeight.Kilograms, DensityUnit.KilogramPerCubicMeter);
        }

        #endregion

        /// <summary>Get <see cref="Mass{T}"/> from <see cref="Density{T}"/> times <see cref="Volume{T}"/>.</summary>
        public static Mass<T> operator *(Density<T> density, Volume<T> volume )
        {
            return Mass<T>.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        /// <summary>Get <see cref="Mass{T}"/> from <see cref="Volume{T}"/> times <see cref="Density{T}"/>.</summary>
        public static Mass<T> operator *(Volume<T> volume, Density<T> density )
        {
            return Mass<T>.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        /// <summary>Get <see cref="DynamicViscosity{T}"/> from <see cref="Density{T}"/> times <see cref="KinematicViscosity{T}"/>.</summary>
        public static DynamicViscosity<T> operator *(Density<T> density, KinematicViscosity<T> kinematicViscosity )
        {
            return DynamicViscosity<T>.FromNewtonSecondsPerMeterSquared(kinematicViscosity.SquareMetersPerSecond * density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="MassFlux{T}"/> <see cref="Density{T}"/> times <see cref="Speed{T}"/>.</summary>
        public static MassFlux<T> operator *(Density<T> density, Speed<T> speed )
        {
            return MassFlux<T>.FromKilogramsPerSecondPerSquareMeter(density.KilogramsPerCubicMeter * speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="SpecificWeight{T}"/> from <see cref="Density{T}"/> times <see cref="Acceleration{T}"/>.</summary>
        public static SpecificWeight<T> operator *(Density<T> density, Acceleration<T> acceleration )
        {
            return new SpecificWeight<T>( density.KilogramsPerCubicMeter * acceleration.MetersPerSecondSquared, SpecificWeightUnit.NewtonPerCubicMeter);
        }

        /// <summary>Get <see cref="Molarity{T}"/> from <see cref="Density{T}"/> divided by <see cref="Mass{T}"/>.</summary>
        /// <seealso cref="MassConcentration{T}.op_Division(MassConcentration{T}, MolarMass{T})"/>
        [Obsolete("This operator is deprecated in favor of MassConcentration.op_Division(MassConcentration, MolarMass).")]
        public static Molarity<T> operator /(Density<T> density, Mass<T> molecularWeight )
        {
            return new Molarity<T>( density.KilogramsPerCubicMeter / molecularWeight.Kilograms, MolarityUnit.MolesPerCubicMeter);
        }
    }
}
