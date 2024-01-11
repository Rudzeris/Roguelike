using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal abstract class Enemy : Person
    {
        public Enemy(Position spawn_position) : base(spawn_position)
        {
            sym = 'X';
            tag = "Enemy";
            maxHP = 1;
            hp = maxHP;
        }
        override internal void Spawn()
        {
            foreach (var enemy in Game._enemies)
                if (enemy == this)
                {
                    return;
                }
            Game._enemies.Add(this);
            base.Spawn();
        }
        /*override internal void Conduct()
        {
            // Сперва проверим 4 стороны, если там игрок - ударить его
            // иначе сходить в рандомное место

            // Hit
            foreach (var move in ControllerEnemy._move)
            {
                if (position + move == Game._player.position)
                {
                    Hit(Game._player);
                }
            }

            Position new_position = ControllerEnemy.Conduct(position);
            if(Game.is_it_empty(new_position))
                position=new_position;
        }*/

        internal void Conduct(Position array)
        {
            if(Game._player != null)
                if (array + position == Game._player.position)
                    Hit(Game._player);
            if (!Game.is_it_empty(position + array))
                return;
            int x = -1;
            for (int i = 0; i < ControllerEnemy._move.Length; i++)
            {
                if (ControllerEnemy._move[i] == array)
                {
                    x = i;
                    break;
                }
            }

            switch (x)
            {
                case 0:
                    MoveUp();
                    break;
                case 1:
                    MoveLeft();
                    break;
                case 2:
                    MoveDown();
                    break;
                case 3:
                    MoveRight();
                    break;
            }
        }
        internal override void Dead()
        {
            Game._enemies.Remove(this);
        }
    }
}
