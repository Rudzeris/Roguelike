
namespace Roguelike
{
    public abstract class Enemy : Person
    {
        public uint distance_view { get; protected set; }
        public Enemy(ICollision _ICollision, Vector2 position,char symbol) :
            base(_ICollision, position,symbol)
        {
        }
    }
}
