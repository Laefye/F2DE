using F2DE.Base.Components;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.SimpleMath
{
    internal class MatrixLike
    {
        private Locator locator;

        public MatrixLike(Locator locator)
        {
            this.locator = locator;
        }

        public Vector2 Translate(Vector2 v) => locator.position + v;
        public Vector2 InverseTranslate(Vector2 v) => v - locator.position;
        public Vector2 Rotate(Vector2 v) => v * locator.rotation;

        public Vector2 ToUp(Vector2 point) => Translate(Rotate(point));

        public Vector2 ToLocal(Vector2 point) => InverseTranslate(point);
    }
}
