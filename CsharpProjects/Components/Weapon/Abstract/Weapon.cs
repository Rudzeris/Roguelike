using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public abstract class Weapon : GameObject
    {
        public ICollision _collision;
        public Action<GameObject?> _create;
        public Action<Person?> _attack;
        public Action<GameObject?> _remove;
        public int _distance_attack { get; protected set; }
        public int _damage { get; protected set; }
        public Weapon(Vector2 _position, char symbol, int _distance_attack, int _damage)
            : base(_position, symbol, true)
        {
            this._distance_attack = _distance_attack;
            this._damage = _damage;
        }
        public void Destruct()
        {
            _remove?.Invoke(this);
        }
        public abstract void Attack(KeyMode direction);
    }
}