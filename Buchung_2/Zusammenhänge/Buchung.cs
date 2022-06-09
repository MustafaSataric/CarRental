using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchung_2
{
    internal class Buchung
    {

        public void FahrzeugZuruecknehmen(string auswahl)
        {
            Fahrzeug meinFahrzeug;

            if (auswahl == "PKW")
            {
                meinFahrzeug = new PKW(); // hier wird das Objekt erzeugt! 
            }
            else
            {
                meinFahrzeug = new LKW(); // hier wird das Objekt erzeugt! 
            }


            Console.Clear();
            Console.WriteLine("Welches Fahrzeug möchten sie ausleihen:");
            double vorherigerKmStand = meinFahrzeug.KmStand;
            Console.WriteLine("Bitte geben sie ihren Km Stand bei Rückgabe an");
            meinFahrzeug.KmStand = Convert.ToDouble(Console.ReadLine());
            FahrzeugAbrechnen(vorherigerKmStand, meinFahrzeug.KmStand, meinFahrzeug.PreisProKm, meinFahrzeug.Grundpreis);
        }

        public void FahrzeugAbrechnen(double vorherigerKmStand, double aktuellerKmStand, double kmPreis, double grundpreis)
        {
            Fahrzeug meinFahrzeug;
            double gefahreneKm = (aktuellerKmStand - vorherigerKmStand);
            Console.WriteLine("Vorheriger Km Stand: " + vorherigerKmStand);
            Console.WriteLine("Neuer Km Stand:  " + aktuellerKmStand);
            Console.WriteLine("Km gefahren:  " + gefahreneKm);
            Console.WriteLine("Grundpreis:  " + grundpreis + "    (Preis pro Km: " + kmPreis + " )");
            Console.WriteLine("Kosten:  " + (grundpreis + (kmPreis * gefahreneKm)));

        }


    }
}
