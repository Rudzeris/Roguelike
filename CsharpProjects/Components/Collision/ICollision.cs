using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public interface ICollision
    {
        bool isItEmpty(Vector2 position);
        Person? getPerson(Vector2 position);
    }
}
