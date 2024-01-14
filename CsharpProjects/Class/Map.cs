using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Map
    {
        internal List<List<GameObject>> map;

        internal Position spawn_player { get; private set; }
        internal Position finish_position{ get; private set; }
        internal List<Position> spawn_enemies { get; private set; }

        internal int n { get; private set; }
        internal int m { get; private set; }
        public Map()
        {
            Create();
        }
        public void Create()
        {
            n = 13;
            m = 25;

            spawn_player = new Position(
                1 + 2 * Game._rand.Next(0, (n - 2) / 2),
                1 + 2 * Game._rand.Next(0, (m - 2) / 2)
                );

            finish_position = new Position(
                1+((n-2)-spawn_player.x),
                1+((m-2)-spawn_player.y)
                );

            int radius = 4;
            spawn_enemies = new List<Position>();
            for(int i = 1; i < n-1; i += 4)
            {
                for(int j = 1; j < m-1;  j += 4)
                {
                    if (Math.Pow(spawn_player.x - i, 2)+
                        Math.Pow(spawn_player.y - j, 2) > radius)
                    {
                        spawn_enemies.Add(new Position(i, j));
                    }
                }
            }

            map?.Clear();
            map=new List<List<GameObject>>();
            for (int i = 0; i < n; i++)
            {
                List<GameObject> row = new List<GameObject>();
                for (int j = 0; j < m; j++)
                {
                    row.Add(null);
                }
                map.Add(row);
            }

            // Создаем стены по краям
            for (int i = 1; i < n - 1; i++)
            {
                map[i][0] = new Wall();
                map[i][m - 1] = new Wall();

            }
            for (int i = 0; i < m; i++)
            {
                map[0][i] = new Wall();
                map[n - 1][i] = new Wall();
            }

            // Создаем дороги с помощью рекурсивной функции
            CreateRoad(
                1 + 2 * Game._rand.Next(0, (n - 2) / 2),
                1 + 2 * Game._rand.Next(0, (m - 2) / 2)
                );

            // Добавляем стены внутри лабиринта
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (map[i][j] == null) map[i][j] = new Wall();
                }
            }
            map[finish_position.x][finish_position.y] = new Finish();
        }

        private void CreateRoad(int i, int j)
        {
            // Надо послать во все 4 стороны))
            map[i][j] = new Empty();

            bool[] bl = { true, true, true, true };
            int sl;
            // 3 1 4 2
            // 0 0 1 1
            // пойти в 1
            for (int q = 4; q > 0; q--)
            {
                sl = Game._rand.Next(q);
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
                            if (map[i - 2][j] == null)
                            {
                                map[i - 1][j] = new Empty();
                                CreateRoad(i - 2, j);
                            }
                        }
                        break;
                    case 1: // Запад
                        if (j - 2 > 0)
                        {
                            if (map[i][j - 2] == null)
                            {
                                map[i][j - 1] = new Empty();
                                CreateRoad(i, j - 2);
                            }
                        }
                        break;
                    case 2: // Юг
                        if (i + 2 < n - 1)
                        {
                            if (map[i + 2][j] == null)
                            {
                                map[i + 1][j] = new Empty();
                                CreateRoad(i + 2, j);
                            }
                        }
                        break;
                    case 3: // Восток
                        if (j + 2 < m - 1)
                        {
                            if (map[i][j + 2] == null)
                            {
                                map[i][j + 1] = new Empty();
                                CreateRoad(i, j + 2);
                            }
                        }
                        break;
                }
            }
        }

        internal bool IsItFinish(Player player) 
        {
            if (player != null)
            {
                if(player.position == finish_position)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsItEmpty(Position newPosition) // нет применения
        {
            if (newPosition.x >= n || newPosition.y >= m) return false;
            if (map[newPosition.x][newPosition.y] == null) return false;
            if (Empty.GetSymSt() == map[newPosition.x][newPosition.y].GetSym())
            {
                return true;
            }
            return false;
        }
        private void ClearMap() // нет применения
        {
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (map[i][j] == null)
                        map[i][j] = new Empty();
                    else if (map[i][j].tag != typeof(Wall).Name && map[i][j].tag != typeof(Empty).Name)
                        map[i][j] = new Empty();
                }
            }
        }
    }
}
