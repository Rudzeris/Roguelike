// See https://aka.ms/new-console-template for more information

using System.Diagnostics.SymbolStore;
using System.Numerics;
using System.Runtime.InteropServices;
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
    public Player player;
    private Map myMap;
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

    private void MovePlayer(int x, int y)
    {
        if (player == null) return;
        Position pos = player.GetPosition();
        pos.x += x;
        pos.y += y;
        if (itsEmpty(pos))
        {
            myMap.Move(player.GetPosition(), pos, player);
            player.Move(pos);
        }
    }

    private void KeyDownFunction(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.Escape:
                exit = true;
                break;
            case ConsoleKey.Enter:
                SpawnPlayer();
                break;
            case ConsoleKey.W:
                MovePlayer(-1, 0);
                break;
            case ConsoleKey.S:
                MovePlayer(1, 0);
                break;
            case ConsoleKey.A:
                MovePlayer(0, -1);
                break;
            case ConsoleKey.D:
                MovePlayer(0, 1);
                break;
        }
    }
    public bool itsEmpty(Position newPosition)
    {
        if(myMap == null) return false;
        return myMap.itsEmpty(newPosition);
    }
    public void SpawnPlayer()
    {
        if(player==null) player = new Player();
        player.Move(myMap.SpawnPlayer(player));
    }
}

class Map
{
    GameObject[,] map;
    Position spawnPlayer;
    public int n;
    public int m;
    public void Create()
    {
        n = 10;
        m = 20;
        spawnPlayer = new Position(n/2,m/2);
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
                Console.Write(map[i,j].GetSym());
            }
            Console.WriteLine();
        }
    }

    public bool itsEmpty(Position newPosition)
    {
        if(Empty.GetSymSt() == map[newPosition.x,newPosition.y].GetSym())
        {
            return true;
        }
        return false;
    }
    public void Move(Position oldPos, Position newPos, GameObject player)
    {
        if (newPos.x >= n || newPos.y >= m) return;
        map[oldPos.x, oldPos.y] = map[newPos.x, newPos.y];
        map[newPos.x, newPos.y] = player;
    }
    public Position SpawnPlayer(GameObject player)
    {
        map[spawnPlayer.x, spawnPlayer.y] = player;
        return spawnPlayer;
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
    protected static char symSt;
    public Empty()
    {   
        sym = '.';
    }
    static Empty()
    {
        symSt = '.';
    }
    public static char GetSymSt()
    {
        return symSt;
    }
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
    Position position;

    public Player()
    {
        sym = 'P';
        hp = 100;
        position = new Position();
    }
    public void Create(Position position)
    {
        this.position = position;
    }
    public void Move(Position newPosition){
        position = newPosition;
    }
    public Position GetPosition()
    {
        return position;
    }
}

struct Position
{
    public int x, y;
    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    
}