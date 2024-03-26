namespace Roguelike
{
    public class EnemyFabric
    {
        ICollision _collision;
        IMapReader _mapReader;
        List<Vector2>? _enemyPositions;
        Action<GameObject?> _create;
        Action<GameObject?> _delete;
        public EnemyFabric(ICollision _collision, Action<GameObject?> _delete, IMapReader _mapReader, Action<GameObject?> _create)
        {
            this._collision = _collision;
            this._delete = _delete;
            this._create = _create;
            this._mapReader = _mapReader;
            _enemyPositions = null;
        }

        public void CreateEnemy(string typeEnemy, int count)
        {
            if (count <= 0) return;
            for (int i = 0; i < count; i++)
                CreateEnemy(typeEnemy);
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
            _create?.Invoke(enemy);
            if (enemy != null)
            {
                enemy._remove = _delete;
                enemy._create = _create;
                enemy._collision = _collision;
            }
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
