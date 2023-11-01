// See https://aka.ms/new-console-template for more information

using System.Diagnostics.SymbolStore;
using System.Security.Cryptography;

namespace Rogalic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            game.Update();
        }
    }
}

class Game
{
    public GameObject? player;
    private Map? myMap;
    byte fps = 20;
    string str = "";
    bool exit = false;
    public void SetFPS(byte fps)
    {
        if (fps < 5 || fps > 240) this.fps = 20;
        else this.fps = fps;
    }
    public void Start()
    {
        myMap = new Map();
        myMap.Create();

    }

    public void Update()
    {
        Thread.Sleep(1000 / fps);
        Console.Clear();
        myMap.Show();
        if (Console.KeyAvailable)
            KeyDownFunction(Console.ReadKey(true).Key);
        Console.WriteLine(str);

        if (!exit) Update();
    }

    private void KeyDownFunction(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.Escape:
                exit = true;
                break;
            case ConsoleKey.W:

                break;
            case ConsoleKey.S:

                break;
            case ConsoleKey.A:

                break;
            case ConsoleKey.D:

                break;
        }
    }
}

class Map
{
    GameObject[,]? map;
    public int n;
    public int m;
    public void Create()
    {
        n = 10;
        m = 20;
        map = new GameObject[n, m];
        for (int i = 1; i < n - 1; i++)
        {
            map[i, 0] = map[i, m - 1] = new Wall();
            for (int j = 1; j < m - 1; j++)
                map[i, j] = new Empty();
        }
        for (int i = 0; i < m; i++)
        {
            map[0, i] = map[n - 1, i] = new Wall();
        }
    }

    public void Show()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(map[i, j].GetSym());
            }
            Console.WriteLine();
        }
    }
}

abstract class GameObject
{
    protected char sym = ' ';
    protected bool f = true;
    public string tag = "None";
    public char GetSym()
    {
        return sym;
    }
    public string GetTag()
    {
        return tag;
    }
}

class Empty : GameObject
{
}

class Wall : GameObject
{
    public Wall()
    {
        sym = '#';
        f = false;
        tag = "Wall";
    }
}

class Player : GameObject
{
    string nickName = "player";
    float hp;
    int x, y;

    public Player()
    {
        hp = 100;
    }
    //public Move

}