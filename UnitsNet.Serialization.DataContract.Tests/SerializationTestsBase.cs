// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using UnitsNet.Serialization.Contracts;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.DataContract.Tests
{
    public abstract class SerializationTestsBase<TPayload>
    {
        protected abstract TPayload SerializeObject(object obj);
        protected abstract T DeserializeObject<T>(TPayload payload);

        protected void GenericQuantityValueContract_SerializationRoundTrips<TValue, TUnit>(TValue value, TUnit unit)
        {
            var quantityValue = new QuantityValueContract<TValue, TUnit>(value, unit);

            var payload = SerializeObject(quantityValue);
            var result = DeserializeObject<QuantityValueContract<TValue, TUnit>>(payload);

            Assert.Equal(unit, quantityValue.Unit);
            Assert.Equal(value, quantityValue.Value);
            Assert.Equal(quantityValue.Unit, result.Unit);
            Assert.Equal(quantityValue.Value, result.Value);
        }

        protected void GenericExtendedQuantityValueContract_SerializationRoundTrips<TValueType, TUnit>(
            double value, TUnit unit, string valueString, TValueType valueType)
        {
            var quantityValue = new ExtendedQuantityValueContract<TValueType, TUnit>(value, unit, valueString, valueType);

            var payload = SerializeObject(quantityValue);
            var result = DeserializeObject<ExtendedQuantityValueContract<TValueType, TUnit>>(payload);

            Assert.Equal(unit, quantityValue.Unit);
            Assert.Equal(value, quantityValue.Value);
            Assert.Equal(valueString, quantityValue.ValueString);
            Assert.Equal(valueType, quantityValue.ValueType);
            Assert.Equal(quantityValue.Unit, result.Unit);
            Assert.Equal(quantityValue.Value, result.Value);
            Assert.Equal(quantityValue.ValueString, result.ValueString);
            Assert.Equal(quantityValue.ValueType, result.ValueType);
        }

        protected void GenericQuantityWithAbbreviationContract_SerializationRoundTrips<TValue, TQuantity>(
            TValue value, TQuantity quantityType, string unitAbbreviation)
        {
            var quantityValue = new QuantityWithAbbreviationContract<TValue, TQuantity>(value, quantityType, unitAbbreviation);

            var payload = SerializeObject(quantityValue);
            var result = DeserializeObject<QuantityWithAbbreviationContract<TValue, TQuantity>>(payload);

            Assert.Equal(unitAbbreviation, result.Unit);
            Assert.Equal(value, result.Value);
            Assert.Equal(quantityType, result.QuantityType);
            Assert.Equal(quantityValue.Unit, result.Unit);
            Assert.Equal(quantityValue.Value, result.Value);
            Assert.Equal(quantityValue.QuantityType, result.QuantityType);
        }

        [Fact]
        public void DoubleValueQuantity_SerializationRoundTrips()
        {
            var quantity = new Mass(1.2, MassUnit.Milligram);

            var payload = SerializeObject(quantity);
            var result = DeserializeObject<Mass>(payload);

            Assert.Equal(quantity.Unit, result.Unit);
            Assert.Equal(quantity.Value, result.Value);
            Assert.Equal(quantity, result);
        }

        [Fact]
        public void LargeDoubleValueQuantity_SerializationRoundTrips()
        {
            var quantity = new Mass(1E+9, MassUnit.Milligram);

            var payload = SerializeObject(quantity);
            var result = DeserializeObject<Mass>(payload);

            Assert.Equal(quantity.Unit, result.Unit);
            Assert.Equal(quantity.Value, result.Value);
            Assert.Equal(quantity, result);
        }

        [Fact]
        public void DecimalValueQuantity_SerializationRoundTrips()
        {
            var quantity = Information.FromExabytes(1.20m);

            var payload = SerializeObject(quantity);
            var result = DeserializeObject<Information>(payload);

            Assert.Equal(quantity.Unit, result.Unit);
            Assert.Equal(quantity.Value, result.Value);
            Assert.Equal(quantity, result);
        }

        [Fact]
        public void LargeDecimalValueQuantity_SerializationRoundTrips()
        {
            var quantity = Information.FromExabytes(1E+9);

            var payload = SerializeObject(quantity);
            var result = DeserializeObject<Information>(payload);

            Assert.Equal(quantity.Unit, result.Unit);
            Assert.Equal(quantity.Value, result.Value);
            Assert.Equal(quantity, result);
        }

        [Fact]
        public virtual void ArrayOfDoubleValueQuantities_SerializationRoundTrips()
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
        public virtual void ArrayOfDecimalValueQuantities_SerializationRoundTrips()
        {
            var quantities = new[] { new Information(1.2m, InformationUnit.Exabit), new Information(2, InformationUnit.Exabyte) };

            var payload = SerializeObject(quantities);
            var results = DeserializeObject<Information[]>(payload);

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
        public virtual void EnumerableOfDoubleValueQuantities_SerializationRoundTrips()
        {
            var firstQuantity = new Mass(1.2, MassUnit.Milligram);
            var secondQuantity = new Mass(2, MassUnit.Gram);
            IEnumerable<Mass> quantities = new List<Mass> { firstQuantity, secondQuantity };

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
        public virtual void EnumerableOfDecimalValueQuantities_SerializationRoundTrips()
        {
            var firstQuantity = new Information(1.2m, InformationUnit.Exabit);
            var secondQuantity = new Information(2, InformationUnit.Exabyte);
            IEnumerable<Information> quantities = new List<Information> { firstQuantity, secondQuantity };

            var payload = SerializeObject(quantities);
            var results = DeserializeObject<IEnumerable<Information>>(payload);

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

            Assert.Equal(quantity.Unit, results.Item1.Value.Unit);
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
            Assert.Equal(quantity.Unit, results.Item2.Value.Unit);
            Assert.Equal(quantity.Value, results.Item2.Value.Value);
            Assert.Equal(quantity, results.Item2);
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        protected void ClassOfDoubleAndNullUnits_SerializationRoundTrips()
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
        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        protected void ClassOfDecimalAndNullUnits_SerializationRoundTrips()
        {
            var quantity = new Information(2, InformationUnit.Exabyte);
            var quantities = new TestObject<Information> { Quantity = quantity, NullableQuantity = null };

            var payload = SerializeObject(quantities);
            var results = DeserializeObject<TestObject<Information>>(payload);

            Assert.Equal(quantity.Unit, results.Quantity.Unit);
            Assert.Equal(quantity.Value, results.Quantity.Value);
            Assert.Equal(quantity, results.Quantity);
            Assert.Null(results.NullableQuantity);
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public void ClassOfMixedValueQuantities_SerializationRoundTrips()
        {
            var doubleQuantity = new Mass(1.2, MassUnit.Milligram);
            var decimalQuantity = new Information(2, InformationUnit.Exabyte);
            var quantities = new TestObject<Mass, Information>
            {
                Quantity = doubleQuantity, NullableQuantity = doubleQuantity, DecimalQuantity = decimalQuantity
            };

            var payload = SerializeObject(quantities);
            var results = DeserializeObject<TestObject<Mass, Information>>(payload);

            Assert.Equal(doubleQuantity.Unit, results.Quantity.Unit);
            Assert.Equal(doubleQuantity.Value, results.Quantity.Value);
            Assert.Equal(doubleQuantity, results.Quantity);
            Assert.Equal(doubleQuantity.Unit, results.NullableQuantity.Value.Unit);
            Assert.Equal(doubleQuantity.Value, results.NullableQuantity.Value.Value);
            Assert.Equal(doubleQuantity, results.NullableQuantity);
            Assert.Equal(decimalQuantity.Unit, results.DecimalQuantity.Unit);
            Assert.Equal(decimalQuantity.Value, results.DecimalQuantity.Value);
            Assert.Equal(decimalQuantity, results.DecimalQuantity);
            Assert.Null(results.NullableDecimalQuantity);
        }

        [Fact]
        public virtual void EmptyArray_RoundTripsEmpty()
        {
            var payload = SerializeObject(Array.Empty<Mass>());

            var result = DeserializeObject<Mass[]>(payload);

            Assert.Empty(result);
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

        [DataContract]
        protected class TestObject<TDoubleQuantity, TDecimalQuantity> : TestObject<TDoubleQuantity>
            where TDoubleQuantity : struct, IQuantity
            where TDecimalQuantity : struct, IQuantity, IDecimalQuantity
        {
            [DataMember]
            public TDecimalQuantity DecimalQuantity { get; set; }

            [DataMember]
            public TDecimalQuantity? NullableDecimalQuantity { get; set; }
        }
    }
}
