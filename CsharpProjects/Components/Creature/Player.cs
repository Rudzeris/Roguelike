
namespace Roguelike
{
    public class Player : Person
    {
        public Player(ICollision _ICollision, Vector2 position) : base(_ICollision, position, 'P')
        {
            //weapon = null;
            defense = 0;
            damage = 1;
            maxHP = hp = 4;
        }

    }
}
