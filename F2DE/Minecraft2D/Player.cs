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
        private Vector2 g = Vector2.down * 4 * (1 / 60f);
        private Vector2 gravity = Vector2.zero;
        private Locator world;

        public Player(Entity entity) : base(entity)
        {
            locator = entity.GetComponent<Locator>()!;
            boundingBox = entity.GetComponent<BoundingBox>()!;
            world = entity.instance.GetComponents<World>()[0].entity.GetComponent<Locator>()!;
        }

        private bool CheckFree(Vector2 delta)
        {
            var position = (locator.position + delta) * locator.Matrix;
            var blocks = entity.instance.GetComponents<BlockState>().FindAll((m) => Vector2.Distance(m.entity.GetComponent<Locator>()!.Position, locator.Position) < 40);
            foreach (var block in blocks)
            {
                var bbox = block.entity.GetComponent<BoundingBox>();
                if (boundingBox.IsIntersect(position, bbox!))
                {
                    return true;
                }
            }
            return false;
        }

        private bool onGround = false;

        public void Tick()
        {
            gravity += g;
            if (!CheckFree(gravity))
            {
                locator.position += gravity;
                onGround = false;
            }
            else
            {
                onGround = true;
                gravity = Vector2.zero;
            }
            var velocity = new Vector2(entity.instance.game.input.GetAxis("horisontal"), 0) * (1f / 60) * 48f;
            if (!CheckFree(velocity))
            {
                locator.position += velocity;
            }
            if (onGround && entity.instance.game.input.GetButton("jump"))
            {
                gravity += Vector2.up * 1.7f;
            }
            world.position = locator.position * -1 + Vector2.right * (320 / 2) + Vector2.down * (240 / 2);
        }
    }
}
