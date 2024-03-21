namespace Roguelike
{
    public class EnemyFabric
    {
        IMapReader _mapReader;
        Action<Person> _spawnEnemy;
        List<Vector2> _enemyPositions;
        public EnemyFabric(IMapReader _mapReader, Action<Person> _enemySpawn)
        {
            this._mapReader = _mapReader;
            this._spawnEnemy = _enemySpawn;
            _enemyPositions = new List<Vector2>();
            foreach(var i in _mapReader.getSpawnEnemies())
            {
                _enemyPositions.Add(i);
            }
        }
        public void CreateEnemy(bool type)
        {
            Vector2? enemy_position = GetEnemyPosition();
            if (enemy_position == null)
                return;
            Enemy? enemy = null;
            if (type) enemy = new Archer(enemy_position??new Vector2(1,1));
            else enemy = new Warrior(enemy_position ?? new Vector2(1, 1));
            _spawnEnemy?.Invoke(enemy);
        }
        public Vector2? GetEnemyPosition()
        {
            if (_enemyPositions.Count == 0) return null;
            int index = Random4ik.getRandomNumber(0, _enemyPositions.Count);
            Vector2 enemy_position = _enemyPositions[index];
            _enemyPositions.RemoveAt(index);
            return enemy_position;
        }


    }

}
