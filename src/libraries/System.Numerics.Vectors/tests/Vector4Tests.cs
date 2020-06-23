/*********************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx     *
 * script in tests\src\libraries\System.Numerics.Vectors\tests. In order to make *
 * changes, please update the corresponding template and run according to the    *
 * directions listed in the file.                                                *
 *********************************************************************************/
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Globalization;
using System.Runtime.InteropServices;
using Xunit;

namespace System.Numerics.Tests
{
    public partial class Vector4Tests
    {
        [Fact]
        public void Vector4CopyToTest()
        {
            Vector4 v1 = new Vector4(2.5f, 2.0f, 3.0f, 3.3f);

            var a = new Single[5];
            var b = new Single[4];

            Assert.Throws<ArgumentOutOfRangeException>(() => v1.CopyTo(a, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => v1.CopyTo(a, a.Length));

            v1.CopyTo(a, 1);
            v1.CopyTo(b);
            Assert.Equal(0.0f, a[0]);
            Assert.Equal(2.5f, a[1]);
            Assert.Equal(2.0f, a[2]);
            Assert.Equal(3.0f, a[3]);
            Assert.Equal(3.3f, a[4]);
            Assert.Equal(2.5f, b[0]);
            Assert.Equal(2.0f, b[1]);
            Assert.Equal(3.0f, b[2]);
            Assert.Equal(3.3f, b[3]);
        }

        [Fact]
        public void Vector4GetHashCodeTest()
        {
            Vector4 v1 = new Vector4(2.5f, 2.0f, 3.0f, 3.3f);
            Vector4 v2 = new Vector4(2.5f, 2.0f, 3.0f, 3.3f);
            Vector4 v3 = new Vector4(2.5f, 2.0f, 3.0f, 3.3f);
            Vector4 v5 = new Vector4(3.3f, 3.0f, 2.0f, 2.5f);
            Assert.Equal(v1.GetHashCode(), v1.GetHashCode());
            Assert.Equal(v1.GetHashCode(), v2.GetHashCode());
            Assert.NotEqual(v1.GetHashCode(), v5.GetHashCode());
            Assert.Equal(v1.GetHashCode(), v3.GetHashCode());
            Vector4 v4 = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Vector4 v6 = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
            Vector4 v7 = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
            Vector4 v8 = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            Vector4 v9 = new Vector4(1.0f, 1.0f, 0.0f, 0.0f);
            Assert.NotEqual(v4.GetHashCode(), v6.GetHashCode());
            Assert.NotEqual(v4.GetHashCode(), v7.GetHashCode());
            Assert.NotEqual(v4.GetHashCode(), v8.GetHashCode());
            Assert.NotEqual(v7.GetHashCode(), v6.GetHashCode());
            Assert.NotEqual(v8.GetHashCode(), v6.GetHashCode());
            Assert.NotEqual(v8.GetHashCode(), v7.GetHashCode());
            Assert.NotEqual(v9.GetHashCode(), v7.GetHashCode());
        }

        [Fact]
        public void Vector4ToStringTest()
        {
            string separator = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
            CultureInfo enUsCultureInfo = new CultureInfo("en-US");

            Vector4 v1 = new Vector4(2.5f, 2.0f, 3.0f, 3.3f);

            string v1str = v1.ToString();
            string expectedv1 = string.Format(CultureInfo.CurrentCulture
                , "<{1:G}{0} {2:G}{0} {3:G}{0} {4:G}>"
                , separator, 2.5, 2, 3, 3.3);
            Assert.Equal(expectedv1, v1str);

            string v1strformatted = v1.ToString("c", CultureInfo.CurrentCulture);
            string expectedv1formatted = string.Format(CultureInfo.CurrentCulture
                , "<{1:c}{0} {2:c}{0} {3:c}{0} {4:c}>"
                , separator, 2.5, 2, 3, 3.3);
            Assert.Equal(expectedv1formatted, v1strformatted);

            string v2strformatted = v1.ToString("c", enUsCultureInfo);
            string expectedv2formatted = string.Format(enUsCultureInfo
                , "<{1:c}{0} {2:c}{0} {3:c}{0} {4:c}>"
                , enUsCultureInfo.NumberFormat.NumberGroupSeparator, 2.5, 2, 3, 3.3);
            Assert.Equal(expectedv2formatted, v2strformatted);

            string v3strformatted = v1.ToString("c");
            string expectedv3formatted = string.Format(CultureInfo.CurrentCulture
                , "<{1:c}{0} {2:c}{0} {3:c}{0} {4:c}>"
                , separator, 2.5, 2, 3, 3.3);
            Assert.Equal(expectedv3formatted, v3strformatted);
        }

        // A test for DistanceSquared (Vector4f, Vector4f)
        [Fact]
        public void Vector4DistanceSquaredTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 6.0f, 7.0f, 8.0f);

            Single expected = 64.0f;
            Single actual;

            actual = Vector4.DistanceSquared(a, b);
            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector4f.DistanceSquared did not return the expected value.");
        }

        // A test for Distance (Vector4f, Vector4f)
        [Fact]
        public void Vector4DistanceTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 6.0f, 7.0f, 8.0f);

            Single expected = 8.0f;
            Single actual;

            actual = Vector4.Distance(a, b);
            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector4f.Distance did not return the expected value.");
        }

        // A test for Distance (Vector4f, Vector4f)
        // Distance from the same point
        [Fact]
        public void Vector4DistanceTest1()
        {
            Vector4 a = new Vector4(new Vector2(1.051f, 2.05f), 3.478f, 1.0f);
            Vector4 b = new Vector4(new Vector3(1.051f, 2.05f, 3.478f), 0.0f);
            b.W = 1.0f;

            Single actual = Vector4.Distance(a, b);
            Assert.Equal(0.0f, actual);
        }

        // A test for Dot (Vector4f, Vector4f)
        [Fact]
        public void Vector4DotTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 6.0f, 7.0f, 8.0f);

            Single expected = 70.0f;
            Single actual;

            actual = Vector4.Dot(a, b);
            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector4f.Dot did not return the expected value.");
        }

        // A test for Dot (Vector4f, Vector4f)
        // Dot test for perpendicular vector
        [Fact]
        public void Vector4DotTest1()
        {
            Vector3 a = new Vector3(1.55f, 1.55f, 1);
            Vector3 b = new Vector3(2.5f, 3, 1.5f);
            Vector3 c = Vector3.Cross(a, b);

            Vector4 d = new Vector4(a, 0);
            Vector4 e = new Vector4(c, 0);

            Single actual = Vector4.Dot(d, e);
            Assert.True(MathHelper.EqualScalar(0.0f, actual), "Vector4f.Dot did not return the expected value.");
        }

        // A test for Length ()
        [Fact]
        public void Vector4LengthTest()
        {
            Vector3 a = new Vector3(1.0f, 2.0f, 3.0f);
            Single w = 4.0f;

            Vector4 target = new Vector4(a, w);

            Single expected = (Single)System.Math.Sqrt(30.0f);
            Single actual;

            actual = target.Length();

            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Length did not return the expected value.");
        }

        // A test for Length ()
        // Length test where length is zero
        [Fact]
        public void Vector4LengthTest1()
        {
            Vector4 target = new Vector4();

            Single expected = 0.0f;
            Single actual = target.Length();

            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector4f.Length did not return the expected value.");
        }

        // A test for LengthSquared ()
        [Fact]
        public void Vector4LengthSquaredTest()
        {
            Vector3 a = new Vector3(1.0f, 2.0f, 3.0f);
            Single w = 4.0f;

            Vector4 target = new Vector4(a, w);

            Single expected = 30;
            Single actual;

            actual = target.LengthSquared();

            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector4f.LengthSquared did not return the expected value.");
        }

        // A test for Min (Vector4f, Vector4f)
        [Fact]
        public void Vector4MinTest()
        {
            Vector4 a = new Vector4(-1.0f, 4.0f, -3.0f, 1000.0f);
            Vector4 b = new Vector4(2.0f, 1.0f, -1.0f, 0.0f);

            Vector4 expected = new Vector4(-1.0f, 1.0f, -3.0f, 0.0f);
            Vector4 actual;
            actual = Vector4.Min(a, b);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Min did not return the expected value.");
        }

        // A test for Max (Vector4f, Vector4f)
        [Fact]
        public void Vector4MaxTest()
        {
            Vector4 a = new Vector4(-1.0f, 4.0f, -3.0f, 1000.0f);
            Vector4 b = new Vector4(2.0f, 1.0f, -1.0f, 0.0f);

            Vector4 expected = new Vector4(2.0f, 4.0f, -1.0f, 1000.0f);
            Vector4 actual;
            actual = Vector4.Max(a, b);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Max did not return the expected value.");
        }

        [Fact]
        public void Vector4MinMaxCodeCoverageTest()
        {
            Vector4 min = Vector4.Zero;
            Vector4 max = Vector4.One;
            Vector4 actual;

            // Min.
            actual = Vector4.Min(min, max);
            Assert.Equal(actual, min);

            actual = Vector4.Min(max, min);
            Assert.Equal(actual, min);

            // Max.
            actual = Vector4.Max(min, max);
            Assert.Equal(actual, max);

            actual = Vector4.Max(max, min);
            Assert.Equal(actual, max);
        }

        // A test for Clamp (Vector4f, Vector4f, Vector4f)
        [Fact]
        public void Vector4ClampTest()
        {
            Vector4 a = new Vector4(0.5f, 0.3f, 0.33f, 0.44f);
            Vector4 min = new Vector4(0.0f, 0.1f, 0.13f, 0.14f);
            Vector4 max = new Vector4(1.0f, 1.1f, 1.13f, 1.14f);

            // Normal case.
            // Case N1: specified value is in the range.
            Vector4 expected = new Vector4(0.5f, 0.3f, 0.33f, 0.44f);
            Vector4 actual = Vector4.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Clamp did not return the expected value.");

            // Normal case.
            // Case N2: specified value is bigger than max value.
            a = new Vector4(2.0f, 3.0f, 4.0f, 5.0f);
            expected = max;
            actual = Vector4.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Clamp did not return the expected value.");

            // Case N3: specified value is smaller than max value.
            a = new Vector4(-2.0f, -3.0f, -4.0f, -5.0f);
            expected = min;
            actual = Vector4.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Clamp did not return the expected value.");

            // Case N4: combination case.
            a = new Vector4(-2.0f, 0.5f, 4.0f, -5.0f);
            expected = new Vector4(min.X, a.Y, max.Z, min.W);
            actual = Vector4.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Clamp did not return the expected value.");

            // User specified min value is bigger than max value.
            max = new Vector4(0.0f, 0.1f, 0.13f, 0.14f);
            min = new Vector4(1.0f, 1.1f, 1.13f, 1.14f);

            // Case W1: specified value is in the range.
            a = new Vector4(0.5f, 0.3f, 0.33f, 0.44f);
            expected = max;
            actual = Vector4.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Clamp did not return the expected value.");

            // Normal case.
            // Case W2: specified value is bigger than max and min value.
            a = new Vector4(2.0f, 3.0f, 4.0f, 5.0f);
            expected = max;
            actual = Vector4.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Clamp did not return the expected value.");

            // Case W3: specified value is smaller than min and max value.
            a = new Vector4(-2.0f, -3.0f, -4.0f, -5.0f);
            expected = max;
            actual = Vector4.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Clamp did not return the expected value.");
        }

        // A test for Lerp (Vector4f, Vector4f, Single)
        [Fact]
        public void Vector4LerpTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 6.0f, 7.0f, 8.0f);

            Single t = 0.5f;

            Vector4 expected = new Vector4(3.0f, 4.0f, 5.0f, 6.0f);
            Vector4 actual;

            actual = Vector4.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector4f, Vector4f, Single)
        // Lerp test with factor zero
        [Fact]
        public void Vector4LerpTest1()
        {
            Vector4 a = new Vector4(new Vector3(1.0f, 2.0f, 3.0f), 4.0f);
            Vector4 b = new Vector4(4.0f, 5.0f, 6.0f, 7.0f);

            Single t = 0.0f;
            Vector4 expected = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 actual = Vector4.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector4f, Vector4f, Single)
        // Lerp test with factor one
        [Fact]
        public void Vector4LerpTest2()
        {
            Vector4 a = new Vector4(new Vector3(1.0f, 2.0f, 3.0f), 4.0f);
            Vector4 b = new Vector4(4.0f, 5.0f, 6.0f, 7.0f);

            Single t = 1.0f;
            Vector4 expected = new Vector4(4.0f, 5.0f, 6.0f, 7.0f);
            Vector4 actual = Vector4.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector4f, Vector4f, Single)
        // Lerp test with factor > 1
        [Fact]
        public void Vector4LerpTest3()
        {
            Vector4 a = new Vector4(new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
            Vector4 b = new Vector4(4.0f, 5.0f, 6.0f, 7.0f);

            Single t = 2.0f;
            Vector4 expected = new Vector4(8.0f, 10.0f, 12.0f, 14.0f);
            Vector4 actual = Vector4.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector4f, Vector4f, Single)
        // Lerp test with factor < 0
        [Fact]
        public void Vector4LerpTest4()
        {
            Vector4 a = new Vector4(new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
            Vector4 b = new Vector4(4.0f, 5.0f, 6.0f, 7.0f);

            Single t = -2.0f;
            Vector4 expected = -(b * 2);
            Vector4 actual = Vector4.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector4f, Vector4f, Single)
        // Lerp test from the same point
        [Fact]
        public void Vector4LerpTest5()
        {
            Vector4 a = new Vector4(4.0f, 5.0f, 6.0f, 7.0f);
            Vector4 b = new Vector4(4.0f, 5.0f, 6.0f, 7.0f);

            Single t = 0.85f;
            Vector4 expected = a;
            Vector4 actual = Vector4.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Lerp did not return the expected value.");
        }

        // A test for Transform (Vector2f, Matrix4x4)
        [Fact]
        public void Vector4TransformTest1()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector4 expected = new Vector4(10.316987f, 22.183012f, 30.3660259f, 1.0f);
            Vector4 actual;

            actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Matrix4x4)
        [Fact]
        public void Vector4TransformTest2()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector4 expected = new Vector4(12.19198728f, 21.53349376f, 32.61602545f, 1.0f);
            Vector4 actual;

            actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "vector4.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4f, Matrix4x4)
        [Fact]
        public void Vector4TransformVector4Test()
        {
            Vector4 v = new Vector4(1.0f, 2.0f, 3.0f, 0.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector4 expected = new Vector4(2.19198728f, 1.53349376f, 2.61602545f, 0.0f);
            Vector4 actual;

            actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");

            //
            v.W = 1.0f;

            expected = new Vector4(12.19198728f, 21.53349376f, 32.61602545f, 1.0f);
            actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4f, Matrix4x4)
        // Transform vector4 with zero matrix
        [Fact]
        public void Vector4TransformVector4Test1()
        {
            Vector4 v = new Vector4(1.0f, 2.0f, 3.0f, 0.0f);
            Matrix4x4 m = new Matrix4x4();
            Vector4 expected = new Vector4(0, 0, 0, 0);

            Vector4 actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4f, Matrix4x4)
        // Transform vector4 with identity matrix
        [Fact]
        public void Vector4TransformVector4Test2()
        {
            Vector4 v = new Vector4(1.0f, 2.0f, 3.0f, 0.0f);
            Matrix4x4 m = Matrix4x4.Identity;
            Vector4 expected = new Vector4(1.0f, 2.0f, 3.0f, 0.0f);

            Vector4 actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Matrix4x4)
        // Transform Vector3f test
        [Fact]
        public void Vector4TransformVector3Test()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector4 expected = Vector4.Transform(new Vector4(v, 1.0f), m);
            Vector4 actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Matrix4x4)
        // Transform vector3 with zero matrix
        [Fact]
        public void Vector4TransformVector3Test1()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);
            Matrix4x4 m = new Matrix4x4();
            Vector4 expected = new Vector4(0, 0, 0, 0);

            Vector4 actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Matrix4x4)
        // Transform vector3 with identity matrix
        [Fact]
        public void Vector4TransformVector3Test2()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);
            Matrix4x4 m = Matrix4x4.Identity;
            Vector4 expected = new Vector4(1.0f, 2.0f, 3.0f, 1.0f);

            Vector4 actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Matrix4x4)
        // Transform Vector2f test
        [Fact]
        public void Vector4TransformVector2Test()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector4 expected = Vector4.Transform(new Vector4(v, 0.0f, 1.0f), m);
            Vector4 actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Matrix4x4)
        // Transform Vector2f with zero matrix
        [Fact]
        public void Vector4TransformVector2Test1()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Matrix4x4 m = new Matrix4x4();
            Vector4 expected = new Vector4(0, 0, 0, 0);

            Vector4 actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Matrix4x4)
        // Transform vector2 with identity matrix
        [Fact]
        public void Vector4TransformVector2Test2()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Matrix4x4 m = Matrix4x4.Identity;
            Vector4 expected = new Vector4(1.0f, 2.0f, 0, 1.0f);

            Vector4 actual = Vector4.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Quaternion)
        [Fact]
        public void Vector4TransformVector2QuatanionTest()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));

            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector4 expected = Vector4.Transform(v, m);
            Vector4 actual;

            actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Quaternion)
        [Fact]
        public void Vector4TransformVector3Quaternion()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector4 expected = Vector4.Transform(v, m);
            Vector4 actual;

            actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "vector4.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4f, Quaternion)
        [Fact]
        public void Vector4TransformVector4QuaternionTest()
        {
            Vector4 v = new Vector4(1.0f, 2.0f, 3.0f, 0.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector4 expected = Vector4.Transform(v, m);
            Vector4 actual;

            actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");

            //
            v.W = 1.0f;
            expected.W = 1.0f;
            actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4f, Quaternion)
        // Transform vector4 with zero quaternion
        [Fact]
        public void Vector4TransformVector4QuaternionTest1()
        {
            Vector4 v = new Vector4(1.0f, 2.0f, 3.0f, 0.0f);
            Quaternion q = new Quaternion();
            Vector4 expected = v;

            Vector4 actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4f, Quaternion)
        // Transform vector4 with identity matrix
        [Fact]
        public void Vector4TransformVector4QuaternionTest2()
        {
            Vector4 v = new Vector4(1.0f, 2.0f, 3.0f, 0.0f);
            Quaternion q = Quaternion.Identity;
            Vector4 expected = new Vector4(1.0f, 2.0f, 3.0f, 0.0f);

            Vector4 actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Quaternion)
        // Transform Vector3f test
        [Fact]
        public void Vector4TransformVector3QuaternionTest()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector4 expected = Vector4.Transform(v, m);
            Vector4 actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Quaternion)
        // Transform vector3 with zero quaternion
        [Fact]
        public void Vector4TransformVector3QuaternionTest1()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);
            Quaternion q = new Quaternion();
            Vector4 expected = new Vector4(v, 1.0f);

            Vector4 actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Quaternion)
        // Transform vector3 with identity quaternion
        [Fact]
        public void Vector4TransformVector3QuaternionTest2()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);
            Quaternion q = Quaternion.Identity;
            Vector4 expected = new Vector4(1.0f, 2.0f, 3.0f, 1.0f);

            Vector4 actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Quaternion)
        // Transform Vector2f by quaternion test
        [Fact]
        public void Vector4TransformVector2QuaternionTest()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector4 expected = Vector4.Transform(v, m);
            Vector4 actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Quaternion)
        // Transform Vector2f with zero quaternion
        [Fact]
        public void Vector4TransformVector2QuaternionTest1()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Quaternion q = new Quaternion();
            Vector4 expected = new Vector4(1.0f, 2.0f, 0, 1.0f);

            Vector4 actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Matrix4x4)
        // Transform vector2 with identity Quaternion
        [Fact]
        public void Vector4TransformVector2QuaternionTest2()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Quaternion q = Quaternion.Identity;
            Vector4 expected = new Vector4(1.0f, 2.0f, 0, 1.0f);

            Vector4 actual = Vector4.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Transform did not return the expected value.");
        }

        // A test for Normalize (Vector4f)
        [Fact]
        public void Vector4NormalizeTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);

            Vector4 expected = new Vector4(
                0.1825741858350553711523232609336f,
                0.3651483716701107423046465218672f,
                0.5477225575051661134569697828008f,
                0.7302967433402214846092930437344f);
            Vector4 actual;

            actual = Vector4.Normalize(a);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Normalize did not return the expected value.");
        }

        // A test for Normalize (Vector4f)
        // Normalize vector of length one
        [Fact]
        public void Vector4NormalizeTest1()
        {
            Vector4 a = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);

            Vector4 expected = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
            Vector4 actual = Vector4.Normalize(a);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.Normalize did not return the expected value.");
        }

        // A test for Normalize (Vector4f)
        // Normalize vector of length zero
        [Fact]
        public void Vector4NormalizeTest2()
        {
            Vector4 a = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);

            Vector4 expected = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Vector4 actual = Vector4.Normalize(a);
            Assert.True(Single.IsNaN(actual.X) && Single.IsNaN(actual.Y) && Single.IsNaN(actual.Z) && Single.IsNaN(actual.W), "Vector4f.Normalize did not return the expected value.");
        }

        // A test for operator - (Vector4f)
        [Fact]
        public void Vector4UnaryNegationTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);

            Vector4 expected = new Vector4(-1.0f, -2.0f, -3.0f, -4.0f);
            Vector4 actual;

            actual = -a;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.operator - did not return the expected value.");
        }

        // A test for operator - (Vector4f, Vector4f)
        [Fact]
        public void Vector4SubtractionTest()
        {
            Vector4 a = new Vector4(1.0f, 6.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 2.0f, 3.0f, 9.0f);

            Vector4 expected = new Vector4(-4.0f, 4.0f, 0.0f, -5.0f);
            Vector4 actual;

            actual = a - b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.operator - did not return the expected value.");
        }

        // A test for operator * (Vector4f, Single)
        [Fact]
        public void Vector4MultiplyOperatorTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);

            const Single factor = 2.0f;

            Vector4 expected = new Vector4(2.0f, 4.0f, 6.0f, 8.0f);
            Vector4 actual;

            actual = a * factor;
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.operator * did not return the expected value.");
        }

        // A test for operator * (Single, Vector4f)
        [Fact]
        public void Vector4MultiplyOperatorTest2()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);

            const Single factor = 2.0f;
            Vector4 expected = new Vector4(2.0f, 4.0f, 6.0f, 8.0f);
            Vector4 actual;

            actual = factor * a;
            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.operator * did not return the expected value.");
        }

        // A test for operator * (Vector4f, Vector4f)
        [Fact]
        public void Vector4MultiplyOperatorTest3()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 6.0f, 7.0f, 8.0f);

            Vector4 expected = new Vector4(5.0f, 12.0f, 21.0f, 32.0f);
            Vector4 actual;

            actual = a * b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.operator * did not return the expected value.");
        }

        // A test for operator / (Vector4f, Single)
        [Fact]
        public void Vector4DivisionTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);

            Single div = 2.0f;

            Vector4 expected = new Vector4(0.5f, 1.0f, 1.5f, 2.0f);
            Vector4 actual;

            actual = a / div;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.operator / did not return the expected value.");
        }

        // A test for operator / (Vector4f, Vector4f)
        [Fact]
        public void Vector4DivisionTest1()
        {
            Vector4 a = new Vector4(1.0f, 6.0f, 7.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 2.0f, 3.0f, 8.0f);

            Vector4 expected = new Vector4(1.0f / 5.0f, 6.0f / 2.0f, 7.0f / 3.0f, 4.0f / 8.0f);
            Vector4 actual;

            actual = a / b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.operator / did not return the expected value.");
        }

        // A test for operator / (Vector4f, Vector4f)
        // Divide by zero
        [Fact]
        public void Vector4DivisionTest2()
        {
            Vector4 a = new Vector4(-2.0f, 3.0f, Single.MaxValue, Single.NaN);

            Single div = 0.0f;

            Vector4 actual = a / div;

            Assert.True(Single.IsNegativeInfinity(actual.X), "Vector4f.operator / did not return the expected value.");
            Assert.True(Single.IsPositiveInfinity(actual.Y), "Vector4f.operator / did not return the expected value.");
            Assert.True(Single.IsPositiveInfinity(actual.Z), "Vector4f.operator / did not return the expected value.");
            Assert.True(Single.IsNaN(actual.W), "Vector4f.operator / did not return the expected value.");
        }

        // A test for operator / (Vector4f, Vector4f)
        // Divide by zero
        [Fact]
        public void Vector4DivisionTest3()
        {
            Vector4 a = new Vector4(0.047f, -3.0f, Single.NegativeInfinity, Single.MinValue);
            Vector4 b = new Vector4();

            Vector4 actual = a / b;

            Assert.True(Single.IsPositiveInfinity(actual.X), "Vector4f.operator / did not return the expected value.");
            Assert.True(Single.IsNegativeInfinity(actual.Y), "Vector4f.operator / did not return the expected value.");
            Assert.True(Single.IsNegativeInfinity(actual.Z), "Vector4f.operator / did not return the expected value.");
            Assert.True(Single.IsNegativeInfinity(actual.W), "Vector4f.operator / did not return the expected value.");
        }

        // A test for operator + (Vector4f, Vector4f)
        [Fact]
        public void Vector4AdditionTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 6.0f, 7.0f, 8.0f);

            Vector4 expected = new Vector4(6.0f, 8.0f, 10.0f, 12.0f);
            Vector4 actual;

            actual = a + b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4f.operator + did not return the expected value.");
        }

        [Fact]
        public void OperatorAddTest()
        {
            Vector4 v1 = new Vector4(2.5f, 2.0f, 3.0f, 3.3f);
            Vector4 v2 = new Vector4(5.5f, 4.5f, 6.5f, 7.5f);

            Vector4 v3 = v1 + v2;
            Vector4 v5 = new Vector4(-1.0f, 0.0f, 0.0f, Single.NaN);
            Vector4 v4 = v1 + v5;
            Assert.Equal(8.0f, v3.X);
            Assert.Equal(6.5f, v3.Y);
            Assert.Equal(9.5f, v3.Z);
            Assert.Equal(10.8f, v3.W);
            Assert.Equal(1.5f, v4.X);
            Assert.Equal(2.0f, v4.Y);
            Assert.Equal(3.0f, v4.Z);
            Assert.Equal(Single.NaN, v4.W);
        }

        // A test for Vector4f (Single, Single, Single, Single)
        [Fact]
        public void Vector4ConstructorTest()
        {
            Single x = 1.0f;
            Single y = 2.0f;
            Single z = 3.0f;
            Single w = 4.0f;

            Vector4 target = new Vector4(x, y, z, w);

            Assert.True(MathHelper.Equal(target.X, x) && MathHelper.Equal(target.Y, y) && MathHelper.Equal(target.Z, z) && MathHelper.Equal(target.W, w),
                "Vector4f constructor(x,y,z,w) did not return the expected value.");
        }

        // A test for Vector4f (Vector2f, Single, Single)
        [Fact]
        public void Vector4ConstructorTest1()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Single z = 3.0f;
            Single w = 4.0f;

            Vector4 target = new Vector4(a, z, w);
            Assert.True(MathHelper.Equal(target.X, a.X) && MathHelper.Equal(target.Y, a.Y) && MathHelper.Equal(target.Z, z) && MathHelper.Equal(target.W, w),
                "Vector4f constructor(Vector2f,z,w) did not return the expected value.");
        }

        // A test for Vector4f (Vector3f, Single)
        [Fact]
        public void Vector4ConstructorTest2()
        {
            Vector3 a = new Vector3(1.0f, 2.0f, 3.0f);
            Single w = 4.0f;

            Vector4 target = new Vector4(a, w);

            Assert.True(MathHelper.Equal(target.X, a.X) && MathHelper.Equal(target.Y, a.Y) && MathHelper.Equal(target.Z, a.Z) && MathHelper.Equal(target.W, w),
                "Vector4f constructor(Vector3f,w) did not return the expected value.");
        }

        // A test for Vector4f ()
        // Constructor with no parameter
        [Fact]
        public void Vector4ConstructorTest4()
        {
            Vector4 a = new Vector4();

            Assert.Equal(0.0f, a.X);
            Assert.Equal(0.0f, a.Y);
            Assert.Equal(0.0f, a.Z);
            Assert.Equal(0.0f, a.W);
        }

        // A test for Vector4f ()
        // Constructor with special Singleing values
        [Fact]
        public void Vector4ConstructorTest5()
        {
            Vector4 target = new Vector4(Single.NaN, Single.MaxValue, Single.PositiveInfinity, Single.Epsilon);

            Assert.True(Single.IsNaN(target.X), "Vector4f.constructor (Single, Single, Single, Single) did not return the expected value.");
            Assert.True(Single.Equals(Single.MaxValue, target.Y), "Vector4f.constructor (Single, Single, Single, Single) did not return the expected value.");
            Assert.True(Single.IsPositiveInfinity(target.Z), "Vector4f.constructor (Single, Single, Single, Single) did not return the expected value.");
            Assert.True(Single.Equals(Single.Epsilon, target.W), "Vector4f.constructor (Single, Single, Single, Single) did not return the expected value.");
        }

        // A test for Add (Vector4f, Vector4f)
        [Fact]
        public void Vector4AddTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 6.0f, 7.0f, 8.0f);

            Vector4 expected = new Vector4(6.0f, 8.0f, 10.0f, 12.0f);
            Vector4 actual;

            actual = Vector4.Add(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for Divide (Vector4f, Single)
        [Fact]
        public void Vector4DivideTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Single div = 2.0f;
            Vector4 expected = new Vector4(0.5f, 1.0f, 1.5f, 2.0f);
            Vector4 actual;
            actual = Vector4.Divide(a, div);
            Assert.Equal(expected, actual);
        }

        // A test for Divide (Vector4f, Vector4f)
        [Fact]
        public void Vector4DivideTest1()
        {
            Vector4 a = new Vector4(1.0f, 6.0f, 7.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 2.0f, 3.0f, 8.0f);

            Vector4 expected = new Vector4(1.0f / 5.0f, 6.0f / 2.0f, 7.0f / 3.0f, 4.0f / 8.0f);
            Vector4 actual;

            actual = Vector4.Divide(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for Equals (object)
        [Fact]
        public void Vector4EqualsTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);

            // case 1: compare between same values
            object obj = b;

            bool expected = true;
            bool actual = a.Equals(obj);
            Assert.Equal(expected, actual);

            // case 2: compare between different values
            b.X = 10.0f;
            obj = b;
            expected = false;
            actual = a.Equals(obj);
            Assert.Equal(expected, actual);

            // case 3: compare between different types.
            obj = new Quaternion();
            expected = false;
            actual = a.Equals(obj);
            Assert.Equal(expected, actual);

            // case 3: compare against null.
            obj = null;
            expected = false;
            actual = a.Equals(obj);
            Assert.Equal(expected, actual);
        }

        // A test for Multiply (Single, Vector4f)
        [Fact]
        public void Vector4MultiplyTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            const Single factor = 2.0f;
            Vector4 expected = new Vector4(2.0f, 4.0f, 6.0f, 8.0f);
            Vector4 actual = Vector4.Multiply(factor, a);
            Assert.Equal(expected, actual);
        }

        // A test for Multiply (Vector4f, Single)
        [Fact]
        public void Vector4MultiplyTest2()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            const Single factor = 2.0f;
            Vector4 expected = new Vector4(2.0f, 4.0f, 6.0f, 8.0f);
            Vector4 actual = Vector4.Multiply(a, factor);
            Assert.Equal(expected, actual);
        }

        // A test for Multiply (Vector4f, Vector4f)
        [Fact]
        public void Vector4MultiplyTest3()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 6.0f, 7.0f, 8.0f);

            Vector4 expected = new Vector4(5.0f, 12.0f, 21.0f, 32.0f);
            Vector4 actual;

            actual = Vector4.Multiply(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for Negate (Vector4f)
        [Fact]
        public void Vector4NegateTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);

            Vector4 expected = new Vector4(-1.0f, -2.0f, -3.0f, -4.0f);
            Vector4 actual;

            actual = Vector4.Negate(a);
            Assert.Equal(expected, actual);
        }

        // A test for operator != (Vector4f, Vector4f)
        [Fact]
        public void Vector4InequalityTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);

            // case 1: compare between same values
            bool expected = false;
            bool actual = a != b;
            Assert.Equal(expected, actual);

            // case 2: compare between different values
            b.X = 10.0f;
            expected = true;
            actual = a != b;
            Assert.Equal(expected, actual);
        }

        // A test for operator == (Vector4f, Vector4f)
        [Fact]
        public void Vector4EqualityTest()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);

            // case 1: compare between same values
            bool expected = true;
            bool actual = a == b;
            Assert.Equal(expected, actual);

            // case 2: compare between different values
            b.X = 10.0f;
            expected = false;
            actual = a == b;
            Assert.Equal(expected, actual);
        }

        // A test for Subtract (Vector4f, Vector4f)
        [Fact]
        public void Vector4SubtractTest()
        {
            Vector4 a = new Vector4(1.0f, 6.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(5.0f, 2.0f, 3.0f, 9.0f);

            Vector4 expected = new Vector4(-4.0f, 4.0f, 0.0f, -5.0f);
            Vector4 actual;

            actual = Vector4.Subtract(a, b);

            Assert.Equal(expected, actual);
        }

        // A test for UnitW
        [Fact]
        public void Vector4UnitWTest()
        {
            Vector4 val = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
            Assert.Equal(val, Vector4.UnitW);
        }

        // A test for UnitX
        [Fact]
        public void Vector4UnitXTest()
        {
            Vector4 val = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
            Assert.Equal(val, Vector4.UnitX);
        }

        // A test for UnitY
        [Fact]
        public void Vector4UnitYTest()
        {
            Vector4 val = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
            Assert.Equal(val, Vector4.UnitY);
        }

        // A test for UnitZ
        [Fact]
        public void Vector4UnitZTest()
        {
            Vector4 val = new Vector4(0.0f, 0.0f, 1.0f, 0.0f);
            Assert.Equal(val, Vector4.UnitZ);
        }

        // A test for One
        [Fact]
        public void Vector4OneTest()
        {
            Vector4 val = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            Assert.Equal(val, Vector4.One);
        }

        // A test for Zero
        [Fact]
        public void Vector4ZeroTest()
        {
            Vector4 val = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Assert.Equal(val, Vector4.Zero);
        }

        // A test for Equals (Vector4f)
        [Fact]
        public void Vector4EqualsTest1()
        {
            Vector4 a = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4 b = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);

            // case 1: compare between same values
            Assert.True(a.Equals(b));

            // case 2: compare between different values
            b.X = 10.0f;
            Assert.False(a.Equals(b));
        }

        // A test for Vector4f (Single)
        [Fact]
        public void Vector4ConstructorTest6()
        {
            Single value = 1.0f;
            Vector4 target = new Vector4(value);

            Vector4 expected = new Vector4(value, value, value, value);
            Assert.Equal(expected, target);

            value = 2.0f;
            target = new Vector4(value);
            expected = new Vector4(value, value, value, value);
            Assert.Equal(expected, target);
        }

        // A test for Vector4f comparison involving NaN values
        [Fact]
        public void Vector4EqualsNanTest()
        {
            Vector4 a = new Vector4(Single.NaN, 0, 0, 0);
            Vector4 b = new Vector4(0, Single.NaN, 0, 0);
            Vector4 c = new Vector4(0, 0, Single.NaN, 0);
            Vector4 d = new Vector4(0, 0, 0, Single.NaN);

            Assert.False(a == Vector4.Zero);
            Assert.False(b == Vector4.Zero);
            Assert.False(c == Vector4.Zero);
            Assert.False(d == Vector4.Zero);

            Assert.True(a != Vector4.Zero);
            Assert.True(b != Vector4.Zero);
            Assert.True(c != Vector4.Zero);
            Assert.True(d != Vector4.Zero);

            Assert.False(a.Equals(Vector4.Zero));
            Assert.False(b.Equals(Vector4.Zero));
            Assert.False(c.Equals(Vector4.Zero));
            Assert.False(d.Equals(Vector4.Zero));

            // Counterintuitive result - IEEE rules for NaN comparison are weird!
            Assert.False(a.Equals(a));
            Assert.False(b.Equals(b));
            Assert.False(c.Equals(c));
            Assert.False(d.Equals(d));
        }

        [Fact]
        public void Vector4AbsTest()
        {
            Vector4 v1 = new Vector4(-2.5f, 2.0f, 3.0f, 3.3f);
            Vector4 v3 = Vector4.Abs(new Vector4(Single.PositiveInfinity, 0.0f, Single.NegativeInfinity, Single.NaN));
            Vector4 v = Vector4.Abs(v1);
            Assert.Equal(2.5f, v.X);
            Assert.Equal(2.0f, v.Y);
            Assert.Equal(3.0f, v.Z);
            Assert.Equal(3.3f, v.W);
            Assert.Equal(Single.PositiveInfinity, v3.X);
            Assert.Equal(0.0f, v3.Y);
            Assert.Equal(Single.PositiveInfinity, v3.Z);
            Assert.Equal(Single.NaN, v3.W);
        }

        [Fact]
        public void Vector4SqrtTest()
        {
            Vector4 v1 = new Vector4(-2.5f, 2.0f, 3.0f, 3.3f);
            Vector4 v2 = new Vector4(5.5f, 4.5f, 6.5f, 7.5f);
            Assert.Equal(2, (int)Vector4.SquareRoot(v2).X);
            Assert.Equal(2, (int)Vector4.SquareRoot(v2).Y);
            Assert.Equal(2, (int)Vector4.SquareRoot(v2).Z);
            Assert.Equal(2, (int)Vector4.SquareRoot(v2).W);
            Assert.Equal(Single.NaN, Vector4.SquareRoot(v1).X);
        }

        // A test to make sure these types are blittable directly into GPU buffer memory layouts
        [Fact]
        public unsafe void Vector4SizeofTest()
        {
            Assert.Equal(16, sizeof(Vector4));
            Assert.Equal(32, sizeof(Vector4_2x));
            Assert.Equal(20, sizeof(Vector4PlusSingle));
            Assert.Equal(40, sizeof(Vector4PlusSingle_2x));
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector4_2x
        {
            private Vector4 _a;
            private Vector4 _b;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector4PlusSingle
        {
            private Vector4 _v;
            private Single _f;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector4PlusSingle_2x
        {
            private Vector4PlusSingle _a;
            private Vector4PlusSingle _b;
        }
    }
}