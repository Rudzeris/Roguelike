﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Player : Person
    {
        public Player()
        {
            sym = 'P';
            tag = "Player";
            maxHP = 4;
            //position = null;
        }
        public Player(Position position)
        {
            sym = 'P';
            tag = "Player";
            maxHP = 4;
            this.position = position;
        }
    }
}