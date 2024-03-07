using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Monitoring
    {

        readonly List<List<GameObject>> _map;
        readonly Person _player;
        readonly List<Enemy> _enemies;
        readonly List<Arrow> _arrows;

        int timer = 0;

        List<List<GameObject>> monitorMap;

        internal Monitoring(
            List<List<GameObject>> _map,
            Person _player,
            List<Enemy> _enemies,
            List<Arrow> _arrows)
        {
            this._map = _map;
            this._player = _player;
            this._enemies = _enemies;
            this._arrows = _arrows;
            monitorMap = new List<List<GameObject>>();

            monitorMap = new List<List<GameObject>>();

            for (int i = 0; i < _map.Count; i++)
            {
                List<GameObject> temp = new List<GameObject>();
                for (int j = 0; j < _map[i].Count; j++)
                {
                    temp.Add(_map[i][j]);
                }
                monitorMap.Add(temp);
            }
            timer = 0;
        }

        // Выводит информацию на экран с частотой ...
        internal void Update()
        {
            if (timer++ % 10 == 0)
            {
                Console.Clear();
                drawTimer();
                drawPlayerInformation();
                drawEnemiesInformation();
                drawMap();
            }
        }

        private void drawTimer()
        {
            Console.WriteLine($"Timer: {Game._timer}");
        }

        private void drawPlayerInformation() => Console.WriteLine($"Hit Point: {_player.hp}");
        private void drawEnemiesInformation() => Console.WriteLine($"Enemies: {_enemies.Count}");

        private void drawMap()
        {
            reloadMap();

            for (int i = 0; i < monitorMap.Count; i++)
            {
                for (int j = 0; j < monitorMap[i].Count; j++)
                {
                    if (monitorMap[i][j] == null)
                        Console.Write('E' + " ");
                    else
                        Console.Write(monitorMap[i][j].GetSym() + " ");
                }
                Console.WriteLine();
            }

        }

        private void reloadMap()
        {
            for (int i = 0; i < monitorMap.Count; i++)
            {
                for (int j = 0; j < monitorMap[i].Count; j++)
                {
                    if (monitorMap[i][j] != _map[i][j])
                        monitorMap[i][j] = _map[i][j];
                }
            }

            monitorMap[_player.position.x][_player.position.y] = _player;
            
            foreach(var enemy in _enemies)
            {
                monitorMap[enemy.position.x][enemy.position.y] = enemy;
            }

            foreach(var arrow in _arrows)
            {
                monitorMap[arrow.position.x][arrow.position.y] = arrow;
            }
        }
    }
}
