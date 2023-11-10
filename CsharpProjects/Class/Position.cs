using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal struct Position
    {
        public int x, y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public bool Sravn(Position temp)
        {
            return x==temp.x && y==temp.y;
        }

    }
}
