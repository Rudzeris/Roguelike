using CsharpProjects.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Class
{
    abstract internal class Weapon: GameObject
    {
        internal uint distance_attack { get; private protected set; }
        internal bool bow { get;private protected set; }
        void Attack()
        {
            
        }

        internal Weapon()
        {
            distance_attack = 1; 
            bow = false;
        }
    }
}
