namespace Roguelike
{
    static public class ControllerEnemy
    {
        static public Vector2[] _move { get; private set; } = {
            new Vector2(-1, 0), // up
            new Vector2(0, -1), // left
            new Vector2(1, 0), // down
            new Vector2(0, 1) // right
        };

        /*static public uint TracerPlayer(Vector2 position, Vector2 old_position, uint length = 0)
        {
            if (Game._player == null)
                return length;
            if (position == Game._player.position)
                return length;
            if (length == Enemy.distance_view)
                return length;
            uint temp;
            uint minimum = Enemy.distance_view;
            Vector2 true_position = position;
            foreach (var move in _move)
            {
                if (position + move != old_position)
                {
                    if (!Game.IsItEmpty(position + move, false))
                        continue;
                    temp = TracerPlayer(new Vector2(position + move), position, length + 1);
                    if (temp != Enemy.distance_view && temp < minimum)
                    {
                        minimum = temp;
                        true_position = move;
                    }
                }
            }
            return minimum;
        }*/
        /*static public void Conduct(Enemy enemy)
        {
            // Пустим лучи в разные стороны и проверим где игру, если игрока нашли - пойти к нему
            uint temp;
            uint minimum = Enemy.distance_view;
            Vector2 directionT = new Vector2(0, 0);
            foreach (var move in _move)
            {
                if (!Game.IsItEmpty(enemy.position + move, false))
                    continue;
                temp = TracerPlayer(enemy.position + move, enemy.position);
                if (temp < minimum)
                {
                    minimum = temp;
                    directionT = move;
                }
            }
            bool attacking = false;
            if (minimum == Enemy.distance_view)
            {
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
                    if (Game.IsItEmpty(enemy.position + _move[sl]))
                    {
                        directionT = _move[sl];
                        break;
                    }
                }
                //if (Game._rand.Next(0, 1) % 2 == 0 && Game.IsItEmpty(enemy.position + directionT))
                //    enemy.weapon?.Attack(enemy.position + directionT, directionT);
            }
            else
                attacking = true;

            if (!attacking)
            {
                if (Game.IsItEmpty(enemy.position + directionT, false))
                    enemy.Conduct(directionT);
            }
            else
            {
                if (enemy.weapon != null)
                    enemy.weapon.Attack(enemy.position, directionT);
                else
                if (Game.IsItEmpty(enemy.position + directionT, false))
                    enemy.Conduct(directionT);
            }


        }*/
    }
}
