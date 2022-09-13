using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.Oasys
{
    public class UtilityTests
    {
        [Fact]
        public void OasysUnitsHaveAbbreviation()
        {
            Assert.Equal("lbf", AxialStiffness.GetAbbreviation(AxialStiffnessUnit.PoundForce));
            Assert.Equal("lbf·ft²", BendingStiffness.GetAbbreviation(BendingStiffnessUnit.PoundForceSquareFoot));
            Assert.Equal("m⁻¹", Curvature.GetAbbreviation(CurvatureUnit.PerMeter));
            Assert.Equal("MN·m", Moment.GetAbbreviation(MomentUnit.MeganewtonMeter));
            Assert.Equal("m³", SectionModulus.GetAbbreviation(SectionModulusUnit.CubicMeter));
            Assert.Equal("µε", Strain.GetAbbreviation(StrainUnit.MicroStrain));
        }

        [Fact]
        public void GetAbbreviationReturnsStringInUSEnglishIfAbbreviationIsNotFound()
        {
            Assert.Equal("lbf", AxialStiffness.GetAbbreviation(AxialStiffnessUnit.PoundForce, new CultureInfo("zh-CN")));
            Assert.Equal("lbf·ft²", BendingStiffness.GetAbbreviation(BendingStiffnessUnit.PoundForceSquareFoot, new CultureInfo("zh-CN")));
            Assert.Equal("m⁻¹", Curvature.GetAbbreviation(CurvatureUnit.PerMeter, new CultureInfo("zh-CN")));
            Assert.Equal("MN·m", Moment.GetAbbreviation(MomentUnit.MeganewtonMeter, new CultureInfo("zh-CN")));
            Assert.Equal("m³", SectionModulus.GetAbbreviation(SectionModulusUnit.CubicMeter, new CultureInfo("zh-CN")));
            Assert.Equal("µε", Strain.GetAbbreviation(StrainUnit.MicroStrain, new CultureInfo("zh-CN")));
        }
    }
}
