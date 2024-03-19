using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class DrawToConsole
    {
        private uint _countUpdate = 0;
        private uint _timer = 0;

        private readonly Game _game;
        private readonly List<List<GameObject>> _map;
        private readonly Person _player;
        private readonly List<Person> _enemies;
        //private readonly List<GameObject> _arrows;

        public DrawToConsole(Game _game,List<List<GameObject>> _map,
            Person _player,
            List<Person> _enemies
            //List<GameObject> _arrows,
            )
        {
            this._game= _game;
            this._map = _map;
            this._player = _player;
            this._enemies = _enemies;
            //this._arrows = _arrows;
            _countUpdate = 10;
        }

        public void update()
        {
            if (_timer % _countUpdate == 0)
            {
                Console.Clear();
                DrawTimer();
                DrawInformation();
                DrawMap();
            }

            _timer++;
        }

        public void DrawTimer()
        {
            Console.WriteLine(_game._timer);
        }

        public void DrawInformation()
        {
            Console.WriteLine($"Hit Point: {_player.hp}");
        }
        public void DrawMap()
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

                /*if (_arrows != null)
                {
                    foreach (var arrow in _arrows)
                    {
                        map[arrow.position.x][arrow.position.y] = arrow;
                    }
                }*/
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == null)
                        Console.Write('E' + " ");
                    else
                        Console.Write(map[i][j].symbol + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
