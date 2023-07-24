using F2DE.Base.Registries;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base
{
    internal class Game : IDisposable
    {
        public RenderWindow window;
        public Instance? instance;
        public Input input;
        public Registry registry = new Registry();

        public Game()
        {
            window = new RenderWindow(new VideoMode(320, 240), "Game");
            window.SetFramerateLimit(60);
            window.Closed += (e, r) =>
            {
                window.Close();
            };
            input = new Input(this);
        }

        public void Dispose()
        {
            instance?.Dispose();
            registry.Dispose();
            window.Dispose();
        }

        public void Run()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();
                instance?.Tick();
                window.Clear();
                Render();
                window.Display();
            }
            Dispose();
        }

        private void Render()
        {
            foreach (var layer in registry.GetValues<RenderLayer>())
            {
                instance?.RenderTick(layer.layer);
            }
        }
    }
}
