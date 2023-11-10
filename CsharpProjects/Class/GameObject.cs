using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal abstract class GameObject
    {
        protected char sym = ' ';
        protected bool f = true;
        public string tag = "None";
        public virtual bool HitKill()
        {
            return false;
        }
        public virtual void Move(Position position)
        {

        }
        public char GetSym()
        {
            return sym;
        }
        public string GetTag()
        {
            return tag;
        }
    }

}
