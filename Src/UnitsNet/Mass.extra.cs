using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet
{
    /// <summary>
    /// Extension to the generated Mass struct.
    /// Makes it easier to work with Stone/Pound combination, which are customarily used in the UK
    /// to express body weight. For example, someone weighs 11 stone 4 pounds (about 72 kilograms).
    /// </summary>
    public partial struct Mass
    {
        private const double StoneToPounds = 14;

        public class StonePoundsCombo
        {
            public double Stone { get; private set; }
            public double Pounds { get; private set; }

            public StonePoundsCombo(double stone, double pounds)
            {
                Stone = stone;
                Pounds = pounds;
            }

            public override string ToString()
            {
                // Stone/pounds combos are only used in the UK. So should be safe to use English text
                // here.
                /// 
                // Note that it isn't customary to use fractions - one wouldn't say "I am 11 stone and 4.5 pounds".
                // So pounds are rounded here.
                return string.Format("{0} st {1} lb", Stone, Math.Round(Pounds));
            }
        }

        /// <summary>
        /// Converts the mass to a customary stone/pounds combination.
        /// </summary>
        public StonePoundsCombo StonePounds
        {
            get {
                double totalPounds = Pounds;
                double wholeStone = Math.Floor(totalPounds / StoneToPounds);
                double pounds = totalPounds % StoneToPounds;

                return new StonePoundsCombo(wholeStone, pounds); 
            }
        }

        /// <summary>
        ///     Get Mass from combination of stone and pounds.
        /// </summary>
        public static Mass FromStonePounds(double stone, double pounds)
        {
            return FromPounds((StoneToPounds * stone) + pounds);
        }
    }
}
