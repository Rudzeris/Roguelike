
namespace Roguelike
{
    public abstract class Enemy : Person
    {
        public Action<Person> _enemyDelete;
        public uint distance_view { get; protected set; }

        private const int _attackTime = 100;
        private int _attack = 0;
        private const int _moveTime = 80;
        private int _move = 0;
        public Enemy(Vector2 position, char symbol) :
            base(position, symbol)
        {
        }
        protected override void Dead()
        {
            _enemyDelete?.Invoke(this);
        }
        public override void Attack(Person? person)
        {
            if (_attack <= 0)
            {
                base.Attack(person);
                _attack = _attackTime;
            }
            else
                _attack--;

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
