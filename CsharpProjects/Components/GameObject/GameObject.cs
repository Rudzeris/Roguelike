namespace Roguelike
{
    public abstract class GameObject
    {
        public Vector2 position { get; protected set; }

        public char symbol {get; private set;}

        public bool passable { get; private set; }

        protected GameObject(Vector2 position,char symbol, bool passage)
        {
            this.symbol = symbol;
            this.passable = passage;
            this.position = position;
        }
    }
}
