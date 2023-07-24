using F2DE.Base;
using F2DE.Base.Components;
using F2DE.Base.Interfaces;
using F2DE.Base.SimpleMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Minecraft2D
{
    internal class Player : EntityComponent, ITickable
    {
        private Locator transform;

        public Player(Entity entity) : base(entity)
        {
            transform = entity.GetComponent<Locator>()!;
        }

        public void Tick()
        {
            transform.position += new Vector2(48, 0) * (1f / 60f) * entity.instance.game.input.Horisontal;
        }
    }
}
