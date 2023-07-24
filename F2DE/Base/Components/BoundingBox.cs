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

        public BoundingBox(Entity entity) : base(entity)
        {
            locator = entity.GetComponent<Locator>()!;
        }
    }
}
