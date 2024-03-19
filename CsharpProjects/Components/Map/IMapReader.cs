﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public interface IMapReader
    {
        int getHeight();
        int getWidth();
        bool isItEmpty(int x, int y);
        char at(int x, int y);
    }
}
