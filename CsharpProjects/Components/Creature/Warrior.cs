
namespace Roguelike
{
    public class Warrior:Enemy
    {
        public Warrior(Vector2 position) : base(position, 'W')
        {
            //weapon = null;
            distance_view = 5;
            defense = 0;
            damage = 1;
            maxHP = hp = 1;
        }
        public override void Attack(KeyMode direction)
        {
            if (_attack == 0)
            {
                weapon = new Sword(position);
                base.Attack(direction);
                _attack = _attackTime;
            }
            else
                _attack--;
        }
    }
}
