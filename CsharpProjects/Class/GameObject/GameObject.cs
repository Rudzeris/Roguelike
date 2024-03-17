namespace Roguelike
{
    internal abstract class GameObject
    {
        internal char symbol {get; private set;}

        internal bool passage { get; private set; }

        private protected GameObject(char symbol, bool passage=true)
        {
            this.symbol = symbol;
            this.passage = passage;
        }
    }
}
