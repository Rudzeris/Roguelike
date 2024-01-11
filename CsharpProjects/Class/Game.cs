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
        static internal uint _move_speed_player {get; private set; }

        public void Start()
        {
            _map = new Map();
            SpawnPlayer();
            _enemies = new List<Enemy>();
            _monitor = new Monitor();
            _enemy_fabric = new EnemyFabric();
            _player.Spawn();
            FPS = 20;
            _timer = 0;
            _move_speed_enemy = 30;
            _move_speed_player = 10;
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

        internal static void SpawnPlayer()
        {
            if (_player == null)
                _player = new Player(_map.spawn_player);
            else
                _player.Spawn();
        }

        public void Update()
        {

            Monitoring();
            if (_timer % _move_speed_enemy == 0)
                ConductEnemies();
            if (_timer % _move_speed_player == 0)
                ConductPlayer();
            Thread.Sleep(1);
            _timer++;
        }

        private void Intersection(Position position)
        {

        }

        private void ConductPlayer()
        {
            ControllerPlayer.Conduct(_player);
        }

        private void ConductEnemies()
        {
            if (_enemies.Count < 1) return;
            foreach (var enemy in _enemies)
            {
                ControllerEnemy.Conduct(enemy);
            }
        }

        private void Monitoring()
        {
            _monitor.Monitoring(_map.map, 10,_player, _enemies.ToList<Person>());
        }

        static internal bool is_it_empty(Position new_position,bool search_person = true)
        {
            if (!(new_position.x > 0 && new_position.x < _map.n - 1 && new_position.y > 0 && new_position.y < _map.m))
                return false;
            if (_map.map[new_position.x][new_position.y] is not Empty)
            {
                return false;
            }
            if (search_person)
            {
                for (int i = 0; i < _enemies.Count; i++)
                {
                    if (_enemies[i].position == new_position)
                        return false;
                }
                if(_player!=null)
                    if (_player.position == new_position)
                        return false;
            }
            return true;
        }
    }
}
