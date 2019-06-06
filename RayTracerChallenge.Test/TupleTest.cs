using System;
using System.Drawing;
using FluentAssertions;
using RayTracerChallenge.Math;
using Xunit;

namespace RayTracerChallenge.Test
{
    public class TupleTest
    {
        #region construction

        [Fact]
        public void W_EqualsOne_IsAPoint()
        {
            var point = new Toople(2.1f, 2.2f, 2.3f, 1.0f);

            point.X.Should().Be(2.1f);
            point.Y.Should().Be(2.2f);
            point.Z.Should().Be(2.3f);
            point.W.Should().Be(1.0f);

            point.IsPoint.Should().BeTrue();
            point.IsVector.Should().BeFalse();
        }

        [Fact]
        public void W_EqualsZero_IsAVector()
        {
            var vector = new Toople(1.1f, 1.2f, 1.3f, 0f);
            vector.IsPoint.Should().BeFalse();
            vector.IsVector.Should().BeTrue();
        }

        [Fact]
        public void W_aboveOne_NeitherPointNorVector()
        {
            var a = new Toople(1f, 1f, 1f, 5f);
            a.IsPoint.Should().BeFalse();
            a.IsVector.Should().BeFalse();
        }

        [Fact]
        public void Point_CreatesPoint()
        {
            var point = Toople.Point(1f, 2f, 3f);
            point.IsPoint.Should().BeTrue();
        }

        [Fact]
        public void Vector_CreatesVector()
        {
            var vector = Toople.Vector(1f, 2f, 3f);
            vector.IsVector.Should().BeTrue();
        }

        #endregion

        #region equality

        [Fact]
        public void EqualsWorks()
        {
            var point = Toople.Point(1f, 2f, 3f);

            point.Should().BeEquivalentTo(new Toople(1f, 2f, 3f, 1f));

            var p2 = Toople.Point(1f, 2f, 3f);
            point.Equals(p2).Should().BeTrue();

            var vector = Toople.Vector(1f, 2f, 3f);

            point.Equals(vector).Should().BeFalse();
        }

        [Theory]
        [InlineData(1.1f, 2f, 3f, 0f, false)]
        [InlineData(1f, 2.1f, 3f, 0f, false)]
        [InlineData(1f, 2f, 3.1f, 0f, false)]
        [InlineData(1f, 2f, 3f, 1f, false)]
        public void DetailedEquals(float x, float y, float z, float w, bool expected)
        {
            var p = new Toople(1f, 2f, 3f, 0f);

            var a = new Toople(x, y, z, w);
            p.Equals(a).Should().Be(expected);
        }

        #endregion

        #region operators

        [Fact]
        public void AddingTuples()
        {
            var point = Toople.Point(3f, -2f, 5f);
            var vector = Toople.Vector(-2f, 3f, 1f);

            var result = point + vector;
            result.Should().BeEquivalentTo(new Toople(1f, 1f, 6f, 1f));
        }

        [Fact]
        public void Subtracting_twoPoints()
        {
            var pointA = Toople.Point(3f, 2f, 1f);
            var pointB = Toople.Point(5f, 6f, 7f);

            var result = pointA - pointB;
            result.Should().BeEquivalentTo(Toople.Vector(-2f, -4f, -6f));
        }

        [Fact]
        public void Subtracting_vectorFromPoint()
        {
            var point = Toople.Point(3f, 2f, 1f);
            var vector = Toople.Vector(5f, 6f, 7f);

            var result = point - vector;
            result.Should().BeEquivalentTo(Toople.Point(-2f, -4f, -6f));
        }

        [Fact]
        public void Subtracting_twoVectors()
        {
            var vectorA = Toople.Vector(3f, 2f, 1f);
            var vectorB = Toople.Vector(5f, 6f, 7f);

            var result = vectorA - vectorB;
            result.Should().BeEquivalentTo(Toople.Vector(-2f, -4f, -6f));
        }

        [Fact]
        public void Subtracting_fromZeroVector()
        {
            var zero = Toople.Vector(0, 0, 0);
            var v = Toople.Vector(1f, -2f, 3f);

            var result = zero - v;
            result.Should().BeEquivalentTo(Toople.Vector(-1f, 2f, -3f));
        }

        [Fact]
        public void Negation()
        {
            var t = new Toople(1f, -2f, 3f, -4f);

            (-t).Should().BeEquivalentTo(new Toople(-1f, 2f, -3f, 4f));
        }

        [Fact]
        public void Multiplication_scalar()
        {
            var t = new Toople(1f, -2f, 3f, -4f);

            var result = t * 3.5f;
            result.Should().BeEquivalentTo(new Toople(3.5f, -7f, 10.5f, -14f));
        }

        [Fact]
        public void Multiplication_fraction()
        {
            var t = new Toople(1f, -2f, 3f, -4f);

            var result = t * 0.5f;
            result.Should().BeEquivalentTo(new Toople(0.5f, -1f, 1.5f, -2f));
        }

        [Fact]
        public void Division_scalar()
        {
            var t = new Toople(1f, -2f, 3f, -4f);
            var result = t / 2;
            result.Should().BeEquivalentTo(new Toople(0.5f, -1f, 1.5f, -2f));
        }

        #endregion

        #region vectorMath

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1f, 0, 0, 1f)]
        [InlineData(0, 1f, 0, 1f)]
        [InlineData(0, 0, 1f, 1f)]
        public void Magnitude_identities(float x, float y, float z, float magnitude)
        {
            var v = Toople.Vector(x, y, z);
            v.Magnitude.Should().BeApproximately(magnitude, float.Epsilon);
        }

        [Fact]
        public void Magnitude_simpleCase()
        {
            var v = Toople.Vector(1f, 2f, 3f);
            v.Magnitude.Should().BeApproximately(MathF.Sqrt(14f), float.Epsilon);
        }

        [Fact]
        public void Magnitude_negatives()
        {
            var v = Toople.Vector(1f, -2f, -3f);
            v.Magnitude.Should().BeApproximately(MathF.Sqrt(14f), float.Epsilon);
        }


        [Fact]
        public void Normalization_simpleCase()
        {
            var v = Toople.Vector(4f, 0, 0);
            v.Normalize().Should().BeEquivalentTo(Toople.Vector(1f, 0, 0));
        }

        [Fact]
        public void Normalization_values()
        {
            var v = Toople.Vector(1f, 2f, 3f);
            var sqrt = MathF.Sqrt(14f);
            v.Normalize().Should().BeEquivalentTo(
                Toople.Vector(1f / sqrt, 2f / sqrt, 3f / sqrt));
        }

        [Theory]
        [InlineData(2f, 4.3f, -6.2f)]
        [InlineData(5f, 0, 0)]
        [InlineData(1f, 2f, 3f)]
        public void NormalizedMagnitude_isOne(float x, float y, float z)
        {
            var normalize = Toople.Vector(x, y, z).Normalize();
            normalize.Magnitude.Should().BeApproximately(1f, (float) 1e-5);
        }

        [Fact]
        public void DotProduct()
        {
            var a = Toople.Vector(1f, 2f, 3f);
            var b = Toople.Vector(2f, 3f, 4f);

            var result = a.Dot(b);
            result.Should().BeApproximately(20, float.Epsilon);
        }

        [Fact]
        public void CrossProduct()
        {
            var a = Toople.Vector(1f, 2f, 3f);
            var b = Toople.Vector(2f, 3f, 4f);

            a.Cross(b).Should().BeEquivalentTo(Toople.Vector(-1f, 2f, -1f));
            b.Cross(a).Should().BeEquivalentTo(Toople.Vector(1f, -2f, 1f));
        }

        #endregion
    }
}