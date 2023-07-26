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
        public abstract TextureResource? GetTexture(BlockState blockState);

        public Game game;

        public AbstractBlock(Game game)
        {
            this.game = game;
        }

        public virtual void SetBoudingBox(BlockState blockState, BoundingBox boundingBox)
        {
            boundingBox.size = new Vector2(16, 16);
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
    }
}
