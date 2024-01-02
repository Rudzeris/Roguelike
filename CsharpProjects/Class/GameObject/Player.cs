using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Player : Person
    {
        internal void Spawn()
        {
            hp = maxHP;
            position = spawn_position;
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
    }
}
