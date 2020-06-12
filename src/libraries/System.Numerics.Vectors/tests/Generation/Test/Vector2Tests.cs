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
    public partial class Vector2Tests
    {


        [Fact]
        public void Vector2CopyToTest()
        {
            Vector2 v1 = new Vector2(2.0f, 3.0f);

            var a = new Single[3];
            var b = new Single[2];

            Assert.Throws<ArgumentOutOfRangeException>(() => v1.CopyTo(a, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => v1.CopyTo(a, a.Length));

            v1.CopyTo(a, 1);
            v1.CopyTo(b);
            Assert.Equal(0.0, a[0]);
            Assert.Equal(2.0, a[1]);
            Assert.Equal(3.0, a[2]);
            Assert.Equal(2.0, b[0]);
            Assert.Equal(3.0, b[1]);
        }

        [Fact]
        public void Vector2GetHashCodeTest()
        {
            Vector2 v1 = new Vector2(2.0f, 3.0f);
            Vector2 v2 = new Vector2(2.0f, 3.0f);
            Vector2 v3 = new Vector2(3.0f, 2.0f);
            Assert.Equal(v1.GetHashCode(), v1.GetHashCode());
            Assert.Equal(v1.GetHashCode(), v2.GetHashCode());
            Assert.NotEqual(v1.GetHashCode(), v3.GetHashCode());
            Vector2 v4 = new Vector2(0.0f, 0.0f);
            Vector2 v6 = new Vector2(1.0f, 0.0f);
            Vector2 v7 = new Vector2(0.0f, 1.0f);
            Vector2 v8 = new Vector2(1.0f, 1.0f);
            Assert.NotEqual(v4.GetHashCode(), v6.GetHashCode());
            Assert.NotEqual(v4.GetHashCode(), v7.GetHashCode());
            Assert.NotEqual(v4.GetHashCode(), v8.GetHashCode());
            Assert.NotEqual(v7.GetHashCode(), v6.GetHashCode());
            Assert.NotEqual(v8.GetHashCode(), v6.GetHashCode());
            Assert.NotEqual(v8.GetHashCode(), v7.GetHashCode());
        }

        [Fact]
        public void Vector2ToStringTest()
        {
            string separator = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
            CultureInfo enUsCultureInfo = new CultureInfo("en-US");

            Vector2 v1 = new Vector2(2.0f, 3.0f);

            string v1str = v1.ToString();
            string expectedv1 = string.Format(CultureInfo.CurrentCulture
                , "<{1:G}{0} {2:G}>"
                , new object[] { separator, 2, 3 });
            Assert.Equal(expectedv1, v1str);

            string v1strformatted = v1.ToString("c", CultureInfo.CurrentCulture);
            string expectedv1formatted = string.Format(CultureInfo.CurrentCulture
                , "<{1:c}{0} {2:c}>"
                , new object[] { separator, 2, 3 });
            Assert.Equal(expectedv1formatted, v1strformatted);

            string v2strformatted = v1.ToString("c", enUsCultureInfo);
            string expectedv2formatted = string.Format(enUsCultureInfo
                , "<{1:c}{0} {2:c}>"
                , new object[] { enUsCultureInfo.NumberFormat.NumberGroupSeparator, 2, 3 });
            Assert.Equal(expectedv2formatted, v2strformatted);

            string v3strformatted = v1.ToString("c");
            string expectedv3formatted = string.Format(CultureInfo.CurrentCulture
                , "<{1:c}{0} {2:c}>"
                , new object[] { separator, 2, 3 });
            Assert.Equal(expectedv3formatted, v3strformatted);
        }

        // A test for Distance (Vector2, Vector2)
        [Fact]
        public void Vector2DistanceTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);

            Single expected = (Single)System.Math.Sqrt(8);
            Single actual;

            actual = Vector2.Distance(a, b);
            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector2.Distance did not return the expected value.");
        }

        // A test for Distance (Vector2, Vector2)
        // Distance from the same point
        [Fact]
        public void Vector2DistanceTest2()
        {
            Vector2 a = new Vector2(1.051f, 2.05f);
            Vector2 b = new Vector2(1.051f, 2.05f);

            Single actual = Vector2.Distance(a, b);
            Assert.Equal(0.0f, actual);
        }

        // A test for DistanceSquared (Vector2, Vector2)
        [Fact]
        public void Vector2DistanceSquaredTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);

            Single expected = 8.0f;
            Single actual;

            actual = Vector2.DistanceSquared(a, b);
            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector2.DistanceSquared did not return the expected value.");
        }

        // A test for Dot (Vector2, Vector2)
        [Fact]
        public void Vector2DotTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);

            Single expected = 11.0f;
            Single actual;

            actual = Vector2.Dot(a, b);
            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector2.Dot did not return the expected value.");
        }

        // A test for Dot (Vector2, Vector2)
        // Dot test for perpendicular vector
        [Fact]
        public void Vector2DotTest1()
        {
            Vector2 a = new Vector2(1.55f, 1.55f);
            Vector2 b = new Vector2(-1.55f, 1.55f);

            Single expected = 0.0f;
            Single actual = Vector2.Dot(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for Dot (Vector2, Vector2)
        // Dot test with special Single values
        [Fact]
        public void Vector2DotTest2()
        {
            Vector2 a = new Vector2(Single.MinValue, Single.MinValue);
            Vector2 b = new Vector2(Single.MaxValue, Single.MaxValue);

            Single actual = Vector2.Dot(a, b);
            Assert.True(Single.IsNegativeInfinity(actual), "Vector2.Dot did not return the expected value.");
        }

        // A test for Length ()
        [Fact]
        public void Vector2LengthTest()
        {
            Vector2 a = new Vector2(2.0f, 4.0f);

            Vector2 target = a;

            Single expected = (Single)System.Math.Sqrt(20);
            Single actual;

            actual = target.Length();

            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector2.Length did not return the expected value.");
        }

        // A test for Length ()
        // Length test where length is zero
        [Fact]
        public void Vector2LengthTest1()
        {
            Vector2 target = Vector2.Zero;

            Single expected = 0.0f;
            Single actual;

            actual = target.Length();

            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector2.Length did not return the expected value.");
        }

        // A test for LengthSquared ()
        [Fact]
        public void Vector2LengthSquaredTest()
        {
            Vector2 a = new Vector2(2.0f, 4.0f);

            Vector2 target = a;

            Single expected = 20.0f;
            Single actual;

            actual = target.LengthSquared();

            Assert.True(MathHelper.EqualScalar(expected, actual), "Vector2.LengthSquared did not return the expected value.");
        }

        // A test for LengthSquared ()
        // LengthSquared test where the result is zero
        [Fact]
        public void Vector2LengthSquaredTest1()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);

            Single expected = 0.0f;
            Single actual = a.LengthSquared();

            Assert.Equal(expected, actual);
        }

        // A test for Min (Vector2, Vector2)
        [Fact]
        public void Vector2MinTest()
        {
            Vector2 a = new Vector2(-1.0f, 4.0f);
            Vector2 b = new Vector2(2.0f, 1.0f);

            Vector2 expected = new Vector2(-1.0f, 1.0f);
            Vector2 actual;
            actual = Vector2.Min(a, b);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Min did not return the expected value.");
        }

        [Fact]
        public void Vector2MinMaxCodeCoverageTest()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(1, 1);
            Vector2 actual;

            // Min.
            actual = Vector2.Min(min, max);
            Assert.Equal(actual, min);

            actual = Vector2.Min(max, min);
            Assert.Equal(actual, min);

            // Max.
            actual = Vector2.Max(min, max);
            Assert.Equal(actual, max);

            actual = Vector2.Max(max, min);
            Assert.Equal(actual, max);
        }

        // A test for Max (Vector2, Vector2)
        [Fact]
        public void Vector2MaxTest()
        {
            Vector2 a = new Vector2(-1.0f, 4.0f);
            Vector2 b = new Vector2(2.0f, 1.0f);

            Vector2 expected = new Vector2(2.0f, 4.0f);
            Vector2 actual;
            actual = Vector2.Max(a, b);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Max did not return the expected value.");
        }

        // A test for Clamp (Vector2, Vector2, Vector2)
        [Fact]
        public void Vector2ClampTest()
        {
            Vector2 a = new Vector2(0.5f, 0.3f);
            Vector2 min = new Vector2(0.0f, 0.1f);
            Vector2 max = new Vector2(1.0f, 1.1f);

            // Normal case.
            // Case N1: specified value is in the range.
            Vector2 expected = new Vector2(0.5f, 0.3f);
            Vector2 actual = Vector2.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Clamp did not return the expected value.");
            // Normal case.
            // Case N2: specified value is bigger than max value.
            a = new Vector2(2.0f, 3.0f);
            expected = max;
            actual = Vector2.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Clamp did not return the expected value.");
            // Case N3: specified value is smaller than max value.
            a = new Vector2(-1.0f, -2.0f);
            expected = min;
            actual = Vector2.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Clamp did not return the expected value.");
            // Case N4: combination case.
            a = new Vector2(-2.0f, 4.0f);
            expected = new Vector2(min.X, max.Y);
            actual = Vector2.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Clamp did not return the expected value.");
            // User specified min value is bigger than max value.
            max = new Vector2(0.0f, 0.1f);
            min = new Vector2(1.0f, 1.1f);

            // Case W1: specified value is in the range.
            a = new Vector2(0.5f, 0.3f);
            expected = max;
            actual = Vector2.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Clamp did not return the expected value.");

            // Normal case.
            // Case W2: specified value is bigger than max and min value.
            a = new Vector2(2.0f, 3.0f);
            expected = max;
            actual = Vector2.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Clamp did not return the expected value.");

            // Case W3: specified value is smaller than min and max value.
            a = new Vector2(-1.0f, -2.0f);
            expected = max;
            actual = Vector2.Clamp(a, min, max);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Clamp did not return the expected value.");
        }

        // A test for Lerp (Vector2, Vector2, Single)
        [Fact]
        public void Vector2LerpTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);

            Single t = 0.5f;

            Vector2 expected = new Vector2(2.0f, 3.0f);
            Vector2 actual;
            actual = Vector2.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector2, Vector2, Single)
        // Lerp test with factor zero
        [Fact]
        public void Vector2LerpTest1()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);
            Vector2 b = new Vector2(3.18f, 4.25f);

            Single t = 0.0f;
            Vector2 expected = Vector2.Zero;
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector2, Vector2, Single)
        // Lerp test with factor one
        [Fact]
        public void Vector2LerpTest2()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);
            Vector2 b = new Vector2(3.18f, 4.25f);

            Single t = 1.0f;
            Vector2 expected = new Vector2(3.18f, 4.25f);
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector2, Vector2, Single)
        // Lerp test with factor > 1
        [Fact]
        public void Vector2LerpTest3()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);
            Vector2 b = new Vector2(3.18f, 4.25f);

            Single t = 2.0f;
            Vector2 expected = b * 2.0f;
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector2, Vector2, Single)
        // Lerp test with factor < 0
        [Fact]
        public void Vector2LerpTest4()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);
            Vector2 b = new Vector2(3.18f, 4.25f);

            Single t = -2.0f;
            Vector2 expected = -(b * 2.0f);
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector2, Vector2, Single)
        // Lerp test with special Single value
        [Fact]
        public void Vector2LerpTest5()
        {
            Vector2 a = new Vector2(45.67f, 90.0f);
            Vector2 b = new Vector2(Single.PositiveInfinity, Single.NegativeInfinity);

            Single t = 0.408f;
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.True(Single.IsPositiveInfinity(actual.X), "Vector2.Lerp did not return the expected value.");
            Assert.True(Single.IsNegativeInfinity(actual.Y), "Vector2.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector2, Vector2, Single)
        // Lerp test from the same point
        [Fact]
        public void Vector2LerpTest6()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(1.0f, 2.0f);

            Single t = 0.5f;

            Vector2 expected = new Vector2(1.0f, 2.0f);
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector2, Vector2, Single)
        // Lerp test with values known to be innacurate with the old lerp impl
        [Fact]
        public void Vector2LerpTest7()
        {
            Vector2 a = new Vector2(0.44728136f);
            Vector2 b = new Vector2(0.46345946f);

            Single t = 0.26402435f;

            Vector2 expected = new Vector2(0.45155275f);
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        // A test for Lerp (Vector2, Vector2, Single)
        // Lerp test with values known to be innacurate with the old lerp impl
        // (Old code incorrectly gets 0.33333588)
        [Fact]
        public void Vector2LerpTest8()
        {
            Vector2 a = new Vector2(-100);
            Vector2 b = new Vector2(0.33333334f);

            Single t = 1f;

            Vector2 expected = new Vector2(0.33333334f);
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        // // A test for Transform(Vector2, Matrix4x4)
        // [Fact]
        // public void Vector2TransformTest()
        // {
        //     Vector2 v = new Vector2(1.0f, 2.0f);
        //     Matrix4x4 m =
        //         Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
        //         Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
        //         Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
        //     m.M41 = 10.0f;
        //     m.M42 = 20.0f;
        //     m.M43 = 30.0f;

        //     Vector2 expected = new Vector2(10.316987f, 22.183012f);
        //     Vector2 actual;

        //     actual = Vector2.Transform(v, m);
        //     Assert.True(MathHelper.Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        // }

        // // A test for Transform(Vector2, Matrix3x2)
        // [Fact]
        // public void Vector2Transform3x2Test()
        // {
        //     Vector2 v = new Vector2(1.0f, 2.0f);
        //     Matrix3x2 m = Matrix3x2.CreateRotation(MathHelper.ToRadians(30.0f));
        //     m.M31 = 10.0f;
        //     m.M32 = 20.0f;

        //     Vector2 expected = new Vector2(9.866025f, 22.23205f);
        //     Vector2 actual;

        //     actual = Vector2.Transform(v, m);
        //     Assert.True(MathHelper.Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        // }

        // // A test for TransformNormal (Vector2, Matrix4x4)
        // [Fact]
        // public void Vector2TransformNormalTest()
        // {
        //     Vector2 v = new Vector2(1.0f, 2.0f);
        //     Matrix4x4 m =
        //         Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
        //         Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
        //         Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
        //     m.M41 = 10.0f;
        //     m.M42 = 20.0f;
        //     m.M43 = 30.0f;

        //     Vector2 expected = new Vector2(0.3169873f, 2.18301272f);
        //     Vector2 actual;

        //     actual = Vector2.TransformNormal(v, m);
        //     Assert.True(MathHelper.Equal(expected, actual), "Vector2.Tranform did not return the expected value.");
        // }

        // // A test for TransformNormal (Vector2, Matrix3x2)
        // [Fact]
        // public void Vector2TransformNormal3x2Test()
        // {
        //     Vector2 v = new Vector2(1.0f, 2.0f);
        //     Matrix3x2 m = Matrix3x2.CreateRotation(MathHelper.ToRadians(30.0f));
        //     m.M31 = 10.0f;
        //     m.M32 = 20.0f;

        //     Vector2 expected = new Vector2(-0.133974612f, 2.232051f);
        //     Vector2 actual;

        //     actual = Vector2.TransformNormal(v, m);
        //     Assert.True(MathHelper.Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        // }

        // // A test for Transform (Vector2, Quaternion)
        // [Fact]
        // public void Vector2TransformByQuaternionTest()
        // {
        //     Vector2 v = new Vector2(1.0f, 2.0f);

        //     Matrix4x4 m =
        //         Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
        //         Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
        //         Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
        //     Quaternion q = Quaternion.CreateFromRotationMatrix(m);

        //     Vector2 expected = Vector2.Transform(v, m);
        //     Vector2 actual = Vector2.Transform(v, q);
        //     Assert.True(MathHelper.Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        // }

        // // A test for Transform (Vector2, Quaternion)
        // // Transform Vector2 with zero quaternion
        // [Fact]
        // public void Vector2TransformByQuaternionTest1()
        // {
        //     Vector2 v = new Vector2(1.0f, 2.0f);
        //     Quaternion q = new Quaternion();
        //     Vector2 expected = v;

        //     Vector2 actual = Vector2.Transform(v, q);
        //     Assert.True(MathHelper.Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        // }

        // // A test for Transform (Vector2, Quaternion)
        // // Transform Vector2 with identity quaternion
        // [Fact]
        // public void Vector2TransformByQuaternionTest2()
        // {
        //     Vector2 v = new Vector2(1.0f, 2.0f);
        //     Quaternion q = Quaternion.Identity;
        //     Vector2 expected = v;

        //     Vector2 actual = Vector2.Transform(v, q);
        //     Assert.True(MathHelper.Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        // }

        // A test for Normalize (Vector2)
        [Fact]
        public void Vector2NormalizeTest()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            Vector2 expected = new Vector2(0.554700196225229122018341733457f, 0.8320502943378436830275126001855f);
            Vector2 actual;

            actual = Vector2.Normalize(a);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Normalize did not return the expected value.");
        }

        // A test for Normalize (Vector2)
        // Normalize zero length vector
        [Fact]
        public void Vector2NormalizeTest1()
        {
            Vector2 a = new Vector2(); // no parameter, default to 0.0f
            Vector2 actual = Vector2.Normalize(a);
            Assert.True(Single.IsNaN(actual.X) && Single.IsNaN(actual.Y), "Vector2.Normalize did not return the expected value.");
        }

        // A test for Normalize (Vector2)
        // Normalize infinite length vector
        [Fact]
        public void Vector2NormalizeTest2()
        {
            Vector2 a = new Vector2(Single.MaxValue, Single.MaxValue);
            Vector2 actual = Vector2.Normalize(a);
            Vector2 expected = new Vector2(0, 0);
            Assert.Equal(expected, actual);
        }

        // A test for operator - (Vector2)
        [Fact]
        public void Vector2UnaryNegationTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);

            Vector2 expected = new Vector2(-1.0f, -2.0f);
            Vector2 actual;

            actual = -a;

            Assert.True(MathHelper.Equal(expected, actual), "Vector2.operator - did not return the expected value.");
        }



        // A test for operator - (Vector2)
        // Negate test with special Single value
        [Fact]
        public void Vector2UnaryNegationTest1()
        {
            Vector2 a = new Vector2(Single.PositiveInfinity, Single.NegativeInfinity);

            Vector2 actual = -a;

            Assert.True(Single.IsNegativeInfinity(actual.X), "Vector2.operator - did not return the expected value.");
            Assert.True(Single.IsPositiveInfinity(actual.Y), "Vector2.operator - did not return the expected value.");
        }

        // A test for operator - (Vector2)
        // Negate test with special Single value
        [Fact]
        public void Vector2UnaryNegationTest2()
        {
            Vector2 a = new Vector2(Single.NaN, 0.0f);
            Vector2 actual = -a;

            Assert.True(Single.IsNaN(actual.X), "Vector2.operator - did not return the expected value.");
            Assert.True(Single.Equals(0.0f, actual.Y), "Vector2.operator - did not return the expected value.");
        }

        // A test for operator - (Vector2, Vector2)
        [Fact]
        public void Vector2SubtractionTest()
        {
            Vector2 a = new Vector2(1.0f, 3.0f);
            Vector2 b = new Vector2(2.0f, 1.5f);

            Vector2 expected = new Vector2(-1.0f, 1.5f);
            Vector2 actual;

            actual = a - b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector2.operator - did not return the expected value.");
        }

        // A test for operator * (Vector2, Single)
        [Fact]
        public void Vector2MultiplyOperatorTest()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            const Single factor = 2.0f;

            Vector2 expected = new Vector2(4.0f, 6.0f);
            Vector2 actual;

            actual = a * factor;
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.operator * did not return the expected value.");
        }

        // A test for operator * (Single, Vector2)
        [Fact]
        public void Vector2MultiplyOperatorTest2()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            const Single factor = 2.0f;

            Vector2 expected = new Vector2(4.0f, 6.0f);
            Vector2 actual;

            actual = factor * a;
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.operator * did not return the expected value.");
        }

        // A test for operator * (Vector2, Vector2)
        [Fact]
        public void Vector2MultiplyOperatorTest3()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            Vector2 b = new Vector2(4.0f, 5.0f);

            Vector2 expected = new Vector2(8.0f, 15.0f);
            Vector2 actual;

            actual = a * b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector2.operator * did not return the expected value.");
        }

        // A test for operator / (Vector2, Single)
        [Fact]
        public void Vector2DivisionTest()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);

            Single div = 2.0f;

            Vector2 expected = new Vector2(1.0f, 1.5f);
            Vector2 actual;

            actual = a / div;

            Assert.True(MathHelper.Equal(expected, actual), "Vector2.operator / did not return the expected value.");
        }

        // A test for operator / (Vector2, Vector2)
        [Fact]
        public void Vector2DivisionTest1()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            Vector2 b = new Vector2(4.0f, 5.0f);

            Vector2 expected = new Vector2(2.0f / 4.0f, 3.0f / 5.0f);
            Vector2 actual;

            actual = a / b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector2.operator / did not return the expected value.");
        }

        // A test for operator / (Vector2, Single)
        // Divide by zero
        [Fact]
        public void Vector2DivisionTest2()
        {
            Vector2 a = new Vector2(-2.0f, 3.0f);

            Single div = 0.0f;

            Vector2 actual = a / div;

            Assert.True(Single.IsNegativeInfinity(actual.X), "Vector2.operator / did not return the expected value.");
            Assert.True(Single.IsPositiveInfinity(actual.Y), "Vector2.operator / did not return the expected value.");
        }

        // A test for operator / (Vector2, Vector2)
        // Divide by zero
        [Fact]
        public void Vector2DivisionTest3()
        {
            Vector2 a = new Vector2(0.047f, -3.0f);
            Vector2 b = new Vector2();

            Vector2 actual = a / b;

            Assert.True(Single.IsInfinity(actual.X), "Vector2.operator / did not return the expected value.");
            Assert.True(Single.IsInfinity(actual.Y), "Vector2.operator / did not return the expected value.");
        }

        // A test for operator + (Vector2, Vector2)
        [Fact]
        public void Vector2AdditionTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);

            Vector2 expected = new Vector2(4.0f, 6.0f);
            Vector2 actual;

            actual = a + b;

            Assert.True(MathHelper.Equal(expected, actual), "Vector2.operator + did not return the expected value.");
        }

        // A test for Vector2 (Single, Single)
        [Fact]
        public void Vector2ConstructorTest()
        {
            Single x = 1.0f;
            Single y = 2.0f;

            Vector2 target = new Vector2(x, y);
            Assert.True(MathHelper.Equal(target.X, x) && MathHelper.Equal(target.Y, y), "Vector2(x,y) constructor did not return the expected value.");
        }

        // A test for Vector2 ()
        // Constructor with no parameter
        [Fact]
        public void Vector2ConstructorTest2()
        {
            Vector2 target = new Vector2();
            Assert.Equal(0.0f, target.X);
            Assert.Equal(0.0f, target.Y);
        }

        // A test for Vector2 (Single, Single)
        // Constructor with special Singleing values
        [Fact]
        public void Vector2ConstructorTest3()
        {
            Vector2 target = new Vector2(Single.NaN, Single.MaxValue);
            Assert.Equal(target.X, Single.NaN);
            Assert.Equal(target.Y, Single.MaxValue);
        }

        // A test for Vector2 (Single)
        [Fact]
        public void Vector2ConstructorTest4()
        {
            Single value = 1.0f;
            Vector2 target = new Vector2(value);

            Vector2 expected = new Vector2(value, value);
            Assert.Equal(expected, target);

            value = 2.0f;
            target = new Vector2(value);
            expected = new Vector2(value, value);
            Assert.Equal(expected, target);
        }

        // A test for Add (Vector2, Vector2)
        [Fact]
        public void Vector2AddTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(5.0f, 6.0f);

            Vector2 expected = new Vector2(6.0f, 8.0f);
            Vector2 actual;

            actual = Vector2.Add(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for Divide (Vector2, Single)
        [Fact]
        public void Vector2DivideTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Single div = 2.0f;
            Vector2 expected = new Vector2(0.5f, 1.0f);
            Vector2 actual;
            actual = Vector2.Divide(a, div);
            Assert.Equal(expected, actual);
        }

        // A test for Divide (Vector2, Vector2)
        [Fact]
        public void Vector2DivideTest1()
        {
            Vector2 a = new Vector2(1.0f, 6.0f);
            Vector2 b = new Vector2(5.0f, 2.0f);

            Vector2 expected = new Vector2(1.0f / 5.0f, 6.0f / 2.0f);
            Vector2 actual;

            actual = Vector2.Divide(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for Equals (object)
        [Fact]
        public void Vector2EqualsTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(1.0f, 2.0f);

            // case 1: compare between same values
            object obj = b;

            bool expected = true;
            bool actual = a.Equals(obj);
            Assert.Equal(expected, actual);

            // case 2: compare between different values
            b = new Vector2(b.X, 10);
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

        // A test for Multiply (Vector2, Single)
        [Fact]
        public void Vector2MultiplyTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            const Single factor = 2.0f;
            Vector2 expected = new Vector2(2.0f, 4.0f);
            Vector2 actual = Vector2.Multiply(a, factor);
            Assert.Equal(expected, actual);
        }

        // A test for Multiply (Single, Vector2)
        [Fact]
        public void Vector2MultiplyTest2()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            const Single factor = 2.0f;
            Vector2 expected = new Vector2(2.0f, 4.0f);
            Vector2 actual = Vector2.Multiply(factor, a);
            Assert.Equal(expected, actual);
        }

        // A test for Multiply (Vector2, Vector2)
        [Fact]
        public void Vector2MultiplyTest3()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(5.0f, 6.0f);

            Vector2 expected = new Vector2(5.0f, 12.0f);
            Vector2 actual;

            actual = Vector2.Multiply(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for Negate (Vector2)
        [Fact]
        public void Vector2NegateTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);

            Vector2 expected = new Vector2(-1.0f, -2.0f);
            Vector2 actual;

            actual = Vector2.Negate(a);
            Assert.Equal(expected, actual);
        }

        // A test for operator != (Vector2, Vector2)
        [Fact]
        public void Vector2InequalityTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(1.0f, 2.0f);

            // case 1: compare between same values
            bool expected = false;
            bool actual = a != b;
            Assert.Equal(expected, actual);

            // case 2: compare between different values
            b = new Vector2(b.X, 10);
            expected = true;
            actual = a != b;
            Assert.Equal(expected, actual);
        }

        // A test for operator == (Vector2, Vector2)
        [Fact]
        public void Vector2EqualityTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(1.0f, 2.0f);

            // case 1: compare between same values
            bool expected = true;
            bool actual = a == b;
            Assert.Equal(expected, actual);

            // case 2: compare between different values
            b = new Vector2(b.X, 10);
            expected = false;
            actual = a == b;
            Assert.Equal(expected, actual);
        }

        // A test for Subtract (Vector2, Vector2)
        [Fact]
        public void Vector2SubtractTest()
        {
            Vector2 a = new Vector2(1.0f, 6.0f);
            Vector2 b = new Vector2(5.0f, 2.0f);

            Vector2 expected = new Vector2(-4.0f, 4.0f);
            Vector2 actual;

            actual = Vector2.Subtract(a, b);
            Assert.Equal(expected, actual);
        }

        // A test for UnitX
        [Fact]
        public void Vector2UnitXTest()
        {
            Vector2 val = new Vector2(1.0f, 0.0f);
            Assert.Equal(val, Vector2.UnitX);
        }

        // A test for UnitY
        [Fact]
        public void Vector2UnitYTest()
        {
            Vector2 val = new Vector2(0.0f, 1.0f);
            Assert.Equal(val, Vector2.UnitY);
        }

        // A test for One
        [Fact]
        public void Vector2OneTest()
        {
            Vector2 val = new Vector2(1.0f, 1.0f);
            Assert.Equal(val, Vector2.One);
        }

        // A test for Zero
        [Fact]
        public void Vector2ZeroTest()
        {
            Vector2 val = new Vector2(0.0f, 0.0f);
            Assert.Equal(val, Vector2.Zero);
        }

        // A test for Equals (Vector2)
        [Fact]
        public void Vector2EqualsTest1()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(1.0f, 2.0f);

            // case 1: compare between same values
            bool expected = true;
            bool actual = a.Equals(b);
            Assert.Equal(expected, actual);

            // case 2: compare between different values
            b = new Vector2(b.X, 10);
            expected = false;
            actual = a.Equals(b);
            Assert.Equal(expected, actual);
        }

        // A test for Vector2 comparison involving NaN values
        [Fact]
        public void Vector2EqualsNanTest()
        {
            Vector2 a = new Vector2(Single.NaN, 0);
            Vector2 b = new Vector2(0, Single.NaN);

            Assert.False(a == Vector2.Zero);
            Assert.False(b == Vector2.Zero);

            Assert.True(a != Vector2.Zero);
            Assert.True(b != Vector2.Zero);

            Assert.False(a.Equals(Vector2.Zero));
            Assert.False(b.Equals(Vector2.Zero));

            // Counterintuitive result - IEEE rules for NaN comparison are weird!
            Assert.False(a.Equals(a));
            Assert.False(b.Equals(b));
        }

        // A test for Reflect (Vector2, Vector2)
        [Fact]
        public void Vector2ReflectTest()
        {
            Vector2 a = Vector2.Normalize(new Vector2(1.0f, 1.0f));

            // Reflect on XZ plane.
            Vector2 n = new Vector2(0.0f, 1.0f);
            Vector2 expected = new Vector2(a.X, -a.Y);
            Vector2 actual = Vector2.Reflect(a, n);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Reflect did not return the expected value.");

            // Reflect on XY plane.
            n = new Vector2(0.0f, 0.0f);
            expected = new Vector2(a.X, a.Y);
            actual = Vector2.Reflect(a, n);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Reflect did not return the expected value.");

            // Reflect on YZ plane.
            n = new Vector2(1.0f, 0.0f);
            expected = new Vector2(-a.X, a.Y);
            actual = Vector2.Reflect(a, n);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Reflect did not return the expected value.");
        }

        // A test for Reflect (Vector2, Vector2)
        // Reflection when normal and source are the same
        [Fact]
        public void Vector2ReflectTest1()
        {
            Vector2 n = new Vector2(0.45f, 1.28f);
            n = Vector2.Normalize(n);
            Vector2 a = n;

            Vector2 expected = -n;
            Vector2 actual = Vector2.Reflect(a, n);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Reflect did not return the expected value.");
        }

        // A test for Reflect (Vector2, Vector2)
        // Reflection when normal and source are negation
        [Fact]
        public void Vector2ReflectTest2()
        {
            Vector2 n = new Vector2(0.45f, 1.28f);
            n = Vector2.Normalize(n);
            Vector2 a = -n;

            Vector2 expected = n;
            Vector2 actual = Vector2.Reflect(a, n);
            Assert.True(MathHelper.Equal(expected, actual), "Vector2.Reflect did not return the expected value.");
        }

        [Fact]
        public void Vector2AbsTest()
        {
            Vector2 v1 = new Vector2(-2.5f, 2.0f);
            Vector2 v3 = Vector2.Abs(new Vector2(0.0f, Single.NegativeInfinity));
            Vector2 v = Vector2.Abs(v1);
            Assert.Equal(2.5f, v.X);
            Assert.Equal(2.0f, v.Y);
            Assert.Equal(0.0f, v3.X);
            Assert.Equal(Single.PositiveInfinity, v3.Y);
        }

        [Fact]
        public void Vector2SqrtTest()
        {
            Vector2 v1 = new Vector2(-2.5f, 2.0f);
            Vector2 v2 = new Vector2(5.5f, 4.5f);
            Assert.Equal(2, (int)Vector2.SquareRoot(v2).X);
            Assert.Equal(2, (int)Vector2.SquareRoot(v2).Y);
            Assert.Equal(Single.NaN, Vector2.SquareRoot(v1).X);
        }

        #pragma warning disable xUnit2000 // 'sizeof(constant) should be argument 'expected'' error
        // A test to make sure these types are blittable directly into GPU buffer memory layouts
        [Fact]
        public unsafe void Vector2SizeofTest()
        {
            Assert.Equal(sizeof(Single) * 2, sizeof(Vector2));
            Assert.Equal(sizeof(Single) * 2 * 2, sizeof(Vector2_2x));
            Assert.Equal(sizeof(Single) * 2 + sizeof(Single), sizeof(Vector2PlusSingle));
            Assert.Equal((sizeof(Single) * 2 + sizeof(Single)) * 2, sizeof(Vector2PlusSingle_2x));
        }
        #pragma warning restore xUnit2000 // 'sizeof(constant) should be argument 'expected'' error

        [StructLayout(LayoutKind.Sequential)]
        struct Vector2_2x
        {
            private Vector2 _a;
            private Vector2 _b;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector2PlusSingle
        {
            private Vector2 _v;
            private Single _f;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector2PlusSingle_2x
        {
            private Vector2PlusSingle _a;
            private Vector2PlusSingle _b;
        }
        

    }
}