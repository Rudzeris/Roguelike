
namespace Roguelike
{
    public class Archer : Enemy
    {
        public Archer(Vector2 position) : base(position, 'A')
        {
            //weapon = new Bow();
            distance_view = 5;
            defense = 0;
            damage = 1;
            maxHP = hp = 1;
        }
    }
}
