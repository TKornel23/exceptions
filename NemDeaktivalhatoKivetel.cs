using System;
using System.Collections.Generic;
using System.Text;

namespace Kivétel
{
    class NemDeaktivalhatoKivetel :Exception
    {
        public NemDeaktivalhatoKivetel(string hibaÜzenet, Exception ex)
            :base(hibaÜzenet, ex)
        {

        }
    }
}
