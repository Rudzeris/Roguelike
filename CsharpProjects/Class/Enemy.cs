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
        public override bool HitKill()
        {
            hp--;
            if (hp == 0)
            {
                position = new Position(0, 0);
                //life = false;
                Game.enemy.Remove(this);
            }
            return hp == 0;
        }
    }
}
