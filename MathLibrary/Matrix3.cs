﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Matrix3
    {
        public float M00, M01, M02, M10, M11, M12, M20, M21, M22;

        public Matrix3(float m00, float m01, float m02,
                       float m10, float m11, float m12,
                       float m20, float m21, float m22)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
        }

        public static Matrix3 Identity
        {
            get
            {
                return new Matrix3(1, 0, 0,
                                   0, 1, 0,
                                   0, 0, 1);
            }
        }

        /// <summary>
        /// Creates a new matric that has been rotated by the given value in radians
        /// </summary>
        /// <param name="raidans"></param>
        /// <returns>The result of the rotation</returns>
        public static Matrix3 CreateRotation(float radians)
        {

        }

        /// <summary>
        /// Creates a new matix that has been translted by the
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Matrix3 CreateTranslation(float x, float y)
        {

        }

        /// <summary>
        /// Creates a new matrix that has been scaled by the given value
        /// </summary>
        /// <param name="x">the value to use to scale the materix in the x axis</param>
        /// <param name="y">the value to use to scale the materix in the y axis</param>
        /// <returns>The result of the scale</returns>
        public static Matrix3 CreateScale(float x, float y)
        {

        }
        
        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {

        }

        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {

        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {

        }
    }
}
