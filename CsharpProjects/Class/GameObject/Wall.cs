﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Wall : GameObject
    {
        public Wall()
        {
            sym = '#';
            f = false;
            tag = typeof(Wall).Name;
            //position = null;
        }
    }
}
