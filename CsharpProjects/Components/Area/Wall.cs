namespace Roguelike
{
    public class Wall : Area
    {
        public Wall(ICollision? _ICollision, Vector2 position) : base(_ICollision,position, '#', false) { }
    }
}
