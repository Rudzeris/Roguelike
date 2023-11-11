using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal abstract class Person : GameObject
    {
        public uint maxHP { get; protected set; }
        public uint hp { get; protected set; }
        public Position position { get; protected set; }
        //public bool life { get; private set; }
        public override bool HitKill()
        {
            hp--;
            if (hp == 0)
            {
                position = new Position(0, 0);
                //life = false;
            }
            return hp == 0;
        }

        public void Create(Position position) // В конструктор
        {
            //life = true;
            hp = maxHP;
            this.position = position;
        }
        public override void Move(Position newPosition)
        {
            position = newPosition;
        }
        public Position GetPosition()
        {
            return position;
        }
    }
}
