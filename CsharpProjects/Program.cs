// See https://aka.ms/new-console-template for more information

using Microsoft.VisualBasic.FileIO;
using System.Diagnostics.SymbolStore;
using System.Formats.Asn1;
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
    byte bMenu = 0;
    bool openMenu;
    string[] textMenu =
    {
        "Продолжить игру",
        "Создать новую карту",
        "Добавить противника",
        "Выйти"
    };
    int maxLengthTextMenu;
    public void SetFPS(byte fps)
    {
        if (fps < 5 || fps > 240) this.fps = 20;
        else this.fps = fps;
    }
    public void Start()
    {
        maxLengthTextMenu = 0;
        for (int i = 0; i < textMenu.Length; i++)
        {
            if (textMenu[i].Length>maxLengthTextMenu) maxLengthTextMenu = textMenu[i].Length;
        }
        Menu();
        Update();
    }


    public void Update()
    {
        Thread.Sleep(1000 / fps);
        Console.Clear();
        myMap.Show();
        if (Console.KeyAvailable)
            KeyDownFunction(Console.ReadKey(true).Key);
        Console.WriteLine(str + player?.hp.ToString());

        if (!exit) Update();
    }

    private void SpawnEnemy()
    {
        if (myMap == null) return;
        if (enemy == null) enemy = new List<Enemy>();
        int q = 1;
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
    public void Menu()
    {
        openMenu = true;
        Console.Clear();
        while (openMenu)
        {
            Thread.Sleep(1000 / fps);
            Console.Clear();
            for (int i = 0;i < textMenu.Length; i++)
            {
                Console.Write('\t');
                for (int j = 0; j < (maxLengthTextMenu - textMenu[i].Length) / 2; j++)
                    Console.Write(' ');
                Console.Write((bMenu==i) ? ('[') : (' '));
                Console.Write(textMenu[i].ToString());
                Console.WriteLine((bMenu == i) ? (']') : (' '));
            }
            KeyDownFunction(Console.ReadKey(true).Key);
        }
    }

    void MenuActivate(int x)
    {
        switch (x)
        {
            case 0:
                if (myMap == null) return;
                if(myMap.n==-1 || myMap.m==-1)  return;
                openMenu = false;
                break;
            case 1:
                if (myMap == null) myMap = new Map();
                myMap.Create();
                SpawnPlayer();
                break;
            case 2:

                break;
            case 3:
                openMenu = false;
                exit = true;
                break;
        }
    }

    private void KeyDownFunction(ConsoleKey key)
    {
        if (openMenu)
        {
            switch (key)
            {
                case ConsoleKey.Escape:
                    MenuActivate(0);
                    break;
                case ConsoleKey.Enter:
                    MenuActivate(bMenu);
                    break;
                case ConsoleKey.W:
                    if(bMenu > 0) bMenu--;
                    break;
                case ConsoleKey.S:
                    if (bMenu < textMenu.Length-1) bMenu++;
                    break;
            }
        }
        else
        {
            switch (key)
            {
                case ConsoleKey.Escape:
                    Menu();
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
    }
    public bool itsEmpty(Position newPosition)
    {
        if (myMap == null) return false;
        return myMap.itsEmpty(newPosition);
    }
    // Создать класс который добавляет на карту персонажа
    // принимает метод создания объекта, создает объект и добавляет объект в map справочник GameObject
    // и вернуть сам объект
    public void SpawnPlayer()
    {
        if (player == null) player = new Player();
        player.Create(myMap.SpawnPlayer(player)); // -получает Position и отдает в player
    }
}

class Map
{
    GameObject[,] map;
    Position spawnPlayer;
    Random rand = new Random();
    public int n { get; private set; }
    public int m { get; private set; }
    public Map()
    {
        n = -1;
        m = -1;
    }
    public void Create()
    {
        n = 13;
        m = 25;
        // (n-2)/2+1
        spawnPlayer = new Position(1 + rand.Next((n - 2) / 2 + 1)*2,1 + rand.Next((m - 2) / 2 + 1)*2);
        map = new GameObject[n, m];
        for (int i = 1; i < n - 1; i++)
        {
            map[i, 0] = new Wall();
            map[i, m - 1] = new Wall();

            //for (int j = 1; j < m - 1; j++)
            //{
            //    map[i, j] = null;
            //    /*if (i % 2 != 0 || j % 2 != 0) map[i, j] = new Empty();
            //    else map[i, j] = new Wall();*/
            //}
        }
        for (int i = 0; i < m; i++)
        {
            map[0, i] = new Wall();
            map[n - 1, i] = new Wall();
        }
        // Теперь надо бы сделать лабиринт -_-
        
        CreateRoad(1, 1); // Рекурсивная функция

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (map[i, j] == null) map[i, j] = new Wall();
            }
        }
    }

    private void CreateRoad(int i, int j)
    {
        // Надо послать во все 4 стороны))
        map[i, j] = new Empty();
        
        bool[] bl = { true, true, true, true };
        int sl;
        // 3 1 4 2
        // 0 0 1 1
        // пойти в 1
        for (int q = 4; q > 0; q--)
        {
            sl = rand.Next(q);
            for (int k = 0; k <= sl; k++)
            {
                if (!bl[k]) sl++;
            }
            bl[sl] = false;
            switch (sl)
            {
                case 0: // Север
                    if (i - 2 > 0)
                    {
                        if (map[i - 2, j] == null)
                        {
                            map[i - 1, j] = new Empty();
                            CreateRoad(i - 2, j);
                        }
                    }
                    break;
                case 1: // Запад
                    if (j - 2 > 0)
                    {
                        if (map[i, j - 2] == null)
                        {
                            map[i, j - 1] = new Empty();
                            CreateRoad(i, j - 2);
                        }
                    }
                    break;
                case 2: // Юг
                    if (i + 2 < n - 1)
                    {
                        if (map[i + 2, j] == null)
                        {
                            map[i + 1, j] = new Empty();
                            CreateRoad(i + 2, j);
                        }
                    }
                    break;
                case 3: // Восток
                    if (j + 2 < m - 1)
                    {
                        if (map[i, j + 2] == null)
                        {
                            map[i, j + 1] = new Empty();
                            CreateRoad(i, j + 2);
                        }
                    }
                    break;
            }
        }
    }

    public void Show()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (map[i, j] != null)
                    Console.Write(map[i, j].GetSym() + " ");
                else
                    Console.Write('E' + " ");
            }
            Console.WriteLine();
        }
    }

    public bool itsEmpty(Position newPosition)
    {
        if (newPosition.x >= n || newPosition.y >= m) return false;
        if (Empty.GetSymSt() == map[newPosition.x, newPosition.y].GetSym())
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
    private void ClearMap()
    {
        for(int i = 1;i < n; i++)
        {
            for (int j = 1; j < m; j++)
            {
                if (map[i, j].tag != typeof(Wall).Name && map[i, j].tag != typeof(Empty).Name)
                    map[i, j] = new Empty();
            }
        }
    }
    public Position SpawnPlayer(GameObject player)
    {
        ClearMap();
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
        tag = typeof(Empty).Name;
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
        tag = typeof(Wall).Name;
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
    public void Move(Position newPosition)
    {
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