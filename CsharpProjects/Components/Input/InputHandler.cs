using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class InputHandler
    {
        public InputManager _input{get; private set;}
        public ControllerPlayer _controllerPlayer { get; private set;}
        
        public InputHandler(ControllerPlayer _controllerPlayer, InputManager input)
        {
            _controllerPlayer = _controllerPlayer;
            _input = input;
            _input.OnAction += _controllerPlayer.Action;
        }
    }
}
