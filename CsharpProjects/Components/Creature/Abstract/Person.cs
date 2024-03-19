
namespace Roguelike
{
    public abstract class Person : GameObject
    {
        public int maxHP { get; protected set; }
        public int hp { get; protected set; }
        public int damage { get; protected set; }
        public int defense { get; protected set; }
        //public Bow ?weapon { get; protected set; }

        protected Person(ICollision _ICollision, Vector2 position,char symbol):
            base(_ICollision, position,symbol,false)
        {
        }
        public void Spawn()
        {

        }
        public void Dead()
        {

        }

        public void Attack(Person person)
        {
            person?.TakeDamage(damage);
        }

        private void TakeDamage(int damage)
        {
            damage = (defense-damage);
            hp -= damage < 0 ? 0 : damage;
            if (hp <= 0)
                Dead();
            
        }

        public void Action(KeyMode mode)
        {
            switch (mode)
            {
                case KeyMode.Up:
                case KeyMode.Down:
                case KeyMode.Left:
                case KeyMode.Right:
                    Move(mode); 
                    break;
                case KeyMode.Attack:
                    break;
                default:
                    break;
            }
        }

        public void Move(KeyMode direction)
        {
            position += Vector2.V2Direction[(int)direction];
        }

    }
}
