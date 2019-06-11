using System;
using FluentAssertions;
using RayTracerChallenge.Canvas;
using Xunit;

namespace RayTracerChallenge.Test
{
    public class ColorTests
    {
        private const float Precision = 0.00000001f;

        [Fact]
        public void ColorWorks()
        {
            var color = new Color(0.5f, 0.2f, 1f);
            color.R.Should().BeApproximately(0.5f, Precision);
            color.G.Should().BeApproximately(0.2f, Precision);
            color.B.Should().BeApproximately(1f, Precision);
        }

        [Fact]
        public void AddColor()
        {
            var a = new Color(0.1f, 2.3f, 0.75f);
            var b = new Color(0.1f, 0.3f, 0.25f);

            var res = a + b;

            res.R.Should().BeApproximately(0.2f, Precision);
            res.G.Should().BeApproximately(2.6f, Precision);
            res.B.Should().BeApproximately(1.0f, Precision);
        }

        [Fact]
        public void SubtractColor()
        {
            var a = new Color(0.1f, 2.3f, 0.75f);
            var b = new Color(0.1f, 0.3f, 0.25f);

            var res = a - b;

            res.R.Should().BeApproximately(0f, Precision);
            res.G.Should().BeApproximately(2.0f, Precision);
            res.B.Should().BeApproximately(0.5f, Precision);
        }

        [Fact]
        public void MultiplyScalar()
        {
            var a = new Color(0.1f, 2.3f, 0.75f);

            var res = a * 2f;

            res.R.Should().BeApproximately(0.2f, Precision);
            res.G.Should().BeApproximately(4.6f, Precision);
            res.B.Should().BeApproximately(1.5f, Precision);
        }

        [Fact]
        public void MultiplyColor()
        {
            var a = new Color(1f, 0.2f, 0.4f);
            var b = new Color(0.9f, 1f, 0.1f);

            var res = a * b;

            res.R.Should().BeApproximately(0.9f, Precision);
            res.G.Should().BeApproximately(0.2f, Precision);
            res.B.Should().BeApproximately(0.04f, Precision);
        }
    }
}