using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class VectorTests
    {
        [Fact]
        public void Constructor_InitializesProperties()
        {
            var lengthX = Length.FromMeters(1.0);
            var lengthY = Length.FromMeters(2.0);
            var lengthZ = Length.FromMeters(3.0);

            var vector = new Vector3<Length>(lengthX, lengthY, lengthZ);

            Assert.Equal(lengthX, vector.X);
            Assert.Equal(lengthY, vector.Y);
            Assert.Equal(lengthZ, vector.Z);
        }

        [Fact]
        public void Add_WithSameUnits()
        {
            var length1X = Length.FromMeters(1.0);
            var length1Y = Length.FromMeters(2.0);
            var length1Z = Length.FromMeters(3.0);
            var length2X = Length.FromMeters(4.0);
            var length2Y = Length.FromMeters(5.0);
            var length2Z = Length.FromMeters(6.0);

            var vector1 = new Vector3<Length>(length1X, length1Y, length1Z);
            var vector2 = new Vector3<Length>(length2X, length2Y, length2Z);

            var result = vector1 + vector2;

            var expectedX = Length.FromMeters(5.0);
            var expectedY = Length.FromMeters(7.0);
            var expectedZ = Length.FromMeters(9.0);

            Assert.Equal( new Vector3<Length>( expectedX, expectedY, expectedZ ), result );
        }
    }
}
