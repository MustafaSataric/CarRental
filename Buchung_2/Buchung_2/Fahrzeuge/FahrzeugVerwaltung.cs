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