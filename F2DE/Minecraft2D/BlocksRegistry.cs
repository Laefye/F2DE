using F2DE.Base;
using F2DE.Base.Interfaces;
using F2DE.Minecraft2D.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D
{
    internal class BlocksRegistry : RegisterValue
    {
        private class BlockRegister : RegisterValue
        {
            public AbstractBlock block;
            public string id;

            public BlockRegister(string id, AbstractBlock block)
            {
                this.id = id;
                this.block = block;
            }
        }

        public Registry registry;

        public BlocksRegistry(Registry registry)
        {
            this.registry = registry;
        }

        public void Register(string id, AbstractBlock block)
        {
            registry.Register(new BlockRegister(id, block));
        }

        public AbstractBlock? Get(string id)
        {
            var blocks = registry.GetValues<BlockRegister>();
            foreach (var block in blocks)
            {
                if (block.id == id)
                {
                    return block.block;
                }
            }
            return null;
        }

        public string? Get(AbstractBlock block)
        {
            foreach (var item in registry.GetValues<BlockRegister>())
            {
                if (item.block == block)
                {
                    return item.id;
                }
            }
            return null;
        }
    }
}
