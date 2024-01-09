using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
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
            //position = null;
        }
        public Player(Position spawn_position):base(spawn_position)
        {
            sym = 'P';
            tag = "Player";
            maxHP = 4;
        }

        override internal void Conduct(Position array)
        {
            
        }

        internal override void Dead()
        {
            Game._player = null;
        }

    }
}
