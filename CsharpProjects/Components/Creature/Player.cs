
namespace Roguelike
{
    public class Player : Person
    {
        Action _playerDelete;
        public Player(Action _playerDelete, Vector2 position) : base(position, 'P')
        {
            this._playerDelete = _playerDelete;
            defense = 0;
            damage = 1;
            maxHP = hp = 4;
        }
        protected override void Dead()
        {
            _playerDelete?.Invoke();
        }
        public void spawn(Vector2 position) { this.position = position; hp = maxHP; }
    }
}
