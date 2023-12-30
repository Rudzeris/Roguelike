using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Map
    {
        internal List<List<GameObject>> map;
        Random rand = new Random();
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
            CreateRoad(1 + 2 * rand.Next(0, (n - 2) / 2), 1 + 2 * rand.Next(0, (m - 2) / 2));

            // Добавляем стены внутри лабиринта
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (map[i][j] == null) map[i][j] = new Wall();
                }
            }
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

        public bool itsEmpty(Position newPosition) // нет применения
        {
            if (newPosition.x >= n || newPosition.y >= m) return false;
            if (map[newPosition.x][newPosition.y] == null) return false;
            if (Empty.GetSymSt() == map[newPosition.x][newPosition.y].GetSym())
            {
                return true;
            }
            return false;
        }
        public string itsEmptyTag(Position newPosition) // нет применения
        {
            if (newPosition.x >= n || newPosition.y >= m) return "";
            if (map[newPosition.x][newPosition.y] == null) return "";
            return map[newPosition.x][newPosition.y].tag;
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
