using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    class Punktid //Punktide arv

    {
        private int punktid = 0;

        public void LisaPunkte(int arv) // cчесчик пунктов
        {
            punktid += arv;
        }

        public int PunktideArv()
        {
            return punktid;
        }
    }
}
