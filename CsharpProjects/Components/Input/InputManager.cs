using System.Numerics;

namespace Roguelike
{
    public class InputManager
    {
        public InputManager() { }
        public KeyMode ReadInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        return (KeyMode.Up);
                    case ConsoleKey.A:
                        return (KeyMode.Left);
                    case ConsoleKey.S:
                        return (KeyMode.Down);
                    case ConsoleKey.D:
                        return (KeyMode.Right);
                    case ConsoleKey.Spacebar:
                        return (KeyMode.Attack);
                }
            }
            return KeyMode.None;
        }
    }
}

