using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProjects.Class
{
    internal class Finish:Empty
    {
        public Finish()
        {
            sym = 'W';
            f = true;
            tag = typeof(Finish).Name;
        }
    }
}
