using F2DE.Base;
using F2DE.Base.Builders;
using F2DE.Base.Components;
using F2DE.Base.Interfaces;
using F2DE.Base.SimpleMath;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D
{
    internal class Chunk : EntityComponent, IPost
    {
        private BlockState[] blockStates = new BlockState[16 * 128];

        public Chunk(Entity entity) : base(entity)
        {
        }

        private int minHeight = 0;
        
        public int GetIndex(BlockPos blockPos)
        {
            blockPos.y += minHeight;

            return blockPos.y * 16 + blockPos.x;
        }
        
        public BlockPos GetBlockPos(int index)
        {
            int y = index / 16;
            int x = index % 16;
            return new BlockPos(x, y - minHeight);
        }
        
        public BlockState MakeBlockState(BlockPos blockPos, EntityBuilder entityBuilder)
        {
            if (blockStates[GetIndex(blockPos)] != null)
            {
                blockStates[GetIndex(blockPos)].entity.instance.Destroy(blockStates[GetIndex(blockPos)].entity);
            }
            var state = entity.instance.Add(entityBuilder.Post((e) =>
            {
                var locator = e.GetComponent<Locator>()!;
                locator.parent = entity.GetComponent<Locator>();
                locator.position = new Base.SimpleMath.Vector2(blockPos.x * 16, blockPos.y * 16);
            })).GetComponent<BlockState>()!;
            blockStates[GetIndex(blockPos)] = state;
            return state;
        }

        public void Post()
        {
            var blocks = entity.instance.game.registry.GetValue<BlocksRegistry>()!;
            var air = blocks.Get("air")!;
            var grass = blocks.Get("grass")!;
            var stone = blocks.Get("stone")!;
            for (int i = 0; i < blockStates.Length; i++)
            {
                var blockpos = GetBlockPos(i);
                if (blockpos.y == 7)
                {
                    MakeBlockState(blockpos, grass.GetBasePrefab());
                }
                if (blockpos.y < 7)
                {
                    MakeBlockState(blockpos, air.GetBasePrefab());
                }
                else if (blockpos.y > 7) 
                {
                    MakeBlockState(blockpos, stone.GetBasePrefab());
                }

            }
        }
    }
}
