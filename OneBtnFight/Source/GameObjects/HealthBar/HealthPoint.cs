using Microsoft.Xna.Framework;
using OneBtnFight.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBtnFight.Source.GameObjects.HealthBar
{
    public class HealthPoint : GameObject
    {
        private static readonly string HP_PATH = "Sprites\\healthpoint";
        private static readonly string LOST_HP_PATH = "Sprites\\lost_healthpoint";

        public HealthPoint(Vector2 position, Vector2 dimension, bool isLost)
            : base(isLost ? LOST_HP_PATH : HP_PATH, position, dimension)
        {
        }
    }
}
