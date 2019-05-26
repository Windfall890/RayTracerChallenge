using System;

namespace RayTracerChallenge
{
    public class Toople
    {
        private const float Tolerance = float.Epsilon;

        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        public float W { get; }
        public bool IsPoint => FloatClose(W, 1f);
        public bool IsVector => FloatClose(W, 0f);
        public float Magnitude => (float) Math.Sqrt(X*X + Y*Y + Z*Z + W*W);

        public Toople(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Toople Point(float x, float y, float z)
        {
            return new Toople(x, y, z, 1f);
        }

        public static Toople Vector(float x, float y, float z)
        {
            return new Toople(x, y, z, 0f);
        }

        #region operators

        public static Toople operator +(Toople a, Toople b)
        {
            return new Toople(a.X + b.X,
                              a.Y + b.Y,
                              a.Z + b.Z,
                              a.W + b.W);
        }

        public static Toople operator -(Toople a, Toople b)
        {
            return new Toople(a.X - b.X,
                              a.Y - b.Y,
                              a.Z - b.Z,
                              a.W - b.W);
        }

        public static Toople operator -(Toople a)
        {
            return new Toople(-a.X, -a.Y, -a.Z, -a.W);
        }

        public static Toople operator *(Toople t, float scalar)
        {
            return new Toople(t.X * scalar,
                              t.Y * scalar,
                              t.Z * scalar,
                              t.W * scalar);
        }

        public static Toople operator /(Toople t, float scalar)
        {
            return new Toople(t.X / scalar,
                              t.Y / scalar,
                              t.Z / scalar,
                              t.W / scalar);
        }

        #endregion

        #region equality

        protected bool Equals(Toople other)
        {
            return FloatClose(W, other.W) &&
                   FloatClose(X, other.X) &&
                   FloatClose(Y, other.Y) &&
                   FloatClose(Z, other.Z);
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Toople) obj);
        }

        private bool FloatClose(float a, float b)
        {
            return Math.Abs(a - b) < Tolerance;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}