using System.Numerics;

namespace Roguelike
{
    public class InputManager
    {
        public Action<KeyMode>? OnAction;
        private readonly IPause _pause;
        private readonly IRestart _restart;
        public InputManager(IPause _pause, IRestart _restart)
        {
            this._pause = _pause;
            this._restart = _restart;
        }
        public KeyMode ReadInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        OnAction?.Invoke(KeyMode.Up);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        OnAction?.Invoke(KeyMode.Left);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        OnAction?.Invoke(KeyMode.Down);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        OnAction?.Invoke(KeyMode.Right);
                        break;
                    case ConsoleKey.Spacebar:
                        OnAction?.Invoke(KeyMode.Attack);
                        break;
                    case ConsoleKey.P:
                        if (_pause.paused()) _pause.play();
                        else _pause.pause();
                        break;
                    case ConsoleKey.R:
                        if (_pause.paused()) _restart.restart();
                        break;
                }
            }
            return KeyMode.None;
        }
    }
}

