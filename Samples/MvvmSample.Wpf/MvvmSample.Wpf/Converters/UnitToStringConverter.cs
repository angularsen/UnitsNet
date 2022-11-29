using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using CommonServiceLocator;
using UnitsNet;
using WpfMVVMSample.Settings;

namespace WpfMVVMSample.Converters
{
    public class UnitToStringConverter : MarkupExtension, IValueConverter
    {
        //http://www.thejoyofcode.com/WPF_Quick_Tip_Converters_as_MarkupExtensions.aspx
        private readonly SettingsManager _settings;
        private static UnitToStringConverter _instance;

        public UnitToStringConverter()
        {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                _settings = ServiceLocator.Current.GetInstance<SettingsManager>();
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is IQuantity quantity))
                throw new ArgumentException("Expected value of type UnitsNet.IQuantity.", nameof(value));

            Enum unitEnumValue = _settings.GetDefaultUnit(quantity.QuantityInfo.UnitType);
            int significantDigits = _settings.SignificantDigits;

            IQuantity quantityInUnit = quantity.ToUnit(unitEnumValue);

            return quantityInUnit.ToString(null, significantDigits);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!typeof(IQuantity).IsAssignableFrom(targetType))
                throw new ArgumentException("Expected targetType of type UnitsNet.IQuantity.", nameof(value));

            if (value == null ||
                !(value is string valueString) ||
                string.IsNullOrWhiteSpace(valueString))
            {
                return new ValidationResult(false, "Input is not valid. Expected a number or a string like \"1.5 kg\".");
            }

            try
            {
                // If input is just a number, use the configured default unit
                if (double.TryParse(valueString, out double number))
                {
                    Type unitEnumType = Quantity.Infos.First(qi => qi.ValueType == targetType).UnitType;
                    Enum defaultUnit = _settings.GetDefaultUnit(unitEnumType);
                    return Quantity.From(number, defaultUnit);
                }

                // Otherwise try to parse the string, such as "1.5 kg"
                return Quantity.Parse(targetType, valueString);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, e.InnerException?.Message ?? e.Message);
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ?? (_instance = new UnitToStringConverter());
        }
    }
}
