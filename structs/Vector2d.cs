using System.Diagnostics.CodeAnalysis;

namespace GeometriCS.structs
{
    /// <summary>
    /// Two-dimensional vector with double precision.
    /// </summary>
    public struct Vector2d
    {
        /// <summary>
        /// Vector with 0 length.
        /// </summary>
        public static readonly Vector2d ZeroVector = new(0d, 0d);

        /// <summary>
        /// Unit vector following the X axis, or (1; 0)
        /// </summary>
        public static readonly Vector2d XAxis = new(1d, 0d);

        /// <summary>
        /// Unit vector following the Y axis, or (0; 1)
        /// </summary>
        public static readonly Vector2d YAxis = new(0d, 1d);

        /// <summary>
        /// X component of the vector.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y component of the vector.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Length of the vector.
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(X*X + Y*Y);
            }
            set
            {
                // If desired length is 0, set the components to 0 manually.
                if(IsZero) 
                {
                    X = 0;
                    Y = 0;
                    return;
                }

                // New length divided by the old Length.
                // Or, the scalar we need to apply to the vector in order for it to reach the desired length.
                double scaleDelta = value / Length;

                // Scale the vector by the scalar delta.
                X *= scaleDelta;
                Y *= scaleDelta;
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
        /// <returns>Normalized vector, or <c>(0; 0)</c> if original is <c>(0; 0)</c>.</returns>
        public Vector2d Normalized()
        {
            // If this is a zero vector, return a zero vector.
            if(IsZero)
            {
                return new Vector2d(0, 0);
            }

            // Get the inverse of the length of the vector,
            // Or the scalar we need to apply to the vector in order for it to reach the desired length.
            double scaleDelta = 1 / Length;

            // Return this vector scaled to have its Length equal to 1
            return new Vector2d(X * scaleDelta, Y * scaleDelta);
        }

        /// <summary>
        /// Compute the cross product between this and another vector.
        /// </summary>
        /// <remarks>
        /// Determinant of a matrix made of the two vectors.
        /// </remarks>
        /// <param name="other">Other vector.</param>
        /// <returns>The cross product of the two vectors.</returns>
        public double CrossProduct(Vector2d other)
        {
            // Compute the determinant by the rule of Sarrus
            return (X * other.Y) - (Y * other.X);
        }

        /// <summary>
        /// Compute the dot product between this and another vector.
        /// </summary>
        /// <param name="other">Other vector.</param>
        /// <returns>The dot product of the two vectors.</returns>
        public double DotProduct(Vector2d other)
        {
            return X * other.X + Y * other.Y;
        }

        /// <summary>
        /// Get the vector needed to get from the point at the end of this vector to the end of another vector.
        /// </summary>
        /// <param name="other">The vector to get to the end of.</param>
        /// <returns>Vector leading from the tip of this vector to the tip of the other vector.</returns>
        public Vector2d GetVectorTo(Vector2d other)
        {
            return new Vector2d(-X + other.Y, -Y + other.Y);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">X component of the vector.</param>
        /// <param name="y">Y component of the vector.</param>
        public Vector2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// String representation of the vector.
        /// </summary>
        /// <returns>(X; Y)</returns>
        public override string ToString()
        {
            return $"({X}; {Y})";
        }

        /// <summary>
        /// Do the two objects represent the same vector?
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><c>true</c> if the vectors are equal. Otherwise <c>false</c></returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2d asVect)
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
            return HashCode.Combine(X, Y);
        }

        /// <summary>
        /// Negation of the vector.
        /// </summary>
        /// <param name="vect">Vector to negate.</param>
        /// <returns>Negated vector.</returns>
        public static Vector2d operator -(Vector2d vect)
        {
            return new Vector2d(-vect.X, -vect.Y);
        }

        /// <summary>
        /// Are the vectors equal?
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns><c>true</c> if the vectors are equal. Otherwise <c>false</c></returns>
        public static bool operator ==(Vector2d a, Vector2d b)
        {
            return Utils.DoubleEquals(a.X, b.X) && Utils.DoubleEquals(a.Y, b.Y);
        }

        /// <summary>
        /// Are the vectors different?
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns><c>true</c> if the vectors are different. Otherwise <c>false</c></returns>
        public static bool operator !=(Vector2d a, Vector2d b)
        {
            return !(Utils.DoubleEquals(a.X, b.X) && Utils.DoubleEquals(a.Y, b.Y));
        }

        /// <summary>
        /// Add the vectors together.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>a + b</returns>
        public static Vector2d operator +(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.X + b.X, a.Y + b.Y);
        }

        /// <summary>
        /// Add the first vector and the negation of the second negation.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>a + (-b)</returns>
        public static Vector2d operator -(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.X - b.X, a.Y - b.Y);
        }

        /// <summary>
        /// Scale the vector by the scalar.
        /// </summary>
        /// <param name="vect">Vector.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>vect * scalar</returns>
        public static Vector2d operator *(Vector2d vect, double scalar)
        {
            return new Vector2d(vect.X * scalar, vect.Y * scalar);
        }

        /// <summary>
        /// Scale the vector by the inverse of the scalar.
        /// </summary>
        /// <param name="vect">Vector.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>vect * (1 / scalar)</returns>
        public static Vector2d operator /(Vector2d vect, double scalar)
        {
            if(Utils.DoubleEquals(scalar, 0))
            {
                throw new DivideByZeroException("Cannot divide by zero, silly.");
            }
            return new Vector2d(vect.X / scalar, vect.Y / scalar);
        }
    }
}
