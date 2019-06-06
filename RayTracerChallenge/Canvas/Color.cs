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
    }
}