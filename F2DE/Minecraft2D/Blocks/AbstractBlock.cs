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

        public EntityBuilder GetBasePrefab()
        {
            return new EntityBuilder()
                .Add<Locator>()
                .Add<BoundingBox>()
                .Add<SpriteRenderer>()
                .Add<BlockState>()
                .Post((p) => {
                    p.GetComponent<SpriteRenderer>()!.layer = "background";
                    var state = p.GetComponent<BlockState>()!;
                    state.block = this;
                    state.Update();
                });
        }

        public virtual void Update(BlockState blockState, BlockPos blockPos)
        {
            blockState.entity.GetComponent<BoundingBox>()!.size = new Vector2(16, 16);
        }
    }
}
