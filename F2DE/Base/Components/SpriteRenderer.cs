using F2DE.Base.Interfaces;
using F2DE.Base.Registries;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Components
{
    internal class SpriteRenderer : EntityComponent, IRenderTickable, IDisposable
    {
        private Sprite? sprite;
        private Locator locator;
        public string? layer = null;

        public SpriteRenderer(Entity entity) : base(entity)
        {
            locator = entity.GetComponent<Locator>()!;
        }

        public void Dispose()
        {
            sprite?.Dispose();
        }

        public void SetTexture(TextureResource? texture)
        {
            if (sprite != null)
            {
                sprite.Dispose();
                sprite = null;
            }
            if (texture != null)
            {
                sprite = new Sprite(texture.texture);
            }
        }

        public void RenderTick(string layer)
        {
            if (sprite == null)
            {
                return;
            }
            if (this.layer == null || layer == this.layer)
            {
                sprite.Position = locator.Position.toSfmlVector();
                sprite.Rotation = locator.Rotation.Degree;
                entity.instance.game.window.Draw(sprite);
            }
        }
    }
}
