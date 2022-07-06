// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Entropy
    {
        /// <summary>Get <see cref="SpecificEntropy"/> from <see cref="Entropy"/> divided by <see cref="Mass"/>.</summary>
        public static SpecificEntropy operator /(Entropy entropy, Mass mass)
        {
            return SpecificEntropy.FromJoulesPerKilogramKelvin(entropy.JoulesPerKelvin / mass.Kilograms);
        }
    }
}
