using Newtonsoft.Json;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public class UnitsNetQuantityTypeJsonConverterTests
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly JsonSerializerSettings _jsonSerializerSettingsUnits;
        private readonly JsonSerializerSettings _jsonSerializerSettingsResolve;

        protected UnitsNetQuantityTypeJsonConverterTests()
        {
            _jsonSerializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            _jsonSerializerSettings.Converters.Add(new SimpleUnitsNetJsonConverter());

            _jsonSerializerSettingsUnits = new JsonSerializerSettings { Formatting = Formatting.Indented };
            _jsonSerializerSettingsUnits.Converters.Add(new SimpleUnitsNetJsonConverter(LengthUnit.Centimeter));

            _jsonSerializerSettingsResolve =  new JsonSerializerSettings { Formatting = Formatting.Indented };
            _jsonSerializerSettingsResolve.Converters.Add(new SimpleUnitsNetJsonConverter(null, new[] { LengthUnit.DtpPoint.ToString() }));
        }

        private string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
        }

        private string SerializeObjectUnit(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettingsUnits);
        }

        private T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }

        private T DeserializeObjectResolve<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettingsResolve);
        }

        public class SerializeQuantityType : UnitsNetQuantityTypeJsonConverterTests
        {
            [Fact]
            public void Length_SerializeMeters()
            {
                Length l = Length.FromMeters(2);
                string expectedValue = "\"2 m\"";

                string json = SerializeObject(l);

                Assert.Equal(expectedValue, json);
            }

            [Fact]
            public void Length_SerializeCentimeters()
            {
                Length l = Length.FromCentimeters(2e1);
                string expectedValue = "\"20 cm\"";

                string json = SerializeObject(l);

                Assert.Equal(expectedValue, json);
            }

            [Fact]
            public void Length_SerializeFeet()
            {
                Length l = Length.FromFeet(5e-1);
                string expectedValue = "\"0.5 ft\"";

                string json = SerializeObject(l);

                Assert.Equal(expectedValue, json);
            }

            [Fact]
            public void Mass_SerializeKilograms()
            {
                Mass m = Mass.FromKilograms(5e-1);
                string expectedValue = "\"0.5 kg\"";

                string json = SerializeObject(m);

                Assert.Equal(expectedValue, json);
            }

            [Fact]
            public void Mass_SerializeGrams()
            {
                Mass m = Mass.FromGrams(5e3);
                string expectedValue = "\"5,000 g\"";

                string json = SerializeObject(m);

                Assert.Equal(expectedValue, json);
            }

            [Fact]
            public void Ratio_SerializeDecimalFraction()
            {
                Ratio m = Ratio.FromDecimalFractions(3e-1);
                string expectedValue = "\"0.3 \"";

                string json = SerializeObject(m);

                Assert.Equal(expectedValue, json);
            }

            [Fact]
            public void Length_SerializeMetersInCm()
            {
                Length l = Length.FromMeters(2);
                string expectedValue = "\"200 cm\"";

                string json = SerializeObjectUnit(l);

                Assert.Equal(expectedValue, json);
            }

            [Fact]
            public void Length_SerializeCentimetersInCm()
            {
                Length l = Length.FromCentimeters(2e1);
                string expectedValue = "\"20 cm\"";

                string json = SerializeObjectUnit(l);

                Assert.Equal(expectedValue, json);
            }

            [Fact]
            public void Length_SerializeFeetInCm()
            {
                Length l = Length.FromFeet(5e-1);
                string expectedValue = "\"15.24 cm\"";

                string json = SerializeObjectUnit(l);

                Assert.Equal(expectedValue, json);
            }
        }

        public class DeserializeQuantityType : UnitsNetQuantityTypeJsonConverterTests
        {
            [Fact]
            public void Length_DeserializeMeters()
            {
                Length l = Length.FromMeters(2);
                string json = SerializeObject(l);

                Length deserializedTestObj = DeserializeObject<Length>(json);

                Assert.Equal(l, deserializedTestObj);
            }

            [Fact]
            public void Length_DeserializeCentimeters()
            {
                Length l = Length.FromCentimeters(2e1);
                string json = SerializeObject(l);

                Length deserializedTestObj = DeserializeObject<Length>(json);

                Assert.Equal(l, deserializedTestObj);
            }

            [Fact]
            public void Length_DeserializeFeet()
            {
                Length l = Length.FromFeet(5e-1);
                string json = SerializeObject(l);

                Length deserializedTestObj = DeserializeObject<Length>(json);

                Assert.Equal(l, deserializedTestObj);
            }

            [Fact]
            public void Length_DeserializePoint()
            {
                Length l = Length.FromDtpPoints(5e-1);
                string json = SerializeObject(l);

                Length deserializedTestObj = DeserializeObjectResolve<Length>(json);

                Assert.Equal(l, deserializedTestObj);
            }

            [Fact]
            public void Mass_DeserializeKilograms()
            {
                Mass m = Mass.FromKilograms(5e-1);
                string json = SerializeObject(m);

                Mass deserializedTestObj = DeserializeObject<Mass>(json);

                Assert.Equal(m, deserializedTestObj);
            }

            [Fact]
            public void Mass_DeserializeGrams()
            {
                Mass m = Mass.FromGrams(5e3);
                string json = SerializeObject(m);

                Mass deserializedTestObj = DeserializeObject<Mass>(json);

                Assert.Equal(m, deserializedTestObj);
            }

            [Fact]
            public void Ratio_DeserializeDecimalFraction()
            {
                Ratio r = Ratio.FromDecimalFractions(0.5);
                string json = SerializeObject(r);

                Ratio deserializedTestObj = DeserializeObject<Ratio>(json);

                Assert.Equal(r, deserializedTestObj);
            }
        }

    }
}
