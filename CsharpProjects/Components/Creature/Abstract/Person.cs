
namespace Roguelike
{
    public abstract class Person : GameObject
    {
        public int maxHP { get; protected set; }
        public int hp { get; protected set; }
        public int damage { get; protected set; }
        public int defense { get; protected set; }
        //public Bow ?weapon { get; protected set; }

        protected Person(Vector2 position,char symbol):base(position,symbol,false)
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

        public void Move(KeyMode direction)
        {
            Vector2[] vectorDir = new Vector2[4]{
                new Vector2(0,-1), new Vector2(-1,0), // Up, Left
                new Vector2(0,1), new Vector2(1,0) // Down, Right
            };
            position += vectorDir[(int)direction];
        }

    }
}
