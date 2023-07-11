// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.ComponentModel;
using System.Globalization;

namespace UnitsNet
{
    /// <summary>
    /// Is the base class for all attributes that are related to <see cref="QuantityTypeConverter{T}"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class UnitAttributeBase : Attribute
    {
        /// <summary>
        /// The unit to convert to, such as <see cref="UnitsNet.Units.LengthUnit" />. Defaults to the unit the quantity as constructed with.
        /// </summary>
        public Enum? UnitType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitAttributeBase"/> class.
        /// </summary>
        /// <param name="unitType"></param>
        public UnitAttributeBase(object? unitType)
        {
            UnitType = unitType as Enum;
        }
    }

    /// <summary>
    /// This attribute defines the default Unit to use if the string to convert only consists of digits
    /// </summary>
    public class DefaultUnitAttribute : UnitAttributeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultUnitAttribute"/> class.
        /// </summary>
        /// <param name="unitType">The unit the quantity gets when the string parsing dose only consist of digits</param>
        public DefaultUnitAttribute(object? unitType) : base(unitType) { }
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
        public ConvertToUnitAttribute(object? unitType) : base(unitType) { }
    }

    /// <summary>
    /// This attribute defines the unit the quantity has when converting to string
    /// </summary>
    public class DisplayAsUnitAttribute : DefaultUnitAttribute
    {
        /// <summary>
        /// The formatting used when the quantity is converted to string. See <see cref="IQuantity.ToString(System.IFormatProvider)"/>
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayAsUnitAttribute"/> class.
        /// </summary>
        /// <param name="unitType">The unit the quantity should be displayed in</param>
        /// <param name="format">Formatting string <see cref="IQuantity.ToString(System.IFormatProvider)"/> </param>
        public DisplayAsUnitAttribute(object? unitType, string format = "") : base(unitType)
        {
            Format = format;
        }
    }

    /// <summary>
    /// <para>
    ///     Converts between IQuantity and string.
    ///     Implements a TypeConverter for IQuantities. This allows eg the PropertyGrid to read and write properties of type IQuantity.
    /// </para>
    ///   <para>For basic understanding of TypeConverters consult the .NET documentation.</para>
    /// </summary>
    /// <typeparam name="TQuantity">Quantity value type, such as <see cref="Length"/> or <see cref="Mass"/>.</typeparam>
    /// <remarks>
    /// <para>
    ///     When a string is converted a Quantity the unit given by the string is used.
    ///     When no unit is given by the string the base unit is used.
    ///     The base unit can be overwritten by use of the <see cref="DefaultUnitAttribute"/>.
    ///     The converted Quantity can be forced to be in a certain unit by use of the <see cref="ConvertToUnitAttribute"/>.
    /// </para>
    /// <para>
    ///     The displayed unit can be forced to a certain unit by use of the <see cref="DisplayAsUnitAttribute"/>.
    ///     The <see cref="DisplayAsUnitAttribute"/> provides the possibility to format the displayed Quantity.
    /// </para>
    /// </remarks>
    /// <example>
    ///   <para>These examples show how to use this TypeConverter.</para>
    ///
    /// <code title="Using the TypeConverter without additional attributes">
    ///     [TypeConverter(typeof(UnitsNetTypeConverter{Length}))]
    ///     Units.Length PropertyName { get; set; }
    /// </code>
    ///
    /// <code title="Using the TypeConverter with DisplayAsUnit attribute">
    ///     [DisplayAsUnit(UnitsNet.Units.LengthUnit.Meter)]
    ///     [TypeConverter(typeof(UnitsNetTypeConverter{Length}))]
    ///     Units.Length Length { get; set; }
    /// </code>
    ///
    /// <code title="Using the TypeConverter with DisplayAsUnit attribute with formatting">
    ///     [DisplayAsUnit(UnitsNet.Units.LengthUnit.Meter, "g")]
    ///     [TypeConverter(typeof(UnitsNetTypeConverter{Length}))]
    ///     Units.Length Length { get; set; }
    /// </code>
    ///
    /// <code title="Using the TypeConverter with ConvertToUnit attribute">
    ///     [ConvertToUnitAttribute(UnitsNet.Units.LengthUnit.Meter)]
    ///     [TypeConverter(typeof(UnitsNetTypeConverter{Length}))]
    ///     Units.Length Length { get; set; }
    /// </code>
    ///
    /// <code title="Using the TypeConverter with DefaultUnit attribute">
    ///     [DefaultUnitAttribute(UnitsNet.Units.LengthUnit.Meter)]
    ///     [TypeConverter(typeof(UnitsNetTypeConverter{Length}))]
    ///     Units.Length Length { get; set; }
    /// </code>
    /// </example>
    public class QuantityTypeConverter<TQuantity> : TypeConverter where TQuantity : struct, IQuantity
    {
        /// <summary>
        ///     Returns true if sourceType if of type <see cref="string"/>
        /// </summary>
        /// <param name="context">An <see cref="System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="System.Type"/> that represents the type you want to convert from.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return (sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType);
        }

        private static TAttribute? GetAttribute<TAttribute>(ITypeDescriptorContext? context) where TAttribute : UnitAttributeBase
        {
            if (context?.PropertyDescriptor is null) return null;

            var attribute = (TAttribute?)context.PropertyDescriptor.Attributes[typeof(TAttribute)];

            // Ensure the attribute's unit is compatible with this converter's quantity.
            if (attribute?.UnitType != null)
            {
                string converterQuantityName = default(TQuantity).QuantityInfo.Name;
                string attributeQuantityName = Quantity.From(1, attribute.UnitType).QuantityInfo.Name;
                if (converterQuantityName != attributeQuantityName)
                {
                    throw new ArgumentException($"The {attribute.GetType()}'s UnitType [{attribute.UnitType}] is not compatible with the converter's quantity [{converterQuantityName}].");
                }
            }

            return attribute;
        }

        /// <summary>
        ///     Converts the given object, when it is of type <see cref="string"/> to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
        /// <param name="culture">The System.Globalization.CultureInfo to use as the current culture.</param>
        /// <param name="value">The System.Object to convert.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="System.NotSupportedException">The conversion cannot be performed.</exception>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string stringValue && !string.IsNullOrEmpty(stringValue))
            {
                IQuantity? quantity = null;

                if (double.TryParse(stringValue, NumberStyles.Any, culture, out double dvalue))
                {
                    var defaultUnit = GetAttribute<DefaultUnitAttribute>(context) ?? new DefaultUnitAttribute(default(TQuantity).Unit);
                    if(defaultUnit.UnitType != null)
                        quantity = Quantity.From(dvalue, defaultUnit.UnitType);
                }
                else
                {
                    quantity = Quantity.Parse(culture, typeof(TQuantity), stringValue);
                }

                if( quantity != null)
                {
                    ConvertToUnitAttribute? convertToUnit = GetAttribute<ConvertToUnitAttribute>(context);
                    if (convertToUnit != null && convertToUnit.UnitType != null)
                        quantity = quantity.ToUnit(convertToUnit.UnitType);

                    return quantity;
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>Returns true whether this converter can convert the <see cref="IQuantity"/> to string, using the specified context.</summary>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context. </param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to. </param>
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            return (destinationType == typeof(string)) || base.CanConvertTo(context, destinationType);
        }

        /// <summary>Converts the given <see cref="IQuantity"/> object to <see cref="string"/>, using the specified context and culture information.</summary>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context. </param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed. </param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert. </param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType" /> parameter is null. </exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            DisplayAsUnitAttribute? displayAsUnit = GetAttribute<DisplayAsUnitAttribute>(context);

            if (value is not IQuantity qvalue || destinationType != typeof(string))
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }

            if (displayAsUnit == null)
            {
                return qvalue.ToString(culture);
            }

            if (displayAsUnit.UnitType == null)
            {
                return qvalue.ToString(displayAsUnit.Format, culture);
            }

            return qvalue.ToUnit(displayAsUnit.UnitType).ToString(displayAsUnit.Format, culture);
        }
    }
}
