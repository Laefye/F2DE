using F2DE.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Registries
{
    internal class RenderLayer : RegisterValue
    {
        public string layer;

        public RenderLayer(string layer)
        {
            this.layer = layer;
        }
    }
}
