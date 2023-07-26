using F2DE.Base.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.SimpleMath
{
    internal struct MagicMatrixLike
    {
        public Vector2 translation;
        public Rotation rotatation;

        public MagicMatrixLike()
        {
            translation = Vector2.zero;
            rotatation = Rotation.identity;
        }

        public MagicMatrixLike(Vector2 translation, Rotation rotatation)
        {
            this.translation = translation;
            this.rotatation = rotatation;
        }

        public Vector2 Translate(Vector2 v) => translation + v;
        public Vector2 InverseTranslate(Vector2 v) => v - translation;
        public Vector2 Rotate(Vector2 v) => v * rotatation;

        public Vector2 Evaluate(Vector2 point) => Translate(Rotate(point));
        public Vector2 Reevaluate(Vector2 point) => InverseTranslate(point);

        public static Vector2 operator *(Vector2 left, MagicMatrixLike right) => (left + right.translation) * right.rotatation;
        public static Rotation operator *(Rotation left, MagicMatrixLike right) => left * right.rotatation;
        public static MagicMatrixLike operator *(MagicMatrixLike left, MagicMatrixLike right) => new MagicMatrixLike(left.translation + right.translation, left.rotatation * right.rotatation);
    }
}
