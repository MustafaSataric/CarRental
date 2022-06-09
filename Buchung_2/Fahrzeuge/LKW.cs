using System;
using System.Collections.Generic;
using System.Text;

namespace Buchung_2
{
    // Die Basisklasse Konto soll die gemeinsamen Attribute bereithalten, so dass die Kindklassen darüber verfügen
    class LKW : Fahrzeug// abstract bedeutet: diese Klasse kann nicht instanziiert werden! Wir können nur von den 
                        // Kindklassen Objekte/Instanzen erzeugen!
    {
        private string ladeform;
        private double zulässigesGesamtgewicht;
        private string aufbau;
        private int zulaessigesGesamtgewicht;


        public override void FahrzeugEinrichten() //siehe Kommentar GiroKonto!
        {
            double betrag;
            Console.WriteLine("\n\n\n Ausstatung ihres PKWs");
            Console.Write("\n\tLadeform:           : ");
            ladeform = Console.ReadLine();
            Console.Write("\n\tZulässiges Gesamtgewicht           : ");
            zulaessigesGesamtgewicht = Convert.ToInt32(Console.ReadLine());

        }

        public override void KategorieWaehlen()
        {


            int auswahl = 0;
            do
            {
                Console.Clear();
               auswahl = AuswahlsMenue.Menue("Bitte Wählen Sie ihren gewünschten Aufbau:", "(K)asten", "(P)ritsche", "P(l)ane");

                switch (auswahl)
                {
                    case 0:

                        markeModell = "BMW E70";
                        kmStand = 1500;
                        Grundpreis = 89;
                        preisProKm = 0.20;
                        break;
                    case 1:

                        markeModell = "BMW E70";
                        kmStand = 1500;
                        Grundpreis = 89;
                        preisProKm = 0.20;
                        break;
                    default:
                        auswahl = AuswahlsMenue.Menue("Bitte Wählen Sie ihren gewünschten Aufbau:", "(K)asten", "(P)ritsche", "P(l)ane");
                        break;
                }
                auswahl = -1;
            } while (auswahl != -1);

        }

        public override void KonfigurationsDaten()
        {
            Console.WriteLine("LKW:");
            Console.WriteLine("\n\tIhre Marke lautet: {0}", markeModell);
            Console.WriteLine("\tIhr KM Stand lautet    : {0}", kmStand);
            Console.WriteLine("\tIhr Kennzeichen lauten    : {0}", kennzeichen);
            Console.WriteLine("\tIhr Fahrzeugtyp lauten    : {0}", fahrzeugTyp);
            Console.WriteLine("\tDer Grundpreis beträgt: {0}", grundpreis);
            Console.WriteLine("\tDer Preis pro Km beträgt: {0}", preisProKm);
            Console.ReadKey();
        }

    }


}

