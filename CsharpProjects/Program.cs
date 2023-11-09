// See https://aka.ms/new-console-template for more information

using Microsoft.VisualBasic.FileIO;
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
    public List<Enemy> enemy;
    private Map myMap;
    byte fps = 20;
    string str = "HP: ";
    bool exit = false;
    public Random rng = new Random();
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
        Console.WriteLine(str+player?.hp.ToString());

        if (!exit) Update();
    }

    private void SpawnEnemy()
    {
        if(myMap == null) return;
        if(enemy==null) enemy = new List<Enemy>();
        int q = 2;
        for (int i = 0; i < q; i++)
            enemy.Add(new Enemy());
        int n = myMap.n;
        int m = myMap.m;
        Position position = new Position();
        //for (int w = 0;w < n; w+=4)
        //{
        //    for (int i = w; i < w+4 && i < n; i++)
        //    {
        //    }
        //}
    }
    

    static int GenerateDigit(Random rng)
    {
        return rng.Next(10);
    }

    private void MoveEnemy()
    {

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
                SpawnEnemy();
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
    // Создать класс который добавляет на карту персонажа
    // принимает метод создания объекта, создает объект и добавляет объект в map справочник GameObject
    // и вернуть сам объект
    public void SpawnPlayer()
    {
        if(player==null) player = new Player();
        player.Create(myMap.SpawnPlayer(player)); // -получает Position и отдает в player
    }
}

class Map
{
    GameObject[,] map;
    Position spawnPlayer;
    public int n { get; private set; }
    public int m { get; private set; }
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
        if (newPosition.x >= n || newPosition.y >= m) return false;
        if (Empty.GetSymSt() == map[newPosition.x,newPosition.y].GetSym())
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

abstract class Person : GameObject
{
    public uint maxHP { get; protected set; }
    public uint hp { get; protected set; }
    public Position position { get; protected set; }

    public void Create(Position position) // В конструктор
    {
        hp = maxHP;
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

class Player : Person
{
    public Player()
    {
        sym = 'P';
        tag = "Player";
        maxHP = 4;
    }
}

class Enemy : Person
{
    public Enemy()
    {
        sym = 'X';
        tag = "Enemy";
        maxHP = 1;
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