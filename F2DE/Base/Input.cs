using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base
{
    internal class Input
    {
        private bool left;
        private bool right;
        private bool up;
        private bool down;
        public float Horisontal
        {
            get
            {
                return (left ? -1f : 0f) + (right ? 1f : 0f);
            }
        }
        public float Vertical
        {
            get
            {
                return (up ? -1f : 0f) + (down ? 1f : 0f);
            }
        }

        public Input(Game game)
        {
            game.window.KeyPressed += Window_KeyPressed;
            game.window.KeyReleased += Window_KeyReleased;
        }

        private void Window_KeyReleased(object? sender, SFML.Window.KeyEventArgs e)
        {
            if (e.Code == SFML.Window.Keyboard.Key.Left)
            {
                left = false;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Right)
            {
                right = false;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Up)
            {
                up = false;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Down)
            {
                down = false;
            }
        }

        private void Window_KeyPressed(object? sender, SFML.Window.KeyEventArgs e)
        {
            if (e.Code == SFML.Window.Keyboard.Key.Left)
            {
                left = true;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Right)
            {
                right = true;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Up)
            {
                up = true;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Down)
            {
                down = true;
            }
        }
    }
}
