
namespace Roguelike
{
    public abstract class Enemy : Person
    {
        public ICollision _collision;
        public Action<GameObject?> _remove;
        public Action<GameObject?> _create;
        public uint distance_view { get; protected set; }

        protected const int _attackTime = 100;
        protected int _attack = 0;
        private const int _moveTime = 80;
        private int _move = 0;
        public Enemy(Vector2 position, char symbol) :
            base(position, symbol)
        {
            this._collision = _collision;
        }
        protected override void Dead()
        {
            _remove?.Invoke(this);
        }

        public override void Attack(KeyMode direction)
        {
            if(weapon != null)
            {
                weapon._attack = Attack;
                weapon._remove = _remove;
                weapon._create = _create;
                weapon._collision = _collision;
                weapon.Attack(direction);
                weapon = null;
            }
        }
        public override void Attack(Person? person)
        {
            
                base.Attack(person);
                _attack = _attackTime;
            

        }

        public override void Move(KeyMode direction)
        {
            if (_move <= 0)
            {
                base.Move(direction);
                _move = _moveTime;
            }
            else
                _move--;
        }
    }
}
