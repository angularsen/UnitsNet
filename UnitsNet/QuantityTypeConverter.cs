// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace UnitsNet
{
    /// <summary>
    /// Is the base class for all attributes that are related to <see cref="UnitsNetTypeConverter{T}"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class UnitAttributeBase : Attribute
    {
        /// <summary>
        /// The unit enum type, such as <see cref="UnitsNet.Units.LengthUnit" />
        /// </summary>
        public Enum UnitType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitAttributeBase"/> class.
        /// </summary>
        /// <param name="unitType"></param>
        public UnitAttributeBase(object unitType)
        {
            UnitType = unitType as Enum;
        }
    }

    /// <summary>
    /// This attribute defines the default Unit to use. It is only used when the string only consists of digits
    /// </summary>
    public class DefaultUnitAttribute : UnitAttributeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultUnitAttribute"/> class.
        /// </summary>
        /// <param name="unitType">The unit the quantity gets when the string parsing dose only consist of digits</param>
        public DefaultUnitAttribute(object unitType) : base(unitType) { }
    }

    /// <summary>
    /// This attribute defines the Unit the quantity is converted to after it has been parsed.
    /// </summary>
    public class ConvertToUnitAttribute : DefaultUnitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConvertToUnitAttribute"/> class.
        /// </summary>
        /// <param name="unitType">The unit the quantity is converted to when parsing from string</param>
        public ConvertToUnitAttribute(object unitType) : base(unitType) { }
    }

    /// <summary>
    /// This attribute defines the unit the quantity has when converting to string
    /// </summary>
    public class DisplayAsUnitAttribute : DefaultUnitAttribute
    {
        /// <summary>
        /// The formating used when the quantity is converted to string. See <see cref="IQuantity.ToString(System.IFormatProvider)"/>
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayAsUnitAttribute"/> class.
        /// </summary>
        /// <param name="unitType">The unit the quantity should be displayed in</param>
        /// <param name="format">Formating string <see cref="IQuantity.ToString(System.IFormatProvider)"/></param>
        public DisplayAsUnitAttribute(object unitType, string format = "") : base(unitType)
        {
            Format = format;
        }
    }

    // TODO example or documentation ? when documentation where?
    /// <summary>
    ///     Converts between IQuantity and string.
    ///     Implements the TypeConverter interface so that eg the PropertyGrid can read and write the properties implementing the IQuantity interface.
    /// </summary>
    /// <example>
    /// 
    /// </example>
    /// <typeparam name="TQuantity">Quantity value type, such as <see cref="Length"/> or <see cref="Mass"/>.</typeparam>
    public class UnitsNetTypeConverter<TQuantity> : TypeConverter where TQuantity : IQuantity
    {
        // TODO be more specific that only string is supported same below
        /// <summary>
        ///     Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
        /// <param name="sourceType">A System.Type that represents the type you want to convert from.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType);
        }

        private static TAttribute GetAttribute<TAttribute>(ITypeDescriptorContext context) where TAttribute : UnitAttributeBase
        {
            TAttribute attribute = null;
            AttributeCollection ua = context?.PropertyDescriptor.Attributes;

            attribute = (TAttribute)ua?[typeof(TAttribute)];

            if(attribute != null)
            {
                QuantityType expected = default(TQuantity).Type;
                QuantityType actual = Quantity.From(1, attribute.UnitType).Type;
                if(expected != actual)
                {
                    throw new ArgumentException($"The specified UnitType:'{attribute.UnitType}' dose not match QuantityType:'{expected}'");
                }
            }

            return attribute;
        }

        // TODO 
        /// <summary>
        ///     Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
        /// <param name="culture">The System.Globalization.CultureInfo to use as the current culture.</param>
        /// <param name="value">The System.Object to convert.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="System.NotSupportedException">The conversion cannot be performed.</exception>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string stringValue = value as string;
            object result = null;

            if (!string.IsNullOrEmpty(stringValue))
            {
                if (double.TryParse(stringValue, NumberStyles.Any, culture, out double dvalue))
                {
                    DefaultUnitAttribute defaultUnit = GetAttribute<DefaultUnitAttribute>(context) ?? new DefaultUnitAttribute(default(TQuantity).Unit);

                    result = Quantity.From(dvalue, defaultUnit.UnitType);
                }
                else
                {
                    // TODO this should not be part of QuantityTypeConverter. it should rather be part of the parse function
                    stringValue = stringValue.Replace("^-9", "⁻⁹"); 
                    stringValue = stringValue.Replace("^-8", "⁻⁸");
                    stringValue = stringValue.Replace("^-7", "⁻⁷");
                    stringValue = stringValue.Replace("^-6", "⁻⁶");
                    stringValue = stringValue.Replace("^-5", "⁻⁵");
                    stringValue = stringValue.Replace("^-4", "⁻⁴");
                    stringValue = stringValue.Replace("^-3", "⁻³");
                    stringValue = stringValue.Replace("^-2", "⁻²");
                    stringValue = stringValue.Replace("^-1", "⁻¹");
                    stringValue = stringValue.Replace("^1", "");
                    stringValue = stringValue.Replace("^2", "²");
                    stringValue = stringValue.Replace("^3", "³");
                    stringValue = stringValue.Replace("^4", "⁴");
                    stringValue = stringValue.Replace("^5", "⁵");
                    stringValue = stringValue.Replace("^6", "⁶");
                    stringValue = stringValue.Replace("^7", "⁷");
                    stringValue = stringValue.Replace("^8", "⁸");
                    stringValue = stringValue.Replace("^9", "⁹");
                    stringValue = stringValue.Replace("*", "·");

                    result = Quantity.Parse(culture, typeof(TQuantity), stringValue);
                }

                ConvertToUnitAttribute convertToUnit = GetAttribute<ConvertToUnitAttribute>(context);
                if (convertToUnit != null)
                {
                    result = ((IQuantity)result).ToUnit(convertToUnit.UnitType);
                }
            }

            return result ?? base.ConvertFrom(context, culture, value);
        }

        // TODO
        /// <summary>Returns whether this converter can convert the object to the specified type, using the specified context.</summary>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context. </param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to. </param>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType == typeof(string)) || base.CanConvertTo(context, destinationType);
        }

        // TODO
        /// <summary>Converts the given value object to the specified type, using the specified context and culture information.</summary>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context. </param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed. </param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert. </param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType" /> parameter is null. </exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            IQuantity qvalue = value as IQuantity;
            object result = null;
            DisplayAsUnitAttribute displayAsUnit = GetAttribute<DisplayAsUnitAttribute>(context);

            if (destinationType == typeof(string) && qvalue != null && displayAsUnit != null)
            {
                result = qvalue.ToUnit(displayAsUnit.UnitType).ToString(displayAsUnit.Format, culture);
            }
            else
            {
                result = base.ConvertTo(context, culture, value, destinationType);
            }

            return result;
        }
    }
}
