using System;
using System.Collections.Generic;
using System.Text;

namespace Kivétel
{
    class NincsElegEnergiaKivetel : Exception
    {
        public int hianyMerteke { get; }

        public NincsElegEnergiaKivetel(int hianyzoTeljesitmeny)
            :base($"[KIVETEL] Nincs elég teljesítmény, { hianyzoTeljesitmeny } MW hiányzik")
        {
            this.hianyMerteke = hianyzoTeljesitmeny;
        }
    }
}
