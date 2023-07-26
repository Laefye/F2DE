using F2DE.Base.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.SimpleMath
{
    internal class MagicMatrix
    {
        public Vector2 translation;
        public Rotation rotatation;

        public Vector2 Translate(Vector2 v) => translation + v;
        public Vector2 InverseTranslate(Vector2 v) => v - translation;
        public Vector2 Rotate(Vector2 v) => v * locator.rotation;

        public Vector2 ToUp(Vector2 point) => Translate(Rotate(point));
    }
}
