using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace UnitsNet.OperatorOverloads.Tests
{
    public static class OverloadGeneratorTests
    {
        [Fact]
        public static void ShouldReturnDivisionAndSpeedWhenGivenLength()
        {
            var lengthQuantity = JsonConvert.DeserializeObject<Quantity>(File.ReadAllText(@"C:\dev\UnitsNet\UnitsNet\UnitDefinitions\Length.json"));
            lengthQuantity.SiArray = new[] {1, 0, 0, 0, 0, 0, 0};
            var timeQuantity = JsonConvert.DeserializeObject<Quantity>(File.ReadAllText(@"C:\dev\UnitsNet\UnitsNet\UnitDefinitions\Duration.json"));
            timeQuantity.SiArray = new[] { 0, 0, 1, 0, 0, 0, 0 };
            var speedQuantity = JsonConvert.DeserializeObject<Quantity>(File.ReadAllText(@"C:\dev\UnitsNet\UnitsNet\UnitDefinitions\Speed.json"));
            speedQuantity.SiArray = new[] { 1, 0, -1, 0, 0, 0, 0 };

            var overloadGenerator = new OverloadGenerator(new[] {lengthQuantity, timeQuantity, speedQuantity});
            var actualQuantities = overloadGenerator.GetDivisionOverloads(lengthQuantity).ToArray();
            var actualQuantityNames = actualQuantities.Select(x => x.Name).ToArray();
            Assert.Equal(2,actualQuantities.Length);
            
            Assert.Contains(speedQuantity.Name, actualQuantityNames);
            Assert.Contains(timeQuantity.Name, actualQuantityNames);
        }
    }
}
