using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D
{
    internal struct BlockPos
    {
        public int x;
        public int y;

        public BlockPos(int  x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
