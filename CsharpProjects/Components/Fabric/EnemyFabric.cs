namespace Roguelike
{
    public class EnemyFabric
    {
        IMapReader _mapReader;
        List<Vector2>? _enemyPositions;
        Action<Person?> _createEnemy;
        Action<Person> _deleteEnemy;
        public EnemyFabric(Action<Person> _deleteEnemy,IMapReader _mapReader, Action<Person?> _createEnemy)
        {
            this._deleteEnemy = _deleteEnemy;
            this._createEnemy = _createEnemy;
            this._mapReader = _mapReader;
            _enemyPositions = null;
        }
        public void CreateEnemy(string typeEnemy)
        {
            recreatePositions();
            Type? type = Type.GetType($"Roguelike.{typeEnemy}", false, true);
            if (type == null) return;
            Vector2? enemy_position = GetEnemyPosition();
            if (enemy_position == null)
                return;
            System.Reflection.ConstructorInfo ci = type.GetConstructor(new Type[] { typeof(Vector2) });
            Enemy enemy = (Enemy)ci.Invoke(new object[] { enemy_position });
            _createEnemy?.Invoke(enemy);
            if (enemy != null)
                enemy._enemyDelete = _deleteEnemy;

        }
        private void recreatePositions()
        {
            if (_enemyPositions != null) return;
            if (_mapReader.getSpawnEnemies().Count == 0) return;
            _enemyPositions = new List<Vector2>();
            foreach (var i in _mapReader.getSpawnEnemies())
            {
                _enemyPositions.Add(i);
            }
        }
        public void createPositions()
        {
            _enemyPositions = null;
            recreatePositions();

        }
        public Vector2? GetEnemyPosition()
        {
            if (_enemyPositions.Count == 0) return null;
            int index = Random4ik.Next(0, _enemyPositions.Count);
            Vector2 enemy_position = _enemyPositions[index];
            _enemyPositions.RemoveAt(index);
            return enemy_position;
        }
    }

}
