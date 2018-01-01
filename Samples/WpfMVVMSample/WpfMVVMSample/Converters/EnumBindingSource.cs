using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WpfMVVMSample.Converters
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _enumType;
        private Type EnumType
        {
            get { return this._enumType; }
            set
            {
                if (value != this._enumType)
                {
                    if (null != value)
                    {
                        Type enumType = Nullable.GetUnderlyingType(value) ?? value;

                        if (!enumType.IsEnum)
                            throw new ArgumentException("Type must be for an Enum.");
                    }

                    this._enumType = value;
                }
            }
        }

        public EnumBindingSourceExtension() { }

        public EnumBindingSourceExtension(Type enumType)
        {
            this.EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this._enumType== null)
                throw new InvalidOperationException("The EnumType must be specified.");

            Type actualEnumType = Nullable.GetUnderlyingType(this._enumType) ?? this._enumType;
            Array enumValues = Enum.GetValues(actualEnumType);

            //if (actualEnumType == this._enumType)
            //    return enumValues;

            //ommits the first enum element, typically "undefined"
            Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length -1);
            Array.ConstrainedCopy(enumValues,1,tempArray, 0,enumValues.Length-1);
            return tempArray;
        }
    }
}
