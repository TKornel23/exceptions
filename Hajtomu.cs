using System;
using System.Collections.Generic;
using System.Text;

namespace Kivétel
{
    class Hajtomu : IKomponens
    {
        int toloero;
        public int Teljesitmeny { get; set; }
        public bool Allapot { get; set; }

        public void Aktival()
        {
            Teljesitmeny = toloero;
            Allapot = true;
        }

        public void Deaktival()
        {
            Teljesitmeny = 0;
            Allapot = false;
        }

        public Hajtomu(int toloEro)
        {
            this.toloero = toloEro;
        }
    }
}
