namespace Roguelike
{
    public class Empty : Area
    {
        public Empty(ICollision? _ICollision, Vector2 position) : base(_ICollision, position, ' ', true) { }
    }
}
