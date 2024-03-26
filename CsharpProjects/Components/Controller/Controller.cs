using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Controller
    {
        ControllerEnemy _enemyC;
        ControllerArrow _weaponC;
        IPause _pause;

        public Controller(ICollision collision, IPause pause)
        {
            this._pause = pause;
            this._enemyC = new ControllerEnemy(collision); 
            this._weaponC = new ControllerArrow(collision);
        }
        public void Action(GameObject obj)
        {
            if (_pause.paused()) return;
            switch (obj)
            {
                case Enemy:
                    _enemyC.Conduct((Person)obj);
                    break;
                case Arrow:
                    _weaponC.Action((Arrow)obj);
                    break;
            }
        }
    }
}
