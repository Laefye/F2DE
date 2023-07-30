using F2DE.Base;
using F2DE.Base.Builders;
using F2DE.Base.Components;
using F2DE.Base.Interfaces;
using F2DE.Base.Registries;
using F2DE.Base.SimpleMath;
using F2DE.Minecraft2D.Blocks;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D
{
    internal class Chunk : EntityComponent, IPost, IDisposable, IRenderTickable
    {
        private BlockState[] blockStates = new BlockState[GameConstants.CHUNK_WIDTH * 128];
        private Dictionary<TextureResource, Sprite> cache = new Dictionary<TextureResource, Sprite>();
        private Locator locator;

        public Chunk(Entity entity) : base(entity)
        {
            locator = entity.GetComponent<Locator>()!;
        }

        private int minHeight = 0;
        
        public int GetIndex(BlockPos blockPos)
        {
            blockPos.y += minHeight;

            return blockPos.y * GameConstants.CHUNK_WIDTH + blockPos.x;
        }
        
        public BlockPos GetBlockPos(int index)
        {
            int y = index / GameConstants.CHUNK_WIDTH;
            int x = index % GameConstants.CHUNK_WIDTH;
            return new BlockPos(x, y - minHeight);
        }
        
        public BlockState MakeBlockState(BlockPos blockPos, AbstractBlock block)
        {
            var st = block.GetDefaultBlockState();
            blockStates[GetIndex(blockPos)] = st;
            return st;
        }

        public void Post()
        {
            var rand = new Random();
            var blocks = entity.instance.game.registry.GetValue<BlocksRegistry>()!;
            var air = blocks.Get("air")!;
            var grass = blocks.Get("grass")!;
            var stone = blocks.Get("stone")!;
            for (int x = 0; x < GameConstants.CHUNK_WIDTH; x++)
            {
                int offset = rand.Next(2);
                for (int y = 0;  y < GameConstants.CHUNK_HEIGHT; y++)
                {
                    var blockpos = new BlockPos(x, y);
                    if (blockpos.y == 7 + offset)
                    {
                        MakeBlockState(blockpos, grass);
                    }
                    if (blockpos.y < 7 + offset)
                    {
                        MakeBlockState(blockpos, air);
                    }
                    else if (blockpos.y > 7 + offset)
                    {
                        MakeBlockState(blockpos, stone);
                    }
                }
            }
        }

        public static EntityBuilder GetEntityBuilder()
        {
            return new EntityBuilder()
                .Add<Locator>()
                .Add<Chunk>();
        }

        public Sprite GetSprite(TextureResource resource)
        {
            if (cache.ContainsKey(resource))
            {
                return cache[resource];
            }
            var sprite = new Sprite(resource.texture);
            cache[resource] = sprite;
            return sprite;
        }

        public void Dispose()
        {
            foreach (var sprite in cache.Values)
            {
                sprite.Dispose();
            }
        }

        public void RenderTick(string layer)
        {
            if (layer != "background")
            {
                return;
            }
            for (int i = 0; i < blockStates.Length; i++)
            {
                var blockpos = GetBlockPos(i);
                var realpos = (locator.Position + new Vector2(blockpos.x * GameConstants.BLOCK_SIZE, blockpos.y * GameConstants.BLOCK_SIZE));
                if (realpos.x > 320 || realpos.x < 0 || realpos.y < 0 || realpos.y > 240)
                {
                    continue;
                }
                var state = blockStates[i];
                var texture = state.block.GetTexture(state, blockpos);
                if (texture != null)
                {
                    var sprite = GetSprite(texture!);
                    sprite.Position = realpos.toSfmlVector();
                    entity.instance.game.window.Draw(sprite);
                }
            }
        }
    }
}
