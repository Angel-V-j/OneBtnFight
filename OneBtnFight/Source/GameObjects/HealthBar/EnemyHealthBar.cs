using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OneBtnFight.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBtnFight.Source.GameObjects.HealthBar
{
    public class EnemyHealthBar : GameObject
    {
        private  Texture2D healthLeft;
        private float maxHP;
        private int healthWidth;
        public EnemyHealthBar(Vector2 position, Vector2 dimension, float maxHP) 
            : base("Sprites\\enemy_hpbar_empty", position, dimension)
        {
            this.maxHP = maxHP;
            healthLeft = Globals.content.Load<Texture2D>("Sprites\\enemy_hpbar");
        }

        public void Update(float currentHP)
        {
            base.Update();
            healthWidth = (int)(dimension.X * (currentHP / maxHP));
        }

        public override void Draw()
        {
            base.Draw();
            Globals.spriteBatch.Draw(healthLeft, new Rectangle((int)position.X*2, (int)position.Y, healthWidth, (int)dimension.Y),
                                 null, Color.White, rotation, new Vector2(myModel.Bounds.Width, myModel.Bounds.Height / 2), new SpriteEffects(), 1);
        }
    }
}
