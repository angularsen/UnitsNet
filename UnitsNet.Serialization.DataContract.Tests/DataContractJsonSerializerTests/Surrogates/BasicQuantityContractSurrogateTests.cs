using System.Runtime.Serialization.Json;
using UnitsNet.Serialization.Surrogates;

namespace UnitsNet.Serialization.DataContract.Tests.DataContractJsonSerializerTests.Surrogates
{
    /// <summary>
    ///     There are no special tests here: uses the <i>standard</i> format of encoding the Unit & Value (with no support for
    ///     decimals):
    ///     https://github.com/angularsen/UnitsNet#serialization
    ///     <remarks>
    ///         <para>Compatible with the legacy JsonConverter</para>
    ///     </remarks>
    /// </summary>
    public class BasicQuantityContractSurrogateTests : StringUnitJsonDataContractSerializerTestsBase
    {
        public BasicQuantityContractSurrogateTests()
            : base(new DataContractJsonSerializerSettings {DataContractSurrogate = new BasicQuantityContractSurrogate()})
        {
        }
    }
}
