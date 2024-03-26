namespace Roguelike
{
    public abstract class Area:GameObject
    {
        public Area(Vector2 position, char symbol, bool passage):
            base(position,symbol,passage) { }
    }
}
