// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UnitsNet.Tests.Helpers
{
    /// <summary>
    /// Is used to imitate e property with attributes
    /// </summary>
    public class TypeDescriptorContext : ITypeDescriptorContext
    {
        public class PropertyDescriptor_ : PropertyDescriptor
        {
            public PropertyDescriptor_(string name, Attribute[] attributes) : base(name, attributes)
            {

            }

            public override Type ComponentType => throw new NotImplementedException();

            public override bool IsReadOnly => throw new NotImplementedException();

            public override Type PropertyType => throw new NotImplementedException();

            public override bool CanResetValue(object component)
            {
                throw new NotImplementedException();
            }

            public override object GetValue(object component)
            {
                throw new NotImplementedException();
            }

            public override void ResetValue(object component)
            {
                throw new NotImplementedException();
            }

            public override void SetValue(object component, object value)
            {
                throw new NotImplementedException();
            }

            public override bool ShouldSerializeValue(object component)
            {
                throw new NotImplementedException();
            }
        }

        public TypeDescriptorContext(string name, Attribute[] attributes)
        {
            PropertyDescriptor = new PropertyDescriptor_(name, attributes);
        }

        public IContainer Container => throw new NotImplementedException();

        public object Instance => throw new NotImplementedException();

        public PropertyDescriptor PropertyDescriptor { get; set; }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public void OnComponentChanged()
        {
            throw new NotImplementedException();
        }

        public bool OnComponentChanging()
        {
            throw new NotImplementedException();
        }
    }
}
