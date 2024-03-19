
namespace Roguelike
{
    public class Warrior:Enemy
    {
        public Warrior(ICollision _ICollision, Vector2 position) : base(_ICollision, position, 'W')
        {
            //weapon = null;
            distance_view = 5;
            defense = 0;
            damage = 1;
            maxHP = hp = 1;
        }
    }
}
