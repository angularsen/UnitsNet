// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    /// <summary>
    /// Represents a three-dimensional vector.
    /// </summary>
    /// <typeparam name="T">The unit type of the quantity.</typeparam>
    public class Vector3<T> : IEquatable<Vector3<T>>
    {
        /// <summary>
        /// Creates a new three-dimensional vector.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <param name="z">The Z component of the vector.</param>
        public Vector3(T x, T y, T z)
        {
            X = x ?? throw new ArgumentNullException(nameof(x));
            Y = y ?? throw new ArgumentNullException(nameof(y));
            Z = z ?? throw new ArgumentNullException(nameof(z));
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is Vector3<T> vector))
                return false;

            return Equals(vector);
        }

        /// <inheritdoc />
        public bool Equals(Vector3<T> other)
        {
            if(other is null)
                throw new ArgumentNullException(nameof(other));

            return X!.Equals(other.X) && Y!.Equals(other.Y) && Z!.Equals(other.Z);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return new {X, Y, Z}.GetHashCode();
        }

        /// <summary>
        /// Adds two three-dimensional vectors together.
        /// </summary>
        /// <param name="left">The left hand side vector.</param>
        /// <param name="right">The right hand side vector.</param>
        /// <returns>The added vector.</returns>
        public static Vector3<T> operator+(Vector3<T> left, Vector3<T> right)
        {
            var x = CompiledLambdas.Add(left.X, right.X);
            var y = CompiledLambdas.Add(left.Y, right.Y);
            var z = CompiledLambdas.Add(left.Z, right.Z);

            return new Vector3<T>(x, y, z);
        }

        /// <summary>
        /// The X component of the vector.
        /// </summary>
        public T X
        {
            get;
        }

        /// <summary>
        /// The Y component of the vector.
        /// </summary>
        public T Y
        {
            get;
        }

        /// <summary>
        /// The Z component of the vector.
        /// </summary>
        public T Z
        {
            get;
        }
    }
}
