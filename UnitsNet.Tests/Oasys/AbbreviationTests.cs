using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.Oasys
{
    public class AbbreviationTests
    {
        [Fact]
        public void GetAbbreviationFromToStringTest()
        {
            Moment moment = new Moment(1, MomentUnit.KilonewtonMeter);
            string unitAbbreviation = moment.ToString("a");
            Assert.Equal("kN·m", unitAbbreviation);
        }

        [Fact]
        public void OasysUnitsHaveAbbreviationTest()
        {
            Assert.Equal("lbf", AxialStiffness.GetAbbreviation(AxialStiffnessUnit.PoundForce));
            Assert.Equal("lbf·ft²", BendingStiffness.GetAbbreviation(BendingStiffnessUnit.PoundForceSquareFoot));
            Assert.Equal("m⁻¹", Curvature.GetAbbreviation(CurvatureUnit.PerMeter));
            Assert.Equal("MN·m", Moment.GetAbbreviation(MomentUnit.MeganewtonMeter));
            Assert.Equal("m³", SectionModulus.GetAbbreviation(SectionModulusUnit.CubicMeter));
            Assert.Equal("µε", Strain.GetAbbreviation(StrainUnit.MicroStrain));
        }

        [Fact]
        public void GetAbbreviationReturnsStringInUSEnglishIfAbbreviationIsNotFoundTest()
        {
            Assert.Equal("lbf", AxialStiffness.GetAbbreviation(AxialStiffnessUnit.PoundForce, new CultureInfo("zh-CN")));
            Assert.Equal("lbf·ft²", BendingStiffness.GetAbbreviation(BendingStiffnessUnit.PoundForceSquareFoot, new CultureInfo("zh-CN")));
            Assert.Equal("m⁻¹", Curvature.GetAbbreviation(CurvatureUnit.PerMeter, new CultureInfo("zh-CN")));
            Assert.Equal("MN·m", Moment.GetAbbreviation(MomentUnit.MeganewtonMeter, new CultureInfo("zh-CN")));
            Assert.Equal("m³", SectionModulus.GetAbbreviation(SectionModulusUnit.CubicMeter, new CultureInfo("zh-CN")));
            Assert.Equal("µε", Strain.GetAbbreviation(StrainUnit.MicroStrain, new CultureInfo("zh-CN")));
        }

        [Fact]
        public void OasysUnitsParseAbbreviationTest()
        {
            Assert.Equal(AxialStiffnessUnit.PoundForce, AxialStiffness.ParseUnit("lbf"));
            Assert.Equal(BendingStiffnessUnit.PoundForceSquareFoot, BendingStiffness.ParseUnit("lbf·ft²"));
            Assert.Equal(CurvatureUnit.PerMeter, Curvature.ParseUnit("m⁻¹"));
            Assert.Equal(MomentUnit.MeganewtonMeter, Moment.ParseUnit("MN·m"));
            Assert.Equal(SectionModulusUnit.CubicMeter, SectionModulus.ParseUnit("m³"));
            Assert.Equal(StrainUnit.MicroStrain, Strain.ParseUnit("µε"));
        }

        [Fact]
        public void ParseMomentUnitFromAbbreviation()
        {
            string unitAbbreviation = Moment.GetAbbreviation(MomentUnit.KilonewtonMeter);
            MomentUnit momentUnit = Moment.ParseUnit(unitAbbreviation);
            Assert.Equal(MomentUnit.KilonewtonMeter, momentUnit);
        }
    }
}
