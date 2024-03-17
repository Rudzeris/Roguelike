using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Roguelike
{
    public class Game
    {
        static public Random _rand = new Random();
        public List<Enemy> _enemies { set; get; }
        //public List<Arrow> _arrows { set; get; }
        public Player _player { set; get; }
        public Monitor _monitor { set; get; }
        public uint _count_enemy_on_the_map;
        public Map _map { set; get; }
        public EnemyFabric _enemy_fabric { set; get; }
        public uint FPS { get; private set; }
        public uint _timer { get; private set; }
        public uint _move_speed_enemy { get; private set; }
        public uint _move_speed_player { get; private set; }
        public uint _move_speed_arrow { get; private set; }

        public Game()
        {
            _map = new Map(27, 13);
            _enemies = new List<Enemy>();
            //_arrows = new List<Arrow>();
            _monitor = new Monitor();
            _enemy_fabric = new EnemyFabric();
            _player = new Player(_map.spawn_player);

            Start();
        }

        public void Start()
        {
            _player.Spawn();
            FPS = 20;
            _timer = 0;
            _move_speed_enemy = 80;
            _move_speed_player = 10;
            _move_speed_arrow = 10;
            _count_enemy_on_the_map = 5;
            for (int i = 0; i < _count_enemy_on_the_map; i++)
            {
                //_enemy_fabric.CreateEmemy(i % 2 == 0);
            }
            while (true)
            {
                Update();
            }

        }

        public void Update()
        {
            Monitoring();
            //if (_timer % _move_speed_enemy == 0)
            //    ConductEnemies();
            //if (_timer % _move_speed_player == 0)
            //    ConductPlayer();
            //if (_timer % _move_speed_arrow == 0)
            //    MoveArrows();
            Thread.Sleep(1);
            _timer++;
        }

        //public static bool IsEnemy(Vector2 position)
        //{
        //    if (_enemies.Count < 1) return false;
        //    foreach (var enemy in _enemies)
        //    {
        //        if (enemy.position == position) return true;
        //    }
        //    return false;
        //}

        //public static void SpawnPlayer()
        //{
        //    if (_player == null)
        //        _player = new Player(_map.spawn_player);
        //    else
        //        _player.Spawn();
        //}

        //private void ConductPlayer()
        //{
        //    ControllerPlayer.Conduct(_player);
        //    if (_map.IsItFinish(_player))
        //    {
        //        NewGame();
        //    }
        //}

        /*private void ConductEnemies()
        {
            if (_enemies.Count < 1) return;
            foreach (var enemy in _enemies)
            {
                ControllerEnemy.Conduct(enemy);
            }
        }

        private void MoveArrows()
        {
            if (_arrows.Count < 1) return;
            for (int i = 0; i < _arrows.Count; i++)
            {
                if (!_arrows[i].Move())
                {
                    i--;
                }
            }
        }*/
        private void Monitoring()
        {
            _monitor.Monitoring(_map.map, 10, _player, _enemies.ToList<Person>());
        }

        //static public bool IsItEmpty(Vector2 new_position, bool search_person = true)
        //{
        //    if (!(new_position.x > 0 && new_position.x < _map.n - 1 && new_position.y > 0 && new_position.y < _map.m))
        //        return false;
        //    if (_map.map[new_position.x][new_position.y] is not Empty)
        //    {
        //        return false;
        //    }
        //    if (search_person)
        //    {
        //        for (int i = 0; i < _enemies.Count; i++)
        //        {
        //            if (_enemies[i].position == new_position)
        //                return false;
        //        }
        //        if (_player != null)
        //            if (_player.position == new_position)
        //                return false;
        //    }
        //    return true;
        //}
    }
}
