using System.Numerics;

namespace Roguelike
{
    public class InputManager
    {
        public Action<KeyMode>? OnAction;
        public InputManager() { }
        public KeyMode ReadInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        OnAction?.Invoke(KeyMode.Up);
                        break;
                    case ConsoleKey.A:
                        OnAction?.Invoke(KeyMode.Left);
                        break;
                    case ConsoleKey.S:
                        OnAction?.Invoke(KeyMode.Down);
                        break;
                    case ConsoleKey.D:
                        OnAction?.Invoke(KeyMode.Right);
                        break;
                    case ConsoleKey.Spacebar:
                        OnAction?.Invoke(KeyMode.Attack);
                        break;
                }
            }
            return KeyMode.None;
        }
    }
}

