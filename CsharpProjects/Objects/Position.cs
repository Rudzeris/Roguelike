using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal struct Position
    {
        public int x, y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Position(Position temp)
        {
            this.x=temp.x;
            this.y=temp.y;
        }
        public static bool operator !=(Position pos1, Position pos2)
        {
            return !(pos1 == pos2);
        }
        public static bool operator ==(Position pos1, Position pos2)
        {
            return pos1.x == pos2.x && pos1.y == pos2.y;
        }
        public static Position operator +(Position pos1, Position pos2)
        {
            return new Position(pos1.x + pos2.x, pos1.y + pos2.y);
        }
        public static Position operator -(Position pos1, Position pos2)
        {
            return new Position(pos1.x - pos2.x, pos1.y - pos2.y);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Position temp = (Position)obj;
            return x == temp.x && y == temp.y;
        }
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }

    }
}
