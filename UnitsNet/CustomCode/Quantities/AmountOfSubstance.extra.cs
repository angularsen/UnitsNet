// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

// ReSharper disable once CheckNamespace

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct AmountOfSubstance<T>
    {
        /// <summary>
        ///     The Avogadro constant is the number of constituent particles, usually molecules, 
        ///     atoms or ions that are contained in the amount of substance given by one mole. It is the proportionality factor that relates 
        ///     the molar mass of a substance to the mass of a sample, is designated with the symbol NA or L[1], and has the value 
        ///     6.02214076e23 mol−1 in the International System of Units (SI).
        /// </summary>
        /// <remarks>
        ///     Pending revisions in the base set of SI units necessitated redefinitions of the concepts of chemical quantity. The Avogadro number,
        ///     and its definition, was deprecated in favor of the Avogadro constant and its definition. Based on measurements made through the
        ///     middle of 2017 which calculated a value for the Avogadro constant of NA = 6.022140758(62)×1023 mol−1, the redefinition of SI units
        ///     is planned to take effect on 20 May 2019. The value of the constant will be fixed to exactly 6.02214076×1023 mol−1.
        ///     See here: https://www.bipm.org/utils/common/pdf/CGPM-2018/26th-CGPM-Resolutions.pdf
        /// </remarks>
        public static double AvogadroConstant { get; } = 6.02214076e23;

        /// <summary>
        /// Calculates the number of particles (atoms or molecules) in this amount of substance using the <see cref="AvogadroConstant"/>.
        /// </summary>
        /// <returns>The number of particles (atoms or molecules) in this amount of substance.</returns>
        public double NumberOfParticles()
        {
            var moles = GetValueAs(AmountOfSubstanceUnit.Mole);
            return AvogadroConstant * moles;
        }


        /// <summary>Get <see cref="AmountOfSubstance{T}" /> from <see cref="Mass{T}" /> and a given <see cref="MolarMass{T}" />.</summary>
        public static AmountOfSubstance<T> FromMass(Mass<T> mass, MolarMass<T> molarMass )
        {
            return mass / molarMass;
        }

        /// <summary>Get <see cref="Mass{T}" /> from <see cref="AmountOfSubstance{T}" /> for a given <see cref="MolarMass{T}" />.</summary>
        public static Mass<T> operator *(AmountOfSubstance<T> amountOfSubstance, MolarMass<T> molarMass )
        {
            return Mass<T>.FromGrams(amountOfSubstance.Moles * molarMass.GramsPerMole);
        }

        /// <summary>Get <see cref="Mass{T}" /> from <see cref="AmountOfSubstance{T}" /> for a given <see cref="MolarMass{T}" />.</summary>
        public static Mass<T> operator *(MolarMass<T> molarMass, AmountOfSubstance<T> amountOfSubstance )
        {
            return Mass<T>.FromGrams(amountOfSubstance.Moles * molarMass.GramsPerMole);
        }

        /// <summary>Get <see cref="Molarity{T}" /> from <see cref="AmountOfSubstance{T}" /> divided by <see cref="Volume{T}" />.</summary>
        public static Molarity<T> operator /(AmountOfSubstance<T> amountOfComponent, Volume<T> mixtureVolume )
        {
            return Molarity<T>.FromMolesPerCubicMeter(amountOfComponent.Moles / mixtureVolume.CubicMeters);
        }

        /// <summary>Get <see cref="Volume{T}" /> from <see cref="AmountOfSubstance{T}" /> divided by <see cref="Molarity{T}" />.</summary>
        public static Volume<T> operator /(AmountOfSubstance<T> amountOfSubstance, Molarity<T> molarity )
        {
            return Volume<T>.FromCubicMeters(amountOfSubstance.Moles / molarity.MolesPerCubicMeter);
        }

    }
}
