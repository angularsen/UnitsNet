using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoreLinq;
using Newtonsoft.Json;
using NUnit.Framework;
using UnitsNet;
using UnitsNet.Tests.Examples;

namespace UnitsNet.Tests.Examples.Serialization
{
    [TestFixture]
    public class AreaJsonConverterTests 
    {
        private class WriterTestParameter
        {
            public Area? Input { get; set; }
            public string ExpectedJson { get; set; }
        }
        
        [Test]
        public void ExampleSerializationWithJsonNet()
        {
            var testParameters = new []
            {
                new WriterTestParameter{Input = Area.FromSquareMeters(20), ExpectedJson = "20.0"}
                ,new WriterTestParameter{Input = null, ExpectedJson = "null"}
            } ;

            testParameters.ForEach(tp => SerializationTest(tp.Input, tp.ExpectedJson));
        }
        
        private void SerializationTest(Area? input, string expectedJson)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new AreaJsonConverter());
            settings.Formatting = Formatting.Indented;

            var json = JsonConvert.SerializeObject(input, settings);
            
            var areaReloaded = JsonConvert.DeserializeObject<Area?>(json, settings);

            Assert.AreEqual(expectedJson, json);
            Assert.AreEqual(input, areaReloaded);
        }
    }
}
