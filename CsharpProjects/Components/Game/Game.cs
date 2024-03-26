using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace Roguelike
{
    public class Game : ITimer, IRestart, IPause
    {
        public List<GameObject> _objects { set; get; }
        public Player _player { set; get; }
        public Renderer _drawToConsole { set; get; }
        public uint _count_enemy_on_the_map;
        public Map _map { set; get; }
        public EnemyFabric _enemy_fabric { set; get; }
        public int FPS { get; private set; }
        public int _timer { get; private set; }
        public InputManager _inputManager { get; private set; }
        public InputHandler _inputHandler { get; private set; }
        public ControllerPlayer _controllerPlayer { get; private set; }
        public Controller _controller { get; private set; }
        public Collision _collusion { get; private set; }
        public int getTimer() { return _timer; }

        private bool _pause;
        public Game()
        {
            FPS = 40;
            _collusion = new Collision();
            _inputManager = new InputManager(this, this);
            _map = new Map();
            _objects = new List<GameObject>();
            _player = new Player(restart, _map.spawn_player);
            _controllerPlayer = new ControllerPlayer(_player, _collusion, this);
            _drawToConsole = new Renderer(this,this, _map, _objects, _player, FPS);
            _inputHandler = new InputHandler(_controllerPlayer, _inputManager);
            _enemy_fabric = new EnemyFabric(_collusion,removeObject, (IMapReader)_map, addObject);
            _collusion.setMapReader(_map)
                    .setPlayer(_player)
                    .setEnemies(_objects);
            _controller = new Controller(_collusion, this);
        }

        public void Start()
        {
            play();
            _objects.Clear();
            _map.recreateMap(1 + Random4ik.Next(3, 6) * 2, 1 + Random4ik.Next(5, 12) * 2);
            _enemy_fabric.createPositions();
            _player.spawn(_map.spawn_player);
            _timer = 0;
            _count_enemy_on_the_map = 5;

            _enemy_fabric.CreateEnemy(typeof(Warrior).Name, 2);
            _enemy_fabric.CreateEnemy(typeof(Archer).Name, 1);


        }

        public void Update()
        {
            while (true)
            {
                _inputManager.ReadInput();
                _drawToConsole.update();
                Thread.Sleep(1);
                _timer++;
                for (int i = 0; i < _objects.Count; i++)
                    _controller?.Action(_objects[i]);
                clearWeapon();
            }
        }

        private void clearWeapon()
        {
            if(_timer % 10 == 0)
            for(int i=0;i< _objects.Count;i++)
                if (_objects[i].GetType() == typeof(Weapon))
                {
                    _objects.RemoveAt(i);
                    i--;
                }
        }

        public void restart()
        {
            Start();
        }

        public void pause()
        {
            _pause = true;
        }
        public void play()
        {
            _pause = false;
        }
        public bool paused()
        {
            return _pause;
        }

        public void addObject(GameObject? _obj)
        {
            if (_obj != null)
                _objects.Add(_obj);
        }
        public void removeObject(GameObject? _obj)
        {
            if(_obj != null)
                _objects.Remove(_obj);
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
