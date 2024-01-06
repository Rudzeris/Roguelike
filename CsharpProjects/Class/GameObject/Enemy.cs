using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal abstract class Enemy : Person
    {
        public Enemy(Position spawn_position):base(spawn_position)
        {
            sym = 'X';
            tag = "Enemy";
            maxHP = 1;
        }

        internal void Move()
        {
            Position new_position = ControllerEnemy.Move(position);
            if(Game.is_it_empty(new_position))
                position=new_position;
        }

    }
}
