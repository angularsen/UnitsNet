using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.DataContract.Tests.DataContractJsonSerializerTests
{
    /// <summary>
    ///     These tests demonstrate the default behavior of the DataContractJsonSerializer when dealing with quantities
    ///     <remarks>
    ///         <para>Note that the produced schema is different from the one generated using the UnitsNet.Json package</para>
    ///     </remarks>
    /// </summary>
    public class DefaultDataContractJsonSerializerTests : DataContractJsonSerializerTestsBase
    {
        [Fact]
        public void DoubleQuantity_SerializedWithDoubleValueAndIntegerUnit()
        {
            var quantity = new Mass(1.20, MassUnit.Milligram);
            var expectedJson = "{\"Value\":1.2,\"Unit\":16}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void DecimalQuantity_SerializedWithDecimalValueValueAndIntegerUnit()
        {
            var quantity = new Information(1.20m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1.20,\"Unit\":4}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void DoubleQuantity_InScientificNotation_SerializedWithExpandedValueAndIntegerUnit()
        {
            var quantity = new Mass(1E+9, MassUnit.Milligram);
            var expectedJson = "{\"Value\":1000000000,\"Unit\":16}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void DecimalQuantity_InScientificNotation_SerializedWithExpandedValueAndIntegerUnit()
        {
            var quantity = new Information(1E+9m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1000000000,\"Unit\":4}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }
    }
}
