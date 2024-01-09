using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal abstract class Person : GameObject
    {
        static internal uint distance_view;
        public uint maxHP { get; protected set; }
        public uint hp { get; protected set; }

        internal Person()
        {
            distance_view = 3;
            maxHP = 1; hp = 1;
        }
        internal Person(Position spawn_position)
        {
            distance_view = 30;
            this.spawn_position = spawn_position;
            this.position = new Position(spawn_position);
        }
        virtual internal void Spawn()
        {
            hp = maxHP;
            position = spawn_position;
        }
        abstract internal void Dead();

        virtual internal void Damage()
        {
            hp--;
            if (hp <= 0)
            {
                Dead();
            }
        }

        virtual internal void Hit(Person person)
        {
            person.Damage();
        }

        //abstract internal void Conduct();
        abstract internal void Conduct(Position array);

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
