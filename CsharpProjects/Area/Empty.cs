﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class Empty : GameObject
    {
        protected static char symSt;
        public Empty()
        {
            tag = typeof(Empty).Name;
            sym = ' ';
            //position = null;
        }
        public static char GetSymSt()
        {
            return symSt;
        }
    }
}
