using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using OneBtnFight.Source.Engine;
using OneBtnFight.Source.GameObjects;
using OneBtnFight.Source.GameObjects.Units;
using System.Collections;
using OneBtnFight.Source.GameObjects.HealthBar;

namespace OneBtnFight.Source.GamePlay
{
    public class GamePlayManager : IUpdate, IDraw
    {
        public Ship player;
        public Enemy enemy;
        public List<Attack> attacks = new();
        public HealthBar healthBar;

        public GamePlayManager()
        {
            enemy = new BACircle(new Vector2(Globals.SCREEN_WIDTH/2, Globals.SCREEN_HEIGHT/2), new Vector2(200, 200));
            player = new Ship(enemy, Vector2.Zero, new Vector2(64, 64));
            healthBar = new HealthBar(new Vector2(Globals.SCREEN_WIDTH / 2, Globals.SCREEN_HEIGHT), player);

            enemy.SetTarget(player);
            GameGlobals.passAttack = AddAttack;
            GameGlobals.SetDirections(enemy.position, enemy.dimension);
        }

        public void Update()
        {
            for (int i = 0; i < attacks.Count; i++)
            {
                attacks[i].Update();
                attacks[i].warning?.Update();

                if (attacks[i].isDone)
                    attacks.RemoveAt(i);
            }
            enemy.Update();
            player.Update();
            healthBar.Update(player);
        }

        public void Draw()
        {
            for (int i = 0; i < attacks.Count; i++)
            {
                if (attacks[i].warning != null)
                {
                    if (attacks[i].isCasting)
                        attacks[i].warning.Draw();
                    else
                        attacks[i].Draw();
                }
                else
                    attacks[i].Draw();

            }
            enemy.Draw();
            player.Draw();
            healthBar.Draw();
        }
        public virtual void AddAttack(object attack)
        {
            attacks.Add((Attack)attack);
        }
    }
}
