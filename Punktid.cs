﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    class Punktid
    {
        private int punktid = 0;

        public void LisaPunkte(int arv)
        {
            punktid += arv;
        }

        public int PunktideArv()
        {
            return punktid;
        }
    }
}
