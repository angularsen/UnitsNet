// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.UnitSystems;

namespace UnitsNet
{
    public partial class UnitSystem
    {
        /// <summary>
        ///     Gets the SI unit system.
        /// </summary>
        public static SI SI { get; } = new SI();


        /// <summary>
        ///     Gets the British Imperial unit system.
        /// </summary>
        public static BI BI { get; } = new BI();


        /// <summary>
        ///     Gets the English Engineering unit system.
        /// </summary>
        public static EE EE { get; } = new EE();


        /// <summary>
        ///     Gets the United States Customary unit system.
        /// </summary>
        public static USC USC { get; } = new USC();


        /// <summary>
        ///     Gets the Centimeter–Gram–Second unit system.
        /// </summary>
        public static CGS CGS { get; } = new CGS();


        /// <summary>
        ///     Gets the Foot–Pound–Second unit system.
        /// </summary>
        public static FPS FPS { get; } = new FPS();


        /// <summary>
        ///     Gets the unit system of typical astronomical units
        /// </summary>
        public static Astronomical Astronomical { get; } = new Astronomical();

    }
}
