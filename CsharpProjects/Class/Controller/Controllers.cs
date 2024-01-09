using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{

    static internal class ControllerPlayer
    {
        static Position[] _move = {
            new Position(0, -1),
            new Position(-1, 0),
            new Position(0, 1),
            new Position(1, 0)
        };
        static internal Position Move(Position position)
        {


            return position + _move[0];
        }
    }
    static internal class ControllerEnemy
    {
        static internal Position[] _move { get; private set; } = {
            new Position(-1, 0), // up
            new Position(0, -1), // left
            new Position(1, 0), // down
            new Position(0, 1) // right
        };

        static internal uint TracerPlayer(Position position, Position old_position, uint length = 0)
        {
            if (Game._player == null)
                return length;
            if (position == Game._player.position)
                return length;
            if (length == Enemy.distance_view)
                return length;
            uint temp;
            uint minimum = Enemy.distance_view;
            Position true_position = position;
            foreach (var move in _move)
            {
                if (position + move != old_position)
                {
                    if (!Game.is_it_empty(position + move, false))
                        continue;
                    temp = TracerPlayer(new Position(position + move), position, length + 1);
                    if (temp != Enemy.distance_view && temp < minimum)
                    {
                        minimum = temp;
                        true_position = move;
                    }
                }
            }
            return minimum;
        }
        static internal void Conduct(Enemy enemy)
        {
            // Пустим лучи в разные стороны и проверим где игру, если игрока нашли - пойти к нему
            uint temp;
            uint minimum = Enemy.distance_view;
            Position true_position = new Position(0, 0);
            foreach (var move in _move)
            {
                if (!Game.is_it_empty(enemy.position + move, false))
                    continue;
                temp = TracerPlayer(enemy.position + move, enemy.position);
                if (temp < minimum)
                {
                    minimum = temp;
                    true_position = move;
                }
            }
            if (minimum == Enemy.distance_view)
            {
                bool[] bl = { true, true, true, true };
                int sl;
                // 3 1 4 2
                // 0 0 1 1
                // пойти в 1
                for (int q = 4; q > 0; q--)
                {
                    sl = Game._rand.Next(q);
                    for (int k = 0; k <= sl; k++)
                    {
                        if (!bl[k]) sl++;
                    }
                    bl[sl] = false;
                    if (Game.is_it_empty(enemy.position + _move[sl]))
                    {
                        true_position = _move[sl];
                        break;
                    }
                }
            }
            // если луч ничего не дал, то ходим в случайное свободное место

            if (Game.is_it_empty(enemy.position + true_position, false))
                enemy.Conduct(true_position);
        }
    }
}
