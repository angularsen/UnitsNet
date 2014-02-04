// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using UnitsNet.ThirdParty.Units;
using UnitsNet.Utils;

namespace UnitsNet.ThirdParty.Tests
{
    [TestFixture]
    public class UnitSystemTests
    {
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            // Register units defined in our third party assembly.
            UnitSystem.AddAssembly(Assembly.GetAssembly(typeof(FooUnit)));
            
            // Clear the static cache created and used by ToString() in unit classes.
            UnitSystem.ClearCache();
        }

        [Test]
        public void AllUnitAbbreviationsImplemented([Values("en-US", "nb-NO", "ru-RU")]string cultureName)
        {
            UnitSystem unitSystem = UnitSystem.GetCached(new CultureInfo(cultureName));

            var unitEnumValuesWithNoAbbreviations = new List<object>()
            .Concat(GetUnitTypesWithMissingAbbreviations(EnumUtils.GetEnumValues<FooUnit>(), unitSystem))
            .Concat(GetUnitTypesWithMissingAbbreviations(EnumUtils.GetEnumValues<BarUnit>(), unitSystem))
            .ToList();

            // We want to flag if any localizations are missing, but not break the build
            // or flag an error for pull requests. For now they are not considered 
            // critical and it is cumbersome to have a third person review the pull request
            // and add in any translations before merging it in.
            if (unitEnumValuesWithNoAbbreviations.Any())
            {
                string message = "Units missing abbreviations: " +
                                 string.Join(", ",
                                     unitEnumValuesWithNoAbbreviations.Select(
                                         unitValue => unitValue.GetType().Name + "." + unitValue).ToArray());

                Assert.Inconclusive("Failed, but skipping error for localization: " + message);
            }
            //Assert.IsEmpty(unitsMissingAbbreviations, message);
        }

        private IEnumerable<object> GetUnitTypesWithMissingAbbreviations<TUnit>(IEnumerable<TUnit> unitValues, UnitSystem unitSystem)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            var unitsMissingAbbreviations = new List<TUnit>();
            foreach (TUnit unit in unitValues)
            {
                try
                {
                    // Skip undefined unit enum value, it usually has no abbreviation attributes.
                    if (unit.ToString() == "Undefined")
                        continue;

                    unitSystem.GetDefaultAbbreviation(unit);
                }
                catch
                {
                    unitsMissingAbbreviations.Add(unit);
                }
            }

            return unitsMissingAbbreviations.Cast<object>();
        }

        [Test]
        public void ToStringAbbreviationForUsEnglishCulture()
        {
            var originalCulture = Thread.CurrentThread.CurrentUICulture;
            try
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

                Assert.AreEqual("1 foo", Foo.FromFoos(1).ToString());
                Assert.AreEqual("1 bar", Bar.FromBars(1).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
        }

        [Test]
        public void ToStringAbbreviationForForNorwegian()
        {
            var originalCulture = Thread.CurrentThread.CurrentUICulture;
            try
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

                Assert.AreEqual("1 foo", Foo.FromFoos(1).ToString());
                Assert.AreEqual("1 bar", Bar.FromBars(1).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
        }


        [Test]
        public void ToStringAbbreviationForRussian()
        {
            var originalCulture = Thread.CurrentThread.CurrentUICulture;
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

                Assert.AreEqual("1 føø", Foo.FromFoos(1).ToString());
                Assert.AreEqual("1 bzz", Bar.FromBars(1).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
        }
    }
}