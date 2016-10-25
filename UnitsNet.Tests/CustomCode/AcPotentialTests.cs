// Copyright © 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
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

using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
  public class AcPotentialTests : AcPotentialTestsBase
  {
    // TODO Override properties in base class here
    protected override double VoltsPeakInOneVoltPeak => 1;
    protected override double VoltsPeakToPeakInOneVoltPeak => 2;
    protected override double VoltsRMSInOneVoltPeak => 0.7071067811865475244008443621048490393;

    [Test]
    public void FromElectricPotential()
    {
      Assert.AreEqual(2.5, AcPotential.FromPeakElectricalPotential(ElectricPotential.FromMillivolts(2500)).VoltsPeak, VoltsPeakTolerance);
      Assert.AreEqual(102.5, AcPotential.FromRMSElectricalPotential(ElectricPotential.FromVolts(102.5)).VoltsRMS, VoltsRMSTolerance);
    }

    [Test]
    public void TakesAbsoluteValueOfInput()
    {
      Assert.AreEqual(1.4, new AcPotential((decimal) -1.4).VoltsPeak, VoltsPeakTolerance);
      Assert.AreEqual(12,new AcPotential((long) -12).VoltsPeak, VoltsPeakTolerance);
      Assert.AreEqual(1.2,new AcPotential(-1.2).VoltsPeak, VoltsPeakTolerance);
      Assert.AreEqual(15,new AcPotential(-15).VoltsPeak, VoltsPeakTolerance);
      Assert.AreEqual(2,AcPotential.FromVoltsPeak(-2).VoltsPeak, VoltsPeakTolerance);
      Assert.AreEqual(2.45,AcPotential.FromVoltsPeakToPeak(-2.45).VoltsPeakToPeak, VoltsPeakToPeakTolerance);
      Assert.AreEqual(2.78, AcPotential.FromVoltsRMS(-2.78).VoltsRMS, VoltsRMSTolerance);
    }
  }
}
