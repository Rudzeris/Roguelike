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
        public Player _player { get; private set;}
        
        public InputHandler(Player player, InputManager input)
        {
            _player = player;
            _input = input;
            _input.OnAction += player.Action;
        }
    }
}
