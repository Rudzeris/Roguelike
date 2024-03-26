namespace Roguelike
{
    public class ControllerEnemy
    {
        ICollision _collision;
        public ControllerEnemy(ICollision _collision)
        {
            this._collision = _collision;
        }
        public void Conduct(Person? enemy)
        {
            if (enemy == null) return;
            bool attacked = false;
            for(int i = 0; i < 4; i++)
            {
                if (!_collision.isItEmpty(enemy.position + Vector2.V2Direction[i]))
                {
                    Person pers = _collision.getPerson(enemy.position + Vector2.V2Direction[i]);
                    if (pers != null)
                    {
                        if (pers.GetType() == typeof(Player))
                        {
                            enemy.Attack((KeyMode)i);
                            attacked = true;
                            break;
                        }
                    }
                }
            }

            if (attacked) return;

            bool[] bl = { true, true, true, true };
            int sl;
            // 3 1 4 2
            // 0 0 1 1
            // пойти в 1
            for (int q = 4; q > 0; q--)
            {
                sl = Random4ik.Next(q);
                for (int k = 0; k <= sl; k++)
                {
                    if (!bl[k]) sl++;
                }
                bl[sl] = false;
                if (_collision.isItEmpty(enemy.position + Vector2.V2Direction[sl]))
                {
                    enemy.Move((KeyMode)sl);
                }
            }
            //if (Game._rand.Next(0, 1) % 2 == 0 && Game.IsItEmpty(enemy.position + directionT))
            //    enemy.weapon?.Attack(enemy.position + directionT, directionT);

        }
    }
}
