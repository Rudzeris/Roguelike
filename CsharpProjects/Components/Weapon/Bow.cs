using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Bow:Weapon
    {
        public Bow(Vector2 _position) : base(_position, '/', 5, 1)
        {
        }

        public override void Attack(KeyMode direction)
        {
            Arrow arrow = new Arrow(_create,position + Vector2.V2Direction[(int)direction]*2,direction,_distance_attack);
            arrow._attack = _attack;
            arrow._remove = _remove;
            arrow._collision = _collision;
        }
    }
}
