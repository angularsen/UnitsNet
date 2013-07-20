using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class ForceTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void NewtonToForceUnits()
        { 
            Force oneNewton = Force.FromNewtons(1);

            Assert.AreEqual(1E-3, oneNewton.Kilonewtons);
            Assert.AreEqual(1, oneNewton.Newtons);
            Assert.AreEqual(1E5, oneNewton.Dyne);
            Assert.AreEqual(0.10197, oneNewton.KilogramForce, Delta);
            Assert.AreEqual(0.10197, oneNewton.KiloPonds, Delta);
            Assert.AreEqual(0.22481, oneNewton.PoundForce, Delta);
            Assert.AreEqual(7.2330, oneNewton.Poundal, Delta);
        }

        [Test]
        public void ForceUnitsRoundTrip()
        {
            Force oneNewton = Force.FromNewtons(1);

            Assert.AreEqual(1, Force.FromNewtons(oneNewton.Newtons).Newtons, Delta);
            Assert.AreEqual(1, Force.FromKilonewtons(oneNewton.Kilonewtons).Newtons, Delta);
            Assert.AreEqual(1, Force.FromKilogramForce(oneNewton.KilogramForce).Newtons, Delta);
            Assert.AreEqual(1, Force.FromDyne(oneNewton.Dyne).Newtons, Delta);
            Assert.AreEqual(1, Force.FromKiloPonds(oneNewton.KiloPonds).Newtons, Delta);
            Assert.AreEqual(1, Force.FromPoundForce(oneNewton.PoundForce).Newtons, Delta);
            Assert.AreEqual(1, Force.FromPoundal(oneNewton.Poundal).Newtons, Delta);
        }
    }
}