using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Monitor
    {
        internal void DrawMap(List<List<GameObject>> _map, List<GameObject>? _enemies = null, GameObject? _player = null)
        {
            List<List<GameObject>> map = new List<List<GameObject>>(_map);
            if (map == null) return;
            if (_enemies != null)
            {
                foreach (var enemy in _enemies)
                {
                    map[enemy.position.x][enemy.position.y] = enemy;
                }
            }
            if(_player != null)
            {
                map[_player.position.x][_player.position.y] = _player;
            }
            Console.Clear();
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
