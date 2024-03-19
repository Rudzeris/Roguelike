﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public interface IMapReader
    {
        int Height();
        int Width();
        List<List<GameObject>> getMap();
        char at(int x, int y);
    }
}
