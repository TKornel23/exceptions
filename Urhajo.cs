using System;
using System.Collections.Generic;
using System.Text;

namespace Kivétel
{
    class Urhajo
    {
        private string nev { get; }
        private int uresTomeg { get; }
        private int aktualisTeljesitmeny { get;  set; }
        private UrhajoKategoria kategoria { get; }
        private IKomponens[] komponens { get; set; }

        public Urhajo(string nev, int uresTomeg, UrhajoKategoria kategoria)
        {
            if(nev == null)
            {     
                try
                {
                    throw new ArgumentNullException("Adjon meg egy nevet");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                this.nev = nev;
                Console.WriteLine($"{nev} létrehozva!");
            }       
           
            if(uresTomeg <= 0)
            {
                try
                {
                    throw new ArgumentOutOfRangeException("uresTomeg","[KIVETEL] Az üres tömeg nem lehet negatív!");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                this.uresTomeg = uresTomeg;
            }                         
            
            this.kategoria = kategoria;

            switch (kategoria)
            {
                case UrhajoKategoria.Yacht:
                    komponens = new IKomponens[2];
                    break;
                case UrhajoKategoria.Korvett:
                    komponens = new IKomponens[4];
                    break;
                case UrhajoKategoria.Fregatt:
                    komponens = new IKomponens[6];
                    break;
                case UrhajoKategoria.Rombolo:
                    komponens = new IKomponens[8];
                    break;
                case UrhajoKategoria.Teher:
                    komponens = new IKomponens[8];
                    break;
                case UrhajoKategoria.Allomas:
                    komponens = new IKomponens[20];
                    break;
            }
        }

        public void KomponensFelszerel(IKomponens komponens)
        {
            int i = 0;
            while(i < this.komponens.Length && this.komponens[i] != null)
            {
                i++;
            }
            if(i < this.komponens.Length)
            {
                this.komponens[i] = komponens;
                if(komponens is Hajtomu)
                {
                    Console.WriteLine($"[Hozzaadas] Hajtumo hozzáadva a(z) {nev} hajóhoz");
                }
                else
                {
                    Console.WriteLine($"[Hozzaadas] Reaktor hozzáadva a(z) {nev} hajóhoz");
                }
            }
            else
            {
                try
                {
                    throw new KomponensNemFerElKivetel("[KIVETEL] A komponens nem fér el", komponens);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void KomponensLeszerel(int komponensIndex)
        {
            if(this.komponens[komponensIndex] == null)
            {
                try
                {
                    throw new KomponensNemTalalhatoKivetel("[KIVETEL] A törölni kívánt komponens nem található!");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                this.komponens[komponensIndex] = null;
                Console.WriteLine($"[Leszereles] A(z) {komponensIndex} indexu komponens leszerelve a(z) {nev} hajorol.");
            }
        }

        public void Padlogaz()
        {
            for (int i = 0; i < komponens.Length; i++)
            {
                if(komponens[i] is Hajtomu)
                {
                    if (!(komponens[i].Allapot))
                    {
                        komponens[i].Aktival();
                        aktualisTeljesitmeny -= komponens[i].Teljesitmeny;
                    }
                }
            }
            if (aktualisTeljesitmeny <= 0)
            {
                try
                {
                    throw new NincsElegEnergiaKivetel(aktualisTeljesitmeny * -1);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                for (int i = 0; i < komponens.Length; i++)
                {
                    if(komponens[i] is Hajtomu)
                    {
                        if (komponens[i].Allapot)
                        {
                            komponens[i].Deaktival();
                        }
                    }
                }                
            }
            else
            {
                Console.WriteLine($"[Padlogaz] A(z) {nev} urhajo padlogazon megy.");
            }
        }

        public void Beindit()
        {
            Console.WriteLine($"[Beinditas] A(z) {nev} urhajo beinditva.");
            for (int i = 0; i < komponens.Length; i++)
            {
                if(komponens[i] is Reaktor)
                {                  
                    try
                    {
                        komponens[i].Aktival();
                        aktualisTeljesitmeny -= komponens[i].Teljesitmeny;
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine($"[Beinditas] A(z) {nev} urhajo beinditva.");
                    }
                    catch (NotSupportedException ex)
                    {
                        Console.WriteLine(ex.Message);
                        komponens[i] = null;
                    }
                }
            }
        }
        public void GetException()
        {
            for (int i = 0; i < this.komponens.Length; i++)
            {
                try
                {
                    this.komponens[i].Deaktival();
                }
                catch (Exception e)
                {
                    throw new Exception("[KIVETEL] Egy komponens nem deaktiválható!", e);
                }
            }
        }

        public void Leallit()
        {
            Console.WriteLine($"[Leallitas] A(z) {this.nev} urhajo leallitasa meghívva.");
            for (int i = 0; i < this.komponens.Length; i++)
            {
                try
                {
                    this.komponens[i].Deaktival();
                }
                catch (Exception ex)
                {

                    try
                    {
                        throw new NemDeaktivalhatoKivetel("[KIVÉTEL] Az egyik reaktor nem deaktiválható", ex);
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                        if (err.InnerException != null)
                        {
                            Console.Write("[BELSŐ KIVETEL]: ");
                            Console.WriteLine(err.InnerException.Message);
                        }
                    }
                }
            }
        }
    }
}
