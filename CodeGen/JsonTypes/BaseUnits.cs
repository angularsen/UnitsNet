// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Text;

namespace CodeGen.JsonTypes
{
    internal class BaseUnits
    {
        // 0649 Field is never assigned to
#pragma warning disable 0649

        /// <summary>AmountOfSubstance.</summary>
        public string? N;
        /// <summary>ElectricCurrent.</summary>
        public string? I;
        /// <summary>Length.</summary>
        public string? L;
        /// <summary>LuminousIntensity.</summary>
        public string? J;
        /// <summary>Mass.</summary>
        public string? M;
        /// <summary>Temperature.</summary>
        public string? Θ;
        /// <summary>Time.</summary>
        public string? T;

        // 0649 Field is never assigned to
#pragma warning restore 0649

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (N is { } n) sb.Append($"N={n}, ");
            if (I is { } i) sb.Append($"I={i}, ");
            if (L is { } l) sb.Append($"L={l}, ");
            if (J is { } j) sb.Append($"J={j}, ");
            if (M is { } m) sb.Append($"M={m}, ");
            if (Θ is { } θ) sb.Append($"Θ={θ}, ");
            if (T is { } t) sb.Append($"T={t}, ");

            return sb.ToString().TrimEnd(' ', ',');
        }

        public BaseUnits Clone()
        {
            return new BaseUnits
            {
                N = N,
                I = I,
                L = L,
                J = J,
                M = M,
                Θ = Θ,
                T = T
            };
        }
    }
}
