using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Spider : Enemy
    {
        public Web web { get; set; }
        public Spider()
        {
            sym = 'S';
            tag = typeof(Spider).Name;
            maxHP = 1;
        }
    }
}
