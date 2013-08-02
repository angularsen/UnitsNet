using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class UnitValueTests
    {
        [Test]
        public void TryConvertReturnsFalseOnIncompatibleUnits()
        {
            var val = new UnitValue(1, Unit.Meter);
            double newValue;
            Assert.False(val.TryConvert(Unit.Second, out newValue));
        }
    }
}
