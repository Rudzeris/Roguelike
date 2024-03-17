using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal abstract class Enemy : Person
    {
        public Enemy(Position spawn_position,char symbol) : base(spawn_position,symbol)
        {
            symbol = 'X';
            maxHP = 1;
            hp = maxHP;
            weapon = null;
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

        internal void Conduct(Position array)
        {
            if(Game._player != null)
                if (array + position == Game._player.position)
                    Attack(Game._player);
            if (!Game.IsItEmpty(position + array))
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
