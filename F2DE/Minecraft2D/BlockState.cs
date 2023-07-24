using F2DE.Base;
using F2DE.Base.Components;
using F2DE.Base.Interfaces;
using F2DE.Minecraft2D.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D
{
    internal class BlockState : EntityComponent
    {
        public AbstractBlock? block;
        private SpriteRenderer renderer;

        public BlockState(Entity entity) : base(entity)
        {
            renderer = entity.GetComponent<SpriteRenderer>()!;
        }

        public void Update()
        {
            if (block != null)
            {
                var t = block.GetTexture(this);
                renderer.SetTexture(t);
            }
        }
    }
}
