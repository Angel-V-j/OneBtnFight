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
    public abstract class Enemy : Unit
    {
        public string name { get; protected set; }
        public bool isPrepering { get; protected set; }
        public List<Attack[]> attacks { get; protected set; }
        protected int attackCastMS { get; set; }

        public Enemy(int id, string path, Vector2 position, Vector2 dimension, int maxHP) : base(id, path, position, dimension, maxHP)
        {
            isAlive = true;
            this.maxHP = maxHP;
            currentHP = maxHP;
        }
        public void SetTarget(Ship target)
        {
            this.target = target;
        }

        public abstract Vector2 GetNextOrbitVector(float f);
        public abstract void AI();
        public override void TakeDamage()
        {
            currentHP -= ((Ship)target).damage;
            base.TakeDamage();
        }
    }
}
