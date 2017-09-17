using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Xunit;

namespace UnitsNet.OperatorOverloads.Tests
{
    public class QuantityTests
    {
        [Theory]
        [MemberData(nameof(GetJsonFiles))]
        public static void ShouldNotThrowWhenDeserializingUnits(string filename)
        {
            var quantity = JsonConvert.DeserializeObject<Quantity>(File.ReadAllText(filename));
            Assert.NotNull(quantity);
        }

        public static IEnumerable<object[]> GetJsonFiles()
        {
            var files = Directory.EnumerateFiles(@"C:\dev\UnitsNet\UnitsNet\UnitDefinitions", "*.json");
            foreach (string file in files)
            {
                yield return new object[] {file};
            }
        }
    }
}
