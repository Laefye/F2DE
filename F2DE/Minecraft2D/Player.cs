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
        private Locator locator;
        private BoundingBox boundingBox;

        public Player(Entity entity) : base(entity)
        {
            locator = entity.GetComponent<Locator>()!;
            boundingBox = entity.GetComponent<BoundingBox>()!;
        }

        private bool CheckBlocks()
        {
            var blocks = entity.instance.GetComponents<BlockState>().FindAll((m) => Vector2.Distance(m.entity.GetComponent<Locator>()!.Position, locator.Position) < 40);
            foreach (var block in blocks)
            {
                var bbox = block.entity.GetComponent<BoundingBox>();
                if (boundingBox.IsIntersect(locator.Position, bbox!))
                {
                    return true;
                }
            }
            return false;
        }

        public void Tick()
        {
            locator.position += new Vector2(entity.instance.game.input.Horisontal, entity.instance.game.input.Vertical) * (1f/60) * 48f;
            Console.WriteLine(CheckBlocks());
        }
    }
}
