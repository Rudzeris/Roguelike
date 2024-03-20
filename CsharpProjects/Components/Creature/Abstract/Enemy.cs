
namespace Roguelike
{
    public abstract class Enemy : Person
    {
        public uint distance_view { get; protected set; }
        public Enemy(Vector2 position,char symbol) :
            base(position,symbol)
        {
        }
    }
}
