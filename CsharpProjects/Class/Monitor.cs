﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Monitor
    {
        uint flash_per_second = 1;
        uint count_update = 0;
        bool draw_persons = true;

        internal void Monitoring(List<List<GameObject>> _map,uint speed=10,
            Person? _player = null,
            List<Person>? _enemies = null)
        {
            Console.Clear();
            DrawTimer();
            DrawInformation(_player);
            DrawMap(_map, _player, _enemies);
        }

        internal void DrawTimer()
        {
            Console.WriteLine($"Timer: {Game._timer}");
        }

        internal void DrawInformation(Person person)
        {
            Console.WriteLine($"Hit Point: {person.hp}");
        }
        internal void DrawMap(List<List<GameObject>> _map,
            Person? _player = null,
            List<Person>? _enemies = null)
        {
            if (_map == null) return;
            // copy map
            List<List<GameObject>> map = new List<List<GameObject>>(); 
            for(int i = 0; i < _map.Count; i++)
            {
                List<GameObject> temp = new List<GameObject>();
                for(int j = 0; j < _map[i].Count; j++)
                {
                    temp.Add(_map[i][j]);
                }
                map.Add(temp);
            }
            if (draw_persons||count_update%(Game.FPS/(flash_per_second+1)) != 0)
            {
                if (_enemies != null)
                {
                    foreach (var enemy in _enemies)
                    {
                        map[enemy.position.x][enemy.position.y] = enemy;
                    }
                }
                if (_player != null)
                {
                    map[_player.position.x][_player.position.y] = _player;
                }
            }
            count_update=(count_update+1)%Game.FPS;
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == null)
                        Console.Write('E' + " ");
                    else
                        Console.Write(map[i][j].GetSym() + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
