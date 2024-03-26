using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Roguelike
{
    public class Renderer
    {
        private int _countUpdate = 0;
        private uint _timer = 0;

        private readonly ITimer _Itimer;
        private readonly IPause _Ipause;
        private readonly IMapReader _Imap;
        private readonly List<GameObject> _objects;
        private readonly Player _player;

        private char[,] _map;
        private int _height;
        private int _width;
        //private readonly List<GameObject> _arrows;

        public Renderer(IPause _Ipause,ITimer _Itimer, IMapReader _Imap,
            List<GameObject> _enemies, Player _player
            ,int _fps)
        {
            this._Ipause = _Ipause;
            this._player = _player;
            this._Itimer = _Itimer;
            this._Imap = _Imap;
            this._objects = _enemies;
            _countUpdate = (60/_fps);
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
            Console.Write($"Hit Point: {_player.hp}");
            if(_Ipause.paused())
                Console.Write("\tPress 'R' to continue");
            Console.WriteLine();

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
            if(_height != _Imap.getHeight() || _width != _Imap.getWidth())
            {
                _height = _Imap.getHeight();
                _width = _Imap.getWidth();
                _map = new char[_height, _width];
            }
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _map[i,j] = _Imap.at(i, j);
                }
            }
            if (_player.position < new Vector2(_width,_height))
            _map[_player.position.y, _player.position.x] = _player.symbol;
            if(_objects.Count > 0)
                for (int i = 0; i < _objects.Count; i++)
                    if (_objects[i] != null)
                        _map[_objects[i].position.y, _objects[i].position.x] = _objects[i].symbol;
        }
    }
}
