using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Interfaces
{
    internal interface IRenderTickable
    {
        public abstract void RenderTick(string layer);
    }
}
