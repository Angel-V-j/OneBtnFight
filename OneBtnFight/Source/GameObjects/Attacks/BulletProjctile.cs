using Microsoft.Xna.Framework;
using OneBtnFight.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBtnFight.Source.GameObjects.Attacks
{
    public class BulletProjctile : Attack
    {
        public BulletProjctile(Enemy target, Vector2 position)
            : base(0, 1500, target, target.position, "Sprites\\projectile", position, new Vector2(32,32))
        {
        }

        public override void Update()
        {
            base.Update();
            if (Globals.CheckCollision(position, dimension.X, target.position, target.dimension.X))
            {
                target.TakeDamage();
                isDone = true;
            }
            Move();
        }
    }
}
