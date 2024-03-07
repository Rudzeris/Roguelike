using Roguelike.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Arrow : GameObject
    {
        private Vector2 direction;

        private bool friend_arrow;

        public Arrow(Vector2 spawn_position, Vector2 direction, bool friend_arrow)
        {
            this.spawn_position = spawn_position;
            this.direction = direction;
            sym = '*';
            //f = true;
            position = spawn_position + direction;
            this.friend_arrow = friend_arrow;
        }
        internal bool Move()
        {
            if (Game.IsEnemy(position) && friend_arrow)
            {
                foreach (var enemy in Game._enemies)
                {
                    if (enemy.position == position)
                    {
                        enemy.Damage();
                    }
                }

                Destruct();
                return false;
            }
            else
            {
                if (Game._player != null)
                {
                    if (this.position == Game._player.position && !friend_arrow)
                    {
                        Game._player?.Damage();

                        Destruct();
                        return false;
                    }
                }
            }
            if (Game.IsItEmpty(position + direction, false))
            {
                position += direction;
                return true;
            }
            else
            {
                Destruct();
                return false;
            }
        }
        internal void Destruct()
        {
            Game._arrows.Remove(this);
        }
    }
}
