// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text;

namespace CodeGen.JsonTypes
{
    internal class BaseDimensions
    {
        // 0649 Field is never assigned to
#pragma warning disable 0649

        /// <summary>AmountOfSubstance.</summary>
        public int N = 0;
        /// <summary>ElectricCurrent.</summary>
        public int I = 0;
        /// <summary>Length.</summary>
        public int L = 0;
        /// <summary>LuminousIntensity.</summary>
        public int J = 0;
        /// <summary>Mass.</summary>
        public int M = 0;
        /// <summary>Temperature.</summary>
        public int Θ = 0;
        /// <summary>Time.</summary>
        public int T = 0;

        // 0649 Field is never assigned to
#pragma warning restore 0649
        
        
        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();
            
            // There are many possible choices of base physical dimensions. The SI standard selects the following dimensions and corresponding dimension symbols:
            // time (T), length (L), mass (M), electric current (I), absolute temperature (Θ), amount of substance (N) and luminous intensity (J).
            AppendDimensionString(sb, "T", T);
            AppendDimensionString(sb, "L", L);
            AppendDimensionString(sb, "M", M);
            AppendDimensionString(sb, "I", I);
            AppendDimensionString(sb, "Θ", Θ);
            AppendDimensionString(sb, "N", N);
            AppendDimensionString(sb, "J", J);

            return sb.ToString();
        }

        private static void AppendDimensionString(StringBuilder sb, string name, int value)
        {
            switch (value)
            {
                case 0:
                    return;
                case 1:
                    sb.AppendFormat("[{0}]", name);
                    break;
                default:
                    sb.AppendFormat("[{0}^{1}]", name, value);
                    break;
            }
        }
    }
}
