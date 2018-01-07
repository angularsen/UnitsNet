using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using UnitsNet;
using WpfMVVMSample.Settings;

namespace WpfMVVMSample.Converters
{
    public class UnitToStringConverter :MarkupExtension, IValueConverter
    {
        //http://www.thejoyofcode.com/WPF_Quick_Tip_Converters_as_MarkupExtensions.aspx
        private SettingsManager _settings;
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
            var unitType = value.GetType();
            var unitEnumType = unitType.GetProperty("BaseUnit").PropertyType;
            var unitEnumValue = _settings.GetDefaultUnit(unitEnumType);
            var significantDigits = _settings.SignificantDigits;

            var result = unitType
                    .GetMethod("ToString", new[] { unitEnumType, typeof(IFormatProvider), typeof(int) })
                    .Invoke(value, new object[] { unitEnumValue, null, significantDigits });

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var unitEnumType = targetType.GetProperty("BaseUnit").PropertyType;
            var unitEnumValue = _settings.GetDefaultUnit(unitEnumType);

            if ((string)value == "") return 0.0;

            double number;
            if (double.TryParse((string)value, out number))
                return ParseDouble(targetType, number, unitEnumType, unitEnumValue);

            try
            {
                return ParseUnit(value, targetType);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, e.InnerException.Message);
            }
        }


        private static object ParseDouble(Type targetType, double number, Type unitEnumType, object unitEnumValue)
        {
            return targetType
                .GetMethod("From", new[] { typeof(QuantityValue), unitEnumType })
                .Invoke(null, new object[] { (QuantityValue)number, unitEnumValue });
        }
        private static object ParseUnit(object value, Type targetType)
        {
            return targetType
                .GetMethod("Parse", new[] { typeof(string) })
                .Invoke(null, new object[] { value });
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ?? (_instance = new UnitToStringConverter());
        }
    }
}
