using Roguelike;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roguelike
{
    public class Map : IMapSet, IMapReader
    {
        public List<List<GameObject>> _map;
        public Vector2 spawn_player { get; private set; }
        public Vector2 finish_position { get; private set; }
        public List<Vector2> spawn_enemies { get; private set; }

        public int _height { get; private set; }
        public int _width { get; private set; }

        public Map(int width, int height)
        {
            _map = new List<List<GameObject>>();
            spawn_enemies = new List<Vector2>();
            this._height = height < 3 ? 3 : height;
            this._width = width < 3 ? 3 : width;
            randomCreateMap();
        }

        public void randomCreateMap() // a a
        {
            spawn_player = new Vector2(
                1 + 2 * Random4ik.getRandomNumber(0, (_width - 2) / 2),
                1 + 2 * Random4ik.getRandomNumber(0, (_height - 2) / 2)
                );

            finish_position = new Vector2(
                1 + ((_width - 2) - spawn_player.x),
                1 + ((_height - 2) - spawn_player.y)
                );

            spawn_enemies.Clear();
            int radius = 4;
            for (int i = 1; i < _height - 1; i += 4)
            {
                for (int j = 1; j < _width - 1; j += 4)
                {
                    if (Math.Pow(spawn_player.y - i, 2) +
                        Math.Pow(spawn_player.x - j, 2) > radius)
                    {
                        spawn_enemies.Add(new Vector2(j, i));
                    }
                }
            }

            _map.Clear();
            for (int i = 0; i < _height; i++)
            {
                List<GameObject> row = new List<GameObject>();
                for (int j = 0; j < _width; j++)
                {
                    row.Add(null);
                }
                _map.Add(row);
            }

            // Создаем стены по краям
            for (int i = 1; i < _height - 1; i++)
            {
                _map[i][0] = new Wall(new Vector2(i, 0));
                _map[i][_width - 1] = new Wall(new Vector2(i, _width - 1));

            }
            for (int i = 0; i < _width; i++)
            {
                _map[0][i] = new Wall(new Vector2(0, i));
                _map[_height - 1][i] = new Wall(new Vector2(_height - 1, i));
            }

            // Создаем дороги с помощью рекурсивной функции
            CreateRoad(
                1 + 2 * Random4ik.getRandomNumber(0, (_height - 2) / 2),
                1 + 2 * Random4ik.getRandomNumber(0, (_width - 2) / 2)
                );

            // Добавляем стены внутри лабиринта
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (_map[i][j] == null) _map[i][j] = new Wall(new Vector2(i, j));
                }
            }
            _map[finish_position.y][finish_position.x] = new Finish(
                new Vector2(finish_position.y, finish_position.x)
                );
        }

        private void CreateRoad(int i, int j)
        {
            // Надо послать во все 4 стороны))
            _map[i][j] = new Empty(new Vector2(i, j));

            bool[] bl = { true, true, true, true };
            int sl;

            // 3 1 4 2
            // 0 0 1 1
            // пойти в 1
            for (int q = 4; q > 0; q--)
            {
                sl = Random4ik.getRandomNumber(q);
                for (int k = 0; k <= sl; k++)
                {
                    if (!bl[k]) sl++;
                }
                bl[sl] = false;

                if (i + Vector2.V2Direction[sl].y * 2 > 0
                    && i + Vector2.V2Direction[sl].y * 2 < _height - 1
                    && j + Vector2.V2Direction[sl].x * 2 > 0
                    && j + Vector2.V2Direction[sl].x * 2 < _width - 1)

                    if (_map[i + Vector2.V2Direction[sl].y * 2]
                        [j + Vector2.V2Direction[sl].x * 2]
                        == null)
                    {
                        _map[i + Vector2.V2Direction[sl].y]
                        [j + Vector2.V2Direction[sl].x]
                        = new Empty(
                            new Vector2(
                                i + Vector2.V2Direction[sl].y,
                                j + Vector2.V2Direction[sl].x
                                )
                            );
                        CreateRoad(
                            i + Vector2.V2Direction[sl].y * 2,
                            j + Vector2.V2Direction[sl].x * 2
                            );
                    }
            }
        }

        public void recreateMap(int height, int width)
        {
            this._height = height;
            this._width = width;
            randomCreateMap();
        }

        public void setObjectToMap(int height, int width, GameObject obj)
        {
            if (height >= 0 && height < this._height && width >= 0 && width < this._width)
                _map[height][width] = obj;
        }

        public int Height()
        {
            return _height;
        }

        public int Width()
        {
            return _width;
        }

        public List<List<GameObject>> getMap()
        {
            return _map;
        }

        public char at(int y, int x)
        {
            return _map[y][x].symbol;
        }
    }
}
