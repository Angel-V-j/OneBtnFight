using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OneBtnFight.Source.Engine;
using OneBtnFight.Source.GameObjects.Attacks;
using OneBtnFight.Source.GamePlay;

namespace OneBtnFight.Source.GameObjects.Units
{
    public class Ship : Unit
    {
        public byte damage { get; private set; }
        private float moveSpeed, speedMultiplier;
        private sbyte rotationDirection;

        private const float BASE_SPEED = 0.01f;
        private const int BASE_FIRE_RATE_MSec = 700;
        private const float BASE_MULTIPLIER = 1;
        private const int MAX_SPEED_MULTI = 15;
        private const int INITIAL_HP = 3;
        private const int CLOCKWISE = 1;
        private const int COUNTER_CLOCKWISE = -1;

        public Ship(Enemy target, Vector2 position, Vector2 dimension) 
            : base(0, "Sprites\\ship", position, dimension, INITIAL_HP, target)
        {
            timer = new GameTimer(BASE_FIRE_RATE_MSec);
            damage = 1;
            rotationDirection = CLOCKWISE;
            moveSpeed = 0.015f;
            speedMultiplier = 1.1f;
        }

        public override void TakeDamage()
        {
            if (currentHP > 0)
                currentHP -= 1;
            base.TakeDamage();
        }

        private void RaiseSpeed()
        {
            if (timer.Timer % 15 == 0)
            {
                if (rotationDirection > 0 && speedMultiplier <= MAX_SPEED_MULTI)
                    speedMultiplier += 0.025f * speedMultiplier;
                else if (rotationDirection < 0 && speedMultiplier >= -MAX_SPEED_MULTI)
                    speedMultiplier += 0.025f * speedMultiplier;
            }
        }

        public void ChangeRotatain()
        {
            rotationDirection *= COUNTER_CLOCKWISE;
            speedMultiplier = BASE_MULTIPLIER;
            speedMultiplier *= rotationDirection;
        }

        public void Attack()
        {
            timer.UpdateTimer();
            if (timer.Test())
            {
                GameGlobals.passAttack(new BulletProjctile((Enemy)target, position));
                var adjustedMSec = (int)(BASE_FIRE_RATE_MSec / Math.Abs(speedMultiplier));
                timer.Reset(adjustedMSec);
            }
        }

        private void Move()
        {
            moveSpeed += BASE_SPEED * speedMultiplier;
            moveSpeed = (float)(moveSpeed % (2 * Math.PI));
            position = ((Enemy)target).GetNextOrbitVector(moveSpeed);
        }

        public override void Update()
        {
            if (isAlive)
            {
                GameGlobals.Controls(this);
                rotation = Globals.RotateTowards(position, target.position);
                Attack();
                Move();
                RaiseSpeed();
            }
        }
    }
}
