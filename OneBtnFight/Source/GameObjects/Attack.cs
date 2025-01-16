using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OneBtnFight.Source.Engine;
using OneBtnFight.Source.GameObjects.Units;


namespace OneBtnFight.Source.GameObjects
{
    public abstract class Attack : GameObject
    {
        public int id { get; private set; }
        private float speed;
        public Unit target { get; private set; }
        private Vector2 direction;
        public AttackWarning warning { get; protected set; }
        public bool isCasting { get; protected set; }
        public bool isDone { get; protected set; }
        protected GameTimer timer;

        public Attack(int id, int duration, Unit target, Vector2 direction, string path, Vector2 position, Vector2 dimension)
            : base(path, position, dimension)
        {
            this.id = id;
            this.target = target;
            this.direction = direction;
            rotation = Globals.RotateTowards(position, direction);
            speed = 5.0f;
            isDone = false;
            timer = new GameTimer(duration);
        }

        protected virtual void Move()
        {
            position += Globals.GetDirection(position, direction) * speed;
        }

        public override void Update()
        {
            timer.UpdateTimer();
            if (timer.Test())
            {
                isDone = true;
            }
        }
    }
}
