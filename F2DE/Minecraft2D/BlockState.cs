using F2DE.Base;
using F2DE.Base.Components;
using F2DE.Base.Interfaces;
using F2DE.Base.Registries;
using F2DE.Minecraft2D.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D
{
    internal class BlockState
    {
        public AbstractBlock block;

        public BlockState(AbstractBlock block)
        {
            this.block = block;
        }
    }
}
