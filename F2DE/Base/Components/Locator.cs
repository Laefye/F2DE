using F2DE.Base.SimpleMath;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Components
{
    internal class Locator : EntityComponent
    {
        public Vector2 position = Vector2.zero;
        public Rotation rotation = Rotation.identity;
        public MatrixLike matrix;
        public Locator? parent;

        // World Position
        public Vector2 Position
        {
            get
            {
                var position = this.position;
                var parent = this.parent;
                while (parent != null)
                {
                    position = parent.matrix.ToUp(position);
                    parent = parent.parent;
                }
                return position;
            }
        }

        // World Rotation
        public Rotation Rotation
        {
            get
            {
                var rotation = this.rotation;
                var parent = this.parent;
                while (parent != null)
                {
                    rotation = rotation * parent.rotation;
                    parent = parent.parent;
                }
                return rotation;
            }
        }

        public Locator(Entity entity) : base(entity)
        {
            matrix = new MatrixLike(this);
        }
    }
}
