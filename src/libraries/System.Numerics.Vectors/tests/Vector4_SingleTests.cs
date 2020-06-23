// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Globalization;
using System.Runtime.InteropServices;
using Xunit;

namespace System.Numerics.Tests
{
    public partial class Vector4SingleTests
    {
        [Fact]
        public void Vector4SingleCopyToTest()
        {
            Vector4<float> v1 = new Vector4<float>(2.5f, 2.0f, 3.0f, 3.3f);

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
        public void Vector4SingleGetHashCodeTest()
        {
            Vector4<float> v1 = new Vector4<float>(2.5f, 2.0f, 3.0f, 3.3f);
            Vector4<float> v2 = new Vector4<float>(2.5f, 2.0f, 3.0f, 3.3f);
            Vector4<float> v3 = new Vector4<float>(2.5f, 2.0f, 3.0f, 3.3f);
            Vector4<float> v5 = new Vector4<float>(3.3f, 3.0f, 2.0f, 2.5f);
            Assert.Equal(v1.GetHashCode(), v1.GetHashCode());
            Assert.Equal(v1.GetHashCode(), v2.GetHashCode());
            Assert.NotEqual(v1.GetHashCode(), v5.GetHashCode());
            Assert.Equal(v1.GetHashCode(), v3.GetHashCode());
            Vector4<float> v4 = new Vector4<float>(0.0f, 0.0f, 0.0f, 0.0f);
            Vector4<float> v6 = new Vector4<float>(1.0f, 0.0f, 0.0f, 0.0f);
            Vector4<float> v7 = new Vector4<float>(0.0f, 1.0f, 0.0f, 0.0f);
            Vector4<float> v8 = new Vector4<float>(1.0f, 1.0f, 1.0f, 1.0f);
            Vector4<float> v9 = new Vector4<float>(1.0f, 1.0f, 0.0f, 0.0f);
            Assert.NotEqual(v4.GetHashCode(), v6.GetHashCode());
            Assert.NotEqual(v4.GetHashCode(), v7.GetHashCode());
            Assert.NotEqual(v4.GetHashCode(), v8.GetHashCode());
            Assert.NotEqual(v7.GetHashCode(), v6.GetHashCode());
            Assert.NotEqual(v8.GetHashCode(), v6.GetHashCode());
            Assert.NotEqual(v8.GetHashCode(), v7.GetHashCode());
            Assert.NotEqual(v9.GetHashCode(), v7.GetHashCode());
        }

        [Fact]
        public void Vector4SingleToStringTest()
        {
            string separator = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
            CultureInfo enUsCultureInfo = new CultureInfo("en-US");

            Vector4<float> v1 = new Vector4<float>(2.5f, 2.0f, 3.0f, 3.3f);

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

        // A test for DistanceSquared (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleDistanceSquaredTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 6.0f, 7.0f, 8.0f);

            Single expected = 64.0f;
            Single actual;

            actual = Vector4<float>.DistanceSquared(a, b);
            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector4<float>f.DistanceSquared did not return the expected value.");
        }

        // A test for Distance (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleDistanceTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 6.0f, 7.0f, 8.0f);

            Single expected = 8.0f;
            Single actual;

            actual = Vector4<float>.Distance(a, b);
            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector4<float>f.Distance did not return the expected value.");
        }

        // A test for Distance (Vector4<float>f, Vector4<float>f)
        // Distance from the same point
        [Fact]
        public void Vector4SingleDistanceTest1()
        {
            Vector4<float> a = new Vector4<float>(new Vector2(1.051f, 2.05f), 3.478f, 1.0f);
            Vector4<float> b = new Vector4<float>(new Vector3(1.051f, 2.05f, 3.478f), 0.0f);
            b.W = 1.0f;

            Single actual = Vector4<float>.Distance(a, b);
            Assert.Equal(0.0f, actual);
        }

        // A test for Dot (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleDotTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 6.0f, 7.0f, 8.0f);

            Single expected = 70.0f;
            Single actual;

            actual = Vector4<float>.Dot(a, b);
            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector4<float>f.Dot did not return the expected value.");
        }

        // A test for Dot (Vector4<float>f, Vector4<float>f)
        // Dot test for perpendicular vector
        [Fact]
        public void Vector4SingleDotTest1()
        {
            Vector3 a = new Vector3(1.55f, 1.55f, 1);
            Vector3 b = new Vector3(2.5f, 3, 1.5f);
            Vector3 c = Vector3.Cross(a, b);

            Vector4<float> d = new Vector4<float>(a, 0);
            Vector4<float> e = new Vector4<float>(c, 0);

            Single actual = Vector4<float>.Dot(d, e);
            Assert.True(MathHelper.EqualScalar(0.0f, actual), "Vector4<float>f.Dot did not return the expected value.");
        }

        // A test for Length ()
        [Fact]
        public void Vector4SingleLengthTest()
        {
            Vector3 a = new Vector3(1.0f, 2.0f, 3.0f);
            Single w = 4.0f;

            Vector4<float> target = new Vector4<float>(a, w);

            Single expected = (Single)System.Math.Sqrt(30.0f);
            Single actual;

            actual = target.Length();

            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Length did not return the expected value.");
        }

        // A test for Length ()
        // Length test where length is zero
        [Fact]
        public void Vector4SingleLengthTest1()
        {
            Vector4<float> target = new Vector4<float>();

            Single expected = 0.0f;
            Single actual = target.Length();

            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector4<float>f.Length did not return the expected value.");
        }

        // A test for LengthSquared ()
        [Fact]
        public void Vector4SingleLengthSquaredTest()
        {
            Vector3 a = new Vector3(1.0f, 2.0f, 3.0f);
            Single w = 4.0f;

            Vector4<float> target = new Vector4<float>(a, w);

            Single expected = 30;
            Single actual;

            actual = target.LengthSquared();

            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector4<float>f.LengthSquared did not return the expected value.");
        }

        // A test for Min (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleMinTest()
        {
            Vector4<float> a = new Vector4<float>(-1.0f, 4.0f, -3.0f, 1000.0f);
            Vector4<float> b = new Vector4<float>(2.0f, 1.0f, -1.0f, 0.0f);

            Vector4<float> expected = new Vector4<float>(-1.0f, 1.0f, -3.0f, 0.0f);
            Vector4<float> actual;
            actual = Vector4<float>.Min(a, b);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Min did not return the expected value.");
        }

        // A test for Max (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleMaxTest()
        {
            Vector4<float> a = new Vector4<float>(-1.0f, 4.0f, -3.0f, 1000.0f);
            Vector4<float> b = new Vector4<float>(2.0f, 1.0f, -1.0f, 0.0f);

            Vector4<float> expected = new Vector4<float>(2.0f, 4.0f, -1.0f, 1000.0f);
            Vector4<float> actual;
            actual = Vector4<float>.Max(a, b);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Max did not return the expected value.");
        }

        [Fact]
        public void Vector4SingleMinMaxCodeCoverageTest()
        {
            Vector4<float> min = Vector4<float>.Zero;
            Vector4<float> max = Vector4<float>.One;
            Vector4<float> actual;

            // Min.
            actual = Vector4<float>.Min(min, max);
            Assert.Equal(actual, min);

            actual = Vector4<float>.Min(max, min);
            Assert.Equal(actual, min);

            // Max.
            actual = Vector4<float>.Max(min, max);
            Assert.Equal(actual, max);

            actual = Vector4<float>.Max(max, min);
            Assert.Equal(actual, max);
        }

        // A test for Clamp (Vector4<float>f, Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleClampTest()
        {
            Vector4<float> a = new Vector4<float>(0.5f, 0.3f, 0.33f, 0.44f);
            Vector4<float> min = new Vector4<float>(0.0f, 0.1f, 0.13f, 0.14f);
            Vector4<float> max = new Vector4<float>(1.0f, 1.1f, 1.13f, 1.14f);

            // Normal case.
            // Case N1: specified value is in the range.
            Vector4<float> expected = new Vector4<float>(0.5f, 0.3f, 0.33f, 0.44f);
            Vector4<float> actual = Vector4<float>.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Clamp did not return the expected value.");

            // Normal case.
            // Case N2: specified value is bigger than max value.
            a = new Vector4<float>(2.0f, 3.0f, 4.0f, 5.0f);
            expected = max;
            actual = Vector4<float>.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Clamp did not return the expected value.");

            // Case N3: specified value is smaller than max value.
            a = new Vector4<float>(-2.0f, -3.0f, -4.0f, -5.0f);
            expected = min;
            actual = Vector4<float>.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Clamp did not return the expected value.");

            // Case N4: combination case.
            a = new Vector4<float>(-2.0f, 0.5f, 4.0f, -5.0f);
            expected = new Vector4<float>(min.X, a.Y, max.Z, min.W);
            actual = Vector4<float>.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Clamp did not return the expected value.");

            // User specified min value is bigger than max value.
            max = new Vector4<float>(0.0f, 0.1f, 0.13f, 0.14f);
            min = new Vector4<float>(1.0f, 1.1f, 1.13f, 1.14f);

            // Case W1: specified value is in the range.
            a = new Vector4<float>(0.5f, 0.3f, 0.33f, 0.44f);
            expected = max;
            actual = Vector4<float>.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Clamp did not return the expected value.");

            // Normal case.
            // Case W2: specified value is bigger than max and min value.
            a = new Vector4<float>(2.0f, 3.0f, 4.0f, 5.0f);
            expected = max;
            actual = Vector4<float>.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Clamp did not return the expected value.");

            // Case W3: specified value is smaller than min and max value.
            a = new Vector4<float>(-2.0f, -3.0f, -4.0f, -5.0f);
            expected = max;
            actual = Vector4<float>.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Clamp did not return the expected value.");
        }

        // A test for Lerp (Vector4<float>f, Vector4<float>f, Single)
        [Fact]
        public void Vector4SingleLerpTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 6.0f, 7.0f, 8.0f);

            Single t = 0.5f;

            Vector4<float> expected = new Vector4<float>(3.0f, 4.0f, 5.0f, 6.0f);
            Vector4<float> actual;

            actual = Vector4<float>.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector4<float>f, Vector4<float>f, Single)
        // Lerp test with factor zero
        [Fact]
        public void Vector4SingleLerpTest1()
        {
            Vector4<float> a = new Vector4<float>(new Vector3(1.0f, 2.0f, 3.0f), 4.0f);
            Vector4<float> b = new Vector4<float>(4.0f, 5.0f, 6.0f, 7.0f);

            Single t = 0.0f;
            Vector4<float> expected = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> actual = Vector4<float>.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector4<float>f, Vector4<float>f, Single)
        // Lerp test with factor one
        [Fact]
        public void Vector4SingleLerpTest2()
        {
            Vector4<float> a = new Vector4<float>(new Vector3(1.0f, 2.0f, 3.0f), 4.0f);
            Vector4<float> b = new Vector4<float>(4.0f, 5.0f, 6.0f, 7.0f);

            Single t = 1.0f;
            Vector4<float> expected = new Vector4<float>(4.0f, 5.0f, 6.0f, 7.0f);
            Vector4<float> actual = Vector4<float>.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector4<float>f, Vector4<float>f, Single)
        // Lerp test with factor > 1
        [Fact]
        public void Vector4SingleLerpTest3()
        {
            Vector4<float> a = new Vector4<float>(new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
            Vector4<float> b = new Vector4<float>(4.0f, 5.0f, 6.0f, 7.0f);

            Single t = 2.0f;
            Vector4<float> expected = new Vector4<float>(8.0f, 10.0f, 12.0f, 14.0f);
            Vector4<float> actual = Vector4<float>.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector4<float>f, Vector4<float>f, Single)
        // Lerp test with factor < 0
        [Fact]
        public void Vector4SingleLerpTest4()
        {
            Vector4<float> a = new Vector4<float>(new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
            Vector4<float> b = new Vector4<float>(4.0f, 5.0f, 6.0f, 7.0f);

            Single t = -2.0f;
            Vector4<float> expected = -(b * 2);
            Vector4<float> actual = Vector4<float>.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector4<float>f, Vector4<float>f, Single)
        // Lerp test from the same point
        [Fact]
        public void Vector4SingleLerpTest5()
        {
            Vector4<float> a = new Vector4<float>(4.0f, 5.0f, 6.0f, 7.0f);
            Vector4<float> b = new Vector4<float>(4.0f, 5.0f, 6.0f, 7.0f);

            Single t = 0.85f;
            Vector4<float> expected = a;
            Vector4<float> actual = Vector4<float>.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Lerp did not return the expected value.");
        }

        // A test for Transform (Vector2f, Matrix4x4)
        [Fact]
        public void Vector4SingleTransformTest1()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector4<float> expected = new Vector4<float>(10.316987f, 22.183012f, 30.3660259f, 1.0f);
            Vector4<float> actual;

            actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Matrix4x4)
        [Fact]
        public void Vector4SingleTransformTest2()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector4<float> expected = new Vector4<float>(12.19198728f, 21.53349376f, 32.61602545f, 1.0f);
            Vector4<float> actual;

            actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4<float>f, Matrix4x4)
        [Fact]
        public void Vector4SingleTransformVector4<float>Test()
        {
            Vector4<float> v = new Vector4<float>(1.0f, 2.0f, 3.0f, 0.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector4<float> expected = new Vector4<float>(2.19198728f, 1.53349376f, 2.61602545f, 0.0f);
            Vector4<float> actual;

            actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");

            //
            v.W = 1.0f;

            expected = new Vector4<float>(12.19198728f, 21.53349376f, 32.61602545f, 1.0f);
            actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4<float>f, Matrix4x4)
        // Transform Vector4<float> with zero matrix
        [Fact]
        public void Vector4SingleTransformVector4<float>Test1()
        {
            Vector4<float> v = new Vector4<float>(1.0f, 2.0f, 3.0f, 0.0f);
            Matrix4x4 m = new Matrix4x4();
            Vector4<float> expected = new Vector4<float>(0, 0, 0, 0);

            Vector4<float> actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4<float>f, Matrix4x4)
        // Transform Vector4<float> with identity matrix
        [Fact]
        public void Vector4SingleTransformVector4<float>Test2()
        {
            Vector4<float> v = new Vector4<float>(1.0f, 2.0f, 3.0f, 0.0f);
            Matrix4x4 m = Matrix4x4.Identity;
            Vector4<float> expected = new Vector4<float>(1.0f, 2.0f, 3.0f, 0.0f);

            Vector4<float> actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Matrix4x4)
        // Transform Vector3f test
        [Fact]
        public void Vector4SingleTransformVector3Test()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector4<float> expected = Vector4<float>.Transform(new Vector4<float>(v, 1.0f), m);
            Vector4<float> actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Matrix4x4)
        // Transform vector3 with zero matrix
        [Fact]
        public void Vector4SingleTransformVector3Test1()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);
            Matrix4x4 m = new Matrix4x4();
            Vector4<float> expected = new Vector4<float>(0, 0, 0, 0);

            Vector4<float> actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Matrix4x4)
        // Transform vector3 with identity matrix
        [Fact]
        public void Vector4SingleTransformVector3Test2()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);
            Matrix4x4 m = Matrix4x4.Identity;
            Vector4<float> expected = new Vector4<float>(1.0f, 2.0f, 3.0f, 1.0f);

            Vector4<float> actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Matrix4x4)
        // Transform Vector2f test
        [Fact]
        public void Vector4SingleTransformVector2Test()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector4<float> expected = Vector4<float>.Transform(new Vector4<float>(v, 0.0f, 1.0f), m);
            Vector4<float> actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Matrix4x4)
        // Transform Vector2f with zero matrix
        [Fact]
        public void Vector4SingleTransformVector2Test1()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Matrix4x4 m = new Matrix4x4();
            Vector4<float> expected = new Vector4<float>(0, 0, 0, 0);

            Vector4<float> actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Matrix4x4)
        // Transform vector2 with identity matrix
        [Fact]
        public void Vector4SingleTransformVector2Test2()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Matrix4x4 m = Matrix4x4.Identity;
            Vector4<float> expected = new Vector4<float>(1.0f, 2.0f, 0, 1.0f);

            Vector4<float> actual = Vector4<float>.Transform(v, m);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Quaternion)
        [Fact]
        public void Vector4SingleTransformVector2QuatanionTest()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));

            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector4<float> expected = Vector4<float>.Transform(v, m);
            Vector4<float> actual;

            actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Quaternion)
        [Fact]
        public void Vector4SingleTransformVector3Quaternion()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector4<float> expected = Vector4<float>.Transform(v, m);
            Vector4<float> actual;

            actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4<float>f, Quaternion)
        [Fact]
        public void Vector4SingleTransformVector4<float>QuaternionTest()
        {
            Vector4<float> v = new Vector4<float>(1.0f, 2.0f, 3.0f, 0.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector4<float> expected = Vector4<float>.Transform(v, m);
            Vector4<float> actual;

            actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");

            //
            v.W = 1.0f;
            expected.W = 1.0f;
            actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4<float>f, Quaternion)
        // Transform Vector4<float> with zero quaternion
        [Fact]
        public void Vector4SingleTransformVector4<float>QuaternionTest1()
        {
            Vector4<float> v = new Vector4<float>(1.0f, 2.0f, 3.0f, 0.0f);
            Quaternion q = new Quaternion();
            Vector4<float> expected = v;

            Vector4<float> actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector4<float>f, Quaternion)
        // Transform Vector4<float> with identity matrix
        [Fact]
        public void Vector4SingleTransformVector4<float>QuaternionTest2()
        {
            Vector4<float> v = new Vector4<float>(1.0f, 2.0f, 3.0f, 0.0f);
            Quaternion q = Quaternion.Identity;
            Vector4<float> expected = new Vector4<float>(1.0f, 2.0f, 3.0f, 0.0f);

            Vector4<float> actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Quaternion)
        // Transform Vector3f test
        [Fact]
        public void Vector4SingleTransformVector3QuaternionTest()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector4<float> expected = Vector4<float>.Transform(v, m);
            Vector4<float> actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Quaternion)
        // Transform vector3 with zero quaternion
        [Fact]
        public void Vector4SingleTransformVector3QuaternionTest1()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);
            Quaternion q = new Quaternion();
            Vector4<float> expected = new Vector4<float>(v, 1.0f);

            Vector4<float> actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector3f, Quaternion)
        // Transform vector3 with identity quaternion
        [Fact]
        public void Vector4SingleTransformVector3QuaternionTest2()
        {
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);
            Quaternion q = Quaternion.Identity;
            Vector4<float> expected = new Vector4<float>(1.0f, 2.0f, 3.0f, 1.0f);

            Vector4<float> actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Quaternion)
        // Transform Vector2f by quaternion test
        [Fact]
        public void Vector4SingleTransformVector2QuaternionTest()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector4<float> expected = Vector4<float>.Transform(v, m);
            Vector4<float> actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Quaternion)
        // Transform Vector2f with zero quaternion
        [Fact]
        public void Vector4SingleTransformVector2QuaternionTest1()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Quaternion q = new Quaternion();
            Vector4<float> expected = new Vector4<float>(1.0f, 2.0f, 0, 1.0f);

            Vector4<float> actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Transform (Vector2f, Matrix4x4)
        // Transform vector2 with identity Quaternion
        [Fact]
        public void Vector4SingleTransformVector2QuaternionTest2()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Quaternion q = Quaternion.Identity;
            Vector4<float> expected = new Vector4<float>(1.0f, 2.0f, 0, 1.0f);

            Vector4<float> actual = Vector4<float>.Transform(v, q);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Transform did not return the expected value.");
        }

        // A test for Normalize (Vector4<float>f)
        [Fact]
        public void Vector4SingleNormalizeTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);

            Vector4<float> expected = new Vector4<float>(
                0.1825741858350553711523232609336f,
                0.3651483716701107423046465218672f,
                0.5477225575051661134569697828008f,
                0.7302967433402214846092930437344f);
            Vector4<float> actual;

            actual = Vector4<float>.Normalize(a);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Normalize did not return the expected value.");
        }

        // A test for Normalize (Vector4<float>f)
        // Normalize vector of length one
        [Fact]
        public void Vector4SingleNormalizeTest1()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 0.0f, 0.0f, 0.0f);

            Vector4<float> expected = new Vector4<float>(1.0f, 0.0f, 0.0f, 0.0f);
            Vector4<float> actual = Vector4<float>.Normalize(a);
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.Normalize did not return the expected value.");
        }

        // A test for Normalize (Vector4<float>f)
        // Normalize vector of length zero
        [Fact]
        public void Vector4SingleNormalizeTest2()
        {
            Vector4<float> a = new Vector4<float>(0.0f, 0.0f, 0.0f, 0.0f);

            Vector4<float> expected = new Vector4<float>(0.0f, 0.0f, 0.0f, 0.0f);
            Vector4<float> actual = Vector4<float>.Normalize(a);
            Assert.True(Single.IsNaN(actual.X) && Single.IsNaN(actual.Y) && Single.IsNaN(actual.Z) && Single.IsNaN(actual.W), "Vector4<float>f.Normalize did not return the expected value.");
        }

        // A test for operator - (Vector4<float>f)
        [Fact]
        public void Vector4SingleUnaryNegationTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);

            Vector4<float> expected = new Vector4<float>(-1.0f, -2.0f, -3.0f, -4.0f);
            Vector4<float> actual;

            actual = -a;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.operator - did not return the expected value.");
        }

        // A test for operator - (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleSubtractionTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 6.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 2.0f, 3.0f, 9.0f);

            Vector4<float> expected = new Vector4<float>(-4.0f, 4.0f, 0.0f, -5.0f);
            Vector4<float> actual;

            actual = a - b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.operator - did not return the expected value.");
        }

        // A test for operator * (Vector4<float>f, Single)
        [Fact]
        public void Vector4SingleMultiplyOperatorTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);

            const Single factor = 2.0f;

            Vector4<float> expected = new Vector4<float>(2.0f, 4.0f, 6.0f, 8.0f);
            Vector4<float> actual;

            actual = a * factor;
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.operator * did not return the expected value.");
        }

        // A test for operator * (Single, Vector4<float>f)
        [Fact]
        public void Vector4SingleMultiplyOperatorTest2()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);

            const Single factor = 2.0f;
            Vector4<float> expected = new Vector4<float>(2.0f, 4.0f, 6.0f, 8.0f);
            Vector4<float> actual;

            actual = factor * a;
            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.operator * did not return the expected value.");
        }

        // A test for operator * (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleMultiplyOperatorTest3()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 6.0f, 7.0f, 8.0f);

            Vector4<float> expected = new Vector4<float>(5.0f, 12.0f, 21.0f, 32.0f);
            Vector4<float> actual;

            actual = a * b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.operator * did not return the expected value.");
        }

        // A test for operator / (Vector4<float>f, Single)
        [Fact]
        public void Vector4SingleDivisionTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);

            Single div = 2.0f;

            Vector4<float> expected = new Vector4<float>(0.5f, 1.0f, 1.5f, 2.0f);
            Vector4<float> actual;

            actual = a / div;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.operator / did not return the expected value.");
        }

        // A test for operator / (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleDivisionTest1()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 6.0f, 7.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 2.0f, 3.0f, 8.0f);

            Vector4<float> expected = new Vector4<float>(1.0f / 5.0f, 6.0f / 2.0f, 7.0f / 3.0f, 4.0f / 8.0f);
            Vector4<float> actual;

            actual = a / b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.operator / did not return the expected value.");
        }

        // A test for operator / (Vector4<float>f, Vector4<float>f)
        // Divide by zero
        [Fact]
        public void Vector4SingleDivisionTest2()
        {
            Vector4<float> a = new Vector4<float>(-2.0f, 3.0f, Single.MaxValue, Single.NaN);

            Single div = 0.0f;

            Vector4<float> actual = a / div;

            Assert.True(Single.IsNegativeInfinity(actual.X), "Vector4<float>f.operator / did not return the expected value.");
            Assert.True(Single.IsPositiveInfinity(actual.Y), "Vector4<float>f.operator / did not return the expected value.");
            Assert.True(Single.IsPositiveInfinity(actual.Z), "Vector4<float>f.operator / did not return the expected value.");
            Assert.True(Single.IsNaN(actual.W), "Vector4<float>f.operator / did not return the expected value.");
        }

        // A test for operator / (Vector4<float>f, Vector4<float>f)
        // Divide by zero
        [Fact]
        public void Vector4SingleDivisionTest3()
        {
            Vector4<float> a = new Vector4<float>(0.047f, -3.0f, Single.NegativeInfinity, Single.MinValue);
            Vector4<float> b = new Vector4<float>();

            Vector4<float> actual = a / b;

            Assert.True(Single.IsPositiveInfinity(actual.X), "Vector4<float>f.operator / did not return the expected value.");
            Assert.True(Single.IsNegativeInfinity(actual.Y), "Vector4<float>f.operator / did not return the expected value.");
            Assert.True(Single.IsNegativeInfinity(actual.Z), "Vector4<float>f.operator / did not return the expected value.");
            Assert.True(Single.IsNegativeInfinity(actual.W), "Vector4<float>f.operator / did not return the expected value.");
        }

        // A test for operator + (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleAdditionTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 6.0f, 7.0f, 8.0f);

            Vector4<float> expected = new Vector4<float>(6.0f, 8.0f, 10.0f, 12.0f);
            Vector4<float> actual;

            actual = a + b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector4<float>f.operator + did not return the expected value.");
        }

        [Fact]
        public void OperatorAddTest()
        {
            Vector4<float> v1 = new Vector4<float>(2.5f, 2.0f, 3.0f, 3.3f);
            Vector4<float> v2 = new Vector4<float>(5.5f, 4.5f, 6.5f, 7.5f);

            Vector4<float> v3 = v1 + v2;
            Vector4<float> v5 = new Vector4<float>(-1.0f, 0.0f, 0.0f, Single.NaN);
            Vector4<float> v4 = v1 + v5;
            Assert.Equal(8.0f, v3.X);
            Assert.Equal(6.5f, v3.Y);
            Assert.Equal(9.5f, v3.Z);
            Assert.Equal(10.8f, v3.W);
            Assert.Equal(1.5f, v4.X);
            Assert.Equal(2.0f, v4.Y);
            Assert.Equal(3.0f, v4.Z);
            Assert.Equal(Single.NaN, v4.W);
        }

        // A test for Vector4<float>f (Single, Single, Single, Single)
        [Fact]
        public void Vector4SingleConstructorTest()
        {
            Single x = 1.0f;
            Single y = 2.0f;
            Single z = 3.0f;
            Single w = 4.0f;

            Vector4<float> target = new Vector4<float>(x, y, z, w);

            Assert.True(MathHelper.Equal(target.X, x) && MathHelper.Equal(target.Y, y) && MathHelper.Equal(target.Z, z) && MathHelper.Equal(target.W, w),
                "Vector4<float>f constructor(x,y,z,w) did not return the expected value.");
        }

        // A test for Vector4<float>f (Vector2f, Single, Single)
        [Fact]
        public void Vector4SingleConstructorTest1()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Single z = 3.0f;
            Single w = 4.0f;

            Vector4<float> target = new Vector4<float>(a, z, w);
            Assert.True(MathHelper.Equal(target.X, a.X) && MathHelper.Equal(target.Y, a.Y) && MathHelper.Equal(target.Z, z) && MathHelper.Equal(target.W, w),
                "Vector4<float>f constructor(Vector2f,z,w) did not return the expected value.");
        }

        // A test for Vector4<float>f (Vector3f, Single)
        [Fact]
        public void Vector4SingleConstructorTest2()
        {
            Vector3 a = new Vector3(1.0f, 2.0f, 3.0f);
            Single w = 4.0f;

            Vector4<float> target = new Vector4<float>(a, w);

            Assert.True(MathHelper.Equal(target.X, a.X) && MathHelper.Equal(target.Y, a.Y) && MathHelper.Equal(target.Z, a.Z) && MathHelper.Equal(target.W, w),
                "Vector4<float>f constructor(Vector3f,w) did not return the expected value.");
        }

        // A test for Vector4<float>f ()
        // Constructor with no parameter
        [Fact]
        public void Vector4SingleConstructorTest4()
        {
            Vector4<float> a = new Vector4<float>();

            Assert.Equal(0.0f, a.X);
            Assert.Equal(0.0f, a.Y);
            Assert.Equal(0.0f, a.Z);
            Assert.Equal(0.0f, a.W);
        }

        // A test for Vector4<float>f ()
        // Constructor with special Singleing values
        [Fact]
        public void Vector4SingleConstructorTest5()
        {
            Vector4<float> target = new Vector4<float>(Single.NaN, Single.MaxValue, Single.PositiveInfinity, Single.Epsilon);

            Assert.True(Single.IsNaN(target.X), "Vector4<float>f.constructor (Single, Single, Single, Single) did not return the expected value.");
            Assert.True(Single.Equals(Single.MaxValue, target.Y), "Vector4<float>f.constructor (Single, Single, Single, Single) did not return the expected value.");
            Assert.True(Single.IsPositiveInfinity(target.Z), "Vector4<float>f.constructor (Single, Single, Single, Single) did not return the expected value.");
            Assert.True(Single.Equals(Single.Epsilon, target.W), "Vector4<float>f.constructor (Single, Single, Single, Single) did not return the expected value.");
        }

        // A test for Add (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleAddTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 6.0f, 7.0f, 8.0f);

            Vector4<float> expected = new Vector4<float>(6.0f, 8.0f, 10.0f, 12.0f);
            Vector4<float> actual;

            actual = Vector4<float>.Add(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for Divide (Vector4<float>f, Single)
        [Fact]
        public void Vector4SingleDivideTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Single div = 2.0f;
            Vector4<float> expected = new Vector4<float>(0.5f, 1.0f, 1.5f, 2.0f);
            Vector4<float> actual;
            actual = Vector4<float>.Divide(a, div);
            Assert.Equal(expected, actual);
        }

        // A test for Divide (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleDivideTest1()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 6.0f, 7.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 2.0f, 3.0f, 8.0f);

            Vector4<float> expected = new Vector4<float>(1.0f / 5.0f, 6.0f / 2.0f, 7.0f / 3.0f, 4.0f / 8.0f);
            Vector4<float> actual;

            actual = Vector4<float>.Divide(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for Equals (object)
        [Fact]
        public void Vector4SingleEqualsTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);

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

        // A test for Multiply (Single, Vector4<float>f)
        [Fact]
        public void Vector4SingleMultiplyTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            const Single factor = 2.0f;
            Vector4<float> expected = new Vector4<float>(2.0f, 4.0f, 6.0f, 8.0f);
            Vector4<float> actual = Vector4<float>.Multiply(factor, a);
            Assert.Equal(expected, actual);
        }

        // A test for Multiply (Vector4<float>f, Single)
        [Fact]
        public void Vector4SingleMultiplyTest2()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            const Single factor = 2.0f;
            Vector4<float> expected = new Vector4<float>(2.0f, 4.0f, 6.0f, 8.0f);
            Vector4<float> actual = Vector4<float>.Multiply(a, factor);
            Assert.Equal(expected, actual);
        }

        // A test for Multiply (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleMultiplyTest3()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 6.0f, 7.0f, 8.0f);

            Vector4<float> expected = new Vector4<float>(5.0f, 12.0f, 21.0f, 32.0f);
            Vector4<float> actual;

            actual = Vector4<float>.Multiply(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for Negate (Vector4<float>f)
        [Fact]
        public void Vector4SingleNegateTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);

            Vector4<float> expected = new Vector4<float>(-1.0f, -2.0f, -3.0f, -4.0f);
            Vector4<float> actual;

            actual = Vector4<float>.Negate(a);
            Assert.Equal(expected, actual);
        }

        // A test for operator != (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleInequalityTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);

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

        // A test for operator == (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleEqualityTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);

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

        // A test for Subtract (Vector4<float>f, Vector4<float>f)
        [Fact]
        public void Vector4SingleSubtractTest()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 6.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(5.0f, 2.0f, 3.0f, 9.0f);

            Vector4<float> expected = new Vector4<float>(-4.0f, 4.0f, 0.0f, -5.0f);
            Vector4<float> actual;

            actual = Vector4<float>.Subtract(a, b);

            Assert.Equal(expected, actual);
        }

        // A test for UnitW
        [Fact]
        public void Vector4SingleUnitWTest()
        {
            Vector4<float> val = new Vector4<float>(0.0f, 0.0f, 0.0f, 1.0f);
            Assert.Equal(val, Vector4<float>.UnitW);
        }

        // A test for UnitX
        [Fact]
        public void Vector4SingleUnitXTest()
        {
            Vector4<float> val = new Vector4<float>(1.0f, 0.0f, 0.0f, 0.0f);
            Assert.Equal(val, Vector4<float>.UnitX);
        }

        // A test for UnitY
        [Fact]
        public void Vector4SingleUnitYTest()
        {
            Vector4<float> val = new Vector4<float>(0.0f, 1.0f, 0.0f, 0.0f);
            Assert.Equal(val, Vector4<float>.UnitY);
        }

        // A test for UnitZ
        [Fact]
        public void Vector4SingleUnitZTest()
        {
            Vector4<float> val = new Vector4<float>(0.0f, 0.0f, 1.0f, 0.0f);
            Assert.Equal(val, Vector4<float>.UnitZ);
        }

        // A test for One
        [Fact]
        public void Vector4SingleOneTest()
        {
            Vector4<float> val = new Vector4<float>(1.0f, 1.0f, 1.0f, 1.0f);
            Assert.Equal(val, Vector4<float>.One);
        }

        // A test for Zero
        [Fact]
        public void Vector4SingleZeroTest()
        {
            Vector4<float> val = new Vector4<float>(0.0f, 0.0f, 0.0f, 0.0f);
            Assert.Equal(val, Vector4<float>.Zero);
        }

        // A test for Equals (Vector4<float>f)
        [Fact]
        public void Vector4SingleEqualsTest1()
        {
            Vector4<float> a = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);
            Vector4<float> b = new Vector4<float>(1.0f, 2.0f, 3.0f, 4.0f);

            // case 1: compare between same values
            Assert.True(a.Equals(b));

            // case 2: compare between different values
            b.X = 10.0f;
            Assert.False(a.Equals(b));
        }

        // A test for Vector4<float>f (Single)
        [Fact]
        public void Vector4SingleConstructorTest6()
        {
            Single value = 1.0f;
            Vector4<float> target = new Vector4<float>(value);

            Vector4<float> expected = new Vector4<float>(value, value, value, value);
            Assert.Equal(expected, target);

            value = 2.0f;
            target = new Vector4<float>(value);
            expected = new Vector4<float>(value, value, value, value);
            Assert.Equal(expected, target);
        }

        // A test for Vector4<float>f comparison involving NaN values
        [Fact]
        public void Vector4SingleEqualsNanTest()
        {
            Vector4<float> a = new Vector4<float>(Single.NaN, 0, 0, 0);
            Vector4<float> b = new Vector4<float>(0, Single.NaN, 0, 0);
            Vector4<float> c = new Vector4<float>(0, 0, Single.NaN, 0);
            Vector4<float> d = new Vector4<float>(0, 0, 0, Single.NaN);

            Assert.False(a == Vector4<float>.Zero);
            Assert.False(b == Vector4<float>.Zero);
            Assert.False(c == Vector4<float>.Zero);
            Assert.False(d == Vector4<float>.Zero);

            Assert.True(a != Vector4<float>.Zero);
            Assert.True(b != Vector4<float>.Zero);
            Assert.True(c != Vector4<float>.Zero);
            Assert.True(d != Vector4<float>.Zero);

            Assert.False(a.Equals(Vector4<float>.Zero));
            Assert.False(b.Equals(Vector4<float>.Zero));
            Assert.False(c.Equals(Vector4<float>.Zero));
            Assert.False(d.Equals(Vector4<float>.Zero));

            // Counterintuitive result - IEEE rules for NaN comparison are weird!
            Assert.False(a.Equals(a));
            Assert.False(b.Equals(b));
            Assert.False(c.Equals(c));
            Assert.False(d.Equals(d));
        }

        [Fact]
        public void Vector4SingleAbsTest()
        {
            Vector4<float> v1 = new Vector4<float>(-2.5f, 2.0f, 3.0f, 3.3f);
            Vector4<float> v3 = Vector4<float>.Abs(new Vector4<float>(Single.PositiveInfinity, 0.0f, Single.NegativeInfinity, Single.NaN));
            Vector4<float> v = Vector4<float>.Abs(v1);
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
        public void Vector4SingleSqrtTest()
        {
            Vector4<float> v1 = new Vector4<float>(-2.5f, 2.0f, 3.0f, 3.3f);
            Vector4<float> v2 = new Vector4<float>(5.5f, 4.5f, 6.5f, 7.5f);
            Assert.Equal(2, (int)Vector4<float>.SquareRoot(v2).X);
            Assert.Equal(2, (int)Vector4<float>.SquareRoot(v2).Y);
            Assert.Equal(2, (int)Vector4<float>.SquareRoot(v2).Z);
            Assert.Equal(2, (int)Vector4<float>.SquareRoot(v2).W);
            Assert.Equal(Single.NaN, Vector4<float>.SquareRoot(v1).X);
        }

        // A test to make sure these types are blittable directly into GPU buffer memory layouts
        [Fact]
        public unsafe void Vector4SingleSizeofTest()
        {
            Assert.Equal(16, sizeof(Vector4<float>));
            Assert.Equal(32, sizeof(Vector4Single_2x));
            Assert.Equal(20, sizeof(Vector4SinglePlusSingle));
            Assert.Equal(40, sizeof(Vector4SinglePlusSingle_2x));
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector4Single_2x
        {
            private Vector4<float> _a;
            private Vector4<float> _b;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector4SinglePlusSingle
        {
            private Vector4<float> _v;
            private Single _f;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector4SinglePlusSingle_2x
        {
            private Vector4SinglePlusSingle _a;
            private Vector4SinglePlusSingle _b;
        }

        [Fact]
        public void SetFieldsTest()
        {
            Vector4<float> v3 = new Vector4<float>(4f, 5f, 6f, 7f);
            v3 = v3.WithX(1.0f);
            v3 = v3.WithY(2.0f);
            v3 = v3.WithZ(3.0f);
            v3 = v3.WithW(4.0f);
            Assert.Equal(1.0f, v3.X);
            Assert.Equal(2.0f, v3.Y);
            Assert.Equal(3.0f, v3.Z);
            Assert.Equal(4.0f, v3.W);
            Vector4<float> v4 = v3;
            v4 = v4.WithY(0.5f);
            v4 = v4.WithZ(2.2f);
            v4 = v4.WithW(3.5f);
            Assert.Equal(1.0f, v4.X);
            Assert.Equal(0.5f, v4.Y);
            Assert.Equal(2.2f, v4.Z);
            Assert.Equal(3.5f, v4.W);
            Assert.Equal(2.0f, v3.Y);
        }

        [Fact]
        public void EmbeddedVectorSetFields()
        {
            EmbeddedVectorObject evo = new EmbeddedVectorObject();
            evo.FieldVector = evo.FieldVector.WithX(5.0f);
            evo.FieldVector = evo.FieldVector.WithY(5.0f);
            evo.FieldVector = evo.FieldVector.WithZ(5.0f);
            evo.FieldVector = evo.FieldVector.WithW(5.0f);
            Assert.Equal(5.0f, evo.FieldVector.X);
            Assert.Equal(5.0f, evo.FieldVector.Y);
            Assert.Equal(5.0f, evo.FieldVector.Z);
            Assert.Equal(5.0f, evo.FieldVector.W);
        }

        [Fact]
        public void DeeplyEmbeddedObjectTest()
        {
            DeeplyEmbeddedClass obj = new DeeplyEmbeddedClass();
            obj.L0.L1.L2.L3.L4.L5.L6.L7.EmbeddedVector = obj.L0.L1.L2.L3.L4.L5.L6.L7.EmbeddedVector.WithX(5f);
            Assert.Equal(5f, obj.RootEmbeddedObject.X);
            Assert.Equal(5f, obj.RootEmbeddedObject.Y);
            Assert.Equal(1f, obj.RootEmbeddedObject.Z);
            Assert.Equal(-5f, obj.RootEmbeddedObject.W);
            obj.L0.L1.L2.L3.L4.L5.L6.L7.EmbeddedVector = new Vector4<float>Single(1, 2, 3, 4);
            Assert.Equal(1f, obj.RootEmbeddedObject.X);
            Assert.Equal(2f, obj.RootEmbeddedObject.Y);
            Assert.Equal(3f, obj.RootEmbeddedObject.Z);
            Assert.Equal(4f, obj.RootEmbeddedObject.W);
        }

        [Fact]
        public void DeeplyEmbeddedStructTest()
        {
            DeeplyEmbeddedStruct obj = DeeplyEmbeddedStruct.Create();
            obj.L0.L1.L2.L3.L4.L5.L6.L7.EmbeddedVector = obj.L0.L1.L2.L3.L4.L5.L6.L7.EmbeddedVector.WithX(5f);
            Assert.Equal(5f, obj.RootEmbeddedObject.X);
            Assert.Equal(5f, obj.RootEmbeddedObject.Y);
            Assert.Equal(1f, obj.RootEmbeddedObject.Z);
            Assert.Equal(-5f, obj.RootEmbeddedObject.W);
            obj.L0.L1.L2.L3.L4.L5.L6.L7.EmbeddedVector = new Vector4<float>Single(1, 2, 3, 4);
            Assert.Equal(1f, obj.RootEmbeddedObject.X);
            Assert.Equal(2f, obj.RootEmbeddedObject.Y);
            Assert.Equal(3f, obj.RootEmbeddedObject.Z);
            Assert.Equal(4f, obj.RootEmbeddedObject.W);
        }

        private class EmbeddedVectorObject
        {
            public Vector4<float>Single FieldVector;
        }

        private class DeeplyEmbeddedClass
        {
            public readonly Level0 L0 = new Level0();
            public Vector4<float>Single RootEmbeddedObject { get { return L0.L1.L2.L3.L4.L5.L6.L7.EmbeddedVector; } }
            public class Level0
            {
                public readonly Level1 L1 = new Level1();
                public class Level1
                {
                    public readonly Level2 L2 = new Level2();
                    public class Level2
                    {
                        public readonly Level3 L3 = new Level3();
                        public class Level3
                        {
                            public readonly Level4 L4 = new Level4();
                            public class Level4
                            {
                                public readonly Level5 L5 = new Level5();
                                public class Level5
                                {
                                    public readonly Level6 L6 = new Level6();
                                    public class Level6
                                    {
                                        public readonly Level7 L7 = new Level7();
                                        public class Level7
                                        {
                                            public Vector4<float>Single EmbeddedVector = new Vector4<float>Single(1, 5, 1, -5);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Contrived test for strangely-sized and shaped embedded structures, with unused buffer fields.
        #pragma warning disable 0169
        private struct DeeplyEmbeddedStruct
        {
            public static DeeplyEmbeddedStruct Create()
            {
                var obj = new DeeplyEmbeddedStruct();
                obj.L0 = new Level0();
                obj.L0.L1 = new Level0.Level1();
                obj.L0.L1.L2 = new Level0.Level1.Level2();
                obj.L0.L1.L2.L3 = new Level0.Level1.Level2.Level3();
                obj.L0.L1.L2.L3.L4 = new Level0.Level1.Level2.Level3.Level4();
                obj.L0.L1.L2.L3.L4.L5 = new Level0.Level1.Level2.Level3.Level4.Level5();
                obj.L0.L1.L2.L3.L4.L5.L6 = new Level0.Level1.Level2.Level3.Level4.Level5.Level6();
                obj.L0.L1.L2.L3.L4.L5.L6.L7 = new Level0.Level1.Level2.Level3.Level4.Level5.Level6.Level7();
                obj.L0.L1.L2.L3.L4.L5.L6.L7.EmbeddedVector = new Vector4<float>Single(1, 5, 1, -5);

                return obj;
            }

            public Level0 L0;
            public Vector4<float>Single RootEmbeddedObject { get { return L0.L1.L2.L3.L4.L5.L6.L7.EmbeddedVector; } }
            public struct Level0
            {
                private float _buffer0, _buffer1;
                public Level1 L1;
                private float _buffer2;
                public struct Level1
                {
                    private float _buffer0, _buffer1;
                    public Level2 L2;
                    private byte _buffer2;
                    public struct Level2
                    {
                        public Level3 L3;
                        private float _buffer0;
                        private byte _buffer1;
                        public struct Level3
                        {
                            public Level4 L4;
                            public struct Level4
                            {
                                private float _buffer0;
                                public Level5 L5;
                                private long _buffer1;
                                private byte _buffer2;
                                private double _buffer3;
                                public struct Level5
                                {
                                    private byte _buffer0;
                                    public Level6 L6;
                                    public struct Level6
                                    {
                                        private byte _buffer0;
                                        public Level7 L7;
                                        private byte _buffer1, _buffer2;
                                        public struct Level7
                                        {
                                            public Vector4<float>Single EmbeddedVector;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #pragma warning restore 0169
    }
}