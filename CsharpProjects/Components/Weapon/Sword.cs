using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Sword : Weapon
    {
        public Sword(Vector2 _position) : base(_position, '/', 1, 1)
        {
        }

        public override void Attack(KeyMode direction)
        {
            Person? pers = _collision.getPerson(position + Vector2.V2Direction[(int)direction]);
            if (pers != null)
            {
                if(pers.GetType() == typeof(Player)) 
                _attack(pers);
            }
        }

    }
}
