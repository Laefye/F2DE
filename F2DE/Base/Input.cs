using F2DE.Base.Registries;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base
{
    internal class Input
    {
        private Game game;

        public Input(Game game)
        {
            this.game = game;
            game.window.KeyPressed += Window_KeyPressed;
            game.window.KeyReleased += Window_KeyReleased;
        }

        public void Register(string name, Keyboard.Key min, Keyboard.Key max)
        {
            game.registry.Register(new InputAxis(name, min, max));
        }

        public void Register(string name, Keyboard.Key key)
        {
            game.registry.Register(new InputButton(key, name));
        }

        private void Window_KeyReleased(object? sender, SFML.Window.KeyEventArgs e)
        {
            game.registry.GetValues<InputRegisterValue>().ForEach(value => value.Release(e.Code));
        }

        private InputRegisterValue? GetInputRegister(string name)
        {
            foreach (var register in game.registry.GetValues<InputRegisterValue>())
            {
                if (register.name == name)
                {
                    return register;
                }
            }
            return null;
        }

        public float GetAxis(string name)
        {
            var register = GetInputRegister(name);
            if (register != null && register.GetType().IsAssignableTo(typeof(InputAxis)))
            {
                return ((InputAxis)register).Value;
            }
            return 0;
        }

        public bool GetButton(string name)
        {
            var register = GetInputRegister(name);
            if (register != null && register.GetType().IsAssignableTo(typeof(InputButton)))
            {
                return ((InputButton)register).value;
            }
            return false;
        }

        private void Window_KeyPressed(object? sender, SFML.Window.KeyEventArgs e)
        {
            game.registry.GetValues<InputRegisterValue>().ForEach(value => value.Press(e.Code));
        }
    }
}
