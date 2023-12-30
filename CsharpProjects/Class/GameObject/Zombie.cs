using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Zombie:Enemy
    {
        public Zombie()
        {
            sym = 'X';
            tag = "Enemy";
            maxHP = 1;
            //position = null;
        }
        public Zombie(Position position)
        {
            sym = 'X';
            tag = "Enemy";
            maxHP = 1;
            this.position = position;
        }
    }
}
