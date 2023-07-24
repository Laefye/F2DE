using F2DE.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Registries
{
    internal abstract class Resource : RegisterValue
    {
        public string name;

        public Resource(string name)
        {
            this.name = name;
        }
    }
}
