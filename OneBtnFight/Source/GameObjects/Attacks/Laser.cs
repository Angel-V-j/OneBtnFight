using Microsoft.Xna.Framework;
using OneBtnFight.Source.Engine;
using OneBtnFight.Source.GameObjects.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBtnFight.Source.GameObjects.Attacks
{
    public class Laser : Attack
    {
        public Enemy owner { get; private set; }
        public Vector2 direction { get; private set; }
        public Laser(Ship target, BACircle owner, Vector2 direction)
            : base(0, 600, target, direction, "Sprites\\laser_fliped_vertically", owner.position, owner.dimension)
        {
            this.owner = owner;
            this.direction = direction;
        }
        public override void Update()
        {
            Globals.RotateTowards(position, direction);
            base.Update();
        }
        public override void Draw()
        {
            Draw(direction);
        }
    }
}
