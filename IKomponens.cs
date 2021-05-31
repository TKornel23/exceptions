using System;
using System.Collections.Generic;
using System.Text;

namespace Kivétel
{
    public interface IKomponens
    {
        int Teljesitmeny { get; set; }
        bool Allapot { get; set; }

        void Aktival();

        void Deaktival();
    }
}
