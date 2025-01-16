using Microsoft.Xna.Framework;
using OneBtnFight.Source.Engine;
using OneBtnFight.Source.GameObjects.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBtnFight.Source.GameObjects.HealthBar
{
    public class HealthBar : GameObject
    {
        private HealthPoint[] healthPoints;
        private Queue<HealthPoint> lostHealthPoints = new Queue<HealthPoint>();
        public HealthBar(Vector2 position, Ship ship) 
            : base("Sprites\\healthbar_bg", position, new Vector2(Globals.SCREEN_WIDTH, 180 * Globals.SCREEN_WIDTH/400))
        {
            healthPoints = new HealthPoint[(int)ship.maxHP];
            for (int i = 0; i < healthPoints.Length; i++)
            {
                healthPoints[i] = new HealthPoint(new Vector2(dimension.X*(2*i+1)/6,
                    position.Y - dimension.Y/2 + 20), new Vector2(192, 192), false);
            }
        }
        public void Update(Ship ship)
        {
            base.Update();
            for (int i = 0; i < healthPoints.Length-ship.currentHP; i++)
            {
               healthPoints[i] = new HealthPoint(healthPoints[i].position, healthPoints[i].dimension, true);
            }
            for (int i = 0; i < healthPoints.Length; i++)
            {
                healthPoints[i].Update();
            }
        }

        public override void Draw()
        {
            base.Draw(new Vector2(0, -dimension.Y/2));
            foreach (HealthPoint hp in healthPoints)
            {
                hp.Draw();
            }
        }
    }
}
