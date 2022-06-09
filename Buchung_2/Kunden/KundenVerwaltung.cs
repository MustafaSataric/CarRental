using System;
using System.Security.Cryptography.X509Certificates;

namespace Buchung_2
{
    public class KundenVerwaltung
    {
        private double kmDifferenz;
        private int fahrzeugNr;
        List<Kunde> meineListe = new List<Kunde>();


        public void KundenVerwalten()
        {
            Console.Title = "Rent-a-Car V1.0 © Mustafa Sataric";

            PrivatKunde privatKunde = new PrivatKunde();
            FirmenKunde firmenKunde = new FirmenKunde();
            int auswahl = 0;

            do
            {
                 auswahl = AuswahlsMenue.Menue("Kunden Verwaltungs Software", "Privat-Kunden Bestand", "Privat-Kunden Anlegen", "Firmen-Kunden Bestand", "Firmen-Kunden Anlegen");

                switch (auswahl)
                {
                    case 0:
                        Console.Clear();
                        privatKunde.KundeAusgeben();
                        break;
                    case 1:
                        Console.Clear();
                        privatKunde.KundeAufnehmen();
                        break;
                    case 2:
                        Console.Clear();
                        firmenKunde.KundeAusgeben();
                        break;
                    case 3:
                        Console.Clear();
                        firmenKunde.KundeAufnehmen();
                        break;
                    default:
                        auswahl = AuswahlsMenue.Menue("Kunden Verwaltungs Software", "Privat-Kunden Bestand", "Privat-Kunden Anlegen", "Firmen-Kunden Bestand", "Firmen-Kunden Anlegen");
                        break;
                }
                auswahl = AuswahlsMenue.Menue("Kunden Verwaltungs Software", "Privat-Kunden Bestand", "Privat-Kunden Anlegen", "Firmen-Kunden Bestand", "Firmen-Kunden Anlegen");
            } while (auswahl != -1);
        }
    }
}