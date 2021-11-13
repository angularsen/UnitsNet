using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace WpfMVVMSample.Converters
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _enumType;
        private Type EnumType
        {
            get => _enumType;
            set
            {
                if (value != _enumType)
                {
                    if (value != null)
                    {
                        Type enumType = Nullable.GetUnderlyingType(value) ?? value;

                        if (!enumType.IsEnum)
                            throw new ArgumentException("Type must be for an Enum.");
                    }

                    _enumType = value;
                }
            }
        }

        // Instantiated by GUI
        // ReSharper disable once UnusedMember.Global
        public EnumBindingSourceExtension() { }

        public EnumBindingSourceExtension(Type enumType)
        {
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_enumType== null)
                throw new InvalidOperationException("The EnumType must be specified.");

            Type actualEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;

            // Omits the first unit enum element, such as LengthUnit.Undefined
            IEnumerable<object> enumValues = Enum.GetValues(actualEnumType).Cast<Enum>().Skip(1);

            return enumValues;
        }
    }
}
