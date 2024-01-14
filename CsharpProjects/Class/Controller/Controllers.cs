using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{

    static internal class ControllerPlayer
    {
        static internal Position[] _move { get; private set; } = {
            new Position(-1, 0), // up
            new Position(0, -1), // left
            new Position(1, 0), // down
            new Position(0, 1) // right
        };
        static internal void Conduct(Player player)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        player?.Move(_move[0]);
                        break;
                    case ConsoleKey.A:
                        player?.Move(_move[1]);
                        break;
                    case ConsoleKey.S:
                        player?.Move(_move[2]);
                        break;
                    case ConsoleKey.D:
                        player?.Move(_move[3]);
                        break;
                    case ConsoleKey.T:
                        Game.SpawnPlayer();
                        break;
                    case ConsoleKey.P:
                        Game.NewGame();
                        break;
                    case ConsoleKey.Spacebar:
                        if (player == null) break;
                        foreach (var move in _move)
                        {
                            if (Game.IsEnemy(move + player.position))
                            {
                                Enemy enemy = null;
                                foreach (var _enemy in Game._enemies)
                                    if (_enemy.position == (player.position + move))
                                        enemy = _enemy;
                                player.Hit(enemy);
                                break;
                            }
                        }
                        break;
                }
                while (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;
                }
            }

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
                    if (!Game.IsItEmpty(position + move, false))
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
            Position directionT = new Position(0, 0);
            foreach (var move in _move)
            {
                if (!Game.IsItEmpty(enemy.position + move, false))
                    continue;
                temp = TracerPlayer(enemy.position + move, enemy.position);
                if (temp < minimum)
                {
                    minimum = temp;
                    directionT = move;
                }
            }
            bool attacking = false;
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
                    if (Game.IsItEmpty(enemy.position + _move[sl]))
                    {
                        directionT = _move[sl];
                        break;
                    }
                }
                //if (Game._rand.Next(0, 1) % 2 == 0 && Game.IsItEmpty(enemy.position + directionT))
                //    enemy.weapon?.Attack(enemy.position + directionT, directionT);
            }
            else
                attacking = true;

            if (!attacking)
            {
                if (Game.IsItEmpty(enemy.position + directionT, false))
                    enemy.Conduct(directionT);
            }
            else
            {
                if (enemy.weapon != null)
                    enemy.weapon.Attack(enemy.position, directionT);
                else
                if (Game.IsItEmpty(enemy.position + directionT, false))
                    enemy.Conduct(directionT);
            }
            
            
        }
    }
}
