using Microsoft.Xna.Framework;
using OneBtnFight.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBtnFight.Source.GameObjects
{
    public abstract class Unit : GameObject
    {
        public int id { get; private set; }
        public bool isAlive { get; protected set; }
        public float currentHP { get; protected set; }
        public float maxHP { get; protected set; }
        protected Unit target;
        protected GameTimer timer;
        public Unit(int id, string path, Vector2 position, Vector2 dimension, float maxHP) : base(path, position, dimension)
        {
            this.id = id;
            this.maxHP = maxHP;
            this.currentHP = maxHP;
            this.isAlive = true;
        }
        public Unit(int id, string path, Vector2 position, Vector2 dimension, float maxHP, Unit target) : base(path, position, dimension)
        {
            this.id = id;
            this.maxHP = maxHP;
            this.target = target;
            this.currentHP = maxHP;
            this.isAlive = true;
        }
        public virtual void TakeDamage()
        {
            if (currentHP <= 0)
                isAlive = false;
        }

        public override void Update()
        {
            if (isAlive)
                base.Update();
        }

        public override void Draw()
        {
            if (isAlive)
                base.Draw();
        }
    }
}
