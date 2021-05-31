using System;

namespace Kivétel
{

    class Program
    {
        static void Main(string[] args)
        {
            Urhajo rombolo = new Urhajo("Star Destroyer #5530", 100, UrhajoKategoria.Rombolo);
            Urhajo serenity = new Urhajo("Serenity", 50, UrhajoKategoria.Teher);
            Urhajo oldBessie = new Urhajo("Old Bessie", 90, UrhajoKategoria.Korvett);
            Urhajo razorBack = new Urhajo("Razorback", 0, UrhajoKategoria.Yacht);

            Reaktor reaktora = new Reaktor(3000);
            Reaktor reaktorb = new Reaktor(1000);
            Hajtomu hajtumo = new Hajtomu(160);
            Hajtomu hajtomua = new Hajtomu(160);
            Hajtomu hajtomub = new Hajtomu(160);
            Hajtomu hajtumoc = new Hajtomu(160);
            Hajtomu hajtumod = new Hajtomu(160);
            Hajtomu hajtumoe = new Hajtomu(160);
            Hajtomu hajtumof = new Hajtomu(160);

            serenity.KomponensFelszerel(hajtumo);
            serenity.KomponensFelszerel(hajtumo);

            oldBessie.KomponensFelszerel(hajtumo);

            razorBack.KomponensFelszerel(hajtumo);
            razorBack.KomponensFelszerel(reaktora);

            rombolo.KomponensFelszerel(hajtumo);
            rombolo.KomponensFelszerel(hajtomua);
            rombolo.KomponensFelszerel(hajtomub);
            rombolo.KomponensFelszerel(hajtumoc);
            rombolo.KomponensFelszerel(hajtumod);
            rombolo.KomponensFelszerel(hajtumoe);
            rombolo.KomponensFelszerel(hajtumof);
            rombolo.KomponensFelszerel(reaktora);
            rombolo.KomponensFelszerel(reaktorb);

            rombolo.KomponensLeszerel(0);
            rombolo.KomponensLeszerel(0);

            rombolo.Beindit();
            rombolo.Padlogaz();
            rombolo.Leallit();
        }
    }
}
