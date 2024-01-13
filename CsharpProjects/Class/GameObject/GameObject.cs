using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal abstract class GameObject
    {
        internal Position position { get; private protected set; }
        internal Position spawn_position { get; private protected set; }
        protected char sym = ' ';
        protected bool f = true;
        public string tag = "None";
        
        public bool Intersection(GameObject game_object)
        {
            if (game_object == null) return false;
            if (game_object.position == position)
            {
                return true;
            }
            else
                return false;
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
