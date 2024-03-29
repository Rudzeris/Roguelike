﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    static internal class PlayerController
    {
        static internal Vector2[] _move { get; private set; } = {
            new Vector2(-1, 0), // up
            new Vector2(0, -1), // left
            new Vector2(1, 0), // down
            new Vector2(0, 1) // right
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
}
