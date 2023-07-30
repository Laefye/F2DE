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
    internal class Block : AbstractBlock
    {
        public Block(Game game) : base(game)
        {
        }

        public override TextureResource? GetTexture(BlockState blockState, BlockPos blockPos)
        {
            return game.registry.GetResource<TextureResource>("texture/block/" + game.registry.GetValue<BlocksRegistry>()!.Get(blockState.block!));
        }
    }
}
