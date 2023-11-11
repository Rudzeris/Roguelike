// See https://aka.ms/new-console-template for more information

using CsharpProjects.Class;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics.SymbolStore;
using System.Formats.Asn1;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.Json;


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
    public static List<Enemy> enemy;
    private Map myMap;
    byte fps = 20;
    string str = "HP: ";
    bool exit = false;
    public Random rng = new Random();
    byte bMenu = 0;
    bool openMenu;
    uint timers;
    int timeHit;
    int timeMove;
    int timeBullet;
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
            if (textMenu[i].Length > maxLengthTextMenu) maxLengthTextMenu = textMenu[i].Length;
        }
        timers = 0;
        timeHit = fps * 3;
        timeMove = fps;
        timeBullet = fps * 2;
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
        Console.WriteLine("Скорость врагов: " + (fps/timeMove).ToString());
        Console.WriteLine("Скорость атаки у врагов: " + (fps/timeHit).ToString());
        if (timers % timeMove == 0) MoveEnemy(timers % timeHit == 0);
        //if (timers % timeBullet == 0) MoveBullet();

        timers = timers % 240 + 1;
        if (!exit) Update();
    }

    private void MoveEnemy(int x, int y, Enemy en)
    {
        //return;
        if (enemy == null) return;
        Position pos = new Position(x, y);
        if (itsEmpty(pos))
        {
            myMap.Move(en.GetPosition(), pos, en);
            en.Move(pos);
        }
    }

    /*private void MoveBullet()
    {
        int x, y;
        if (bullet == null) return;
        for (int i = 0; i < bullet.Count; i++)
        {
            x = bullet[i].position.x - bullet[i].attack.x;
            y = bullet[i].position.y - bullet[i].attack.y;

            x = (x!=0)?(x/Math.Abs(x)):(0);
            y = (y!=0)?(y/Math.Abs(y)):(0);
            Position newP = new Position(bullet[i].position.x + x, bullet[i].position.y+y);
            if (!myMap.itsEmpty(newP))
            {
                if(myMap.itsEmptyTag(newP) == typeof(Wall).Name)
                {
                    myMap.Move(bullet[i].position, bullet[i].position, new Empty());
                    bullet.Remove(bullet[i]);
                    i--;
                }
                else if(myMap.itsEmptyTag(newP) == typeof(Player).Name)
                {
                    myMap.Move(bullet[i].position, bullet[i].position, new Empty());
                    bullet.Remove(bullet[i]);
                    player.HitKill();
                    i--;
                }
            }
            myMap.Move(bullet[i].position, newP, bullet[i]);
            bullet[i].Move(newP);
        }
    }*/

    /*private void CreateWeb(Position pos,Position attack)
    {
        if (bullet == null) bullet = new List<Web>();
        Web temp = new Web(pos,attack);
        bullet.Add(temp);
    }*/

    private void MoveEnemy(bool kick)
    {
        if (enemy == null) return;
        for (int i = 0; i < enemy.Count; i++)
        {
            if (enemy[i].hp < 1)
            {
                enemy.Remove(enemy[i]);
            }
            bool[] bl = myMap.Napravlenie4(enemy[i].position);

            int x, y;
            x = enemy[i].position.x;
            y = enemy[i].position.y;

            if (kick && enemy[i].tag == typeof(Enemy).Name)
            {
                if (player.position.x == x - 1 && player.position.y == y) myMap.Hit(new Position(x - 1, y));
                if (player.position.x == x + 1 && player.position.y == y) myMap.Hit(new Position(x + 1, y));
                if (player.position.x == x && player.position.y == y - 1) myMap.Hit(new Position(x, y - 1));
                if (player.position.x == x && player.position.y == y + 1) myMap.Hit(new Position(x, y + 1));
            }
            else
            {
                int count = 0;
                foreach (var ix in bl) if (ix) count++;

                count = rng.Next(count);
                for (int k = 0; k <= count; k++)
                {
                    if (!bl[k]) count++;
                }
                x = enemy[i].position.x;
                y = enemy[i].position.y;
                switch (count)
                {
                    case 0:
                        x--;
                        //if (kick && enemy[i].tag == typeof(Spider).Name)
                        //    CreateWeb(new Position(x, y), enemy[i].position);
                        //else
                        if (player.position.x != x || player.position.y != y)
                            MoveEnemy(x, y, enemy[i]);
                        break;
                    case 1:
                        y--;
                        //if (kick && enemy[i].tag == typeof(Spider).Name)
                        //    CreateWeb(new Position(x, y), enemy[i].position);
                        //else
                        if (player.position.x != x || player.position.y != y)
                            MoveEnemy(x, y, enemy[i]);
                        break;
                    case 2:
                        x++;
                        //if (kick && enemy[i].tag == typeof(Spider).Name)
                        //    CreateWeb(new Position(x, y), enemy[i].position);
                        //else
                        if (player.position.x != x || player.position.y != y)
                            MoveEnemy(x, y, enemy[i]);
                        break;
                    case 3:
                        y++;
                        //if (kick && enemy[i].tag == typeof(Spider).Name)
                        //    CreateWeb(new Position(x, y), enemy[i].position);
                        //else
                        if (player.position.x != x || player.position.y != y)
                            MoveEnemy(x, y, enemy[i]);
                        break;
                }
            }
        }
    }


    private void MovePlayer(int x, int y)
    {
        if (player == null) return;
        if (player.position.x == 0 || player.position.y == 0) return;
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
            for (int i = 0; i < textMenu.Length; i++)
            {
                Console.Write('\t');
                for (int j = 0; j < (maxLengthTextMenu - textMenu[i].Length) / 2; j++)
                    Console.Write(' ');
                Console.Write((bMenu == i) ? ('[') : (' '));
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
                if (myMap.n == -1 || myMap.m == -1) return;
                openMenu = false;
                break;
            case 1:
                if (myMap == null) myMap = new Map();
                myMap.Create();
                SpawnPlayer();
                myMap.CreatePositionForEnemy(player.position);
                break;
            case 2:
                if (myMap == null) return;
                if (enemy != null) if (enemy.Count != 0) return;
                //myMap.CreatePositionForEnemy(player.position);
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
                    if (bMenu > 0) bMenu--;
                    else bMenu = (byte)(textMenu.Length - 1);
                    break;
                case ConsoleKey.S:
                    if (bMenu < textMenu.Length - 1) bMenu++;
                    else bMenu = 0;
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
                    //SpawnPlayer();
                    //enemy.Clear();
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
                case ConsoleKey.E:
                    Kick();
                    break;
                case ConsoleKey.K:
                    timeHit *= 2;
                    break;
                case ConsoleKey.L:
                    timeHit /= 2;
                    break;
                case ConsoleKey.O:
                    timeMove*= 2;
                    break;
                case ConsoleKey.P:
                    timeMove/= 2;
                    break;
            }
        }
    }

    private void Kick()
    {
        if(enemy == null || player  == null) return;
        for (int i = 0; i < enemy.Count; i++)
        {
            if (Math.Abs(enemy[i].position.x - player.position.x)
                + Math.Abs(enemy[i].position.y - player.position.y) == 1)
                myMap.Hit(enemy[i].position);
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

