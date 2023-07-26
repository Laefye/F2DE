using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Registries
{
    internal class InputButton : InputRegisterValue
    {
        public bool value = false;
        public Keyboard.Key key;

        public InputButton(Keyboard.Key key, string name) : base(name)
        {
            this.key = key;
        }

        public override void Press(Keyboard.Key key)
        {
            if (key == this.key)
            {
                value = true;
            }
        }

        public override void Release(Keyboard.Key key)
        {
            if (key == this.key)
            {
                value = false;
            }
        }
    }
}
