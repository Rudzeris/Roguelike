using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Web : GameObject
    {
        public Position attack { get; private set; }
        public Web(Position pos, Position at)
        {
            position = pos;
            attack = at;
            sym = '*';
            f = true;
            tag = typeof(Wall).Name;
        }
    }
}
