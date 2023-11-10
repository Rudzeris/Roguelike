using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Map
    {
        GameObject[,] map;
        Position spawnPlayer;
        Position finish;
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
            spawnPlayer = new Position(1 + rand.Next((n - 2) / 2 + 1) * 2, 1 + rand.Next((m - 2) / 2 + 1) * 2);
            finish = new Position(n-1-spawnPlayer.x,m-1-spawnPlayer.y);
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

        public void Hit(Position pos)
        {
            if(map==null) return;
            if(pos.x<0  || pos.y<0 || pos.x>= n || pos.y>=m) return;
            if(map[pos.x, pos.y].HitKill()) map[pos.x,pos.y]=new Empty();
        }
        public bool[] Napravlenie4(Position pos)
        {
            bool[] bl = new bool[4];
            bl[0] = map[pos.x - 1, pos.y].tag != typeof(Wall).Name;
            bl[1] = map[pos.x + 1, pos.y].tag != typeof(Wall).Name;
            bl[2] = map[pos.x, pos.y - 1].tag != typeof(Wall).Name;
            bl[3] = map[pos.x, pos.y + 1].tag != typeof(Wall).Name;
            return bl;
        }
        public void CreatePositionForEnemy(Position pos)
        {
            if (map == null || n == -1 || m == -1) return; // нет карты
            if (map[spawnPlayer.x, spawnPlayer.y].tag == null) return; // нет дороги


            for (int i = 1; i < n; i += 8)
            {
                for (int j = 1; j < m; j += 8)
                {
                    if (Math.Pow(pos.x - i, 2) + Math.Pow(pos.y - j, 2) >= 7)
                    {
                        map[i, j] = EnemyFabrica.CreateEmemy(rand.Next(100) / 70, new Position(i, j));
                    }
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
                        if (i == finish.x && j == finish.y)
                            Console.Write("W ");
                        else Console.Write(map[i, j].GetSym() + " ");
                    else
                        Console.Write('E' + " ");
                }
                Console.WriteLine();
            }
        }

        public bool itsEmpty(Position newPosition)
        {
            if (newPosition.x >= n || newPosition.y >= m) return false;
            if (map[newPosition.x, newPosition.y] == null) return false;
            if (Empty.GetSymSt() == map[newPosition.x, newPosition.y].GetSym())
            {
                return true;
            }
            return false;
        }
        public string itsEmptyTag(Position newPosition)
        {
            if (newPosition.x >= n || newPosition.y >= m) return "";
            if (map[newPosition.x, newPosition.y] == null) return "";
            return map[newPosition.x, newPosition.y].tag;
        }
        public void Move(Position oldPos, Position newPos, GameObject player)
        {
            if (player.tag==typeof(Player).Name && newPos.Sravn(finish)) Create();
            if (newPos.x >= n || newPos.y >= m) return;
            map[oldPos.x, oldPos.y] = map[newPos.x, newPos.y];
            map[newPos.x, newPos.y] = player;
        }
        private void ClearMap()
        {
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (map[i, j] == null)
                        map[i, j] = new Empty();
                    else if (map[i, j].tag != typeof(Wall).Name && map[i, j].tag != typeof(Empty).Name)
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
        //public Position SpawnFinish(GameObject fin)
        //{
        //    map[finish.x, finish.y] = fin;
        //    return finish;
        //}
    }

}
