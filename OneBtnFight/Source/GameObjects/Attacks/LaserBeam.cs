using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OneBtnFight.Source.Engine;
using OneBtnFight.Source.GameObjects.Units;
using OneBtnFight.Source.GamePlay;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static OneBtnFight.Source.GamePlay.GameGlobals;

namespace OneBtnFight.Source.GameObjects.Attacks
{
    public class LaserBeam : Attack
    {
        public Enemy owner { get; private set; }
        public Vector2 direction { get; private set; }
        private static int durationMS = 1000;
        private GameTimer castingTimer;
        public LaserBeam(Ship target, BACircle owner, Vector2 direction)
            : base(0, durationMS, target, direction, "Sprites\\laserbeam", owner.position, new Vector2(owner.dimension.X, owner.dimension.Y * 3))
        {
            this.owner = owner;
            this.direction = direction;
            warning = new AttackWarning("Sprites\\laserbeam_warning", owner.position, dimension, direction, GetOffSetVector(direction, owner));
            castingTimer = new GameTimer(warning.duration + 100);
        }
        public override void Update()
        {
            castingTimer.UpdateTimer();
            if (castingTimer.Test())
            {
                isCasting = false;
                base.Update();
                if (Globals.CheckCollision(GetOSVectorInOrb(direction), dimension.X - 20, target.position, target.dimension.X))
                {
                    isDone = true;
                    target.TakeDamage();
                }
            } else
            {
                isCasting = true;
            }
        }

        public override void Draw()
        {
            base.Draw(GetOffSetVector(direction, owner));
        }

        private Vector2 GetOSVectorInOrb(Vector2 direction)
        {
            var vector = position;
            if (direction == East)
                return owner.GetNextOrbitVector(0);
            else if (direction == SouthEast)
                return owner.GetNextOrbitVector(float.Pi / 4);
            else if (direction == South)
                return owner.GetNextOrbitVector(float.Pi / 2);
            else if (direction == SouthWest)
                return owner.GetNextOrbitVector(3 * float.Pi / 4);
            else if (direction == West)
                return owner.GetNextOrbitVector(float.Pi);
            else if (direction == NorthWest)
                return owner.GetNextOrbitVector(5 * float.Pi / 4);
            else if (direction == North)
                return owner.GetNextOrbitVector(3 * float.Pi / 2);
            else if (direction == NorthEast)
                return owner.GetNextOrbitVector(7 * float.Pi / 4);


            return Vector2.Zero;
        }
    }
}
