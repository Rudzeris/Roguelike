using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal abstract class Person : GameObject
    {
        static internal uint distance_view;
        private Position spawn_position { get; set; }
        internal Position position { get; private set; }
        public int maxHP { get; protected set; }
        public int hp { get; protected set; }

        internal Bow ?weapon { get; private protected set; }

        private protected Person(char symbol):base(symbol,false)
        {
            weapon = null;
            distance_view = 3;
            maxHP = 1; hp = 1;
        }
        internal Person(Position spawn_position, char symbol) : this(symbol)
        {
            this.spawn_position = spawn_position;
            this.position = new Position(spawn_position);
        }
        virtual internal void Spawn()
        {
            hp = maxHP;
            position = spawn_position;
        }
        abstract internal void Dead();

        virtual internal void Attack(Person person)
        {
            person?.Damage(1);
        }

        private void Damage(int i)
        {
            hp-=i;
            if (hp <= 0)
            {
                Dead();
            }
        }

        //abstract internal void Conduct();
        
        private protected void MoveUp()
        {
            position += ControllerEnemy._move[0];
        }
        private protected void MoveLeft()
        {
            position += ControllerEnemy._move[1];
        }
        private protected void MoveDown()
        {
            position += ControllerEnemy._move[2];
        }
        private protected void MoveRight()
        {
            position += ControllerEnemy._move[3];
        }

        //public bool life { get; private set; }

    }
}
