
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Arrow : GameObject
    {
        public ICollision _collision;
        public Action<Person?> _attack;
        public Action<GameObject?> _remove;
        public int _move = 0;
        public const int _moveTime = 60;
        public KeyMode _direction { get; private set; } 
        private int _distance;
        public Arrow(Action<GameObject> _create,Vector2 _position, KeyMode _direction, int _distance):
                base(_position,'*',true)
        {
            _create?.Invoke(this);
            this._distance = _distance;
            this._direction = _direction;
        }
        public void Move()
        {
            if (_move == 0)
            {
                if (_distance <= 0 || !_collision.isItEmpty(position))
                    Destruct();
                else
                {
                    position += Vector2.V2Direction[(int)_direction];
                    _distance--;
                }
                _move = _moveTime;
            }
            else
            {
                _move--;
            }
        }
        public void Destruct(){
            _remove?.Invoke(this);
        }
        public void Attack(Person? person)
        {
            if (person != null)
            {
                _attack?.Invoke(person);
                Destruct();
            }
        }
    }
}
