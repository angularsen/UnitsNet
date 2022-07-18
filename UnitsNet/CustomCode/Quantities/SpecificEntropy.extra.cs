// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct SpecificEntropy
    {
        /// <summary>Get <see cref="Entropy"/> from <see cref="SpecificEntropy"/> times <see cref="Mass"/>.</summary>
        public static Entropy operator *(SpecificEntropy specificEntropy, Mass mass)
        {
            return Entropy.FromJoulesPerKelvin(specificEntropy.JoulesPerKilogramKelvin * mass.Kilograms);
        }

        /// <summary>Get <see cref="Entropy"/> from <see cref="Mass"/> times <see cref="SpecificEntropy"/>.</summary>
        public static Entropy operator *(Mass mass, SpecificEntropy specificEntropy)
        {
            return Entropy.FromJoulesPerKelvin(specificEntropy.JoulesPerKilogramKelvin * mass.Kilograms);
        }
    }
}
