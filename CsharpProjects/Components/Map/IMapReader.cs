using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public interface IMapReader
    {
        Vector2 getSpawnPlayer();
        List<Vector2> getSpawnEnemies();
        int getHeight();
        int getWidth();
        bool isItEmpty(int x, int y);
        bool isItEmpty(Vector2 position) { return isItEmpty(position.x, position.y); }
        bool isItFinish(int x, int y);
        bool isItFinish(Vector2 position) { return isItFinish(position.x, position.y); }
        char at(int x, int y);
    }
}
