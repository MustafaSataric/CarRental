using System;
using System.Text;

namespace Buchung_2
{
    class Program
    {

        static void Main()
        {


            Console.Title = "Rent V1.0 © Sataric Mustafa";
            var x = 0;
            var y = 0;
            int auswahl = 0;
            Verwaltung verwalte = new Verwaltung();

            do
            {


                auswahl = AuswahlsMenue.Menue("CarRent Software", "Fahrzeug Verwaltung", "Kunden Verwaltung");



                switch (auswahl)
                             {
                                    case 0:
                                        verwalte.FahrzeugeVerwalten();
                                        x++;
                                        break;
                                    case 1:
                                        verwalte.KundenVerwalten();
                //                        verwalte.KundenlisteAusgeben(x);
                                        break;
                                     default:
                auswahl = AuswahlsMenue.Menue("CarRent Software", "Fahrzeug Verwaltung", "Kunden Verwaltung");
                        break;
                             }



                         } while (auswahl != -1);



        }
    }
}
