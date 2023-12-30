using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal abstract class GameObject
    {
        internal Position position { get; private protected set; }
        protected char sym = ' ';
        protected bool f = true;
        public string tag = "None";
        
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
