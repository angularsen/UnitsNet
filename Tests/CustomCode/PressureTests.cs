// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35.UnitClassTests
{
    [TestFixture]
    public class PressureTests : PressureTestsBase
    {
        public override double AtmospheresInOnePascal
        {
            get { return 9.8692*1E-6; }
        }

        public override double BarsInOnePascal
        {
            get { return 1E-5; }
        }

        public override double KilogramForcePerSquareCentimeterInOnePascal
        {
            get { return 1/98066.5; }
        }

        public override double KilopascalsInOnePascal
        {
            get { return 1E-3; }
        }

        public override double MegapascalsInOnePascal
        {
            get { return 1E-6; }
        }

        public override double NewtonsPerSquareCentimeterInOnePascal
        {
            get { return 1E-4; }
        }

        public override double NewtonsPerSquareMeterInOnePascal
        {
            get { return 1; }
        }

        public override double NewtonsPerSquareMillimeterInOnePascal
        {
            get { return 1E-6; }
        }

        public override double PascalsInOnePascal
        {
            get { return 1; }
        }

        public override double PsiInOnePascal
        {
            get { return 1.450377*1E-4; }
        }

        public override double TechnicalAtmospheresInOnePascal
        {
            get { return 1.0197*1E-5; }
        }

        public override double TorrsInOnePascal
        {
            get { return 7.5006*1E-3; }
        }
    }
}