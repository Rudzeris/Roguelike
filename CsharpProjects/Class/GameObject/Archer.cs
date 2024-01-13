using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Archer : Enemy
    {

        public Archer(Position spawn_position):base(spawn_position)
        {
            sym = 'A';
        }
    }
}
