using F2DE.Base;
using F2DE.Base.Components;
using F2DE.Base.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D.Blocks
{
    internal class Air : AbstractBlock
    {
        public Air(Game game) : base(game)
        {
        }

        public override void Update(BlockState blockState, BlockPos blockPos)
        {
            base.Update(blockState, blockPos);
            blockState.entity.GetComponent<SpriteRenderer>()!.SetTexture(null);
            blockState.entity.GetComponent<BoundingBox>()!.enabled = false;
        }
    }
}
