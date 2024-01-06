using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CsharpProjects.Class
{
    internal class Game
    {
        static public Random _rand = new Random();
        static internal List<Enemy> _enemies { set; get; }
        static internal Player _player { set; get; }
        static internal Monitor _monitor { set; get; }

        static internal uint _count_enemy_on_the_map = 5;

        static internal Map _map { set; get; }

        internal EnemyFabric _enemy_fabric { set; get; }

        static internal uint FPS { get; private set; }

        static internal uint _timer { get; private set; }

        static internal uint _move_speed_enemy {get; private set; }

        public void Start()
        {
            _map = new Map();
            _player = new Player(_map.spawn_player);
            _enemies = new List<Enemy>();
            _monitor = new Monitor();
            _enemy_fabric = new EnemyFabric();
            _player.Spawn();
            FPS = 20;
            _timer = 0;
            _move_speed_enemy = 20;
            for (int i = 0; i < _count_enemy_on_the_map; i++)
            {
                _enemy_fabric.CreateEmemy(i % 2 == 0);
            }
            while (true)
            {
                Update();
                //Thread.Sleep(1000 / (int)FPS);
            }

        }

        public void Update()
        {

            Monitoring();
            MoveEnemies();
            Thread.Sleep(1);
            _timer++;
        }

        private void Intersection()
        {

        }

        private void MoveEnemies()
        {
            if (_timer%_move_speed_enemy!=0)
                return;
            foreach (var enemy in _enemies)
            {
                enemy.Move();
            }
        }

        private void Monitoring()
        {
            _monitor.Monitoring(_map.map, 10,_player, _enemies.ToList<Person>());
        }

        static internal bool is_it_empty(Position new_position)
        {
            if (_map.map[new_position.x][new_position.y] is not Empty)
            {
                return false;
            }
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].position == new_position)
                    return false;
            }
            if (_player.position == new_position)
                return false;
            return true;
        }
    }
}
