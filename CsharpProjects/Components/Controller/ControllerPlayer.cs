using System;

namespace Roguelike
{
    public class ControllerPlayer
    {
        ICollision _collision;
        Person _player;
        public ControllerPlayer(Person _player, ICollision _collision)
        {
            this._player = _player;
            this._collision = _collision;
        }
        public void Action(KeyMode key)
        {
            switch (key)
            {
                case KeyMode.Up:
                    if (_collision.isItEmpty(_player.position + Vector2.Up))
                        _player.Move(KeyMode.Up);
                    break;
                case KeyMode.Left:
                    if (_collision.isItEmpty(_player.position + Vector2.Left))
                        _player.Move(KeyMode.Left);
                    break;
                case KeyMode.Down:
                    if (_collision.isItEmpty(_player.position + Vector2.Down))
                        _player.Move(KeyMode.Down);
                    break;
                case KeyMode.Right:
                    if (_collision.isItEmpty(_player.position + Vector2.Right))
                        _player.Move(KeyMode.Right);
                    break;
                case KeyMode.Attack:
                    Person person = null;
                    _player.Attack(person);
                    break;
            }
        }
    }

}
