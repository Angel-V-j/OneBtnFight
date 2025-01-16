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

namespace OneBtnFight.Source.Engine
{
    public abstract class GameObject : IUpdate, IDraw
    {
        public float rotation;
        public Vector2 position, dimension;
        public Texture2D myModel;

        public GameObject(string path, Vector2 position, Vector2 dimension)
        {
            this.position = position;
            this.dimension = dimension;

            try
            { 
                myModel = Globals.content.Load<Texture2D>(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION");
                Console.WriteLine(e);
                throw;
            }
        }
        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
            if (myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y),
                                null, Color.White, rotation, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }
        public virtual void Draw(Color color)
        {
            if (myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y),
                                null, color, rotation, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }
        public virtual void Draw(Vector2 offSet)
        {
            if(myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(position.X + offSet.X), (int)(position.Y + offSet.Y), (int)dimension.X, (int)dimension.Y),
                                null, Color.White, rotation, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }
    }
}
