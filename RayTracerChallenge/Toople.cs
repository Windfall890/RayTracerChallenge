using System;

namespace RayTracerChallenge.Test
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
            return null;
        }

        #endregion
        #region equality

        protected bool Equals(Toople other)
        {
            return FloatClose(W,other.W) &&
                   FloatClose(X ,other.X) &&
                   FloatClose(Y ,other.Y) &&
                   FloatClose(Z ,other.Z);
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