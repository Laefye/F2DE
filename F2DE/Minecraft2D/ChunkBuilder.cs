using F2DE.Base;
using F2DE.Base.Builders;
using F2DE.Base.Components;
using F2DE.Base.Registries;
using F2DE.Base.SimpleMath;
using F2DE.Minecraft2D.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D
{
    internal class ChunkBuilder
    {
        public EntityBuilder CreateBuilder()
        {
            return new EntityBuilder()
                .Add<Locator>()
                .Add<Chunk>();
        }
    }
}
