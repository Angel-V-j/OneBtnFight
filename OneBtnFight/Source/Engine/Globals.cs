using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using OneBtnFight.Source.GameObjects;
using Android.Content.PM;

namespace OneBtnFight.Source.Engine
{
    public delegate void PassObject(object obj);
    public delegate object PassObjectAndReturn(object obj);
    public class Globals
    {
        public static readonly int SCREEN_WIDTH = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static readonly int SCREEN_HEIGHT = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static GameTime gameTime;
        public static Vector2 GetDirection(Vector2 position, Vector2 compassDir)
        {
            Vector2 direction = compassDir - position;
            direction.Normalize();
            return direction;
        }

        public static float GetDistance(Vector2 pos1, Vector2 pos2)
        {
            return (float)Math.Sqrt(Math.Pow(pos1.X - pos2.X, 2) + Math.Pow(pos1.Y - pos2.Y, 2));
        }

        public static float RotateTowards(Vector2 pos, Vector2 focus)
        {
            float h, sineTheta, angle;
            if (pos.Y - focus.Y != 0)
            {
                h = GetDistance(pos, focus);
                sineTheta = (float)(Math.Abs((pos.Y - focus.Y) / h));
            }
            else
            {
                h = pos.X - focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            if (pos.X - focus.X < 0 && pos.Y - focus.Y < 0)
                angle = (float)(Math.PI / 2 + angle);
            else if (pos.X - focus.X < 0 && pos.Y - focus.Y > 0)
                angle = (float)(Math.PI / 2 - angle);
            else if (pos.X - focus.X > 0 && pos.Y - focus.Y < 0)
                angle = (float)(Math.PI * 3 / 2 - angle);
            else if (pos.X - focus.X > 0 && pos.Y - focus.Y > 0)
                angle = (float)(Math.PI * 3 / 2 + angle);
            else if (pos.X - focus.X > 0 && pos.Y - focus.Y == 0)
                angle = (float)Math.PI * 3 / 2;
            else if (pos.X - focus.X < 0 && pos.Y - focus.Y == 0)
                angle = (float)Math.PI / 2;
            else if (pos.X - focus.X == 0 && pos.Y - focus.Y < 0)
                angle = (float)Math.PI;
            else if (pos.X - focus.X == 0 && pos.Y - focus.Y > 0)
                angle = 0;

            return angle;
        }

        public static bool CheckCollision(Vector2 attackPosition, float attackDimensionX, Vector2 targetPosition, float targetDimensionX)
        {
            return GetDistance(attackPosition, targetPosition) < (attackDimensionX / 2 + targetDimensionX / 2);
        }
    }
}
