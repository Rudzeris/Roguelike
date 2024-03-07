using Roguelike.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal abstract class Person : GameObject
    {
        static internal uint distance_view;
        public uint maxHP { get; protected set; }
        public uint hp { get; protected set; }

        internal Bow ?weapon { get; private protected set; }

        internal Person()
        {
            weapon = null;
            distance_view = 3;
            maxHP = 1; hp = 1;
        }
        internal Person(Vector2 spawn_position)
        {
            weapon = null;
            distance_view = 3;
            this.spawn_position = spawn_position;
            this.position = new Vector2(spawn_position);
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
            if(person==null) return;
            person.Damage();
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
