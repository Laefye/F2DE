using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base
{
    internal abstract class EntityComponent
    {
        public Entity entity;

        public EntityComponent(Entity entity)
        {
            this.entity = entity;
        }
    }
}
