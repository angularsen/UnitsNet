// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using UnitsNet.Serialization.DataContract.Tests;
using UnitsNet.Serialization.Surrogates;
using Xunit;

namespace UnitsNet.Serialization.DataContract.Compatibility.JsonNetTests.UnitsNetJsonConverter
{
    public class DataContractToJsonNetSerializationTests : SerializationTestsBase<string>
    {
        private readonly DataContractJsonSerializerSettings _dataContractJsonSerializerSettings;

        private readonly JsonSerializerSettings _jsonNetSerializerSettings;

        public DataContractToJsonNetSerializationTests()
        {
            _jsonNetSerializerSettings = new JsonSerializerSettings();
            _jsonNetSerializerSettings.Converters.Add(new JsonNet.UnitsNetJsonConverter());
            _dataContractJsonSerializerSettings = new DataContractJsonSerializerSettings {DataContractSurrogate = new BasicQuantityContractSurrogate()};
        }

        protected override string SerializeObject(object obj)
        {
            var serializer = new DataContractJsonSerializer(obj.GetType(), _dataContractJsonSerializerSettings);
            using var stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            stream.Position = 0;
            using var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }

        protected override T DeserializeObject<T>(string payload)
        {
            return JsonConvert.DeserializeObject<T>(payload, _jsonNetSerializerSettings);
        }

        [Fact(Skip = "Arrays are currently not supported by the UnitsNetJsonConverter")]
        public override void ArrayOfDoubleValueQuantities_SerializationRoundTrips()
        {
            base.ArrayOfDoubleValueQuantities_SerializationRoundTrips();
        }

        [Fact(Skip = "Arrays are currently not supported by the UnitsNetJsonConverter")]
        public override void ArrayOfDecimalValueQuantities_SerializationRoundTrips()
        {
            base.ArrayOfDecimalValueQuantities_SerializationRoundTrips();
        }

        [Fact(Skip = "Arrays are currently not supported by the UnitsNetJsonConverter")]
        public override void EmptyArray_RoundTripsEmpty()
        {
            base.EmptyArray_RoundTripsEmpty();
        }

        [Fact(Skip = "Tuples are currently not supported by the UnitsNetJsonConverter")]
        public override void TupleOfMixedValueQuantities_SerializationRoundTrips()
        {
            base.TupleOfMixedValueQuantities_SerializationRoundTrips();
        }

        [Fact(Skip = "Tuples are currently not supported by the UnitsNetJsonConverter")]
        public override void TupleOfDoubleAndNullQuantities_SerializationRoundTrips()
        {
            base.TupleOfDoubleAndNullQuantities_SerializationRoundTrips();
        }

        [Fact(Skip = "Tuples are currently not supported by the UnitsNetJsonConverter")]
        public override void TupleOfDecimalAndNullQuantities_SerializationRoundTrips()
        {
            base.TupleOfDecimalAndNullQuantities_SerializationRoundTrips();
        }
    }
}
