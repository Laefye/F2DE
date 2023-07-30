using F2DE.Base;
using F2DE.Base.Components;
using F2DE.Base.SimpleMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D
{
    internal class World : EntityComponent
    {
        private Dictionary<int, Chunk> chunks = new Dictionary<int, Chunk>();

        public World(Entity entity) : base(entity)
        {
            PutNewChunk(-1);
            PutNewChunk(0);
            PutNewChunk(1);
        }

        public void PutNewChunk(int index)
        {
            var chunk = entity.instance.Add(Chunk.GetEntityBuilder().Post((c) =>
            {
                var l = c.GetComponent<Locator>()!;
                l.parent = entity.GetComponent<Locator>();
                l.position = new Vector2(index * GameConstants.CHUNK_WIDTH * GameConstants.BLOCK_SIZE, 0);
            }));
        }
    }
}
