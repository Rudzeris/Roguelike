using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike {
    public static class Random4ik
    {
        static Random _rand = new Random();
        public static int getRandomNumber(int start, int end)
        {
            return _rand.Next(start,end);
        }
        public static int getRandomNumber(int end)
        {
            return getRandomNumber(0,end);
        }
    }
}
