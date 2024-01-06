using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal abstract class Person : GameObject
    {
        public uint maxHP { get; protected set; }
        public uint hp { get; protected set; }
        internal Person()
        {
            maxHP = 1; hp = 1;
        }
        internal Person(Position spawn_position)
        {
            this.spawn_position = spawn_position;
            this.position = new Position(spawn_position);
        }

        internal void Move()
        {
        }
        //public bool life { get; private set; }

    }
}
