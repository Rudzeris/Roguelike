
namespace Roguelike
{
    public class Player : Person
    {
        public Player(Vector2 position) : base(position, 'P')
        {
            //weapon = null;
            defense = 0;
            damage = 1;
            maxHP = hp = 4;
        }

    }
}
