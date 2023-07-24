using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Registries
{
    internal class TextureResource : Resource, IDisposable
    {
        public Texture texture;

        public TextureResource(string name, string file) : base(name)
        {
            texture = new Texture(file);
        }

        public void Dispose()
        {
            texture.Dispose();
        }
    }
}
