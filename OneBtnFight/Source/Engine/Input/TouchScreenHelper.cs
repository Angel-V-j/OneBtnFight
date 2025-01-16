using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBtnFight.Source.Engine.Input
{
    public class TouchScreenHelper
    {
        public TouchCollection touchState;
        private bool isReleased = true;

        public bool IsScreenTouched()
        {
            touchState = TouchPanel.GetState();
            if (touchState.Count > 0 && isReleased)
            {
                isReleased = false;
                return true;
            }
            else if (touchState.Count == 0)
            {
                isReleased = true;
            }
            return false;
        }
    }
}
