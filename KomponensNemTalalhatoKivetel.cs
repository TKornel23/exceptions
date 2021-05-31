using System;
using System.Collections.Generic;
using System.Text;

namespace Kivétel
{
    class KomponensNemTalalhatoKivetel : Exception
    {
        public KomponensNemTalalhatoKivetel()
        {

        }

        public KomponensNemTalalhatoKivetel(string hibaÜzenet)
            :base(hibaÜzenet)
        {

        }
    }
}
