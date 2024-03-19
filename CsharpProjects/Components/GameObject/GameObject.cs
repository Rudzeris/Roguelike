namespace Roguelike
{
    public abstract class GameObject
    {
        ICollision? _ICollision;

        public Vector2 position { get; protected set; }

        public char symbol {get; private set;}

        public bool passable { get; private set; }

        protected GameObject(ICollision? _ICollision,Vector2 position,char symbol, bool passage)
        {
            this._ICollision = _ICollision;
            this.symbol = symbol;
            this.passable = passage;
            this.position = position;
        }
    }
}
