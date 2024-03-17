using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Warrior:Enemy
    {
        public Warrior(Position spawn_position):base(spawn_position)
        {
            symbol = 'W';
        }
    }
}
