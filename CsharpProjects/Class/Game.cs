using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CsharpProjects.Class
{
    internal class Game
    {
        internal List<Enemy> _enemies { set; get; }
        internal Player _player { set; get; }
        internal Monitor _monitor { set; get; }

        internal Map _map;

        internal uint FPS = 20;

        public void Start()
        {
            _enemies = new List<Enemy>();
            _player = new Player();
            _monitor = new Monitor();
            _map = new Map();
            while (true)
            {
                Update();
                Thread.Sleep(1000 / (int)FPS);
            }
        }

        public void Update()
        {
            DrawMap();
        }

        private void DrawMap()
        {
            _monitor.DrawMap(_map.map);
        }
    }
}
