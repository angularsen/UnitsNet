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

// ReSharper disable once CheckNamespace

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct AmountOfSubstance
    {
        /// <summary>
        ///     The Avogadro constant is the number of constituent particles, usually molecules, 
        ///     atoms or ions that are contained in the amount of substance given by one mole. It is the proportionality factor that relates 
        ///     the molar mass of a substance to the mass of a sample, is designated with the symbol NA or L[1], and has the value 
        ///     6.02214076e23 mol−1 in the International System of Units (SI).
        /// </summary>
        /// <remarks>
        ///     Pending revisions in the base set of SI units necessitated redefinitions of the concepts of chemical quantity. The Avogadro number,
        ///     and its definition, was deprecated in favor of the Avogadro constant and its definition. Based on measurements made through the
        ///     middle of 2017 which calculated a value for the Avogadro constant of NA = 6.022140758(62)×1023 mol−1, the redefinition of SI units
        ///     is planned to take effect on 20 May 2019. The value of the constant will be fixed to exactly 6.02214076×1023 mol−1.
        ///     See here: https://www.bipm.org/utils/common/pdf/CGPM-2018/26th-CGPM-Resolutions.pdf
        /// </remarks>
        public static double AvogadroConstant { get; } = 6.02214076e23;

        /// <summary>
        /// Calculates the number of particles (atoms or molecules) in this amount of substance using the <see cref="AvogadroConstant"/>.
        /// </summary>
        /// <returns>The number of particles (atoms or molecules) in this amount of substance.</returns>
        public double NumberOfParticles()
        {
            var moles = GetValueAs(AmountOfSubstanceUnit.Mole);
            return AvogadroConstant * moles;
        }
    }
}
