using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Buchung_2
{
    class Program
    {

        static void Main()
        {

            const uint MB_OK = 0x00000000;
            const uint MB_ICONWARNING = 0x00000030;

            [DllImport("User32.dll", CharSet = CharSet.Unicode)]
            static extern int MessageBoxW(IntPtr hWnd, string lpText, string lpCaption, uint uType);

            //   MessageBoxW(IntPtr.Zero, "Dies ist eine Warnung oder so lol", "Test", MB_OK | MB_ICONWARNING);
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
