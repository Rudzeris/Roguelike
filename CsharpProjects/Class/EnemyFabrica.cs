using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class EnemyFabrica
    {
        internal static GameObject CreateEmemy(int x, Position pos)
        {
            //if (Game._enemies == null) Game._enemies = new List<Enemy>();
            /*switch (x)
            {
                case 0:

                    Enemy etemp = new Enemy();
                    etemp.Create(pos);
                    Game.enemy.Add(etemp);
                    return etemp;

                case 1:
                    Enemy temp = new Spider();
                    temp.Create(pos);
                    Game.enemy.Add(temp);
                    return temp;
            }*/
            return new Empty();
        }
    }

}
