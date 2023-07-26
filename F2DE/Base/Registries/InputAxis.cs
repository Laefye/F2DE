using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2DE.Base.Registries
{
    internal class InputAxis : InputRegisterValue
    {
        private bool isMin;
        private bool isMax;
        private Keyboard.Key min;
        private Keyboard.Key max;

        public InputAxis(string name, Keyboard.Key min, Keyboard.Key max) : base(name)
        {
            this.min = min;
            this.max = max;
        }

        public float Value
        {
            get
            {
                return (isMin ? -1f : 0) + (isMax ? 1f : 0);
            }
        }

        public override void Press(Keyboard.Key key)
        {
            if (key == min)
            {
                isMin = true;
            }
            if (key == max)
            {
                isMax = true;
            }
        }

        public override void Release(Keyboard.Key key)
        {
            if (key == min)
            {
                isMin = false;
            }
            if (key == max)
            {
                isMax = false;
            }
        }
    }
}
