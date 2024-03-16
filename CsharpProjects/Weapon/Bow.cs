using Roguelike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Bow:GameObject
    {

        internal uint distance_attack { get; private protected set; }
        private uint debuff = 200;
        private uint attack_time=0;
        internal void Attack(Position spawn_position,Position direction, bool friend_arrow = false)
        {
            if (Game._timer-attack_time>debuff) { 
                attack_time = Game._timer;
                Game._arrows.Add(new Arrow(spawn_position, direction,friend_arrow));
            }
        }

        internal Bow()
        {
            distance_attack = 5;
            debuff = 50;
            attack_time=(uint)Game._rand.Next(0,200);
        }
    }
}
