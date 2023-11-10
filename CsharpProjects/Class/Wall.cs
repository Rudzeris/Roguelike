using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Wall : GameObject
    {
        public Wall()
        {
            sym = '#';
            f = false;
            tag = typeof(Wall).Name;
        }
    }
}
