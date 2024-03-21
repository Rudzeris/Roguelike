using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Collision : ICollision
    {
        private List<Person>? _enemies;
        private Person? _player;
        private IMapReader? _mapReader;

        public Collision()
        {
            this._mapReader = null;
            this._player = null;
            this._enemies = null;
        }
        public Collision(IMapReader _mapReader,
            Player _player, List<Person> _enemies) {
            this._mapReader = _mapReader;
            this._player = _player;
            this._enemies = _enemies;
        }

        public Collision setEnemies(List<Person> _enemies) {
            if (this._enemies == null) this._enemies = _enemies;
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
            if (_enemies == null || _mapReader == null || _player == null) return false;
            if (_enemies?.Count > 0)
                foreach (Person q in _enemies)
                    if (position == q.position) _empty = false;
            if(!_mapReader.isItEmpty(position.x, position.y)) _empty = false;
            if(_player.position == position) _empty = false;
            return _empty;
        }

        public Person? getPerson(Vector2 position)
        {
            Person? person = null;
            if (_enemies?.Count > 0)
                foreach (Person q in _enemies)
                    if (position == q.position) person = q;
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
