using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal interface IMapSet
    {
        void recreateMap(int height, int width);
        void setObjectToMap(int height, int width, GameObject obj);
    }
}
