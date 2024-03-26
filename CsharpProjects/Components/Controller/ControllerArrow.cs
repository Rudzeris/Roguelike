using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class ControllerArrow
    {
        ICollision _collision;
        public ControllerArrow(ICollision _collision)
        {
            this._collision = _collision;
        }
        public void Action(Arrow arrow)
        {
            Person? pers = _collision.getPerson(arrow.position);
            if (pers != null)
            {
                arrow.Attack(pers);

            }
            else
            {
                arrow.Move();
            }
        }

    }
}
