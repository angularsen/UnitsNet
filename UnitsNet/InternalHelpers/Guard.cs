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
using JetBrains.Annotations;

namespace UnitsNet.InternalHelpers
{
    /// <summary>
    ///     Guard methods to ensure parameter values satisfy pre-conditions and use a consistent exception message.
    /// </summary>
    internal static class Guard
    {
        /// <summary>
        ///     Throws <see cref="ArgumentException" /> if value is <see cref="double.NaN" />,
        ///     <see cref="double.PositiveInfinity" /> or <see cref="double.NegativeInfinity" />.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">Name of parameter in calling method.</param>
        /// <returns>The given <paramref name="value" /> if valid.</returns>
        /// <exception cref="ArgumentException">If <paramref name="value" /> is invalid.</exception>
        internal static double EnsureValidNumber(double value, [InvokerParameterName] string paramName)
        {
            if (double.IsNaN(value)) throw new ArgumentException("NaN is not a valid number.", paramName);
            if (double.IsInfinity(value)) throw new ArgumentException("PositiveInfinity or NegativeInfinity is not a valid number.", paramName);
            return value;
        }
    }
}
