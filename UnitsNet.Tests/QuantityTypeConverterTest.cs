// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using UnitsNet.Tests.Helpers;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityTypeConverterTest
    {
        // https://stackoverflow.com/questions/3612909/why-is-this-typeconverter-not-working
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            AppDomain domain = (AppDomain)sender;
            foreach (Assembly asm in domain.GetAssemblies())
            {
                if (asm.FullName == args.Name)
                {
                    return asm;
                }
            }
            return null;
        }

        static QuantityTypeConverterTest()
        {
            // NOTE: After this, you can use your TypeConverter.
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        /// <summary>
        /// Is used for tests that are culture dependent
        /// </summary>
        private static CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

        [Theory]
        [InlineData(typeof(string), true)]
        [InlineData(typeof(double), false)]
        [InlineData(typeof(object), false)]
        [InlineData(typeof(float), false)]
        [InlineData(typeof(Length<double>), false)]
        public void CanConvertFrom_GivenSomeTypes(Type value, bool expectedResult)
        {
            var converter = new QuantityTypeConverter<Length<double>>();

            bool canConvertFrom = converter.CanConvertFrom(value);

            Assert.Equal(expectedResult, canConvertFrom);
        }

        [Theory]
        [InlineData(typeof(string), true)]
        [InlineData(typeof(double), false)]
        [InlineData(typeof(object), false)]
        [InlineData(typeof(float), false)]
        [InlineData(typeof(Length<double>), false)]
        public void CanConvertTo_GivenSomeTypes(Type value, bool expectedResult)
        {
            var converter = new QuantityTypeConverter<Length<double>>();

            bool canConvertTo = converter.CanConvertTo(value);

            Assert.Equal(expectedResult, canConvertTo);
        }

        [Theory]
        [InlineData("1mm", 1, Units.LengthUnit.Millimeter)]
        [InlineData("1m", 1, Units.LengthUnit.Meter)]
        [InlineData("1", 1, Units.LengthUnit.Meter)]
        [InlineData("1km", 1, Units.LengthUnit.Kilometer)]
        public void ConvertFrom_GivenQuantityStringAndContextWithNoAttributes_ReturnsQuantityWithBaseUnitIfNotSpecified(string str, double expectedValue, Enum expectedUnit)
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            var convertedValue = (Length<double>)converter.ConvertFrom(context, culture, str);

            Assert.Equal(expectedValue, convertedValue.Value);
            Assert.Equal(expectedUnit, convertedValue.Unit);
        }

        [Theory]
        [InlineData("1mm", 1, Units.LengthUnit.Millimeter)]
        [InlineData("1m", 1, Units.LengthUnit.Meter)]
        [InlineData("1", 1, Units.LengthUnit.Centimeter)]
        [InlineData("1km", 1, Units.LengthUnit.Kilometer)]
        public void ConvertFrom_GivenQuantityStringAndContextWithDefaultUnitAttribute_ReturnsQuantityWithGivenDefaultUnitIfNotSpecified(string str, double expectedValue, Enum expectedUnit)
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DefaultUnitAttribute(Units.LengthUnit.Centimeter)
            });

            var convertedValue = (Length<double>)converter.ConvertFrom(context, culture, str);

            Assert.Equal(expectedValue, convertedValue.Value);
            Assert.Equal(expectedUnit, convertedValue.Unit);
        }

        [Theory]
        [InlineData("1mm", 0.001, Units.LengthUnit.Meter)]
        [InlineData("1m", 1, Units.LengthUnit.Meter)]
        [InlineData("1", 0.01, Units.LengthUnit.Meter)]
        [InlineData("1km", 1000, Units.LengthUnit.Meter)]
        public void ConvertFrom_GivenQuantityStringAndContextWithDefaultUnitAndConvertToUnitAttributes_ReturnsQuantityConvertedToUnit(string str, double expectedValue, Enum expectedUnit)
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DefaultUnitAttribute(Units.LengthUnit.Centimeter),
                new ConvertToUnitAttribute(Units.LengthUnit.Meter)
            });

            var convertedValue = (Length<double>)converter.ConvertFrom(context, culture, str);

            Assert.Equal(expectedValue, convertedValue.Value);
            Assert.Equal(expectedUnit, convertedValue.Unit);
        }

        [Fact]
        public void ConvertFrom_GivenEmptyString_ThrowsNotSupportedException()
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Throws<NotSupportedException>(() => converter.ConvertFrom(context, culture, ""));
        }

        [Fact]
        public void ConvertFrom_GivenWrongQuantity_ThrowsArgumentException()
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Throws<ArgumentException>(() => converter.ConvertFrom(context, culture, "1m^2"));
        }

        [Theory]
        [InlineData(typeof(Length<double>))]
        [InlineData(typeof(IQuantity))]
        [InlineData(typeof(object))]
        public void ConvertTo_GivenWrongType_ThrowsNotSupportedException(Type value)
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });
            Length<double> length = Length<double>.FromMeters(1);

            Assert.Throws<NotSupportedException>(() => converter.ConvertTo(length, value));
        }

        [Fact]
        public void ConvertTo_GivenStringType_ReturnsQuantityString()
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });
            Length<double> length = Length<double>.FromMeters(1);

            string convertedQuantity = (string)converter.ConvertTo(length, typeof(string));

            Assert.Equal("1 m", convertedQuantity);
        }

        [Fact]
        public void ConvertTo_GivenSomeQuantityAndContextWithNoAttributes_ReturnsQuantityStringInUnitOfQuantity()
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });
            Length<double> length = Length<double>.FromMeters(1);

            string convertedQuantity = (string)converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("1 m", convertedQuantity);
        }

        [Fact]
        public void ConvertTo_GivenSomeQuantityAndContextWithoutProperty_ReturnsQuantityStringInUnitOfQuantity()
        {
            var converter = new QuantityTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext();
            Length length = Length.FromMeters(1);

            string convertedQuantity = (string)converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("1 m", convertedQuantity);
        }

        [Fact]
        public void ConvertTo_TestDisplayAsFormatting_ReturnsQuantityStringWithDisplayUnitDefaultFormatting()
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DisplayAsUnitAttribute(Units.LengthUnit.Decimeter)
            });
            var length = Length<double>.FromMeters(1);

            string convertedQuantity = (string)converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("10 dm", convertedQuantity);
        }

        [Fact]
        public void ConvertTo_TestDisplayAsFormatting_ReturnsQuantityStringWithDisplayUnitFormatAsValueOnly()
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DisplayAsUnitAttribute(Units.LengthUnit.Decimeter, "v")
            });
            var length = Length<double>.FromMeters(1);

            string convertedQuantity = (string)converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("10", convertedQuantity);
        }

        [Fact]
        public void ConvertTo_TestDisplayAsFormattingWithoutDefinedUnit_ReturnsQuantityStringWithQuantityUnitAndFormattedAsValueOnly()
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DisplayAsUnitAttribute(null, "v")
            });
            var length = Length<double>.FromMeters(1);

            string convertedQuantity = (string)converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("1", convertedQuantity);
        }

        [Fact]
        public void ConvertTo_GivenSomeQuantityAndContextWithDisplayAsUnitAttributes_ReturnsQuantityStringInSpecifiedDisplayUnit()
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DisplayAsUnitAttribute(Units.LengthUnit.Decimeter)
            });
            var length = Length<double>.FromMeters(1);

            string convertedQuantityDefaultCulture = (string)converter.ConvertTo(length, typeof(string));
            string convertedQuantitySpecificCulture = (string)converter.ConvertTo(context, culture, length, typeof(string));

            Assert.Equal("1 m", convertedQuantityDefaultCulture);
            Assert.Equal("10 dm", convertedQuantitySpecificCulture);
        }

        [Fact]
        public void ConvertFrom_GivenDefaultUnitAttributeWithWrongUnitType_ThrowsArgumentException()
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DefaultUnitAttribute(Units.VolumeUnit.CubicMeter)
            });

            Assert.Throws<ArgumentException>(() => converter.ConvertFrom(context, culture, "1"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_1()
        {
            var converter = new QuantityTypeConverter<Length<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Length<double>.FromMeters(1), converter.ConvertFrom(context, culture, "1m"));
            Assert.Equal(Length<double>.FromMeters(1), converter.ConvertFrom(context, culture, "1m^1"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_2()
        {
            var converter = new QuantityTypeConverter<Area<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Area<double>.FromSquareMeters(1), converter.ConvertFrom(context, culture, "1m²"));
            Assert.Equal(Area<double>.FromSquareMeters(1), converter.ConvertFrom(context, culture, "1m^2"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_3()
        {
            var converter = new QuantityTypeConverter<Volume<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Volume<double>.FromCubicMeters(1), converter.ConvertFrom(context, culture, "1m³"));
            Assert.Equal(Volume<double>.FromCubicMeters(1), converter.ConvertFrom(context, culture, "1m^3"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_4()
        {
            var converter = new QuantityTypeConverter<AreaMomentOfInertia<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(AreaMomentOfInertia<double>.FromMetersToTheFourth(1), converter.ConvertFrom(context, culture, "1m⁴"));
            Assert.Equal(AreaMomentOfInertia<double>.FromMetersToTheFourth(1), converter.ConvertFrom(context, culture, "1m^4"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_minus1()
        {
            var converter = new QuantityTypeConverter<CoefficientOfThermalExpansion<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(CoefficientOfThermalExpansion<double>.FromInverseKelvin(1), converter.ConvertFrom(context, culture, "1K⁻¹"));
            Assert.Equal(CoefficientOfThermalExpansion<double>.FromInverseKelvin(1), converter.ConvertFrom(context, culture, "1K^-1"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_minus2()
        {
            var converter = new QuantityTypeConverter<MassFlux<double>>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(MassFlux<double>.FromKilogramsPerSecondPerSquareMeter(1), converter.ConvertFrom(context, culture, "1kg·s⁻¹·m⁻²"));
            Assert.Equal(MassFlux<double>.FromKilogramsPerSecondPerSquareMeter(1), converter.ConvertFrom(context, culture, "1kg·s^-1·m^-2"));
            Assert.Equal(MassFlux<double>.FromKilogramsPerSecondPerSquareMeter(1), converter.ConvertFrom(context, culture, "1kg*s^-1*m^-2"));
        }
    }
}
