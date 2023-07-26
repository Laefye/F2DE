using F2DE.Base.Interfaces;
using F2DE.Base.SimpleMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Components
{
    internal class BoundingBox : EntityComponent
    {
        public Vector2 size = new Vector2(32, 32);
        private Locator locator;
        public bool enabled = true;

        public BoundingBox(Entity entity) : base(entity)
        {
            locator = entity.GetComponent<Locator>()!;
        }

        private bool IsIntersectByX(Vector2 position, BoundingBox other)
        {
            return (position.x + size.x > other.locator.Position.x) && (position.x < other.locator.Position.x + other.size.x);
        }

        private bool IsIntersectByY(Vector2 position, BoundingBox other)
        {
            return (position.y + size.y > other.locator.Position.y) && (position.y < other.locator.Position.y + other.size.y);
        }

        public bool IsIntersect(Vector2 position, BoundingBox other)
        {
            if (!enabled || !other.enabled)
            {
                return false;
            }
            if (other == this)
            {
                return true;
            }
            return IsIntersectByX(position, other) && IsIntersectByY(position, other);
        }
    }
}
