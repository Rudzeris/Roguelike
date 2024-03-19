namespace Roguelike
{
    public class Finish:Area
    {
        public Finish(ICollision? _ICollision, Vector2 position) : base(_ICollision, position, '$', true) { }
    }
}
