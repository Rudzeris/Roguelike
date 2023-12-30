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

        internal Map _map { set; get; }

        internal EnemyFabric _enemy_fabric { set; get; }

        static internal uint FPS {  get; private set; }

        public void Start()
        {
            _map = new Map();
            _player = new Player(_map.spawn_player);
            _enemies = new List<Enemy>();
            _monitor = new Monitor();
            _enemy_fabric = new EnemyFabric(this,_map);
            FPS = 20;
            for (int i = 0; i < 50; i++)
            {
                _enemy_fabric.CreateEmemy(i % 2 == 0);
            }
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
            _monitor.DrawMap(_map.map,_player,_enemies.ToList<GameObject>());
        }
    }
}
