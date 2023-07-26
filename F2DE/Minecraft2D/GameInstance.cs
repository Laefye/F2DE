using F2DE.Base;
using F2DE.Base.Builders;
using F2DE.Base.Components;
using F2DE.Base.Registries;
using F2DE.Base.SimpleMath;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D
{
    internal class GameInstance : Instance
    {
        public GameInstance(Game game) : base(game)
        {
            var player = Add(new EntityBuilder()
                .Add<Locator>()
                .Add<SpriteRenderer>()
                .Add<BoundingBox>()
                .Add<Player>()
                .Post((c) => {
                    var s = c.GetComponent<SpriteRenderer>()!;
                    s.layer = "general";
                    s.SetTexture(game.registry.GetResource<TextureResource>("texture/player")!);
                    c.GetComponent<BoundingBox>()!.size = new Vector2(8, 32);
                })
            ); ;
            var chunk = Add(new ChunkBuilder().CreateBuilder());
        }
    }
}
