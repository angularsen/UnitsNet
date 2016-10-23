function GenerateNumberExtensionsSourceCode($unitClass)
{
    $className = $unitClass.Name;
    $units = $unitClass.Units;
@"
// Copyright (c) 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
// https://github.com/anjdreas/UnitsNet
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

#if !WINDOWS_UWP
// Extension methods/overloads not supported in Universal Windows Platform (WinRT Components)
namespace UnitsNet.Extensions.NumberTo$className
{
    public static class NumberTo$($className)Extensions
    {
"@; foreach ($unit in $units) {
        # A few units share the exact same name across unit classes, which give extension method name conflicts.
        # We add "OmitExtensionMethod": true on all but one of the conflicting units in JSON.
        if ($unit.OmitExtensionMethod) { continue }@"
        #region $($unit.SingularName)

        /// <inheritdoc cref="$className.From$($unit.PluralName)(double)"/>
        public static $className $($unit.PluralName)(this int value) => $className.From$($unit.PluralName)(value);

        /// <inheritdoc cref="$className.From$($unit.PluralName)(double?)"/>
        public static $($className)? $($unit.PluralName)(this int? value) => $className.From$($unit.PluralName)(value);

        /// <inheritdoc cref="$className.From$($unit.PluralName)(double)"/>
        public static $className $($unit.PluralName)(this long value) => $className.From$($unit.PluralName)(value);

        /// <inheritdoc cref="$className.From$($unit.PluralName)(double?)"/>
        public static $($className)? $($unit.PluralName)(this long? value) => $className.From$($unit.PluralName)(value);

        /// <inheritdoc cref="$className.From$($unit.PluralName)(double)"/>
        public static $className $($unit.PluralName)(this double value) => $className.From$($unit.PluralName)(value);

        /// <inheritdoc cref="$className.From$($unit.PluralName)(double?)"/>
        public static $($className)? $($unit.PluralName)(this double? value) => $className.From$($unit.PluralName)(value);

        /// <inheritdoc cref="$className.From$($unit.PluralName)(double)"/>
        public static $className $($unit.PluralName)(this float value) => $className.From$($unit.PluralName)(value);

        /// <inheritdoc cref="$className.From$($unit.PluralName)(double?)"/>
        public static $($className)? $($unit.PluralName)(this float? value) => $className.From$($unit.PluralName)(value);

        /// <inheritdoc cref="$className.From$($unit.PluralName)(double)"/>
        public static $className $($unit.PluralName)(this decimal value) => $className.From$($unit.PluralName)(Convert.ToDouble(value));

        /// <inheritdoc cref="$className.From$($unit.PluralName)(double?)"/>
        public static $($className)? $($unit.PluralName)(this decimal? value) => $className.From$($unit.PluralName)(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

"@; }@"
    }
}
#endif
"@;
}