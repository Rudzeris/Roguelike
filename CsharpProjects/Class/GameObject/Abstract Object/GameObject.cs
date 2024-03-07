using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal abstract class GameObject
    {
        internal Vector2 position { get; private protected set; }
        internal Vector2 spawn_position { get; private protected set; }
        protected char sym = ' ';
        protected string tag = "None";

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
