using UnitsNet.Extensions.NumberToAngle;
using UnitsNet.Extensions.NumberToForce;
using UnitsNet.Extensions.NumberToLength;
using UnitsNet.Extensions.NumberToMass;
using Xunit;

namespace UnitsNet.Tests
{
    public class NumberExtensionsTest
    {
        [Fact]
        public void SomeArbitraryExtensionMethods_CreatesCorrectValue()
        {
            Assert.Equal(Length.FromMeters(1), 1.Meters());
            Assert.Equal(Mass.FromTonnes(2), 2.Tonnes());
            Assert.Equal(Force.FromKiloPonds(3), 3.KiloPonds());
            Assert.Equal(Angle.FromRadians(3), 3.Radians());
        }
    }
}
