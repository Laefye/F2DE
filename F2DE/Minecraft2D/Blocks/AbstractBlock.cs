using F2DE.Base;
using F2DE.Base.Builders;
using F2DE.Base.Components;
using F2DE.Base.Registries;
using F2DE.Base.SimpleMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D.Blocks
{
    internal abstract class AbstractBlock
    {
        public Game game;

        public AbstractBlock(Game game)
        {
            this.game = game;
        }

        public BlockState GetDefaultBlockState()
        {
            return new BlockState(this);
        }

        public virtual void Update(BlockState state, BlockPos pos)
        {

        }

        public virtual TextureResource? GetTexture(BlockState state, BlockPos pos)
        {
            return null;
        }
    }
}
