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
        internal EnemyFabric()
        {
        }
        internal void CreateEmemy(bool type)
        {
            Position enemy_position = GetEnemyPosition();
            if(enemy_position==new Position(-1,-1))
                return;
            Enemy enemy=null;
            if (type) enemy = new Archer(enemy_position);
            else enemy = new Warrior(enemy_position);
            enemy.Spawn();
        }
        internal Position GetEnemyPosition()
        {
            if (Game._map.spawn_enemies.Count == 0) return new Position(-1, -1);
            int index = rand.Next(0, Game._map.spawn_enemies.Count);
            Position enemy_position = Game._map.spawn_enemies[index];
            Game._map.spawn_enemies.RemoveAt(index);
            return enemy_position;
        }


    }

}
