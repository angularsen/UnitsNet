// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using UnitsNet.Tests.Helpers;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityTypeConverterTest
    {
        static QuantityTypeConverterTest()
        {
            // NOTE: After this, you can use your TypeConverter.
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        // https://stackoverflow.com/questions/3612909/why-is-this-typeconverter-not-working
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var domain = (AppDomain) sender;
            foreach (var asm in domain.GetAssemblies())
            {
                if (asm.FullName == args.Name)
                {
                    return asm;
                }
            }

            return null;
        }

        /// <summary>
        ///     Is used for tests that are culture dependent
        /// </summary>
        private static readonly CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

        [Theory]
        [InlineData(typeof(string), true)]
        [InlineData(typeof(double), false)]
        [InlineData(typeof(object), false)]
        [InlineData(typeof(float), false)]
        [InlineData(typeof(Length), false)]
        public void CanConvertFrom_GivenSomeTypes(Type value, bool expectedResult)
        {
            var converter = new QuantityTypeConverter<Length>();

            var canConvertFrom = converter.CanConvertFrom(value);

            Assert.Equal(expectedResult, canConvertFrom);
        }

        [Theory]
        [InlineData(typeof(string), true)]
        [InlineData(typeof(double), false)]
        [InlineData(typeof(object), false)]
        [InlineData(typeof(float), false)]
        [InlineData(typeof(Length), false)]
        public void CanConvertTo_GivenSomeTypes(Type value, bool expectedResult)
        {
            var converter = new QuantityTypeConverter<Length>();

            var canConvertTo = converter.CanConvertTo(value);

            Assert.Equal(expectedResult, canConvertTo);
        }

        [Theory]
        [InlineData("1mm", 1, LengthUnit.Millimeter)]
        [InlineData("1m", 1, LengthUnit.Meter)]
        [InlineData("1", 1, LengthUnit.Meter)]
        [InlineData("1km", 1, LengthUnit.Kilometer)]
        public void ConvertFrom_GivenQuantityStringAndContextWithNoAttributes_ReturnsQuantityWithBaseUnitIfNotSpecified(string str, double expectedValue,
            Enum expectedUnit)
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            var convertedValue = (Length) converter.ConvertFrom(context, culture, str);

            Assert.Equal(expectedValue, convertedValue.Value);
            Assert.Equal(expectedUnit, convertedValue.Unit);
        }

        [Theory]
        [InlineData("1mm", 1, LengthUnit.Millimeter)]
        [InlineData("1m", 1, LengthUnit.Meter)]
        [InlineData("1", 1, LengthUnit.Centimeter)]
        [InlineData("1km", 1, LengthUnit.Kilometer)]
        public void ConvertFrom_GivenQuantityStringAndContextWithDefaultUnitAttribute_ReturnsQuantityWithGivenDefaultUnitIfNotSpecified(string str,
            double expectedValue, Enum expectedUnit)
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] {new DefaultUnitAttribute(LengthUnit.Centimeter)});

            var convertedValue = (Length) converter.ConvertFrom(context, culture, str);

            Assert.Equal(expectedValue, convertedValue.Value);
            Assert.Equal(expectedUnit, convertedValue.Unit);
        }

        [Theory]
        [InlineData("1mm", 0.001, LengthUnit.Meter)]
        [InlineData("1m", 1, LengthUnit.Meter)]
        [InlineData("1", 0.01, LengthUnit.Meter)]
        [InlineData("1km", 1000, LengthUnit.Meter)]
        public void ConvertFrom_GivenQuantityStringAndContextWithDefaultUnitAndConvertToUnitAttributes_ReturnsQuantityConvertedToUnit(string str,
            double expectedValue, Enum expectedUnit)
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName",
                new Attribute[] {new DefaultUnitAttribute(LengthUnit.Centimeter), new ConvertToUnitAttribute(LengthUnit.Meter)});

            var convertedValue = (Length) converter.ConvertFrom(context, culture, str);

            Assert.Equal(expectedValue, convertedValue.Value);
            Assert.Equal(expectedUnit, convertedValue.Unit);
        }

        [Theory]
        [InlineData(typeof(Length))]
        [InlineData(typeof(IQuantity))]
        [InlineData(typeof(object))]
        public void ConvertTo_GivenWrongType_ThrowsNotSupportedException(Type value)
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });
            var length = Length.FromMeters(1);

            Assert.Throws<NotSupportedException>(() => converter.ConvertTo(length, value));
        }

        [Fact]
        public void ConvertFrom_GivenDefaultUnitAttributeWithWrongUnitType_ThrowsArgumentException()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] {new DefaultUnitAttribute(VolumeUnit.CubicMeter)});

            Assert.Throws<ArgumentException>(() => converter.ConvertFrom(context, culture, "1"));
        }

        [Fact]
        public void ConvertFrom_GivenEmptyString_ThrowsNotSupportedException()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Throws<NotSupportedException>(() => converter.ConvertFrom(context, culture, ""));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_1()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Length.FromMeters(1), converter.ConvertFrom(context, culture, "1m"));
            Assert.Equal(Length.FromMeters(1), converter.ConvertFrom(context, culture, "1m^1"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_2()
        {
            var converter = new QuantityTypeConverter<Area>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Area.FromSquareMeters(1), converter.ConvertFrom(context, culture, "1m²"));
            Assert.Equal(Area.FromSquareMeters(1), converter.ConvertFrom(context, culture, "1m^2"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_3()
        {
            var converter = new QuantityTypeConverter<Volume>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Volume.FromCubicMeters(1), converter.ConvertFrom(context, culture, "1m³"));
            Assert.Equal(Volume.FromCubicMeters(1), converter.ConvertFrom(context, culture, "1m^3"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_4()
        {
            var converter = new QuantityTypeConverter<AreaMomentOfInertia>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(AreaMomentOfInertia.FromMetersToTheFourth(1), converter.ConvertFrom(context, culture, "1m⁴"));
            Assert.Equal(AreaMomentOfInertia.FromMetersToTheFourth(1), converter.ConvertFrom(context, culture, "1m^4"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_minus1()
        {
            var converter = new QuantityTypeConverter<CoefficientOfThermalExpansion>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(CoefficientOfThermalExpansion.FromInverseKelvin(1), converter.ConvertFrom(context, culture, "1K⁻¹"));
            Assert.Equal(CoefficientOfThermalExpansion.FromInverseKelvin(1), converter.ConvertFrom(context, culture, "1K^-1"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_minus2()
        {
            var converter = new QuantityTypeConverter<MassFlux>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(MassFlux.FromKilogramsPerSecondPerSquareMeter(1), converter.ConvertFrom(context, culture, "1kg·s⁻¹·m⁻²"));
            Assert.Equal(MassFlux.FromKilogramsPerSecondPerSquareMeter(1), converter.ConvertFrom(context, culture, "1kg·s^-1·m^-2"));
            Assert.Equal(MassFlux.FromKilogramsPerSecondPerSquareMeter(1), converter.ConvertFrom(context, culture, "1kg*s^-1*m^-2"));
        }

        [Fact]
        public void ConvertFrom_GivenWrongQuantity_ThrowsArgumentException()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Throws<ArgumentException>(() => converter.ConvertFrom(context, culture, "1m^2"));
        }

        [Fact]
        public void ConvertTo_GivenSomeQuantitysAndContextWithDisplayAsUnitAttributes_ReturnsQuantityStringInSpecifiedDisplayUnit()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] {new DisplayAsUnitAttribute(LengthUnit.Decimeter)});
            var length = Length.FromMeters(1);

            var convertedQuantityDefaultCulture = (string) converter.ConvertTo(length, typeof(string));
            var convertedQuantitySpecificCulture = (string) converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("1 m", convertedQuantityDefaultCulture);
            Assert.Equal("10 dm", convertedQuantitySpecificCulture);
        }

        [Fact]
        public void ConvertTo_GivenSomeQuantitysAndContextWithNoAttributes_ReturnsQuantityStringInUnitOfQuantity()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });
            var length = Length.FromMeters(1);

            var convertedQuantity = (string) converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("1 m", convertedQuantity);
        }

        [Fact]
        public void ConvertTo_GivenStringType_ReturnsQuantityString()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });
            var length = Length.FromMeters(1);

            var convertedQuantity = (string) converter.ConvertTo(length, typeof(string));

            Assert.Equal("1 m", convertedQuantity);
        }

        [Fact]
        public void ConvertTo_TestDisplayAsFormatting_ReturnsQuantityStringWithDisplayUnitDefaultFormating()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] {new DisplayAsUnitAttribute(LengthUnit.Decimeter)});
            var length = Length.FromMeters(1);

            var convertedQuantity = (string) converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("10 dm", convertedQuantity);
        }

        [Fact]
        public void ConvertTo_TestDisplayAsFormatting_ReturnsQuantityStringWithDisplayUnitFormateAsValueOnly()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context =
                new TypeDescriptorContext("SomeMemberName", new Attribute[] {new DisplayAsUnitAttribute(LengthUnit.Decimeter, "v")});
            var length = Length.FromMeters(1);

            var convertedQuantity = (string) converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("10", convertedQuantity);
        }

        [Fact]
        public void ConvertTo_TestDisplayAsFormattingWithoutDefinedUnit_ReturnsQuantityStringWithQuantetiesUnitAndFormatedAsValueOnly()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] {new DisplayAsUnitAttribute(null, "v")});
            var length = Length.FromMeters(1);

            var convertedQuantity = (string) converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("1", convertedQuantity);
        }
    }
}
