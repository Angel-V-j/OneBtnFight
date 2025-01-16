using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBtnFight.Source.Engine.Input
{
    public class KeyboardHelper
    {
        private KeyboardState keyboardState;
        private bool isReleased = true;

        public bool IsKeyPressed(Keys key)
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(key) && isReleased)
            {
                isReleased = false;
                return true;
            }
            else if (keyboardState.IsKeyUp(key))
            {
                isReleased = true;
            }
            return false;
        }
    }
}
