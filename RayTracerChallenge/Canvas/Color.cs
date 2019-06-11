using RayTracerChallenge.Math;

namespace RayTracerChallenge.Canvas
{
    public class Color
    {
        private Toople _toople;

        public Color(float r, float g, float b)
        {
            _toople = new Toople(r, g, b, 0);
        }

        public float R => _toople.X;
        public float G => _toople.Y;
        public float B => _toople.Z;

        public static Color operator +(Color a, Color b)
        {
            return new Color(a.R + b.R,
                             a.G + b.G,
                             a.B + b.B);
        }

        public static Color operator -(Color a, Color b)
        {
            return new Color(a.R - b.R,
                             a.G - b.G,
                             a.B - b.B);
        }

        public static Color operator *(Color c, float s)
        {
            return new Color(c.R * s,
                             c.G * s,
                             c.B * s);
        }

        public static Color operator *(Color a, Color b)
        {
            return new Color(a.R * b.R,
                             a.G * b.G,
                             a.B * b.B);
        }
    }
}