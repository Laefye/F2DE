using F2DE.Base.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.SimpleMath
{
    internal struct Rotation
    {
        public float x;
        public float y;

        public static Rotation identity = Rotation.of(0);

        public float Radian
        {
            get
            {
                return Mathf.Atan2(y, x);
            }
        }
        public float Degree
        {
            get
            {
                return Radian / Mathf.PI * 180f;
            }
        }

        public Rotation(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Rotation of(float angle) => new Rotation(Mathf.Cos(angle), Mathf.Sin(angle));

        public static Rotation ofDegree(float angle) => of(angle / 180f * Mathf.PI);

        public Vector2 toDirection() => new Vector2(x, y);

        public static Rotation operator *(Rotation a, Rotation q) => new Rotation(a.x * q.x - a.y * q.y, a.x * q.y + a.y * q.x);
        public static Vector2 operator *(Vector2 a, Rotation q) => new Vector2(a.x * q.x - a.y * q.y, a.x * q.y + a.y * q.x);
    }
}
