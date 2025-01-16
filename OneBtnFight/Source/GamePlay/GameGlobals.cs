using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using OneBtnFight.Source.Engine;
using OneBtnFight.Source.Engine.Input;
using OneBtnFight.Source.GameObjects;
using OneBtnFight.Source.GameObjects.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBtnFight.Source.GamePlay
{
    public class GameGlobals
    {
        public static Vector2 North { get; private set; }
        public static Vector2 NorthEast { get; private set; }
        public static Vector2 East { get; private set; }
        public static Vector2 SouthEast { get; private set; }
        public static Vector2 South { get; private set; }
        public static Vector2 SouthWest { get; private set; }
        public static Vector2 West { get; private set; }
        public static Vector2 NorthWest { get; private set; }

        public static PassObject passAttack;
        private static readonly TouchScreenHelper screenHelper = new();

        public static void Controls(Ship ship)
        {
            if (screenHelper.IsScreenTouched())
                ship.ChangeRotatain();
        }
        public static void SetDirections(Vector2 pos, Vector2 dim)
        {
            North = new Vector2(pos.X,
                pos.Y - dim.Y / 2);
            NorthEast = new Vector2(pos.X + dim.X / 2,
                pos.Y - dim.Y / 2);
            East = new Vector2(pos.X + dim.X / 2,
                pos.Y);
            SouthEast = new Vector2(pos.X + dim.X / 2,
                pos.Y + dim.Y / 2);
            South = new Vector2(pos.X,
                pos.Y + dim.Y / 2);
            SouthWest = new Vector2(pos.X - dim.X / 2,
                pos.Y + dim.Y / 2);
            West = new Vector2(pos.X - dim.X / 2,
                pos.Y);
            NorthWest = new Vector2(pos.X - dim.X / 2,
                pos.Y - dim.Y / 2);
        }
        public static Vector2 GetOffSetVector(Vector2 direction, GameObject owner)
        {
            var vector = direction - owner.position;
            if (direction == North)
                return vector += new Vector2(0, -owner.dimension.Y * 7 / 6);
            else if (direction == South)
                return vector += new Vector2(0, owner.dimension.Y * 7 / 6);
            else if (direction == East)
                return vector += new Vector2(owner.dimension.X * 7 / 6, 0);
            else if (direction == West)
                return vector += new Vector2(-owner.dimension.X * 7 / 6, 0);
            else if (direction == NorthEast)
                return (vector += new Vector2(owner.dimension.X * 11 / 6, -owner.dimension.Y * 11 / 6)) / 2;
            else if (direction == NorthWest)
                return (vector += new Vector2(-owner.dimension.X * 11 / 6, -owner.dimension.Y * 11 / 6)) / 2;
            else if (direction == SouthEast)
                return (vector += new Vector2(owner.dimension.X * 11 / 6, owner.dimension.Y * 11 / 6)) / 2;
            else if (direction == SouthWest)
                return (vector += new Vector2(-owner.dimension.X * 11 / 6, owner.dimension.Y * 11 / 6)) / 2;
            return Vector2.Zero;
        }
    }
}
