using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class EnemyFabric
    {
        Random rand = new Random();
        List<Enemy> enemies_list;
        List<Position> spawn_point_for_enemies;
        internal EnemyFabric()
        {
            spawn_point_for_enemies = new List<Position>();
            enemies_list = new List<Enemy>();
        }
        internal EnemyFabric(Game _game, Map map)
        {
            this.enemies_list = _game._enemies;
            this.spawn_point_for_enemies = map.spawn_enemies;
        }
        internal void CreateEmemy(bool type)
        {
            Position enemy_position = GetEnemyPosition();
            if(enemy_position.Sravn(new Position(-1,-1)))
                return;
            Enemy enemy=null;
            if (type) enemy = new Spider(enemy_position);
            else enemy = new Zombie(enemy_position);
            enemies_list.Add(enemy);
        }
        internal Position GetEnemyPosition()
        {
            if (spawn_point_for_enemies.Count == 0) return new Position(-1, -1);
            int index = rand.Next(0, spawn_point_for_enemies.Count);
            Position enemy_position = spawn_point_for_enemies[index];
            spawn_point_for_enemies.RemoveAt(index);
            return enemy_position;
        }


    }

}
