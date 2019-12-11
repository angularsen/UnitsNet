// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using JetBrains.Annotations;

namespace UnitsNet.Tests
{
    internal class DummyIQuantity : IQuantity
    {
        public QuantityType Type => throw new NotImplementedException();

        public BaseDimensions Dimensions => throw new NotImplementedException();

        public QuantityInfo QuantityInfo => throw new NotImplementedException();

        public Enum Unit => throw new NotImplementedException();

        public double Value => throw new NotImplementedException();

        public double As(Enum unit)
        {
            throw new NotImplementedException();
        }

        public double As(UnitSystem unitSystem)
        {
            throw new NotImplementedException();
        }

        public string ToString([CanBeNull] IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString([CanBeNull] IFormatProvider provider, int significantDigitsAfterRadix)
        {
            throw new NotImplementedException();
        }

        public string ToString([CanBeNull] IFormatProvider provider, [NotNull] string format, [NotNull] params object[] args)
        {
            throw new NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public IQuantity ToUnit(Enum unit)
        {
            throw new NotImplementedException();
        }

        public IQuantity ToUnit(UnitSystem unitSystem)
        {
            throw new NotImplementedException();
        }
    }
}
