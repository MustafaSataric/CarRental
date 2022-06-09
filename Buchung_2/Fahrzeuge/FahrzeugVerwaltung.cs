using System;
using System.Security.Cryptography.X509Certificates;

namespace Buchung_2
{
    public class FahrzeugVerwaltung
    {
        private double kmDifferenz;
        private int fahrzeugNr;
        List<Fahrzeug> meineListe = new List<Fahrzeug>();

        public FahrzeugVerwaltung()
        {
            kmDifferenz = 0.0;
            fahrzeugNr = 0;

        }

        public void FahrzeugeVerwalten()
        {
            Console.Title = "Rent-a-Car V1.0 © Mustafa Sataric";

            FahrzeugVerwaltung verwalten = new FahrzeugVerwaltung();
            Console.Clear();
            int auswahl = 0;
            do
            {
                 auswahl = AuswahlsMenue.Menue("Fahrzeug Verwaltungs Software", "Fahrzeug Bestand", "Fahrzeug Ankaufen", "Fahrzeug Löschen", "Fahrzeug Abrechnen");

                switch (auswahl)
                {
                    case 0: verwalten.FahrzeugBestand();break;
                    case 1: verwalten.FahrzeugAnkaufen();break;
                    case 2: verwalten.FahrzeugLoeschen();break;
                    case 3: verwalten.FahrzeugAbrechnen();break;
                    default:
                        auswahl = AuswahlsMenue.Menue("Fahrzeug Verwaltungs Software", "Fahrzeug Bestand", "Fahrzeug Ankaufen", "Fahrzeug Löschen", "Fahrzeug Abrechnen");
                        break;
                }
                auswahl = -1;



            } while (auswahl != -1);


        }



        public void FahrzeugAnkaufen()
        {
            //Array.Resize(ref meineFahrzeuge, fahrzeugNr + 1);

            //Konsole.ClrLines(5,20)
            Console.SetCursorPosition(0, 4);
            int auswahl = 0;
            do {
                auswahl = AuswahlsMenue.Menue("Ihre Fahrzeug Klasse:", "PKW", "LKW");

                switch (auswahl) {
                    case 0:
                        Fahrzeug meinPKW = new PKW();
                        meineListe.Add(meinPKW);

                        meineListe[meineListe.Count - 1].KategorieWaehlen();
                        meineListe[meineListe.Count - 1].KonfigurationsDaten();
                        break;
                    case 1:
                        Fahrzeug meinLKW = new LKW();
                        meineListe.Add(meinLKW);

                        meineListe[meineListe.Count - 1].KategorieWaehlen();
                        meineListe[meineListe.Count - 1].KonfigurationsDaten();

                        break;
                }
            } while (auswahl != -1);




        }
        public void FahrzeugLoeschen()
        {
            for (int i = 0; i < meineListe.Count; i++)
            {
                Console.Write("Fahrzeug Nr.:" + (i + 1));
                meineListe[i].KurzeKonfi();
            }

            Console.WriteLine("Welches fahrzeug möchten sie Löschen");
            int zuLoeschendesFahrzeug = Convert.ToInt32(Console.ReadLine());

            meineListe.Remove
                (meineListe[meineListe.Count - zuLoeschendesFahrzeug]);

            Console.WriteLine("Sie haben " + meineListe.Count + " Fahrzeuge in der Garage");
            Console.ReadKey();

        }

        public void FahrzeugBestand()
        {
            Console.Clear();
            for (int i = 0; i < meineListe.Count; i++)
            {
                Console.Write("\n\n\tFahrzeug Nr.:" + i);
                meineListe[i].KonfigurationsDaten();
            }
            Console.ReadKey();
        }

        public void FahrzeugAbrechnen()
        {
            for (int i = 0; i < meineListe.Count; i++)
            {
                Console.Write("Fahrzeug Nr.:" + (i + 1));
                meineListe[i].KurzeKonfi();
            }
            Console.WriteLine("Welches fahrzeug möchten sie Zurückgeben");
            int fahrzeug = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Der Derzeitige Km-Stand des Fahrzeuges" + meineListe[fahrzeug - 1].MarkeModell);
            double kmStandNeu = Convert.ToDouble(Console.ReadLine());
            double gefahreneKm = (kmStandNeu - meineListe[fahrzeug - 1].KmStand);
            Console.WriteLine("Vorheriger Km Stand: " + meineListe[fahrzeug - 1].KmStand);
            Console.WriteLine("Neuer Km Stand:  " + kmStandNeu);
            Console.WriteLine("Km gefahren:  " + gefahreneKm);
            Console.WriteLine("Grundpreis:  " + meineListe[fahrzeug - 1].Grundpreis + "    (Preis pro Km: " + meineListe[fahrzeug - 1].PreisProKm + " )");
            Console.WriteLine("Kosten:  " + (meineListe[fahrzeug - 1].Grundpreis + (meineListe[fahrzeug - 1].PreisProKm * gefahreneKm)));

            meineListe.Remove(meineListe[meineListe.Count - fahrzeug]);
            Console.ReadKey();


        }
    }
}