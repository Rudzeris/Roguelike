// See https://aka.ms/new-console-template for more information


namespace Roguelike
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            game.Update();
        }
    }
}

