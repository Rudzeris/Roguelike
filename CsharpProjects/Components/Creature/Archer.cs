
namespace Roguelike
{
    public class Archer : Enemy
    {
        public Archer(Vector2 position) : base(position, 'A')
        {
            _attackTime = 200;
            //weapon = new Bow();
            distance_view = 5;
            defense = 0;
            damage = 1;
            maxHP = hp = 1;
        }

        public override void Attack(KeyMode direction)
        {
            if (_attack == 0)
            {
                weapon = new Bow(position);
                base.Attack(direction);
                _attack = _attackTime;
            }
            else
                _attack--;
        }
    }
}
