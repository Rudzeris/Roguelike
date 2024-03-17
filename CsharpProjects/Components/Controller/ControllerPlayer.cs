namespace Roguelike
{
    static public class ControllerPlayer
    {
        static public Vector2[] _move { get; private set; } = {
            new Vector2(-1, 0), // up
            new Vector2(0, -1), // left
            new Vector2(1, 0), // down
            new Vector2(0, 1) // right
        };
        static public void Conduct(Player player)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        player?.Move(Direction.Up);
                        break;
                    case ConsoleKey.A:
                        player?.Move(Direction.Left);
                        break;
                    case ConsoleKey.S:
                        player?.Move(Direction.Down);
                        break;
                    case ConsoleKey.D:
                        player?.Move(Direction.Right);
                        break;
                    case ConsoleKey.T:

                        break;
                    case ConsoleKey.P:

                        break;
                    case ConsoleKey.Spacebar:
                        //if (player == null) break;
                        //foreach (var move in _move)
                        //{
                        //    if (Game.IsEnemy(move + player.position))
                        //    {
                        //        Enemy enemy = null;
                        //        foreach (var _enemy in Game._enemies)
                        //            if (_enemy.position == (player.position + move))
                        //                enemy = _enemy;
                        //        player.Hit(enemy);
                        //        break;
                        //    }
                        //}
                        break;
                }
                while (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;
                }
            }

        }
    }
    
}
