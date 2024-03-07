using Roguelike.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Player : Person
    {
        override internal void Spawn()
        {
            base.Spawn();
            Game._player = this;
        }
        public Player():base()
        {
            sym = 'P';
            tag = "Player";
            maxHP = 4;
            weapon = new Sword();
            //position = null;
        }
        public Player(Position spawn_position):base(spawn_position)
        {
            sym = 'P';
            tag = "Player";
            maxHP = 4;
        }

        internal void Move(Position array)
        {
            if (!Game.IsItEmpty(position + array))
                return;
            int x = -1;
            for (int i = 0; i < ControllerPlayer._move.Length; i++)
            {
                if (ControllerPlayer._move[i] == array)
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
            Game._player = null;
        }

    }
}
