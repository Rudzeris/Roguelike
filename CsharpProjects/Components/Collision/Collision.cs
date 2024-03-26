using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Collision : ICollision
    {
        private List<GameObject>? _objects;
        private Person? _player;
        private IMapReader? _mapReader;

        public Collision()
        {
            this._mapReader = null;
            this._player = null;
            this._objects = null;
        }
        public Collision(IMapReader _mapReader,
            Player _player, List<GameObject> _objects) {
            this._mapReader = _mapReader;
            this._player = _player;
            this._objects = _objects;
        }

        public Collision setEnemies(List<GameObject> _enemies) {
            if (this._objects == null) this._objects = _enemies;
            return this;
        }

        public Collision setPlayer(Person _player)
        {
            if(this._player == null) this._player = _player;
            return this;
        }

        public Collision setMapReader(IMapReader _mapReader)
        {
            if(this._mapReader == null) this._mapReader = _mapReader;
            return this;
        }
        
        public bool isItEmpty(Vector2 position) {
            bool _empty = true;
            if (_objects == null || _mapReader == null || _player == null) return false;
            if (_objects?.Count > 0)
                for (int i = 0; i < _objects.Count; i++)
                    if (_objects[i] != null)
                        if (position == _objects[i].position && _objects[i].passable==false)
                                _empty = false;
            if(!_mapReader.isItEmpty(position.x, position.y)) _empty = false;
            if(_player.position == position) _empty = false;
            return _empty;
        }

        public Person? getPerson(Vector2 position)
        {
            Person? person = null;
            if (_objects?.Count > 0)
                for(int i=0;i<_objects.Count;i++)
                    if (_objects[i].GetType() != typeof(Arrow))
                        if (position == _objects[i].position) person = (Person)_objects[i];
            if(_player!=null)
            if (_player.position == position) person = _player;
            return person;
        }

        public bool isItFinish(Vector2 position)
        {
            if(_mapReader != null)
                return _mapReader.isItFinish(position);
            else return false;
        }
    }
}
