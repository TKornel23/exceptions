using System;
using System.Collections.Generic;
using System.Text;

namespace Kivétel
{
    class KomponensNemFerElKivetel : Exception
    {
        public IKomponens komponens { get; }

        public KomponensNemFerElKivetel(string hibaÜzenet, IKomponens komponens)
            :base(hibaÜzenet)
        {
            this.komponens = komponens;
        }
    }
}
