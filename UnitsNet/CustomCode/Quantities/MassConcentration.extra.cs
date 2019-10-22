// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct MassConcentration<T>
    {
        /// <summary>
        ///     Get <see cref="Molarity{T}" /> from this <see cref="MassConcentration{T}" /> using the known component <see cref="MolarMass{T}" />.
        /// </summary>
        /// <param name="molecularWeight"></param>
        public Molarity<T> ToMolarity(MolarMass<T> molecularWeight )
        {
            return this / molecularWeight;
        }

        /// <summary>
        ///  Get <see cref="VolumeConcentration{T}" /> from this <see cref="MassConcentration{T}" /> using the known component <see cref="Density{T}" />.
        /// </summary>
        /// <param name="componentDensity"></param>
        /// <returns></returns>
        public VolumeConcentration<T> ToVolumeConcentration(Density<T> componentDensity )
        {
            return this / componentDensity;
        }


        #region Static Methods

        /// <summary>
        ///     Get <see cref="MassConcentration{T}" /> from <see cref="Molarity{T}" />.
        /// </summary>
        public static MassConcentration<T> FromMolarity(Molarity<T> molarity, MolarMass<T> mass )
        {
            return molarity * mass;
        }

        /// <summary>
        ///     Get <see cref="MassConcentration{T}" /> from <see cref="VolumeConcentration{T}" /> and component <see cref="Density{T}" />.
        /// </summary>
        public static MassConcentration<T> FromVolumeConcentration(VolumeConcentration<T> volumeConcentration, Density<T> componentDensity )
        {
            return volumeConcentration * componentDensity;
        }

        #endregion

        #region Operators

        /// <summary>Get <see cref="Mass{T}" /> from <see cref="MassConcentration{T}" /> times <see cref="Volume{T}" />.</summary>
        public static Mass<T> operator *(MassConcentration<T> density, Volume<T> volume )
        {
            return Mass<T>.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        /// <summary>Get <see cref="Mass{T}" /> from <see cref="Volume{T}" /> times <see cref="MassConcentration{T}" />.</summary>
        public static Mass<T> operator *(Volume<T> volume, MassConcentration<T> density )
        {
            return Mass<T>.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        /// <summary>Get <see cref="Molarity{T}" /> from <see cref="MassConcentration{T}" /> divided by the component's <see cref="MolarMass{T}" />.</summary>
        public static Molarity<T> operator /(MassConcentration<T> massConcentration, MolarMass<T> componentMass )
        {
            return Molarity<T>.FromMolesPerCubicMeter(massConcentration.GramsPerCubicMeter / componentMass.GramsPerMole);
        }

        /// <summary>Get <see cref="VolumeConcentration{T}" /> from <see cref="MassConcentration{T}" /> divided by the component's <see cref="Density{T}" />.</summary>
        public static VolumeConcentration<T> operator /(MassConcentration<T> massConcentration, Density<T> componentDensity )
        {
            return VolumeConcentration<T>.FromDecimalFractions(massConcentration.KilogramsPerCubicMeter / componentDensity.KilogramsPerCubicMeter);
        }

        #endregion

    }
}
