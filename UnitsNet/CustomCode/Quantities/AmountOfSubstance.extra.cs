// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

// ReSharper disable once CheckNamespace

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct AmountOfSubstance
    {
        /// <summary>
        ///     The Avogadro constant is the number of constituent particles, usually molecules,
        ///     atoms or ions that are contained in the amount of substance given by one mole. It is the proportionality factor
        ///     that relates
        ///     the molar mass of a substance to the mass of a sample, is designated with the symbol NA or L[1], and has the value
        ///     6.02214076e23 mol−1 in the International System of Units (SI).
        /// </summary>
        /// <remarks>
        ///     The Avogadro constant NA is related to other physical constants and properties.
        ///     <para>
        ///         It relates the molar gas constant R and the Boltzmann constant kB, which in the SI is defined to be exactly
        ///         1.380649×10−23 J/K:[9]
        ///     </para>
        ///     <para>R = kB NA = 8.314462618... J⋅mol−1⋅K−1</para>
        ///     <para>
        ///         It relates the Faraday constant F and the elementary charge e, which in the SI is defined as exactly
        ///         1.602176634×10−19 coulombs:[9]
        ///     </para>
        ///     <para>F = e NA = 9.648533212...×104 C⋅mol−1</para>
        ///     <para>
        ///         It relates the molar mass constant Mu and the atomic mass constant mu currently 1.66053906660(50)×10−27
        ///         kg:[25]
        ///     </para>
        ///     <para>Mu = mu NA = 0.99999999965(30)×10−3 kg⋅mol−1</para>
        /// </remarks>
        public static QuantityValue AvogadroConstant { get; } = 6.02214076e23m;

        /// <summary>
        /// Calculates the number of particles (atoms or molecules) in this amount of substance using the <see cref="AvogadroConstant"/>.
        /// </summary>
        /// <returns>The number of particles (atoms or molecules) in this amount of substance.</returns>
        public QuantityValue NumberOfParticles()
        {
            return AvogadroConstant * As(AmountOfSubstanceUnit.Mole);
        }

        /// <summary>Get <see cref="AmountOfSubstance" /> from <see cref="Mass" /> and a given <see cref="MolarMass" />.</summary>
        public static AmountOfSubstance FromMass(Mass mass, MolarMass molarMass)
        {
            return mass / molarMass;
        }
    }
}
