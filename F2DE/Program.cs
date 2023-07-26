using F2DE.Base;
using F2DE.Base.Registries;
using F2DE.Minecraft2D;
using F2DE.Minecraft2D.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.registry.Register(new RenderLayer("background"));
            game.registry.Register(new RenderLayer("general"));
            game.registry.Register(new TextureResource("texture/player", "resources/player.png"));
            game.registry.Register(new TextureResource("texture/block/stone", "resources/stone.png"));
            game.registry.Register(new TextureResource("texture/block/grass", "resources/grass.png"));
            var blocks = new BlocksRegistry(game.registry);
            game.registry.Register(blocks);
            RegisterBlocks(game, blocks);
            game.input.Register("horisontal", SFML.Window.Keyboard.Key.Left, SFML.Window.Keyboard.Key.Right);
            game.input.Register("jump", SFML.Window.Keyboard.Key.Z);
            game.input.Register("break", SFML.Window.Keyboard.Key.X);
            game.instance = new GameInstance(game);
            game.Run();
        }

        internal static void RegisterBlocks(Game game, BlocksRegistry registry)
        {
            registry.Register("air", new Air(game));
            registry.Register("stone", new Stone(game));
            registry.Register("grass", new Grass(game));
        }
    }
}
