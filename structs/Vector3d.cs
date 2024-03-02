﻿using System.Diagnostics.CodeAnalysis;

namespace GeometriCS.structs
{
    /// <summary>
    /// Three-dimensional vector with double precision.
    /// </summary>
    public struct Vector3d
    {
        /// <summary>
        /// Vector with 0 length.
        /// </summary>
        public static readonly Vector3d ZeroVector = new(0d, 0d, 0d);

        /// <summary>
        /// Unit vector following the X axis, or (1; 0; 0)
        /// </summary>
        public static readonly Vector3d XAxis = new(1d, 0d, 0d);

        /// <summary>
        /// Unit vector following the Y axis, or (0; 1; 0)
        /// </summary>
        public static readonly Vector3d YAxis = new(0d, 1d, 0d);

        /// <summary>
        /// Unit vector following the Z axis, or (0; 0; 1)
        /// </summary>
        public static readonly Vector3d ZAxis = new(0d, 1d, 1d);

        /// <summary>
        /// X component of the vector.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y component of the vector.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Z component of the vector.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Length of the vector.
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
            set
            {
                // If desired length is 0, set the components to 0 manually.
                if (IsZero)
                {
                    X = 0;
                    Y = 0;
                    Z = 0;
                    return;
                }

                // New length divided by the old Length.
                // Or, the scalar we need to apply to the vector in order for it to reach the desired length.
                double scaleDelta = value / Length;

                // Scale the vector by the scalar delta.
                X *= scaleDelta;
                Y *= scaleDelta;
                Z *= scaleDelta;
            }
        }

        /// <summary>
        /// Is this a zero vecor?
        /// </summary>
        public bool IsZero => Utils.DoubleEquals(Length, 0);

        /// <summary>
        /// Is this a unit vector?
        /// </summary>
        public bool IsUnit => Utils.DoubleEquals(Length, 1);

        /// <summary>
        /// Normalized, or unit version of the vector.
        /// </summary>
        /// <remarks>Calling this method does not affect the source vector.</remarks>
        /// <returns>Normalized vector, or <c>(0; 0; 0)</c> if original is <c>(0; 0; 0)</c>.</returns>
        public Vector3d Normalized()
        {
            // If this is a zero vector, return a zero vector.
            if (IsZero)
            {
                return new Vector3d(0, 0, 0);
            }

            // Get the inverse of the length of the vector,
            // Or the scalar we need to apply to the vector in order for it to reach the desired length.
            double scaleDelta = 1 / Length;

            // Return this vector scaled to have its Length equal to 1
            return new Vector3d(X * scaleDelta, Y * scaleDelta, Z * scaleDelta);
        }

        /// <summary>
        /// Compute the cross product between this and another vector.
        /// </summary>
        /// <param name="other">Other vector.</param>
        /// <returns>The cross product of the two vectors.</returns>
        public Vector3d CrossProduct(Vector3d other)
        {
            return new Vector3d(
                Y * other.Z - Z * other.Y,
                Z * other.X - X * other.Z,
                X * other.Y - Y * other.X);
        }

        /// <summary>
        /// Compute the dot product between this and another vector.
        /// </summary>
        /// <param name="other">Other vector.</param>
        /// <returns>The dot product of the two vectors.</returns>
        public double DotProduct(Vector3d other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        /// <summary>
        /// Get the vector needed to get from the point at the end of this vector to the end of another vector.
        /// </summary>
        /// <param name="other">The vector to get to the end of.</param>
        /// <returns>Vector leading from the tip of this vector to the tip of the other vector.</returns>
        public Vector3d GetVectorTo(Vector3d other)
        {
            return new Vector3d(-X + other.Y, -Y + other.Y, -Z + other.Z);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">X component of the vector.</param>
        /// <param name="x">X component of the vector.</param>
        /// <param name="z">Z component of the vector.</param>
        public Vector3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// String representation of the vector.
        /// </summary>
        /// <returns>(X; Y; Z)</returns>
        public override string ToString()
        {
            return $"({X}; {Y}; {Z})";
        }

        /// <summary>
        /// Do the two objects represent the same vector?
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><c>true</c> if the vectors are equal. Otherwise <c>false</c></returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector3d asVect)
            {
                return this == asVect;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        /// <summary>
        /// Negation of the vector.
        /// </summary>
        /// <param name="vect">Vector to negate.</param>
        /// <returns>Negated vector.</returns>
        public static Vector3d operator -(Vector3d vect)
        {
            return new Vector3d(-vect.X, -vect.Y, -vect.Z);
        }

        /// <summary>
        /// Are the vectors equal?
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns><c>true</c> if the vectors are equal. Otherwise <c>false</c></returns>
        public static bool operator ==(Vector3d a, Vector3d b)
        {
            return Utils.DoubleEquals(a.X, b.X) && Utils.DoubleEquals(a.Y, b.Y) && Utils.DoubleEquals(a.Z, b.Z);
        }

        /// <summary>
        /// Are the vectors different?
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns><c>true</c> if the vectors are different. Otherwise <c>false</c></returns>
        public static bool operator !=(Vector3d a, Vector3d b)
        {
            return !(Utils.DoubleEquals(a.X, b.X) && Utils.DoubleEquals(a.Y, b.Y) && Utils.DoubleEquals(a.Z, b.Z));
        }

        /// <summary>
        /// Add the vectors together.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>a + b</returns>
        public static Vector3d operator +(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Add the first vector and the negation of the second negation.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>a + (-b)</returns>
        public static Vector3d operator -(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Scale the vector by the scalar.
        /// </summary>
        /// <param name="vect">Vector.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>vect * scalar</returns>
        public static Vector3d operator *(Vector3d vect, double scalar)
        {
            return new Vector3d(vect.X * scalar, vect.Y * scalar, vect.Z * scalar);
        }

        /// <summary>
        /// Scale the vector by the inverse of the scalar.
        /// </summary>
        /// <param name="vect">Vector.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>vect * (1 / scalar)</returns>
        public static Vector3d operator /(Vector3d vect, double scalar)
        {
            if (Utils.DoubleEquals(scalar, 0))
            {
                throw new DivideByZeroException("Cannot divide by zero, silly.");
            }
            return new Vector3d(vect.X / scalar, vect.Y / scalar, vect.Z / scalar);
        }
    }
}
