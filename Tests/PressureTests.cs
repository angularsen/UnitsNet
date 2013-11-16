// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class PressureTests : PressureTestsBase
    {
        protected override double AtmospheresInOnePascal
        {
            get { return 9.8692*1E-6; }
        }

        protected override double BarsInOnePascal
        {
            get { return 1E-5; }
        }

        protected override double KilogramForcePerSquareCentimeterInOnePascal
        {
            get { return 1/98066.5; }
        }

        protected override double KilopascalsInOnePascal
        {
            get { return 1E-3; }
        }

        protected override double MegapascalsInOnePascal
        {
            get { return 1E-6; }
        }

        protected override double NewtonsPerSquareCentimeterInOnePascal
        {
            get { return 1E-4; }
        }

        protected override double NewtonsPerSquareMeterInOnePascal
        {
            get { return 1; }
        }

        protected override double NewtonsPerSquareMillimeterInOnePascal
        {
            get { return 1E-6; }
        }

        protected override double PascalsInOnePascal
        {
            get { return 1; }
        }

        protected override double PsiInOnePascal
        {
            get { return 1.450377*1E-4; }
        }

        protected override double TechnicalAtmospheresInOnePascal
        {
            get { return 1.0197*1E-5; }
        }

        protected override double TorrsInOnePascal
        {
            get { return 7.5006*1E-3; }
        }
    }
}