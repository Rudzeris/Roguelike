namespace Roguelike
{
    public abstract class Area:GameObject
    {
        public Area(ICollision? _ICollision, Vector2 position, char symbol, bool passage):
            base(_ICollision,position,symbol,passage) { }
    }
}
