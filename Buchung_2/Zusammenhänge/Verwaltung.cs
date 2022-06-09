using System;

namespace Buchung_2
{
    class Verwaltung
    {
        List<Kunde> testKunde = new List<Kunde>();
        List<Fahrzeug> testFahrzeug = new List<Fahrzeug>();



        public void KundeEingeben(int iLfdNr)
        {
            Console.Clear();
            ConsoleKeyInfo taste;
            Console.WriteLine("\n\n\n - Zur Kundendateneingabe ...");
            Console.WriteLine("\n       <P>rivatkunde oder <F>irmenkunde?");
            taste = Console.ReadKey(true);
            iLfdNr++;

            switch (taste.KeyChar)
            {
                case 'p':
                    testKunde[iLfdNr] = new PrivatKunde();
                    testKunde[iLfdNr].KundeAufnehmen(); // hier Polymorphie !!
                    break;
                case 'f':
                    testKunde[iLfdNr] = new FirmenKunde();
                    testKunde[iLfdNr].KundeAufnehmen(); // hier auch Polymorphie!!
                    break;
            }
        }

        public void KundenlisteAusgeben(int Anzahl)
        {
            Console.Clear();
            for (int z = 0; z < Anzahl; z++) testKunde[z].KundeAusgeben();
        }

        public void FahrzeugEingeben(int iFahrzeugNr)
        {
            Console.Clear();
            int auswahl = 0;
            do { 
            auswahl = AuswahlsMenue.Menue("Fahrzeug Typ Auswählen", "PKW", "Kunden LKW");



            switch (auswahl)
            {
                case 0:

                    testFahrzeug[iFahrzeugNr] = new PKW();
                    testFahrzeug[iFahrzeugNr].KategorieWaehlen(); // hier Polymorphie !!
                    break;
                case 1:
                    testFahrzeug[iFahrzeugNr] = new LKW();
                    testFahrzeug[iFahrzeugNr].KategorieWaehlen(); // hier auch Polymorphie!!
                    break;
                default:
                    auswahl = AuswahlsMenue.Menue("CarRent Software", "Fahrzeug Verwaltung", "Kunden Verwaltung");
                    break;
            }
                auswahl = AuswahlsMenue.Menue("CarRent Software", "Fahrzeug Verwaltung", "Kunden Verwaltung");




            } while (auswahl != -1);
       }

        public void FahrzeuglisteAusgeben(int Anzahl)
        {
            Console.Clear();
            for (int z = 0; z < Anzahl; z++)
            {
                Console.Write(z + ": ");
                testFahrzeug[z].KurzeKonfi();
            }
        }
    }
}
