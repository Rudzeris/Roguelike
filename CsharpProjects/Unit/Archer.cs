using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Archer : Enemy
    {
        public Archer(Vector2 spawn_position):base(spawn_position)
        {
            sym = 'A';
            weapon = new Bow();
            distance_view = 5;
        }
    }
}
