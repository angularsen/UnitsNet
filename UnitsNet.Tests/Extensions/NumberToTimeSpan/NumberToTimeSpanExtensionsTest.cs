// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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
using Xunit;
using UnitsNet.Extensions.NumberToTimeSpan;

namespace UnitsNet.Tests.Extensions.NumberToTimeSpan
{
    public class NumberToTimeSpanExtensionsTest
    {
        [Fact]
        public void ExtensionMethodsReturnTimeSpanOfSameValue()
        {
            Assert.Equal(TimeSpan.FromDays(1), 1.d());
            Assert.Equal(TimeSpan.FromDays(1), 1L.d());
            Assert.Equal(TimeSpan.FromDays(1), 1f.d());
            Assert.Equal(TimeSpan.FromDays(1), 1d.d());
            Assert.Equal(TimeSpan.FromDays(1), 1m.d());

            Assert.Equal(TimeSpan.FromHours(1), 1.h());
            Assert.Equal(TimeSpan.FromHours(1), 1L.h());
            Assert.Equal(TimeSpan.FromHours(1), 1f.h());
            Assert.Equal(TimeSpan.FromHours(1), 1d.h());
            Assert.Equal(TimeSpan.FromHours(1), 1m.h());

            Assert.Equal(TimeSpan.FromMinutes(1), 1.m());
            Assert.Equal(TimeSpan.FromMinutes(1), 1L.m());
            Assert.Equal(TimeSpan.FromMinutes(1), 1f.m());
            Assert.Equal(TimeSpan.FromMinutes(1), 1d.m());
            Assert.Equal(TimeSpan.FromMinutes(1), 1m.m());

            Assert.Equal(TimeSpan.FromSeconds(1), 1.s());
            Assert.Equal(TimeSpan.FromSeconds(1), 1L.s());
            Assert.Equal(TimeSpan.FromSeconds(1), 1f.s());
            Assert.Equal(TimeSpan.FromSeconds(1), 1d.s());
            Assert.Equal(TimeSpan.FromSeconds(1), 1m.s());

            Assert.Equal(TimeSpan.FromMilliseconds(1), 1.ms());
            Assert.Equal(TimeSpan.FromMilliseconds(1), 1L.ms());
            Assert.Equal(TimeSpan.FromMilliseconds(1), 1f.ms());
            Assert.Equal(TimeSpan.FromMilliseconds(1), 1d.ms());
            Assert.Equal(TimeSpan.FromMilliseconds(1), 1m.ms());
        }
    }
}
