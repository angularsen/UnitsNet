// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Serialization.SystemTextJson.Tests.Infrastructure;
using Xunit;

namespace UnitsNet.Serialization.SystemTextJson.Tests
{
    public class ChuckerTest : UnitsNetJsonBaseTest
    {
        [Fact]
        public void CellularDataUsage_CanDeserialize()
        {
            var expected = new CellularDataUsage(
                Remaining: Information.FromGibibits(16),
                Incremental: null,
                Total: Information.FromKibibits(32));

            var json = SerializeObject(expected);

            var actual = DeserializeObject<CellularDataUsage>(json);

            Assert.Equal(expected.Remaining, actual.Remaining);
            Assert.Equal(expected.Incremental, actual.Incremental);
            Assert.Equal(expected.Total, actual.Total);


        }

        [Fact]
        public void UnitsNet905_CanDeserialize()
        {
            var expected = new UnitsNet905
            {
                DataUsage = UnitsNet.Information.FromGibibytes(15)
            };

            var json = SerializeObject(expected);

            var actual = DeserializeObject<UnitsNet905>(json);

            Assert.Equal(expected.DataUsage, actual.DataUsage);
        }
    }

    public class UnitsNet905
    {
        public Information DataUsage { get; set; }
    }

    public record CellularDataUsage(Information Remaining, Information? Incremental, Information Total);

}
