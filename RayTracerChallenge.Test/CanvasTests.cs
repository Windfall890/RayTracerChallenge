using System;
using FluentAssertions;
using RayTracerChallenge.Canvas;
using Xunit;

namespace RayTracerChallenge.Test
{
    public class CanvasTests
    {
        [Fact]
        public void ColorWorks()
        {
            var color = new Color(0.5f, 0.2f, 1f);
            color.R.Should().BeApproximately(0.5f, Single.Epsilon);
            color.G.Should().BeApproximately(0.2f, Single.Epsilon);
            color.B.Should().BeApproximately(1f, Single.Epsilon);
        }

        [Fact]
        public void AddColor()
        {
            var a = new Color(0, 0, 0);
        }
    }
}