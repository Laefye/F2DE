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
        private BoundingBox boundingBox;
        public BlockPos blockPos;

        public BlockState(Entity entity) : base(entity)
        {
            renderer = entity.GetComponent<SpriteRenderer>()!;
            boundingBox = entity.GetComponent<BoundingBox>()!;
        }

        public void Update()
        {
            if (block != null)
            {
                block.Update(this, blockPos);
            }
        }
    }
}
