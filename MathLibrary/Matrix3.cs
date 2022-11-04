using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    /// <summary>
    /// A 3 by 3 collection of floats.
    /// Organized using row major.
    /// </summary>
    public struct Matrix3
    { 
        private static Matrix3 _identity;
        public float M00, M01, M02;
        public float M10, M11, M12;
        public float M20, M21, M22;
        public Matrix3()
        {
            this = Identity;
        }

        public Matrix3(float m00, float m01, float m02,
                       float m10, float m11, float m12,
                       float m20, float m21, float m22)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
        }

        /// <summary>
        /// A base matrix that does nothing when multiplied by another.
        /// Useful for setting a default matrix value.
        /// </summary>
        public static Matrix3 Identity
        {
            get { return _identity; } 
            set { _identity = value; } 
        }

        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3
               (lhs.M00 + rhs.M00, lhs.M01 + rhs.M01, lhs.M02 + rhs.M02,
                lhs.M10 + rhs.M10, lhs.M11 + rhs.M11, lhs.M12 + rhs.M12,
                lhs.M20 + rhs.M20, lhs.M21 + rhs.M21, lhs.M22 + rhs.M22);
        }

        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3
               (lhs.M00 - rhs.M00, lhs.M01 - rhs.M01, lhs.M02 - rhs.M02,
                lhs.M10 - rhs.M10, lhs.M11 - rhs.M11, lhs.M12 - rhs.M12,
                lhs.M20 - rhs.M20, lhs.M21 - rhs.M21, lhs.M22 - rhs.M22);
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3
               (lhs.M00 * rhs.M00, lhs.M01 * rhs.M01, lhs.M02 * rhs.M02,
                lhs.M10 * rhs.M10, lhs.M11 * rhs.M11, lhs.M12 * rhs.M12,
                lhs.M20 * rhs.M20, lhs.M21 * rhs.M21, lhs.M22 * rhs.M22);
        }
    }
}
