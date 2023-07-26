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
        public Locator? parent;

        // Relative to World
        public MagicMatrixLike Matrix
        {
            get
            {
                if (parent != null)
                {
                    return new MagicMatrixLike(parent.Position, parent.Rotation);
                }
                return new MagicMatrixLike();
            }
        }

        // World Position
        public Vector2 Position
        {
            get
            {
                return position * Matrix;
            }
        }

        // World Rotation
        public Rotation Rotation
        {
            get
            {
                return rotation * Matrix;
            }
        }

        public Locator(Entity entity) : base(entity)
        {
        }
    }
}
