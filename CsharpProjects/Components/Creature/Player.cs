
namespace Roguelike
{
    public class Player : Person
    {
        public Player(Vector2 position) : base(position, 'P')
        {
            defense = 0;
            damage = 1;
            maxHP = hp = 4;
        }
        public void spawn(Vector2 position) { this.position = position; hp = maxHP; }
    }
}
