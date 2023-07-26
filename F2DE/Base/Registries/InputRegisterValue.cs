using F2DE.Base.Interfaces;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Registries
{
    internal abstract class InputRegisterValue : RegisterValue
    {
        public string name;

        public InputRegisterValue(string name)
        {
            this.name = name;
        }

        public abstract void Press(Keyboard.Key key);

        public abstract void Release(Keyboard.Key key);
    }
}
