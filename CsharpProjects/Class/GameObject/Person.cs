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

        //public bool life { get; private set; }

    }
}
