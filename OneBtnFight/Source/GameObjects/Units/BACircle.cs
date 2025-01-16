using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OneBtnFight.Source.Engine;
using OneBtnFight.Source.GameObjects.Attacks;
using OneBtnFight.Source.GamePlay;
using static OneBtnFight.Source.GamePlay.GameGlobals;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace OneBtnFight.Source.GameObjects.Units
{
    public class BACircle : Enemy
    {
        private Random rand = new Random();
        
        private int timeBetweenAttacks = 8000;
        public BACircle(Vector2 position, Vector2 dimension) 
            : base(0, "Sprites\\enemy1_bacircle", position, dimension, 8000)
        {
            name = "Bad Ass Circle";
            timer = new GameTimer(timeBetweenAttacks);
        }

        private LaserBeam[] XAttack(Ship ship)
        {
            LaserBeam[] laserBeamsX =
            [
                new LaserBeam(ship, this, NorthEast),
                new LaserBeam(ship, this, SouthEast),
                new LaserBeam(ship, this, SouthWest),
                new LaserBeam(ship, this, NorthWest),
            ];

            return laserBeamsX;
        }

        private LaserBeam[] PlusAttack(Ship ship)
        {
            LaserBeam[] laserBeamsX =
            [
                new LaserBeam(ship, this, East),
                new LaserBeam(ship, this, South),
                new LaserBeam(ship, this, West),
                new LaserBeam(ship, this, North),
            ];

            return laserBeamsX;
        }

        public override void AI()
        {
            attacks =
            [
                XAttack((Ship)target),
                PlusAttack((Ship)target)
            ];

            timer.UpdateTimer();
            if (timer.Test())
            {
                int index = rand.Next(0, attacks.Count);
                for (int i = 0; i < attacks[index].Length; i++)
                {
                    passAttack((LaserBeam)attacks[index][i]);
                }
                isPrepering = false;
                timer.Reset(timeBetweenAttacks -= (int)(timeBetweenAttacks * ((1 - (currentHP/maxHP)) / 10)));
            }
            else if (timer.Timer >= timeBetweenAttacks-800)
            {
                isPrepering = true;
            }
        }

        public override Vector2 GetNextOrbitVector(float angle)
        {
            var x = position.X + dimension.X * 2 * Math.Cos(angle);
            var y = position.Y + dimension.Y * 2 * Math.Sin(angle);

            return new Vector2((float)x, (float)y);
        }

        public override void Update()
        {
            base.Update();
            AI();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
