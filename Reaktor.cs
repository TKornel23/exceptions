using System;
using System.Collections.Generic;
using System.Text;

namespace Kivétel
{
    class Reaktor : IKomponens
    {
        int teljesitmeny;
        public int Teljesitmeny { get; set; }
        public bool Allapot { get; set; }
        private int allapotSeged = 0;

        public void Aktival()
        {
            Teljesitmeny = -1 * teljesitmeny;
            Allapot = true;


            try
            {
                if (allapotSeged == 1)
                {
                    throw new InvalidOperationException("[HIBA] Egy reaktor már fut.");
                }
                if (allapotSeged == 0)
                {
                    allapotSeged++;
                }
                if (Teljesitmeny == 0)
                {
                    throw new NotSupportedException("[KIVETEL]A reaktor teljesítménye nem lehet 0");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Deaktival()
        {
            Teljesitmeny = 0;
            Allapot = false;
            try
            {
                if (allapotSeged == 0)
                {
                    throw new InvalidOperationException("[KIVETEL] A reaktor még nincs aktiválva.");
                }
                if (allapotSeged == 1)
                {
                    allapotSeged--;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public Reaktor(int teljesitmeny)
        {
            this.teljesitmeny = teljesitmeny;
        }
    }
}
