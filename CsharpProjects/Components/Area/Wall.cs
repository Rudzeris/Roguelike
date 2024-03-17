namespace Roguelike
{
    public class Wall : Area
    {
        public Wall(Vector2 position) : base(position, '#', false) { }
    }
}
