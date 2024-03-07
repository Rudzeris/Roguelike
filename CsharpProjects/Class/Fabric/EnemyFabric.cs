using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class EnemyFabric
    {
        Random rand = new Random();
        internal EnemyFabric()
        {
        }
        internal void CreateEmemy(bool type)
        {
            Vector2 enemy_position = GetEnemyPosition();
            if (enemy_position == new Vector2(-1, -1))
                return;
            Enemy enemy = null;
            if (type) enemy = new Archer(enemy_position);
            else enemy = new Warrior(enemy_position);
            enemy.Spawn();
        }
        internal Vector2 GetEnemyPosition()
        {
            if (Game._map.spawn_enemies.Count == 0) return new Vector2(-1, -1);
            int index = rand.Next(0, Game._map.spawn_enemies.Count);
            Vector2 enemy_position = Game._map.spawn_enemies[index];
            Game._map.spawn_enemies.RemoveAt(index);
            return enemy_position;
        }


    }

}
