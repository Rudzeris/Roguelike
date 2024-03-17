
namespace Roguelike
{
    public class Warrior:Enemy
    {
        public Warrior(Vector2 position):base(position,'W')
        {
            //weapon = null;
            distance_view = 5;
            defense = 0;
            damage = 1;
            maxHP = hp = 1;
        }
    }
}
