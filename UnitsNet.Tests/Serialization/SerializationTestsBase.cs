﻿// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.Serialization
{
    /// <summary>
    ///     A set of serialization/deserialization tests that can be used by for testing the capabilities of different
    ///     serializers / schemas.
    /// </summary>
    /// <remarks>
    ///     Note that some of the tests are marked as virtual: you can [Skip] them in the derived class, in case the given
    ///     capabilities are not supported.
    /// </remarks>
    /// <typeparam name="TPayload">
    ///     The type of payload (typically string) that is the expected result of the serialization
    ///     process.
    /// </typeparam>
    public abstract class SerializationTestsBase<TPayload>
    {
        protected abstract TPayload SerializeObject(object obj);
        protected abstract T DeserializeObject<T>(TPayload payload);

        [Theory]
        [InlineData(1.0)]
        [InlineData(0)]
        [InlineData(-1.0)]
        [InlineData(1.2)]
        [InlineData(-1.2)]
        [InlineData(1E+36)]
        [InlineData(1E-36)]
        [InlineData(-1E+36)]
        public void DoubleValueQuantity_SerializationRoundTrips(double value)
        {
            var quantity = new Mass(value, MassUnit.Milligram);

            var payload = SerializeObject(quantity);
            var result = DeserializeObject<Mass>(payload);

            Assert.Equal(quantity.Unit, result.Unit);
            Assert.Equal(quantity.Value, result.Value);
            Assert.Equal(quantity, result);
        }

        [Fact]
        public void LargeDecimalValueQuantity_SerializationRoundTrips()
        {
            var quantity = Information.FromExabytes(1E+24);

            var payload = SerializeObject(quantity);
            var result = DeserializeObject<Information>(payload);

            Assert.Equal(quantity, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        public void ArrayOfDoubleValueQuantities_SerializationRoundTrips()
        {
            var quantities = new[] { new Mass(1.2, MassUnit.Milligram), new Mass(2, MassUnit.Gram) };

            var payload = SerializeObject(quantities);
            var results = DeserializeObject<Mass[]>(payload);

            Assert.Collection(results, result =>
            {
                Assert.Equal(quantities[0].Unit, result.Unit);
                Assert.Equal(quantities[0].Value, result.Value);
                Assert.Equal(quantities[0], result);
            }, result =>
            {
                Assert.Equal(quantities[1].Unit, result.Unit);
                Assert.Equal(quantities[1].Value, result.Value);
                Assert.Equal(quantities[1], result);
            });
        }

        [Fact]
        public void EmptyArray_RoundTripsEmpty()
        {
            var payload = SerializeObject(Array.Empty<Mass>());

            var result = DeserializeObject<Mass[]>(payload);

            Assert.Empty(result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        public virtual void EnumerableOfDoubleValueQuantities_SerializationRoundTrips()
        {
            var firstQuantity = new Mass(1.2, MassUnit.Milligram);
            var secondQuantity = new Mass(2, MassUnit.Gram);
            var quantities = new List<Mass> { firstQuantity, secondQuantity };

            var payload = SerializeObject(quantities);
            var results = DeserializeObject<IEnumerable<Mass>>(payload);

            Assert.Collection(results, result =>
            {
                Assert.Equal(firstQuantity.Unit, result.Unit);
                Assert.Equal(firstQuantity.Value, result.Value);
                Assert.Equal(firstQuantity, result);
            }, result =>
            {
                Assert.Equal(secondQuantity.Unit, result.Unit);
                Assert.Equal(secondQuantity.Value, result.Value);
                Assert.Equal(secondQuantity, result);
            });
        }

        [Fact]
        public virtual void TupleOfMixedValueQuantities_SerializationRoundTrips()
        {
            var quantities = new Tuple<Mass, Information>(new Mass(1.2, MassUnit.Milligram), new Information(2, InformationUnit.Exabyte));

            var payload = SerializeObject(quantities);
            var results = DeserializeObject<Tuple<Mass, Information>>(payload);

            Assert.Equal(quantities.Item1.Unit, results.Item1.Unit);
            Assert.Equal(quantities.Item1.Value, results.Item1.Value);
            Assert.Equal(quantities.Item1, results.Item1);
            Assert.Equal(quantities.Item2.Unit, results.Item2.Unit);
            Assert.Equal(quantities.Item2.Value, results.Item2.Value);
            Assert.Equal(quantities.Item2, results.Item2);
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public virtual void TupleOfDoubleAndNullQuantities_SerializationRoundTrips()
        {
            var quantity = new Mass(1.2, MassUnit.Milligram);
            var quantities = new Tuple<Mass?, Information?>(quantity, null);

            var payload = SerializeObject(quantities);
            var results = DeserializeObject<Tuple<Mass?, Information?>>(payload);

            Assert.Equal(quantity.Unit, results.Item1!.Value.Unit);
            Assert.Equal(quantity.Value, results.Item1.Value.Value);
            Assert.Equal(quantity, results.Item1);
            Assert.Null(results.Item2);
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public virtual void TupleOfDecimalAndNullQuantities_SerializationRoundTrips()
        {
            var quantity = new Information(2, InformationUnit.Exabyte);
            var quantities = new Tuple<Mass?, Information?>(null, quantity);

            var payload = SerializeObject(quantities);
            var results = DeserializeObject<Tuple<Mass?, Information?>>(payload);

            Assert.Null(results.Item1);
            Assert.Equal(quantity.Unit, results.Item2!.Value.Unit);
            Assert.Equal(quantity.Value, results.Item2.Value.Value);
            Assert.Equal(quantity, results.Item2);
        }

        [Fact]
        public void ClassOfDoubleAndNullUnits_SerializationRoundTrips()
        {
            var quantity = new Mass(1.2, MassUnit.Milligram);
            var quantities = new TestObject<Mass> { Quantity = quantity, NullableQuantity = null };

            var payload = SerializeObject(quantities);
            var results = DeserializeObject<TestObject<Mass>>(payload);

            Assert.Equal(quantity.Unit, results.Quantity.Unit);
            Assert.Equal(quantity.Value, results.Quantity.Value);
            Assert.Equal(quantity, results.Quantity);
            Assert.Null(results.NullableQuantity);
        }

        [Fact]
        public void ClassOfInterfaceQuantity_SerializationRoundTrips()
        {
            var quantity = new Mass(1.2, MassUnit.Milligram);
            var quantityObject = new TestInterfaceObject { Quantity = quantity };

            var payload = SerializeObject(quantityObject);
            var result = DeserializeObject<TestInterfaceObject>(payload);

            Assert.Equal(quantity.Unit, result.Quantity.Unit);
            Assert.Equal(quantity.Value, result.Quantity.Value);
            Assert.Equal(quantity, result.Quantity);
        }

        [DataContract]
        protected class TestObject<TQuantity>
            where TQuantity : struct, IQuantity
        {
            [DataMember]
            public TQuantity Quantity { get; set; }

            [DataMember]
            public TQuantity? NullableQuantity { get; set; }
        }
    }
}
