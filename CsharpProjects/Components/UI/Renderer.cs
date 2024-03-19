using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Renderer
    {
        private uint _countUpdate = 0;
        private uint _timer = 0;

        private readonly ITimer _Itimer;
        private readonly IMapReader _Imap;
        private readonly List<Person> _enemies;
        private readonly Player _player;

        private char[,] _map;
        private int _height;
        private int _width;
        //private readonly List<GameObject> _arrows;

        public Renderer(ITimer _Itimer, IMapReader _Imap,
            List<Person> _enemies, Player _player
            )
        {
            this._player = _player;
            this._Itimer = _Itimer;
            this._Imap = _Imap;
            this._enemies = _enemies;
            _countUpdate = 10;
            _height = _Imap.getHeight();
            _width  = _Imap.getWidth();
            _map = new char[_height, _width];
            
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

        private void DrawTimer()
        {
            Console.WriteLine(_Itimer.getTimer()) ;
        }

        private void DrawInformation()
        {
            Console.WriteLine($"Hit Point: {_player.hp}");
        }
        private void DrawMap()
        {
            updateMap();
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write(_map[i, j].ToString()+" ");
                }
                Console.WriteLine();
            }
        }
        private void updateMap()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _map[i,j] = _Imap.at(i, j);
                }
            }
            if (_player.position < new Vector2(_width,_height))
            _map[_player.position.y, _player.position.x] = _player.symbol;
            if(_enemies.Count > 0)
                foreach (var q in _enemies)
                    _map[q.position.y, q.position.x] = q.symbol;
        }
    }
}
