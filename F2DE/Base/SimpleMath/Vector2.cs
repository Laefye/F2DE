﻿using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.SimpleMath
{
    internal struct Vector2
    {
        public float x = 0;
        public float y = 0;

        public static Vector2 zero = new Vector2(0, 0);
        public static Vector2 down = new Vector2(0, 1);
        public static Vector2 up = new Vector2(0, -1);
        public static Vector2 right = new Vector2(1, 0);
        public static Vector2 left = new Vector2(-1, 0);

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 v)
        {
            x = v.x;
            y = v.y;
        }

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(Vector2f v)
        {
            x = v.X;
            y = v.Y;
        }

        public Vector2f toSfmlVector()
        {
            return new Vector2f(x, y);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, float b) => new Vector2(a.x * b, a.y * b);

        public float Length
        {
            get
            {
                return Mathf.Sqrt(x * x + y * y);
            }
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            return (b - a).Length;
        }
    }
}
