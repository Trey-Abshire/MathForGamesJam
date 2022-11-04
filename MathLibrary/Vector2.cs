namespace MathLibrary
{
    /// <summary>
    /// An object containing two floats.
    /// </summary>
    public struct Vector2
    {
        private float _x;
        private float _y;
        /// <summary>
        /// The first value of the vector.
        /// </summary>
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        /// <summary>
        /// The second value of the vector.
        /// </summary>
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        /// <summary>
        /// Gets the length of this vector.
        /// </summary>
        public float Magnitude
        {
            get
            {
                return (float) Math.Sqrt(X * X + Y * Y);
            }
        }
        /// <summary>
        /// Returns a copy of this vector that has a length of one.
        /// </summary>
        public Vector2 Normalized
        {
            get
            {
                if (Magnitude <= 0.0f)
                {
                    return new Vector2(0.0f, 0.0f);
                }

               Vector2 normalized = new Vector2 (X / Magnitude, Y / Magnitude);
                return normalized;
            }
        }
        /// <param name="x">The first value of the vector.</param>
        /// <param name="y">The second value of the vector.</param>
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
        /// <summary>
        /// Changes the length of this vector to have a magnitude that is equal to one.
        /// </summary>
        /// <returns>The result of the normalization.</returns>
        public Vector2 Normalize()
        {
            if (Magnitude <= 0.0f)
            {
                return new Vector2(0.0f, 0.0f);
            }

            X = X / Magnitude;
            Y = Y / Magnitude;

            return this;
        }
        /// <summary>
        /// Finds the dot product betwen the two vectors.
        /// </summary>
        /// <param name="a">The vector that will be used as the base.</param>
        /// <param name="b">The vector to project on to the other.</param>
        /// <returns>The dot product scalar value.</returns>
        public static float GetDotProduct(Vector2 a, Vector2 b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
        /// <summary>
        /// Finds the distance between two points.
        /// </summary>
        /// <param name="a">The starting position.</param>
        /// <param name="b">The ending position</param>
        /// <returns>The distance scalar value.</returns>
        public static float GetDistance(Vector2 a, Vector2 b)
        {
            return (b - a).Magnitude;
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs._x + rhs._x, lhs._y + rhs._y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs._x - rhs._x, lhs._y - rhs._y);
        }

        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.X * rhs, lhs.Y * rhs);
        }

        public static Vector2 operator *(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs * rhs.X, lhs * rhs.Y);   
        }

        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.X / rhs, lhs.Y / rhs);
        }

        public static Vector2 operator /(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs / rhs.X, lhs / rhs.Y);
        }
    }
}