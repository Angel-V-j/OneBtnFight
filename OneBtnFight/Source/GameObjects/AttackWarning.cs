using Microsoft.Xna.Framework;
using OneBtnFight.Source.Engine;
using OneBtnFight.Source.GamePlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBtnFight.Source.GameObjects
{
    public class AttackWarning : GameObject
    {
        public int duration = 700;
        private GameTimer timer;
        private bool isDone = false;
        private Vector2 offSet = Vector2.Zero;
        public AttackWarning(string path, Vector2 position, Vector2 dimension, Vector2 direction) : base(path, position, dimension)
        {
            timer = new GameTimer(duration);
            rotation = Globals.RotateTowards(position, direction);
        }
        public AttackWarning(string path, Vector2 position, Vector2 dimension, Vector2 direction, Vector2 offSet) : base(path, position, dimension)
        {
            timer = new GameTimer(duration);
            rotation = Globals.RotateTowards(position, direction);
            this.offSet = offSet;
        }
        public override void Update()
        {
            timer.UpdateTimer();
            if (timer.Test())
                isDone = true;
        }

        public override void Draw()
        {
            if (!isDone)
                base.Draw(offSet);
        }
    }
}
