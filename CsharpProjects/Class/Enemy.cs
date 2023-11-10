using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Enemy : Person
    {
        public Enemy()
        {
            sym = 'X';
            tag = "Enemy";
            maxHP = 1;
        }
    }
}
