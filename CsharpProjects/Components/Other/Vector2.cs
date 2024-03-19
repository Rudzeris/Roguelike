using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public struct Vector2
    {
        public int x, y;

        public static Vector2 Up => new Vector2(0,-1);
        public static Vector2 Left => new Vector2(-1, 0);
        public static Vector2 Down => new Vector2(0, 1);
        public static Vector2 Right => new Vector2(1, 0);
        public static Vector2[] V2Direction = new Vector2[4]
        {
            Up,Left,Down,Right
        };
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(Vector2 temp)
        {
            this.x=temp.x;
            this.y=temp.y;
        }
        public static bool operator <(Vector2 pos1, Vector2 pos2)
        {
            return pos1.x < pos2.x && pos1.y < pos2.y;
        }
        public static bool operator >(Vector2 pos1, Vector2 pos2)
        {
            return !(pos1 < pos2);
        }
        public static bool operator !=(Vector2 pos1, Vector2 pos2)
        {
            return !(pos1 == pos2);
        }
        public static bool operator ==(Vector2 pos1, Vector2 pos2)
        {
            return pos1.x == pos2.x && pos1.y == pos2.y;
        }
        public static Vector2 operator +(Vector2 pos1, Vector2 pos2)
        {
            return new Vector2(pos1.x + pos2.x, pos1.y + pos2.y);
        }
        public static Vector2 operator -(Vector2 pos1, Vector2 pos2)
        {
            return new Vector2(pos1.x - pos2.x, pos1.y - pos2.y);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Vector2 temp = (Vector2)obj;
            return x == temp.x && y == temp.y;
        }
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }

    }
}
