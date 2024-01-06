using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    
    static internal class ControllerPlayer
    {

    }
    static internal class ControllerEnemy
    {
        
        static Position[] _move = {
            new Position(0, -1),
            new Position(-1, 0),
            new Position(0, 1),
            new Position(1, 0)
        };
        static internal Position Move(Position position)
        {
            return position + _move[Game._rand.Next(1, 4)];
        }
    }
}
